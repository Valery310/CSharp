using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2_4
{
    class Program
    {
        //Реализовать метод проверки логина и пароля.На вход метода подается логин и пароль. На
        //выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password:
        //GeekBrains). Используя метод проверки логина и пароля, написать программу: пользователь
        //вводит логин и пароль, программа пропускает его дальше или не пропускает.С помощью
        //цикла do while ограничить ввод пароля тремя попытками.
        //КрюковВН

        static void Main(string[] args)
        {
            string login, password;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Введите логин: ");
                login = Console.ReadLine();
                Console.WriteLine("Введите пароль: ");
                password = Console.ReadLine();

                if (CheckUser(login, password))
                {
                    Console.WriteLine($"Добро пожаловать, {login}");
                    break;
                }
                else
                {
                    Console.WriteLine("Пользователь не найден. Доступ запрещен!");
                    continue;
                }
            }
            
            Console.ReadLine();
        }

        public static bool CheckUser(string login, string password, string correctLogin = "root", string correctPassword = "GeekBrains") 
        {
            return ((login == correctLogin) && (password == correctPassword));
        }
    }
}
