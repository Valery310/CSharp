using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_6
{
    class Program
    {
        //*Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000
        //000. «Хорошим» называется число, которое делится на сумму своих цифр.Реализовать
        //подсчёт времени выполнения программы, используя структуру DateTime.
        //КрюковВН

        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;

            int countGoodDigit = 0;
            int sum;
            int number;
            for (int i = 1; i <= 1_000_000_000 ; i++)
            {
                sum = 0;
                number = i;
                while (number != 0)
                {
                    sum += number % 10;
                    number /= 10;
                }

                if (i % sum == 0)
                {
                    countGoodDigit++;
                }
            }

            DateTime finish = DateTime.Now;

            Console.WriteLine($"Количество \"хороших\" чисел: {countGoodDigit}");
            Console.WriteLine("Время выполнения: {0}", (finish - start).Seconds);

            Console.ReadLine();
        }
    }
}
