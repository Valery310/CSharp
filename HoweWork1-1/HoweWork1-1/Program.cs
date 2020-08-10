using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoweWork1_1
{
    class Program
    {
        static void Main(string[] args)
        {
          /*  Написать программу «Анкета». Последовательно задаются вопросы(имя, фамилия, возраст, рост, вес).В результате вся информация выводится в одну строчку:
            а) используя склеивание;
            б) используя форматированный вывод;
            в) используя вывод со знаком $.
         
            Крюков ВН
           */
            Console.WriteLine("Программа \"Анкета\"");
            Console.WriteLine("Введите имя:");
            var firstName = Console.ReadLine();
            Console.WriteLine("Введите фамилию:");
            var lastName = Console.ReadLine();
            Console.WriteLine("Введите возраст");
            var age = Console.ReadLine();
            Console.WriteLine("Введите рост");
            var heightTemp = Console.ReadLine();
            var height = Convert.ToSingle(heightTemp);
            Console.WriteLine("Введите вес");
            var weightTemp = Console.ReadLine();
            var weight = Convert.ToSingle(weightTemp);

            Console.WriteLine("Результат:");
            Console.WriteLine("Имя: " + firstName + ", Фамилия: " + lastName + ", Возраст: " + age + ", Рост: " + height + ", Вес: " + weight + ".");

            Console.WriteLine("Результат: Имя: {0}, Фамилия: {1}, Возраст: {2:d}, Рост:  {3:f2}, Вес:  {4:f2}.", firstName, lastName, age, height, weight);

            Console.WriteLine($"Результат: Имя: {firstName}, Фамилия: {lastName}, Возраст: {age, 10:d}, Рост: {height, 10:f2}, Вес: {weight, 10:f2}.");
            
            Console.ReadLine();
        }
    }
}
