using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace Client
{
    class Program
    {
        static void Main()
        {
            Uri tcpUri = new Uri("http://localhost:1050/MyMPI");
            //регестрация клиента
            EndpointAddress address = new EndpointAddress(tcpUri);
            BasicHttpBinding binding = new BasicHttpBinding();
            ChannelFactory<ISimpleNum> factory = new ChannelFactory<ISimpleNum>(binding, address);
            ISimpleNum service = factory.CreateChannel();
            //конец регистрации
            int integ = 1;
            bool end = false;
            DateTime now = DateTime.Now;
            while (!end)
            {
                try
                {
                    Console.Write("До какого искать простые числа: ");
                    integ = int.Parse(Console.ReadLine());
                    end = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Повторите ввод!!!");
                }
            }
            List<int> list = service.GetNum(integ);
            for (int i = 0; i < list.Count; i++)
            {
                if ((i + 1) % 10 == 0) Console.WriteLine();
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();
            DateTime now1 = DateTime.Now;
            Console.WriteLine("Время ожидания на клиенте в Milliseconds: " + (now1 - now).Milliseconds);
            Console.ReadKey();
        }
    }
}
