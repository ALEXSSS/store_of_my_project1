using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client;
using System.Diagnostics;

namespace Lab5
{
    static class MainMethod
    {
        static void Main()
        {
            Console.Write("Введите 1 для сервера, другое число иначе: ");
            if (int.Parse(Console.ReadLine()) == 1)
            {
                try
                {
                    Program2 A = new Program2();
                    A.Start();
                }
                catch (Exception)
                {
                    Console.WriteLine("Сервер не выдержал от количества сообщений!!!");
                }
            }
            else
            {
                MyThreadBr threads = new MyThreadBr(1, 15000, 1000000);
                Console.WriteLine("Послал!!!");
                Console.ReadKey();
                /*for(int i=0;i<6;i++)//можно запустить несколько программ для большей амуляции процесса
                {
                    Process.Start("C:\\Users\\Александр\\Documents\\Visual Studio 2013\\Projects\\localhostDOS\\localhostDOS\\bin\\Debug\\localhostDOS.exe");
                }*/
                //MyThreadBr threads = new MyThreadBr(8000, 20000,1000);
            }
            Console.ReadKey();
        }
    }
}

