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
        static void Main()
        {
            MyThreadBr threads = new MyThreadBr(800, 15000, 100000);
            Console.WriteLine("Послал!!!");
            Console.ReadKey();
        }
    }
}
