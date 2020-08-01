using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_7
{
    class Program
    {

        //a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
        //б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.   
        //КрюковВН

        static void Main(string[] args)
        {
            RecNumber(1, 10);
            Console.WriteLine($"Сумма чисел от 1 до 10: {SumNumber(1, 10)}");
            Console.ReadKey();
        }

        public static void RecNumber(int a, int b) 
        {          
            Console.WriteLine(a);
            if (a < b)
            {
                a++;
                RecNumber(a, b);
            }          
        }

        public static int SumNumber(int a, int b)
        {
            if (a < b)
            {
                return a + SumNumber(++a, b);
            }
            else
            {
                return a;
            }
            
        }
    }
}
