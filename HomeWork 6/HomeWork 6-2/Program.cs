using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeWork_6_2
{
    class Program
    {
        //Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
        //а) Сделать меню с различными функциями и представить пользователю выбор, для какой функции и на каком отрезке находить минимум.Использовать массив(или список) делегатов, в котором хранятся различные функции.
        //б) *Переделать функцию Load, чтобы она возвращала массив считанных значений.Пусть она возвращает минимум через параметр (с использованием модификатора out). 
        //Крюков ВН
        public delegate double Func(double x);

        public static double F1(double x)
        {
            return x * x - 50 * x + 10;
        }

        public static double F2(double x)
        {
            return x * x - 70 * x + 5;
        }

        public static double F3(double x)
        {
            return x * x - 65 * x + 10;
        }

        public static void SaveFunc(string fileName, Func f, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(f(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }
        public static double [] Load(string fileName, out double result)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            double min = double.MaxValue;
            double[] arr = new double[fs.Length / sizeof(double)];
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему                
                d = bw.ReadDouble();
                arr[i] = d;
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            result = min;
            return arr;
        }


        static void Main(string[] args)
        {
            Func[] f = new Func[3];
            f[0] = F1;
            f[1] = F2;
            f[2] = F3;
            int i;
            string s, s1, s2;
            double min, start, end, step;

            while (true) 
            {
                Console.WriteLine("Введите число от 1 до 3, чтобы выбрать функцию.");

                s = Console.ReadLine();

                if (int.TryParse(s, out i) && (i >= 1 && i <= 3))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка! Попробуйте еще раз!");
                }
            }
            
            while (true)
            {
                Console.WriteLine("Введите начало отрезка.");
                s = Console.ReadLine();
                Console.WriteLine("Введите конец отрезка.");
                s1 = Console.ReadLine();
                Console.WriteLine("Введите конец шаг.");
                s2 = Console.ReadLine();

                if (double.TryParse(s, out start) && double.TryParse(s1, out end) && double.TryParse(s2, out step))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ошибка! Попробуйте еще раз!");
                }
            }

            SaveFunc("data.bin", f[i-1], start, end, step);

            foreach (var item in Load("data.bin", out min))
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"Минимум: {min}");
            Console.ReadKey();
        }
    }
}
