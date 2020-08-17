using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_6_1
{

    public delegate double Fun(double x, double a);

    class Program
    {
        //Изменить программу вывода таблицы функции так, чтобы можно было передавать 
        //    функции типа double (double, double). Продемонстрировать работу на функции 
        //    с функцией a* x^2 и функцией a* sin(x).
        //    Крюков ВН

        public static void Table(Fun F, double x, double a, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x, a));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }

        public static double MyFunc1(double x, double a)
        {
            return a * Math.Sqrt(x);
        }

        public static double MyFunc2(double x, double a)
        {

            return a * Math.Sin(x);
        }



        static void Main(string[] args)
        {

            // Создаем новый делегат и передаем ссылку на него в метод Table
            
            // Параметры метода и тип возвращаемого значения, должны совпадать с делегатом
            Fun fun = MyFunc1;

            Console.WriteLine("Таблица функции MyFunc:");
            Table(fun, -2, 2, 5);

            fun = MyFunc2;
            Console.WriteLine("Таблица другой функции MyFunc:");
            Table(fun, -2, 2, 5);

            Console.ReadKey();
        }
    }
}
