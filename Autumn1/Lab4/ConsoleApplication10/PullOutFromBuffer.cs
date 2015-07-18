using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab2
{
    public class PullOutFromBuffer
    {
        Mutex wait;
        List<object> buffer;
        public PullOutFromBuffer(Mutex wait, List<object> buffer)
        {
            this.wait = wait;
            this.buffer = buffer;
        }
        public void PullOut()
        {
            wait.WaitOne();
            if (buffer.Count == 0)
            {
                wait.ReleaseMutex();
                //Console.WriteLine("Buffer is empty");
            }
            else
            {
                object element = buffer[buffer.Count - 1];
                buffer.RemoveAt(buffer.Count - 1);
                Console.WriteLine("Вытащили из буфера элемент: " + element.ToString());
                wait.ReleaseMutex();
            }
        }
    }
}
