using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
namespace HomeWork_8_3
{
    // Класс для вопроса    
    [Serializable]
    public class Question
    {
        public string Text { get; set; }   // Текст вопроса
        public bool TrueFalse { get; set; }// Правда или нет
                              // Здесь мы нарушаем правила инкапсуляции и эти поля нужно было бы реализовать через открытые свойства, но для упрощения примера оставим так
                              // Вам же предлагается сделать поля закрытыми и реализовать открытые свойства Text и TrueFalse
                              // Для сериализации должен быть пустой конструктор.
        public Question()
        {
        }
        public Question(string text, bool trueFalse)
        {
            this.Text = text;
            this.TrueFalse = trueFalse;
        }
    }
    // Класс для хранения списка вопросов. А также для сериализации в XML и десериализации из XML
    class TrueFalse
    {
        string fileName;
        List<Question> list;
        public string FileName
        {
            set { fileName = value; }
        }
        public TrueFalse(string fileName)
        {
            this.fileName = fileName;
            list = new List<Question>();
        }
        public void Add(string text, bool trueFalse)
        {
            list.Add(new Question(text, trueFalse));
        }
        public void Remove(int index)
        {
            if (list != null && index < list.Count && index >= 0) list.RemoveAt(index);
        }
        // Индексатор - свойство для доступа к закрытому объекту

        public Question this[int index]
        {
            get { return list[index]; }
        }
        public void Save()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, list);
            fStream.Close();
        }

        public void Save(string filename)
        {
            this.fileName = filename;
            Save();
        }

        public void Load()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Question>));
            Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            bool canOpen = false;
            var xmlTextReader = new XmlTextReader(fStream);

            try
            {
                canOpen = xmlFormat.CanDeserialize(xmlTextReader);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка открытия файла.");
                fStream.Close();
                return;
            }
      
            try
            {
                if (canOpen)
                {
                    list = (List<Question>)xmlFormat.Deserialize(xmlTextReader);                   
                }
                else
                {
                    throw new Exception("Ошибка файла!");
                }
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.Message);
            }
            finally
            {
                fStream.Close();
            }
        }

         
        public int Count
        {
            get { return list.Count; }
        }
    }
}
