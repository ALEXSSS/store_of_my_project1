using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            if ((args == null) || (int.Parse(args[0]) == 1))
            {
                Program2 Server = new Program2(true);
            }
            else
            {
                Program2 Server = new Program2(false);
            }
            Console.ReadKey();
        }
    }
}
