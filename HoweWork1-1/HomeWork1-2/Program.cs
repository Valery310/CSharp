using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1_2
{
    class Program
    {
        static void Main(string[] args)
        {

            //Ввести вес и рост человека.Рассчитать и вывести индекс массы тела(ИМТ) по формуле
            //I = m / (h * h); где m — масса тела в килограммах, h — рост в метрах
            //Крюков ВН
            Console.Write("Введите вес в килограммах: ");
            var weight = Convert.ToSingle(Console.ReadLine());
            Console.Write("Введите рост в метрах: ");
            var height = Convert.ToSingle(Console.ReadLine());

            var I = weight / (height * height);

            Console.WriteLine($"Результат ИМТ: {I:f1}");

            Console.ReadLine();
        }
    }
}
