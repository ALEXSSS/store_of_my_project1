using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Chatlocal
{
    static class ChatSendMessage
    {
        public static void send_message(member_chat user)
        {
            List<Socket> list;
            //пишем другим
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Console.Write(user.name + ": ");
                string msg = Console.ReadLine();
                list = new List<Socket>(user.clients);
                //только те что на запись, напишем себе и им
                if (list.Count > 0) Socket.Select(null, list, null, 200);
                foreach (Socket socket in list)
                {
                    try
                    {
                        StreamWriter msgs = new StreamWriter(new NetworkStream(socket));
                        msgs.WriteLine(user.name + ": " + msg);
                        msgs.Flush();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Один из пользователей покинул чат");
                        user.clients.Remove(socket);
                    }
                }
            }
        }
    }
}
