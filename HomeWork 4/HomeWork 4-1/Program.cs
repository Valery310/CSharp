using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_4_1
{
    class Program
    {
        //Дан целочисленный  массив из 20 элементов.Элементы массива  могут принимать  целые значения
        //от –10 000 до 10 000 включительно.Заполнить случайными числами.Написать программу, позволяющую 
        //найти и вывести количество пар элементов массива, в которых только одно число делится на 3. 
        //В данной задаче под парой подразумевается два подряд идущих элемента массива.Например, 
        //для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2. 
        // Крюков ВН



        static void Main(string[] args)
        {
            int[] ar = new int[20];
            Random r = new Random();
            int t;
            int Count = 0;

            for (int i = 0; i < ar.Length; i++)
            {
                t = r.Next(-10000, 10000);

                if (t > -10000 && t < 10000)
                {
                    ar[i] = t;
                }
            }

            for (int i = 0; i < ar.Length - 1; i++)
            {
                if ((ar[i] % 3 == 0) ^ (ar[i + 1] % 3 == 0))
                {
                    Count++;
                    Console.WriteLine(ar[i] + " " + ar[i+1]);
                }
            }
            Console.WriteLine($"Ответ: {Count}");
            Console.ReadLine();
        }

    }
}
