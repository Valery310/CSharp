using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork_7_2
{

    //Используя Windows Forms, разработать игру «Угадай число». Компьютер загадывает число от 1 до 100,
    //а человек пытается его угадать за минимальное число попыток.Компьютер говорит, больше или меньше загаданное число введенного.
    //a) Для ввода данных от человека используется элемент TextBox;
    //б) ** Реализовать отдельную форму c TextBox для ввода числа.
    //КрюковВН

    public partial class Form1 : Form
    {
        public int number = 0;
        public int answer = 0;
        public int countAnswer = 0;
        public Label lblResult;
        public Button btnTry;
        public Label lblCountAnswer;
        Form2 form2;

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            Random r = new Random();
            number = r.Next(1, 100);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            form2 = new Form2(this);
            form2.Visible = true;
            form2.Activate();
            btnStart.Visible = false;

            lblCountAnswer = new Label();
            lblCountAnswer.Text = $"Попыток: {countAnswer}.";
            lblCountAnswer.Width = 150;
            lblCountAnswer.Left = 10;
            lblCountAnswer.Top = 5;
            this.Controls.Add(lblCountAnswer);

            lblResult = new Label();
            lblResult.Width = 200;
            lblResult.Left = 10;
            lblResult.Top = 30;
            this.Controls.Add(lblResult);

            btnTry = new Button();
            btnTry.Text = "Еще попытка!";
            btnTry.Left = 70;
            btnTry.Top = 60;
            btnTry.Width = 100;
            btnTry.Click += btnTry_Click;
            btnTry.Enabled = false;
            this.Controls.Add(btnTry);
        }

        public void checkAnswer() 
        {
            if (answer == number)
            {
                lblResult.Text = "Поздравляю! Вы угадали!";
            }
            else if (answer < number)
            {
                lblResult.Text = "Слишком маленькое число =(";
            }
            else
            {
                lblResult.Text = "Слишком большое число =(";
            }
        }

        private void btnTry_Click(object sender, EventArgs e)
        {
            btnTry.Enabled = false;
            form2.Visible = true;
        }
    }
}
