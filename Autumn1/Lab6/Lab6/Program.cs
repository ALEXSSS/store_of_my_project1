using System;
using System.Threading;

namespace Lab6
{
    class Program
    {
        static void Main()
        {

            Test1 a = new Test1();
            Test2 a1 = new Test2();
            Test3 a2 = new Test3();
            Mutex wait = new Mutex(false);
            MyThreadPool pool = new MyThreadPool(5, wait);
            for (int I = 0; I < 20; I++) pool.PutInQueue(new Test1());
               // pool.PutInQueue(a);
            //pool.PutInQueue(a1);
            //pool.PutInQueue(a2);
            Thread.Sleep(100);
            Console.ReadKey();
            pool.EndMyThreadPool();
            Console.ReadKey();
        }
    }
}
