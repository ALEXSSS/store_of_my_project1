using System.ServiceModel;
using System;
using System.Threading;

namespace SpaceClient
{
    class Client
    {
        Uri tcpUri;
        ServiceHost host;
        int localhost;
        string name;
        SpaceServer.IContractMethodForServer service;
        public Client()
        {
            RunClient();
        }
        public void Close()
        {
            host.Close();
            //exit
        }
        class MyObject : IContractMethodForClient
        {
            public bool IsAlive()
            {
                return true;
            }
            public void ServerMessage(string name, string mess)
            {
                Console.WriteLine(name + ": " + mess);
            }
        }
        void RunClient()
        {
            Initialization();
            SendMessage();
        }
        void SendMessage()
        {
            string msg = "::Видит чат";
            Console.WriteLine("Чтобы выйти из чата введите команду: ExitCommand\\ ");
            Console.WriteLine(service.Connect(localhost));
            while (msg != "ExitCommand\\")
            {
                service.ClientMessage(name, msg, localhost, 0);
                Console.Write(name + ": ");
                msg = Console.ReadLine();
            }
            service.Exit(localhost, name, 0);
            host.Close();
        }
        void Initialization()
        {
            //клиент часть узла клиента
            tcpUri = new Uri("http://localhost:1050/TestService");
            EndpointAddress address = new EndpointAddress(tcpUri);
            BasicHttpBinding binding = new BasicHttpBinding();
            ChannelFactory<SpaceServer.IContractMethodForServer> factory = new ChannelFactory<SpaceServer.IContractMethodForServer>(binding, address);
            service = factory.CreateChannel();
            Console.WriteLine("Связь установлена!");

            //сервер часть узла клиента
            bool end = false;
            while (!end)
            {
                try
                {
                    Console.Write("Вы клиент! укажите номер своего localhost: ");
                    localhost = int.Parse(Console.ReadLine());
                    Console.Write("Укажите своё имя для чата: ");
                    name = Console.ReadLine();
                    host = new ServiceHost(typeof(MyObject), new Uri("http://localhost:" + localhost + "/TestService"));
                    host.AddServiceEndpoint(typeof(IContractMethodForClient), new BasicHttpBinding(), "");
                    host.Open();
                    Console.WriteLine("Узел создан.");
                    end = true;
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Введите натуральное число!!!");
                }
                catch (System.ArgumentNullException)
                {
                    Console.WriteLine("Номер localhost не корректен, измените его!!!");
                }
                catch(System.OverflowException)
                {
                    Console.WriteLine("Введите не такое большое число!!!");
                }
                catch(System.Exception)
                {
                    Console.WriteLine("Вводите корректно!!!");
                    Console.WriteLine("Вероятная ошибка в том, что ваш localhost уже занят. Измените номер localhost в повторном вводе!!!");
                }
            }
        }
    }
}
