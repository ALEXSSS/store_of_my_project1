using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessManager;

namespace lab3
{
    class MyQueue
    {
        static public List<Task> queue = new List<Task>();
        private static Task work_in = null;
        public static uint MainFiber;
        public static uint MainFiber1;
        public static bool first;

        public static Task Get()
        {
            Task task = queue[queue.Count - 1];
            queue.RemoveAt(queue.Count - 1);
            return task;
        }
        public static void Push(Task task)
        {
            queue.Add(task);
            queue.OrderBy(task1 => task1.process.Priority);
        }
        
        public static Task WorkIn()
        {
            return work_in;
        }
        public static void SetWorkIn(Task task)
        {
            work_in = task;
        }
        public static void DeleteWorkIn()
        {
            work_in.IsComplete = true;
        }
    }
}
