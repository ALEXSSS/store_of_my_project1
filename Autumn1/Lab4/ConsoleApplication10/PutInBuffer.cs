using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab2
{
    public class PutInBuffer
    {
        Mutex wait;
        List<object> buffer;
        public PutInBuffer(Mutex wait, List<object> buffer)
        {
            this.wait = wait;
            this.buffer = buffer;
        }
        public void Put(object box)
        {
            wait.WaitOne();
            Console.WriteLine("Кладём элемент в буфер: " + box.ToString());
            buffer.Add(box);
            wait.ReleaseMutex();
        }
    }
}
