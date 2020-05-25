using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTime
{
    class Program
    {
        static void Main(string[] args)
        {

            Time x = new Time(12, 42, 30),
                y = new Time(11, 28, 30);


            Console.WriteLine("x = {0}", x.ToString());
            Console.WriteLine("y = {0}\n", y.ToString());

            Console.WriteLine($"Время в x в часах = {x.ToHour()}");
            Console.WriteLine($"Время в x в минутах = {x.ToMinute()}");
            Console.WriteLine($"Время в x в секундах = {x.ToSecond()}");

            Console.WriteLine("x + y = {0}", (x + y).ToString());
            Console.WriteLine("x - y = {0}\n", (x - y).ToString());

            x.Add_H(44);
            Console.WriteLine("x + 44 hours = {0}", x.ToString());
            x.Add_M(32);
            Console.WriteLine("x + 32 minutes = {0}", x.ToString());
            x.Add_S(55);
            Console.WriteLine("x + 55 seconds = {0}\n", x.ToString());

            x.Sub_H(11);
            Console.WriteLine("x - 11 hours = {0}", x.ToString());
            x.Sub_M(23);
            Console.WriteLine("x - 23 minutes = {0}", x.ToString());
            x.Sub_S(600);
            Console.WriteLine("x - 600 seconds = {0}", x.ToString());

            Console.ReadKey();
        }
    }
}