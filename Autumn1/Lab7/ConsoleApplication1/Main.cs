using MPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
//
//mpiexec -n 8 Console.Application1.exe
//
namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using (new MPI.Environment(ref args))
            {
                Intracommunicator cls = Communicator.world;
                if (cls.Rank == 0)
                {
                    Console.WriteLine("Происходит регистрация сервера!");
                    ServiceHost host = new ServiceHost(typeof(Simple), new Uri("http://localhost:1050/MyMPI"));
                    host.AddServiceEndpoint(typeof(ISimpleNum), new BasicHttpBinding(), "");
                    host.Open();
                    bool end = false;
                    List<int> list = new List<int>();
                    list.Add(-1);
                    list.Add(-1);
                    while (!end)
                    {
                        Console.WriteLine("Сервер запущен!");
                        //Console.ReadLine();
                        Console.Write("Хотите закончить работу сервера(вызовите команду end): ");
                        string a = Console.ReadLine();
                        if (a == "end")
                        {
                            end = true;
                            for (int i = 1; i < cls.Size; i++)
                            {
                                cls.Send<List<int>>(list, i, 0);
                            }
                        }
                    }
                    host.Close();
                }
                else
                {
                    Console.WriteLine("Создаём объекты вычисления!");
                    Simple part = new Simple();
                    while (true)
                    {
                       List<int> a=part.GetNum(0);
                       if ((a.Count > 0) && (a[0] == -1)) break;
                        //
                        //тут прописывал просто (a[0] == -1) и пробовал 
                        //((a!=null)&&(a[0] == -1)) но это было ошибочно(на зачёте), так как и пустой  List имеет ссылку
                        //То есть проблема на самом деле не была в List, но при особом желание везде можно вставить
                        //вместо List, ArrayList "всё практически останется также"
                        //
                    }
                }
            }
        }
    }
}
