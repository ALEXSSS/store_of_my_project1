using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ChatLocal
{
    class MemberChat
    {
        private string name;
        private Socket listener;
        public List<Socket> clients;
        private List<string> message;
        private string adr;
        private int port;
        private int num_msg;
        public MemberChat(string name, Socket listener, int port, string adr)
        {
            this.name = name;
            this.listener = listener;
            this.listener.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), port));
            //длина очереди ожидающих подключений
            this.listener.Listen(10);
            clients = new List<Socket>();
            message = new List<string>();
            this.port = port;
            this.adr = adr;
            num_msg = 0;
        }

        public void Connect()
        {
            Console.Write("Want to join another user? if true, then write 'yes' else other : ");
            Exception ex = new Exception();
            bool control = true;
            while ((control) || (ex != null))
            {
                if (String.Compare(Console.ReadLine(), "YES", true) == 0)
                {
                    try
                    {
                        ex = null;
                        string ip;
                        Console.Write("Введите ip адрес сети: ");
                        ip = Console.ReadLine();
                        int p;
                        Console.Write("Введите порт сети: ");
                        p = int.Parse(Console.ReadLine());
                        Socket clientsoc = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); ;
                        clientsoc.Connect(ip, p);
                        clients.Add(clientsoc);
                        Console.Write("Want to join another user? if true, then write 'yes' else other : ");
                    }
                    catch (Exception exc)
                    {
                        ex = exc;
                        Console.WriteLine("Repeat please!");
                    }
                }
                else
                {
                    control = false;
                    ex = null;
                }
            }
        }
        private void UserConnectMe()
        {
            if (listener.Poll(100, SelectMode.SelectRead))
            {
                Socket socket = listener.Accept();
                clients.Add(socket);
            }
        }
        private void ReceiveMessage()
        {
            bool NoCopeMsg;

            List<Socket> list = new List<Socket>(clients);
            if (list.Count > 0) Socket.Select(list, null, null, 200);//проверяем те, с которых ещё можно читать
            foreach (Socket socket in list)
            {
                NoCopeMsg = true;
                string key_msg;
                string msg = new StreamReader(new NetworkStream(socket)).ReadLine();
                key_msg = KeyControl.KeyLook(msg);
                foreach (string str in message)
                {
                    if (String.Compare(str, key_msg, true) == 0)
                    {
                        NoCopeMsg = false;
                        break;
                    }
                }
                if (NoCopeMsg)
                {
                    List<Socket> list2 = new List<Socket>(clients);//напишет всем своим клиентам
                    if (list2.Count > 0) Socket.Select(null, list2, null, 200);//только те, что на запись
                    foreach (Socket socket1 in list2)
                    {
                        try
                        {
                            if (socket1 != socket)
                            {
                                StreamWriter msgs = new StreamWriter(new NetworkStream(socket1));
                                msgs.WriteLine(msg);
                                msgs.Flush();
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Один из пользователей покинул чат");
                            clients.Remove(socket1);
                        }
                    }
                    //напишем и себе
                    Console.WriteLine(msg.Substring(key_msg.Length + 1));
                    message.Add(key_msg);
                }
            }
        }
        private void SendMessage()
        {
            List<Socket> list;
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.Write(name + ": ");
                string msg = Console.ReadLine();
                if (msg == "//UserConnect")
                {
                    Connect();
                }
                else
                {
                    list = new List<Socket>(clients);
                    //только те что на запись, напишем себе и им
                    if (list.Count > 0) Socket.Select(null, list, null, 200);
                    foreach (Socket socket in list)
                    {
                        try
                        {
                            StreamWriter msgs = new StreamWriter(new NetworkStream(socket));
                            msgs.WriteLine(adr + " " + port + " " + num_msg + " " + name + ": " + msg);
                            msgs.Flush();
                            num_msg++;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Один из пользователей покинул чат");
                            clients.Remove(socket);
                        }
                    }
                }
            }
        }
        public void ExchangeOfInformation()
        {
            while (true)
            {
                UserConnectMe();
                ReceiveMessage();
                SendMessage();
                ReceiveMessage();
            }//выход производится непосредственно закрытием чата, сокеты закрываются также
        }
    }
}
