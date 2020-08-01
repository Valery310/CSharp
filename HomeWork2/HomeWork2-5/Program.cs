using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_5
{
    class Program
    {
        //а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс
        //массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.
        //б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
        //КрюковВН

        static void Main(string[] args)
        {
            Console.Write("Введите вес в килограммах: ");
            var weight = Convert.ToSingle(Console.ReadLine());
            Console.Write("Введите рост в метрах: ");
            var height = Convert.ToSingle(Console.ReadLine());

            Single IMT = GetIMT(height, weight);

            Console.Write($"Результат ИМТ: {IMT:f1}. ");

            if (18.5 <= IMT && IMT <= 25.0)
            {
                Console.WriteLine("Вес в норме.");
            }
            else if(IMT <= 18.5)
            {
                Console.WriteLine("Имеется дефицит веса.");
                Console.WriteLine($"Для нормализации веса нужно набрать минимум {CorrectWeight(IMT, height, weight):f1}кг.");
            }
            else
            {
                Console.WriteLine("Ожирение.");
                Console.WriteLine($"Для нормализации веса нужно сбросить минимум {CorrectWeight(IMT, height, weight):f1}кг.");
            }

            

            Console.ReadLine();
        }

        public static float GetIMT(Single height, Single weight) 
        {
            return weight / (height * height);
        }

        public static float CorrectWeight(Single IMT, Single height, Single weight) 
        {
            Single kg;

            if (IMT <= 18.5)
            {
                kg = (18.5F * (height * height)) - weight;
            }
            else if(IMT >= 25.0)
            {
                kg = weight - (25.0F * (height * height));
            }
            else
            {
                return 0F;
            }

            return kg;
        }
    }
}
