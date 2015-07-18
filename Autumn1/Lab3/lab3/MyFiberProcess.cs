using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;



namespace lab3
{
    public delegate void EndEventHandler();
    class MyFiberProcess
    {
        public event EndEventHandler Exit;
        public void Start()
        {
           // try

            {
                while (MyQueue.queue.Count() > 0)
                {
                    Task task = MyQueue.Get();
                    if (MyQueue.WorkIn() == null)
                    {
                        Console.WriteLine("Произошёл первый вызов распределительного файбера!");
                    }
                    else
                    {
                        if (MyQueue.WorkIn().IsComplete)
                        {
                            Fiber.Delete(MyQueue.WorkIn().fiberID);
                        }
                        else
                        {
                            MyQueue.Push(MyQueue.WorkIn());
                        }
                    }
                    MyQueue.SetWorkIn(task);
                    if (task.IsWork)
                    {
                        Fiber.Switch(task.fiberID);
                    }
                    else
                    {
                        Fiber fiber = new Fiber(task.process.Run);
                        task.fiberID = fiber.Id;
                        task.IsWork = true;
                        Fiber.Switch(task.fiberID);
                    }
                }
                //Thread.Sleep(10000);
               // if (MyQueue.first)
                    Console.WriteLine("Главный файбер вышел из цикла раздачи в методе!!!");
                    Console.ReadKey();
                    Exit();
                //можно и так валить прогу 
                //можно также просто вызывать метод System.Environment.Exit(0);
                    //	Process.GetCurrentProcess().Kill();
            }
            //catch(Exception)он не видит ни каких исключений, выдаёт коды ошибок
        }
    }
}