using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeWork_4_2
{
    class Program
    {
        //Реализуйте задачу 1 в виде статического класса StaticClass;
        //а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
        //б) *Добавьте статический метод для считывания массива из текстового файла.Метод должен возвращать массив целых чисел;
        //в)**Добавьте обработку ситуации отсутствия файла на диске.
        //Крюков ВН

        static void Main(string[] args)
        {
            int[] ar = ReadFileArr();
            Random r = new Random();

            Console.WriteLine($"Ответ: {StaticClass.GetCount(ref ar)}");
            Console.ReadLine();
        }

        static void CreateFileArr() 
        {
            StreamWriter sw = new StreamWriter("array.txt");
            int t;
            Random r = new Random();

            for (int i = 0; i < 20; i++)
            {
                t = r.Next(-10000, 10000);

                if (t > -10000 && t < 10000)
                {
                    sw.WriteLine($"{t};");
                }
            }

            sw.Close();
        }

        static int[] ReadFileArr()
        {
            StreamReader sr;
            string s;

            try
            {
                sr = new StreamReader("array.txt");
            }
            catch (Exception message)
            {
                Console.WriteLine(message);
                CreateFileArr();
                sr = new StreamReader("array.txt");
            }

            s = sr.ReadToEnd();
            var arrNumber = s.Split(';');
            int[] arr = new int[20];
            sr.Close();
            for (int i = 0; i < arr.Length; i++)
            {
                arrNumber[i].Trim(';');
                int.TryParse(arrNumber[i], out arr[i]);
            }

            return arr;
        }
    }

    static class StaticClass 
    {

        static int Count = 0;

        public static int GetCount(ref int [] arr) 
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if ((arr[i] % 3 == 0) ^ (arr[i + 1] % 3 == 0))
                {
                    Count++;
                    Console.WriteLine(arr[i] + " " + arr[i + 1]);
                }
            }
            return Count;
        }


    }
}
