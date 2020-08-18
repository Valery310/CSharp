using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HomeWork_5_2
{
    class Program
    {
        //Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
        //а) Вывести только те слова сообщения,  которые содержат не более n букв.
        //б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
        //в) Найти самое длинное слово сообщения.
        //г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
        //д) ***Создать метод, который производит частотный анализ текста.В качестве параметра в 
        //    него передается массив слов и текст, в качестве результата метод возвращает сколько 
        //    раз каждое из слов массива входит в этот текст.Здесь требуется использовать класс Dictionary.
        //Крюков ВН

        static void Main(string[] args)
        {
            string text = "Съешь же ещё Съешь этих мягких Съешь французских булок, да выпей же чаю";
            Message.GetWordsWithChar(text, 3);
            Message.RemoveAllWordsWithCharEnd(text, 'е');
            Message.GetLongestWord(text);
            Message.GetStringWithLongestWords(text, 3);
            string[] words = { "Съешь", "же", "мягких" };
            Message.GetDictionaryWithWords(words, text);
            Console.ReadKey();
        }
    }

    static class Message 
    {
        public static void GetWordsWithChar(string text, int Length)
        {
            string[] temp = text.Split(' ');
            string result = "";

            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i].Length <= Length)
                {
                    result += temp[i] + " ";
                }
            }
            Console.WriteLine(result);
        }

        public static void RemoveAllWordsWithCharEnd(string text, char ch) 
        {
            string[] temp = text.Split(' ');
            string result = "";
            Regex regex = new Regex($"\\w[{ch}]$");

            for (int i = 0; i < temp.Length; i++)
            {
                if (!regex.IsMatch(temp[i]))
                {
                    result += temp[i] + " ";
                }
            }
            Console.WriteLine(result);
        }

        public static void GetLongestWord(string text)
        {
            string[] temp = text.Split(' ');
            Array.Sort(temp, (x, y) => x.Length.CompareTo(y.Length));
            Array.Reverse(temp);
            Console.WriteLine(temp.FirstOrDefault());
        }

        public static void GetStringWithLongestWords(string text, int Count)
        {
            string[] temp = text.Split(' ');
            StringBuilder result = new StringBuilder();
            Array.Sort(temp, (x, y) => x.Length.CompareTo(y.Length));
            Array.Reverse(temp);

            for (int i = 0; i < temp.Length && i < Count; i++)
            {          
                result.Append(temp[i] + " ");
            }
            Console.WriteLine(result);
        }

        public static void GetDictionaryWithWords(string [] words, string text) 
        {
            string[] temp = text.Split(' ');
            SortedDictionary<string, int> pairs = new SortedDictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                pairs.Add(words[i], 0 );
                for (int b = 0; b < temp.Length; b++)
                {
                    if (words[i] == temp[b])
                    {
                        pairs[words[i]]++;
                    }                  
                }
            }            
            foreach (var item in pairs)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }           
        }
    }
}
