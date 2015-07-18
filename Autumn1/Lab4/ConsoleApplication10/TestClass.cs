using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab2
{
    //класс, который служит только для тестирования работы двух основных классов PutInBuffer и PullOutFromBuffer
    public class TestClass
    {
        private PutInBuffer creator;
        private PullOutFromBuffer consumer;
        private List<object> list;
        private Mutex wait;
        public TestClass(Mutex wait, List<object> list, List<object> buffer)
        {
            this.wait = wait;
            this.list = list;
            this.creator = new PutInBuffer(wait, buffer);
            this.consumer = new PullOutFromBuffer(wait, buffer);
        }
        public void GeneralMethod()
        {
            //этот метод инкапсулирует вызов остальных методов, чтобы не вызывать их в Main
            Thread myThread = new Thread(PutMethod);
            myThread.Start();
            Thread myThread1 = new Thread(PullMethod);
            myThread1.Start();
            myThread.Join();
            myThread1.Join();
        }
        private void PutMethod()
        {
            foreach (object a in list)
            {
                Thread.Sleep(1000);
                creator.Put(a);
            }
            Console.WriteLine("Поток окончил свою тестовую работу");
        }
        public void PullMethod()
        {
            for (int i = 0; i < 60; i++)
            {
                Thread.Sleep(1000);
                consumer.PullOut();
            }
            Console.WriteLine("Поток окончил свою тестовую работу");
        }
    }
}
