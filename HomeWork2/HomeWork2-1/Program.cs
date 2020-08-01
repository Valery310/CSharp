using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_1
{
    class Program
    {
        //Написать метод, возвращающий минимальное из трёх чисел.
        //КрюковВН
        static void Main(string[] args)
        {
            int[] number = new int[3];
            Console.WriteLine("Введите первое число:");
            number[0] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите второе число:");
            number[1] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите третье число:");
            number[2] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Минимальное число: {GetMin(number)}");

            Console.ReadLine();
        }

        public static int GetMin(int [] number) 
        {
            int min = number[0];

            for (int i = 0; i < number.Length - 1; i++)
            {
                if (number[i] <= min)
                {
                    min = number[i];
                }
            }
            return min;
        }
    }
}
