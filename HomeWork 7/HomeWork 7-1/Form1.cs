using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork_7_1
{

    //а) Добавить в программу «Удвоитель» подсчёт количества отданных команд удвоителю.
    //б) Добавить меню и команду «Играть». При нажатии появляется сообщение, какое число должен получить игрок.Игрок должен получить это число за минимальное количество ходов.
    //в) * Добавить кнопку «Отменить», которая отменяет последние ходы.Используйте обобщенный класс Stack.
    // Вся логика игры должна быть реализована в классе с удвоителем.
    //КрюковВН

    public partial class Form1 : Form
    {
        int countCommand = 0;

        int Number = 0;

        int targetNumber = 0;

        Stack<Step> history = new Stack<Step>();

        public delegate void updateCountCommand(string t, bool cancel);

        event updateCountCommand update;

        public void updatelblCountCommand(string t, bool cancel) 
        {
            countCommand++;
            lblNumber.Text = Number.ToString();           
            lblCountCommand.Text = countCommand.ToString();
            if (!cancel)
            {
                history.Push(new Step { N = Number, S = t });
            }
            if (Number == targetNumber )
            {
                MessageBox.Show("Победа!");
            }
        }

        public Form1()
        {
            InitializeComponent();

            update += updatelblCountCommand;
            btnCommand1.Text = "+1";
            btnCommand2.Text = "x2";
            btnReset.Text = "Сброс";
            lblNumber.Text = "0";
            this.Text = "Удвоитель";
        }

        private void btnCommand1_Click(object sender, EventArgs e)
        {       
            Number = (int.Parse(lblNumber.Text) + 1);
            update?.Invoke(this.Text, false);
        }

        private void btnCommand2_Click(object sender, EventArgs e)
        {
            Number = (int.Parse(lblNumber.Text) * 2);
            update?.Invoke(this.Text, false);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Number = 0;
            update?.Invoke(this.Text, false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (history.Count>1)
            {
                history.Pop();
                Step prevStep = history.Peek();
                Number = prevStep.N;
                update?.Invoke(this.Text, true);
            }
            else
            {
                MessageBox.Show("История пуста!");
            }
        }

        private void игратьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            targetNumber = r.Next(0, 100);
            MessageBox.Show($"Надо получить число {targetNumber}.");
        }

        public struct Step
        {
            public int N;
            public String S;
        }
    }
}
