using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Chatlocal
{
    static class ChatReceiveMessage
    {
        public static void receive_message(member_chat user)
        {
            List<Socket> list = new List<Socket>(user.clients);
            if (list.Count > 0) Socket.Select(list, null, null, 200);//проверяем те, с которых ещё можно читать
            foreach (Socket socket in list)
            {
                string msg = new StreamReader(new NetworkStream(socket)).ReadLine();
                List<Socket> list2 = new List<Socket>(user.clients);//напишет всем своим клиентам
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
                        user.clients.Remove(socket1);
                    }
                }
                //напишем и себе
                Console.WriteLine(msg);
            }
        }
    }
}
