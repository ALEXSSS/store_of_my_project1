using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab2
{
    class CreateAndStartThreads
    {
        int number_of_threading;
        List<int> buffer;
        double summ;
        public CreateAndStartThreads(int number_of_threading, List<int> list)
        {
            this.number_of_threading = number_of_threading;
            buffer = list;
            summ = 0;
        }
        public double CreateThreadsCount()
        {
            int iter = 0;
            Mutex wait = new Mutex();
            ClassTread[] array_of_thread = new ClassTread[number_of_threading];
            for (int i = 0; i < number_of_threading; i++)
            {
                int iter1 = iter + (buffer.Count / number_of_threading)-1;
                array_of_thread[i] = new ClassTread(buffer, iter, iter1, wait);
                //for (int j = 0; j < 3; j++) Console.Write(buffer[j]+"**"+j+"*");
                    array_of_thread[i].Count();
                iter = iter1+1;
                
            }
            for(int i=0;i<number_of_threading;i++)
            {
                array_of_thread[i].thread.Join();
                summ += array_of_thread[i].summ;
            }
            return (double) summ / (double) number_of_threading;
        }
    }
}
