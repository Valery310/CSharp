using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HomeWork_5_1
{
    class Program
    {

        //Создать программу, которая будет проверять корректность ввода логина.Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
        //а) без использования регулярных выражений;
        //б) **с использованием регулярных выражений.
        //КрюковВН

        static void Main(string[] args)
        {
            string Login ="";
            Console.WriteLine("Введите логин: ");
            Login = Console.ReadLine();

            Console.WriteLine("Проверка без использования регулярного выражения.");
            if (checkLogin(Login))
            {
                Console.WriteLine("Логин корректен.");
            }
            else
            {
                Console.WriteLine("Логин некорректен!");
            }

            Console.WriteLine("Проверка с использованием регулярного выражения.");
            if (checkLoginRegular(Login))
            {
                Console.WriteLine("Логин корректен.");
            }
            else
            {
                Console.WriteLine("Логин некорректен!");
            }

            Console.ReadKey();
        }

        static bool checkLogin(string Login) 
        {
            if (Login.Length > 2 && Login.Length < 10 )
            {
                int t;
                if (!int.TryParse(Login.Substring(0,1), out t))
                {
                    for (int i = 0; i < Login.Length; i++)
                    {
                        if (!((Login[i] >= 'A' && Login[i] <= 'Z') || (Login[i] >= 'a' && Login[i] <= 'z') || (Login[i] >= '0' && Login[i] <= '9')))
                        {
                            return false;
                        }                        
                    }
                    return true;
                }
            }
            return false;
        }

        static bool checkLoginRegular(string Login)
        {
            RegexOptions regexOp = RegexOptions.IgnoreCase;
            
            Regex regex = new Regex(@"^[a-zA-Z]{1}\w[a-zA-Z0-9]{0,8}$", regexOp);
            
            return regex.IsMatch(Login);
        }
    }
}
