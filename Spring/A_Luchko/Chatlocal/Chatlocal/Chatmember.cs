using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;


namespace Chatlocal
{//структура для каждого пользователя
    struct member_chat
    {
        public string name;
        public Socket listener;
        public List<Socket> clients;
    }
}
