using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;


namespace SpaceServer
{
    class Server
    {
        static List<int> localhosts;
        static List<SpaceClient.IContractMethodForClient> services;
        public Server()
        {
            RunServer();
        }
        class MyObject : IContractMethodForServer
        {
            public void Exit(int localhost,string name,int start)
            {
                int delete = 0;
                try
                {
                    int index = localhosts.IndexOf(localhost);
                    localhosts.RemoveAt(index);
                    services.RemoveAt(index);
                    for (int i = 0; i < localhosts.Count; i++)
                    {
                        delete = i;
                        services[i].ServerMessage("ChatHost", "Пользователь " + name + " покинул чат");
                    }
                }
                catch(System.ServiceModel.EndpointNotFoundException)
                {
                    localhosts.RemoveAt(delete);
                    services.RemoveAt(delete);
                    Exit(localhost, name, delete + 1);
                }
            }
            public string Connect(int i)
            {
                Uri tcpUri = new Uri("http://localhost:" + i + "/TestService");
                EndpointAddress address = new EndpointAddress(tcpUri);
                BasicHttpBinding binding = new BasicHttpBinding();
                ChannelFactory<SpaceClient.IContractMethodForClient> factory = new ChannelFactory<SpaceClient.IContractMethodForClient>(binding, address);
                SpaceClient.IContractMethodForClient service = factory.CreateChannel();
                localhosts.Add(i);
                services.Add(service);
                return "ChatHost: ваш запрос на соединение реализуется.";
            }
            public void ClientMessage(string name, string message, int localhost,int start)
            {
                int delete = 0;
                try
                {
                    for (int i = start; i < localhosts.Count; i++)
                    {
                        if (localhost != localhosts[i])
                        {
                            delete = i;
                            services[i].ServerMessage(name, message);
                        }
                    }
                }
                catch(System.ServiceModel.EndpointNotFoundException)
                {
                    services.RemoveAt(delete);
                    localhosts.RemoveAt(delete);
                    services[delete].ServerMessage("ChatHost", "Пользователь " + name + " покинул чат не предупредив систему!");
                    ClientMessage(name, message, localhost, delete+1);
                }
            }
        }
        
        public void RunServer()
        {
            ServiceHost host = new ServiceHost(typeof(MyObject), new Uri("http://localhost:1050/TestService"));
            host.AddServiceEndpoint(typeof(IContractMethodForServer), new BasicHttpBinding(), "");
            host.Open();
            localhosts = new List<int>();
            services = new List<SpaceClient.IContractMethodForClient>();
            Console.WriteLine("Чат по локальной сети с использованием технологии wcf создан!!!");
        }
    }
}

