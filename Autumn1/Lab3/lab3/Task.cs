using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProcessManager;

namespace lab3
{
    class Task
    {

        public Process process;
        public uint fiberID;
        public bool IsComplete;
        public bool IsWork;

        public Task()
        {
            IsComplete = false;
            IsWork = false;
            process = new Process();
        }
    }
}
