using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_2
{
    class Program
    {
        //Написать метод подсчета количества цифр числа
        //КрюковВН 

        static void Main(string[] args)
        {
            Console.WriteLine("Введите число: ");
            var number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Чисел в числе: {GetLengthNumber(number)}");

            Console.ReadLine();
        }

        public static int GetLengthNumber(int number) 
        {
            return (int)Math.Log10(number) + 1;
        }
    }
}
