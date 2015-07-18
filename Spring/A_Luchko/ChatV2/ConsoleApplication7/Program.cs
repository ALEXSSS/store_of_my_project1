using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace ChatLocal
{
    class MainPart
    {
        static void Main(string[] args)
        {//создание чата, подключение пользователей
            string name;
            int port;
            MemberChat user1;
            Socket listener;
            Exception ex = new Exception();
            Console.WriteLine("To join another user write in chat '/ / UserConnect'.");
            while (ex != null)
            {
                try
                {
                    ex = null;
                    Console.Write("Enter your name: ");
                    name = Console.ReadLine();
                    Console.Write("Enter your port: ");
                    port = int.Parse(Console.ReadLine());

                    listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    user1 = new MemberChat(name, listener, port, "127.0.0.1");
                    user1.Connect();
                    user1.ExchangeOfInformation();
                }
                catch (Exception exc1)
                {
                    ex = exc1;
                    Console.WriteLine("Repeat please!");
                }
            }
        }
    }
}
