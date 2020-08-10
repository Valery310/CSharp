using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork1_6
{
    //* Создать класс с методами, которые могут пригодиться в вашей учебе(Print, Pause).
    public class AssistClass
    {
        static void Print(string msg)
        {
            Console.WriteLine(msg);
        }

        static void Print(string msg, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(msg);
        }

        static void Print(string msg, int x, int y, ConsoleColor consoleColor)
        {
            Console.BackgroundColor = consoleColor;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(msg);
        }

        public void Pause() 
        {
            Console.ReadKey();
        }
    }
}
