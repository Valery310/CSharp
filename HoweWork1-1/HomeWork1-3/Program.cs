using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //а) Написать программу, которая подсчитывает расстояние между точками с координатами x1,
            //    y1 и x2,y2 по формуле r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2).Вывести результат,
            //    используя спецификатор формата .2f(с двумя знаками после запятой);
            //б) *Выполнить предыдущее задание, оформив вычисления расстояния между точками в виде
            //    метода.

            //    Крюков ВН

            int x1, x2, y1, y2;

            Console.WriteLine("Введите коррдинату X первой точки: ");
            x1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите коррдинату Y первой точки: ");
            y1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите коррдинату X второй точки: ");
            x2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите коррдинату Y второй точки: ");
            y2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Расстояние между точками: {Distance(x1, y1, x2, y2)}");

            Console.ReadKey();
        }

        static string Distance(int x1, int y1, int x2, int y2) 
        {
            var r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            
            return String.Format("{0:f2}", r);
        }
    }
}
