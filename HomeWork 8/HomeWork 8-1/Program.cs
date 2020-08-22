using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_8_1
{
    class Program
    {
            //С помощью рефлексии выведите все свойства структуры DateTime
            //КрюковВН

            static PropertyInfo GetPropertyInfo(object obj, string str)
            {
                return obj.GetType().GetProperty(str);
            }

            static PropertyInfo[] GetAllPropertyInfo(object obj)
            {
                return obj.GetType().GetProperties();
            }

            static void Main(string[] args)
            {
                DateTime dateTime = new DateTime();
                //dateTime.DayOfWeek
                Console.WriteLine(GetPropertyInfo(dateTime, "DayOfWeek").CanRead);
                Console.WriteLine(GetPropertyInfo(dateTime, "DayOfWeek").CanWrite);
                Console.WriteLine(GetPropertyInfo(dateTime, "DayOfWeek").GetValue(dateTime, null));

                var Properties = GetAllPropertyInfo(dateTime);

                foreach (var Property in Properties)
                {
                    Console.WriteLine(Property.Name);
                }

                Console.ReadKey();

            }
    }
}
