using System.Threading;
using System;
using System.Collections.Generic;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Mutex wait = new Mutex();
            List<object> buffer = new List<object>();
            List<object> list = new List<object>();
            //информация для теста
            for (int i = 0; i < 20; i++)
            {
                list.Add(i + 10);
            }
            //добавим некоторую информацию
            for (int i = 0; i < 10; i++)
            {
                buffer.Add(i.ToString() + "***");
            }
            TestClass test = new TestClass(wait, list, buffer);
            test.GeneralMethod();
            Console.ReadLine();
        }
    }
}