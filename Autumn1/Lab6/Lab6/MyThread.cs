using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lab6
{
    public class MyThread
    {
        Thread thread;
        Queue<IStart> queue_of_task;
        Mutex wait;
        bool end;
        AutoResetEvent myevent;
        public bool isWork;
        public MyThread(Queue<IStart> queue_of_task, Mutex wait, bool end, AutoResetEvent myevent)
        {
            this.queue_of_task = queue_of_task;
            this.wait = wait;
            thread = new Thread(Execute);
            thread.Start();
            this.end = end;
            this.myevent = myevent;
            isWork = true;
        }
        public void EndThreads()
        {
            end = true;
            thread.Join();
        }
        void Execute()
        {
            while (!end)
            {
                Console.WriteLine("Я ищу еду");
                wait.WaitOne();
                if (queue_of_task.Count > 0)
                {
                    isWork = true;
                    Console.WriteLine("Есть сигнал!!!");
                    Console.WriteLine("еда есть");
                    Console.WriteLine("можно поесть");
                    var task = queue_of_task.Dequeue();
                    wait.ReleaseMutex();
                    Console.WriteLine("количство задач:  " + queue_of_task.Count);
                    Thread.Sleep(100);
                    task.Start();
                    Console.WriteLine("Задача выполнена!");
                }
                else
                {
                    isWork = false;
                    if (!end)
                    {
                        wait.ReleaseMutex();
                        myevent.WaitOne(500);
                    }
                    else
                    {
                        wait.ReleaseMutex();
                    }
                }
            }
        }
    }
}
