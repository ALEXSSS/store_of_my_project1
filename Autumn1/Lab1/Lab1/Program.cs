using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceServer;
using SpaceClient;


class Program
{
    static void Main(string[] args)
    {
        bool enter = true;
        Console.WriteLine("Вы создатель чата или хотите присоедениться к существующему?");
        while (enter)
        {
            Console.Write("введите 1, если создатель, другое число иначе:  ");
            try
            {
                if (int.Parse(Console.ReadLine()) == 1)
                {
                    Console.WriteLine("вы создатель чата!!!");
                    Server server = new Server();
                }
                else
                {
                    Console.WriteLine("вы клиент!!!");
                    Client client = new Client();
                }
                enter = false;
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Повторите ввод!");
            }
            Console.ReadKey();
        }
    }
}

