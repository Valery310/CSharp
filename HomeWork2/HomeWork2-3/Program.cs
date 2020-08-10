using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_3
{
    class Program
    {
        //С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных
        //положительных чисел.
        //КрюковВН

        static void Main(string[] args)
        {
            int number, sum = 0;

            while(true)
            {
                Console.WriteLine("Введите число: ");
                number = Convert.ToInt32(Console.ReadLine());

                if (number == 0)
                {
                    break;
                }

                if ((number > 0) && (number % 2 != 0))
                {
                    sum += number;
                }

            }

            Console.WriteLine($"Сумма всех нечетных положительных цифр равна: {sum}");

            Console.ReadLine();
        }
    }
}
