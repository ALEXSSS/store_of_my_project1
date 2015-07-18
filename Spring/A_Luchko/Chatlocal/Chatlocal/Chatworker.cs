using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Chatlocal
{//рабочая часть обмена информацией 
    class ChatWorker
    {
        public void Exchangeofinformation(member_chat user)
        {
            while (true)
            {
                ChatUserConnect.user_connect(user);
                ChatReceiveMessage.receive_message(user);
                ChatSendMessage.send_message(user);
                ChatReceiveMessage.receive_message(user);
            }//выход производится непосредственно закрытием чата, сокеты закрываются также
        }
    }
    struct member_chat
    {
        public string name;
        public Socket listener;
        public List<Socket> clients;
    }
}
