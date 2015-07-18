using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Chatlocal
{
   static class ChatUserConnect
    {
       public static void user_connect(member_chat user)
       {
           if (user.listener.Poll(100, SelectMode.SelectRead))//можно ли читать с сокета
           {
               Socket socket = user.listener.Accept();
               user.clients.Add(socket);
           }
       }
    }
}
