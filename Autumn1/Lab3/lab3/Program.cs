using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace lab3
{
    static class Program
    {
        //public static Task task2;
        //public static ManualResetEvent a = new ManualResetEvent(false);
        static void Main(string[] args)
        {
            //Action action= new Action(MyFiberProcess.Start);
            //task2 = new Task(action);
            for (int i = 0; i < 2; i++)
            {
                MyQueue.Push(new Task());
            }
            MyFiberProcess main = new MyFiberProcess();
            main.Exit += Exit;
            Fiber FiberFirst = new Fiber(main.Start);
            MyQueue.MainFiber = FiberFirst.Id;
            main.Start();
        }
        static void Exit()
        {
            System.Environment.Exit(0);
        }
    }
}
