using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{//ПОСМОТРЕТЬ НЕПОСРЕДСТВЕННО ДЕБАГ КЛАСС
    class Program
    {
        static void Main(string[] args)
        {
            ResearchClass Research = new ResearchClass(4096, 8);
            //Research.ShowArray();
            DateTime now = DateTime.Now;
            double answer=Research.StartOfResearch();
            DateTime now1 = DateTime.Now;
            TimeSpan os = now1.Subtract(now);
            Console.WriteLine("Среднее арифметическое: "+ answer);
            Console.WriteLine("Время работы в тактах равно {0} и в миллисекундах {1}", os.Ticks.ToString(), os.TotalMilliseconds.ToString());
            Console.Write("Нажмите Enter, чтобы выйти. ");
            Console.ReadKey();
        }
    }
}
