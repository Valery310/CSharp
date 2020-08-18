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
    public partial class Form2 : Form
    {

        Form1 main;
        public Form2(Form1 f)
        {
            InitializeComponent();
            main = f;
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            int i;
            if (int.TryParse(tbAnswer.Text, out i))
            {
                main.answer = i;
                main.countAnswer++;
                main.lblCountAnswer.Text = $"Попыток: {main.countAnswer}.";
                this.Visible = false;
                main.btnTry.Enabled = true;
                main.checkAnswer();
            }
            else
            {
                MessageBox.Show("Ошибка! Попробуйте еще раз!" );
            }
        }
    }
}
