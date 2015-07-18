using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client;

namespace Lab5
{
    static class MainMethod
    {
        static void Main(string[] args1)
        {
            DateTime now = DateTime.Now;
            try
            {
                foreach (string a in args1) Console.WriteLine(a);
                //Console.ReadKey();
                //string[] args = args1[0].Split(' ');
                //Console.WriteLine(args.Length);
                //Console.ReadKey();
                Console.WriteLine(int.Parse(args1[0]) + " " + int.Parse(args1[1]) + " " + int.Parse(args1[2]));
                MyThreadBr threads = new MyThreadBr(int.Parse(args1[0]), int.Parse(args1[1]), int.Parse(args1[2]));
                Console.WriteLine("Послал!!!");
            }
            catch(Exception)
            {
                DateTime now1 = DateTime.Now;
                Console.WriteLine("К клиент не дождался ответа и отсоеденился через: "+(now1-now).Seconds+" секунд.");
            }
            Console.ReadKey();
        }
    }
}
