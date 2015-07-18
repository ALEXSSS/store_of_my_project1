using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab2
{
    class ResearchClass
    {
        private List<int> list;
        private int size;
        private int number_of_threading;
        public ResearchClass(int size, int number_of_threading)
        {
            list=new List<int>();
            this.size = size;
            this.number_of_threading = number_of_threading;
            Random random = new Random();
            for (int i = 0; i < size; i++)
            {
                list.Add(random.Next(1, 100));
            }
        }
        public double StartOfResearch()
        {
          CreateAndStartThreads start=new CreateAndStartThreads(number_of_threading, list);
          return start.CreateThreadsCount();
        }
        public void ShowArray()
        {
            for(int i=0;i<size;i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
