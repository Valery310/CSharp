using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork_8_3
{
    //а) Создать приложение, показанное на уроке, добавив в него защиту от возможных ошибок(не
    //создана база данных, обращение к несуществующему вопросу, открытие слишком большого файла и т.д.).
    //б) Изменить интерфейс программы, увеличив шрифт, поменяв цвет элементов и добавив другие «косметические» улучшения на свое усмотрение.
    //в) Добавить в приложение меню «О программе» с информацией о программе(автор, версия, авторские права и др.).
    //г)* Добавить пункт меню Save As, в котором можно выбрать имя для сохранения базы данных(элемент SaveFileDialog).
    //КрюковВН

    public partial class Form1 : Form
    {
        // База данных с вопросами
        TrueFalse database;

        public Form1()
        {
            InitializeComponent();
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnSaveQuest.Enabled = false;
            nudNumber.Enabled = false;
            cboxTrue.Enabled = false;
            miSave.Enabled = false;
            miSaveAs.Enabled = false;
        }

        public void enabledElements() 
        {
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            btnSaveQuest.Enabled = true;
            nudNumber.Enabled = true;
            cboxTrue.Enabled = true;
            miSave.Enabled = true;
            miSaveAs.Enabled = true;
        }

        // Обработчик пункта меню Exit
        private void miExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Обработчик пункта меню New
        private void miNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(sfd.FileName);
                database.Add("123", true);
                database.Save();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = 1;
                nudNumber.Value = 1;
                enabledElements();
            };
        }
        // Обработчик события изменения значения numericUpDown
        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            tboxQuestion.Text = database[(int)nudNumber.Value - 1].Text;
            cboxTrue.Checked = database[(int)nudNumber.Value - 1].TrueFalse;
        }
        // Обработчик кнопки Добавить
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                MessageBox.Show("Создайте новую базу данных", "Сообщение");
                return;
            }
            database.Add((database.Count + 1).ToString(), true);
            nudNumber.Maximum = database.Count;
            nudNumber.Value = database.Count;
        }
        // Обработчик кнопки Удалить
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (nudNumber.Maximum == 1 || database == null) return;
            database.Remove((int)nudNumber.Value);
            nudNumber.Maximum--;
            if (nudNumber.Value > 1) nudNumber.Value = nudNumber.Value;
        }
        // Обработчик пункта меню Save
        private void miSave_Click(object sender, EventArgs e)
        {
                if (database != null && database.Count > 0) database.Save();
                else MessageBox.Show("База данных не создана или нет записей.");
        }
        // Обработчик пункта меню Open
        private void miOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    database = new TrueFalse(ofd.FileName);
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.Message);
                }
                database.Load();
                if (database != null && database.Count > 0)
                {
                    nudNumber.Minimum = 1;
                    nudNumber.Maximum = database.Count;
                    nudNumber.Value = 1;
                    enabledElements();
                }
                else
                {
                    MessageBox.Show("Не удалось открыть файл.");
                }
            }
        }
        // Обработчик кнопки Сохранить (вопрос)
        private void btnSaveQuest_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tboxQuestion.Text))
            {
                if (database != null)
                {
                    database[(int)nudNumber.Value - 1].Text = tboxQuestion.Text;
                    database[(int)nudNumber.Value - 1].TrueFalse = cboxTrue.Checked;
                }
                else
                {
                    MessageBox.Show("База данных не создана");
                }
            }
            else
            {
                MessageBox.Show("Введите вопрос.");
            }
        }

        private void miSaveAs_Click(object sender, EventArgs e)
        {
            if (database != null && database.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    database.Save(sfd.FileName);
                };
            }
            else
            {
                MessageBox.Show("База данных не создана или нет записей.");
            }   
        }

        private void aboutProgram_Click(object sender, EventArgs e)
        {
            string text = String.Format("Автор проекта: Такой-то Такойтович.\nВерсия: {0}", ProductVersion);
            MessageBox.Show(text, "О программе.");
        }
    }
}
