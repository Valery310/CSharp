using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1_4
{
    class Program
    {
        static void Main(string[] args)
        {

            //Написать программу обмена значениями двух переменных:
            //а) с использованием третьей переменной;
            //б) *без использования третьей переменной

            //Крюков ВН

            int x = 0;
            int y = 1;
            int temp = 0;

            Console.WriteLine($"x = {x}, y = {y}");

            temp = x;
            x = y;
            y = temp;

            Console.WriteLine($"x = {x}, y = {y}");

            int x1 = 5;
            int y1 = 8;

            Console.WriteLine($"x1 = {x1}, y1 = {y1}");

            x1 ^= y1;
            y1 ^= x1;
            x1 ^= y1;

            Console.WriteLine($"x1 = {x1}, y1 = {y1}");

            Console.ReadKey();
        }
    }
}
