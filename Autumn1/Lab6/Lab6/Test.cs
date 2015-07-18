using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lab6
{
    class Test1 : IStart
    {
        public void Start()
        {
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine("Это тест1");
                Thread.Sleep(10);
            }
        }
    }
    class Test2 : IStart
    {
        public void Start()
        {
            for (int i = 0; i < 1; i++)
            {
            Console.WriteLine("Это тест2");
            Thread.Sleep(10);
            }
        }
    }
    class Test3 : IStart
    {
        public void Start()
        {
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine("Это тест3");
                Thread.Sleep(10);
            }
        }
    }
}
