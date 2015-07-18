using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab2
{
    class ClassTread
    {
        List<int> list;
        int start;
        int end;
        public double summ;
        //int num;
        public
            Thread thread;
        Mutex wait;
        public ClassTread(List<int> list, int start, int end, Mutex wait)
        {
            this.list = list;
            this.start = start;
            this.end = end;
            //this.num = num;
            this.wait = wait;
            summ = 0;
        }
        public void Count()
        {
            thread = new Thread(Method);
            thread.Start();
        }
        void Method()
        {
            int summ1 = 0;
            //Console.WriteLine(start + " "+end);
            //Console.ReadKey();
            //Console.WriteLine(list[5] + " " + summ1);
            //for (int i = end; i < 10; i++) Console.WriteLine("list[{0}]={1} ", i, list[i]);
            for (int i = start; i <= end; i++)
            {
                //Console.Write("=");
                //Console.WriteLine(summ1 + " " + list[i]);
                //Console.Write(i + ") " + summ1 + "+" + list[i]);
                summ1 = summ1 + list[i];
                //Console.WriteLine("= "+summ1);
            }
            summ = (double)summ1 / (double)(end - start + 1);
            //Console.WriteLine(summ+" ");
            //Console.ReadKey();
            wait.WaitOne();
            wait.ReleaseMutex();
        }
    }
}
