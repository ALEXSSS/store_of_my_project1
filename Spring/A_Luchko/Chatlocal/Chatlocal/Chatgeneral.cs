using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Chatlocal
{
    class Chatgeneral
    {
        static void Main(string[] args)
        {//создание чата, подключение пользователей
            string name;
            int port;
            Console.Write("Enter your name: ");
            name = Console.ReadLine();
            Console.Write("Enter your port: ");
            port = int.Parse(Console.ReadLine());
            Console.Write("The first user? if true, then write 'yes' else other: ");

            member_chat user1;
            user1.name = name;
            user1.listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //закрепляет сокет за пользователем и его компьютером
            user1.listener.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), port));
            //длина очереди ожидающих подключений
            user1.listener.Listen(10);
            user1.clients = new List<Socket>();
            if (String.Compare(Console.ReadLine(),"no", true) == 0)
            {
                string ip;
                Console.Write("Введите ip адрес сети: ");
                ip = Console.ReadLine();
                int p;
                Console.Write("Введите порт сети: ");
                p = int.Parse(Console.ReadLine());
                Socket clientsoc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); ;
                clientsoc.Connect(ip, p);
                (user1.clients).Add(clientsoc);
            }
            Chatworker.Exchangeofinformation(user1);
        }
    }
}
