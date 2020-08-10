using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1_5
{
    class Program
    {
        static void Main(string[] args)
        {

            //а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
            //б) *Сделать задание, только вывод организовать в центре экрана.
            //в) **Сделать задание б с использованием собственных методов(например, Print(string ms, int
            //x, int y).

            //Крюков ВН


            Console.WriteLine("Введите имя: ");
            var firstName = Console.ReadLine();
            Console.WriteLine("Введите фамилию: ");
            var lastName = Console.ReadLine();

            Console.WriteLine("Введите координату Х: ");
            var x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите координату Y: ");
            var y = Convert.ToInt32(Console.ReadLine());

            Print($"{firstName} {lastName}",x ,y);
           
            Console.ReadLine();
        }

        static void Print(string msg, int x, int y) 
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(msg);
        }
    }
}
