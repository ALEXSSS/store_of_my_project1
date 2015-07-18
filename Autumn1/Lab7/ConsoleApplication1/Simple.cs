using System;
using MPI;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Server
{
    class Simple : ISimpleNum
    {
        public List<int> GetNum(int num)
        {
            Console.WriteLine("ввели num " + num);

            List<int> end = new List<int>();
            Intracommunicator cls = Communicator.world;
            Console.WriteLine("ввели cls.Size " + cls.Size);
            Console.WriteLine("cls.Rank " + cls.Rank);
            if (cls.Rank == 0)
            {
                //Console.WriteLine("cls.Rank **********************************************************************" + cls.Rank);
                int part = num / cls.Size;
                int a = part;
                for (int i = 1; i <= cls.Size - 1; i++)
                {
                    if (i == cls.Size - 1)
                    {
                        List<int> list = new List<int>();
                        list.Add(a + 1);
                        list.Add(num);
                        cls.Send<List<int>>(list, cls.Size - 1, 0);
                    }
                    else
                    {
                        List<int> list = new List<int>();
                        list.Add(a + 1);
                        list.Add(a + part);
                        cls.Send<List<int>>(list, i, 0);
                        a += part;
                    }
                }
                for (int i = 2; i <= part; i++)
                {
                    if (ChekSimple(i))
                    {
                        end.Add(i);
                    }
                }
                List<int> general_list;
                for (int i = 1; i < cls.Size; i++)
                {
                    Console.WriteLine("Rank !!!!!!!!!!!!!!!!!");
                    general_list = cls.Receive<List<int>>(i, 0);
                    for (int j = 0; j < general_list.Count; j++)
                    {
                        end.Add(general_list[j]);
                    }
                }
                cls.Barrier();
            }
            else
            {

                List<int> list = new List<int>();
                List<int> list1 = cls.Receive<List<int>>(0, 0);
                //Console.WriteLine("dsfdsgsdgdsgsdgsdg_____________dsfgsdgsdggdsgsdg");
                Console.WriteLine("1){0}    2){1} ", list1[0], list1[1]);
                if ((list1[0] == -1) || (list1[1] == -1))
                {
                    list.Add(-1);
                    //cls.Send<List<int>>(list, 0, 0);
                    return list;
                }
                else
                {
                    for (int i = list1[0]; i <= list1[1]; i++)
                    {
                        if (ChekSimple(i)) list.Add(i);
                    }
                    cls.Send<List<int>>(list, 0, 0);
                }
                cls.Barrier();
            }
            return end;
        }
        bool ChekSimple(int num)
        {
            if (((num % 2) == 0) && (num != 2)) return false;
            else
            {
                for (int i = 3; i <= Math.Sqrt(num); i += 2)
                {
                    if (num % i == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
