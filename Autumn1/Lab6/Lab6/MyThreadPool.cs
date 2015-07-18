using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab6
{
    class MyThreadPool
    {
        List<MyThread> mythreads;
        int numberofthread;
        Mutex wait;
        Queue<IStart> queue_of_task;
        AutoResetEvent myevent;
        public MyThreadPool(int numberofthread, Mutex wait)
        {
            this.numberofthread = numberofthread;
            mythreads = new List<MyThread>(numberofthread);
            this.wait = wait;
            queue_of_task = new Queue<IStart>();
            myevent = new AutoResetEvent(false);
            for (int i = 0; i < numberofthread; i++)
            {
                mythreads.Add(new MyThread(queue_of_task, wait, false, myevent));
            }
        }
        //
        //кладём в очередь задач, имеет смысл, как исключительная ситуация в случае
        //несоотвествия типов(оболочка проверки типов)
        //
        public void PutInQueue<T>(T task) where T : IStart
        {
            queue_of_task.Enqueue(task);
            bool work = false;
            for (int i = 0; i < numberofthread; i++)
            {
                if (mythreads[i].isWork == false)
                {
                    work = true;
                    break;
                }
            }
            if (work)
            {
                myevent.Set();
            }
        }
        public void EndMyThreadPool()
        {
            foreach (MyThread a in mythreads)
            {
                a.EndThreads();
                Console.WriteLine("поток корректно остановлен, его задача выполнена!!");
            }
            Console.WriteLine("Все потоки успешно остановлены, после выполнения задач!!! ");
        }
    }
}
