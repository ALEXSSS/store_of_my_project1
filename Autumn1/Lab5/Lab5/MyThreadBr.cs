using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Client;

namespace Lab5
{
    class MyThreadBr
    {
        int num_thread;
        int diff;
        int iter_num;
        List<Thread> threads;
        public MyThreadBr(int num_thread, int diff,int iter_num)
        {
            this.num_thread = num_thread;
            this.diff = diff;
            this.iter_num = iter_num;
            threads=new List<Thread>();
            TestCreate();
            TestStart();
        }
        void TestCreate()
        {
            for (int i = 0; i < num_thread; i++)
            {
                threads.Add(new Thread((new Program1(diff,iter_num)).Main1));
            }
        }
        void TestStart()
        {
            for (int i = 0; i < num_thread; i++)
            {
                threads[i].Start();
            }
        }
    }
}
