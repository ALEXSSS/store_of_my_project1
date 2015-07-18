using System;
using System.Collections.Generic;
using System.ServiceModel;
using ContractForMyLab;
using System.Threading;


namespace Lab5
{
    class Program2
    {
        static private List<int> good_num;
        static private int max_num;
        static private object point;
        static private int num_answer;
        static private uint num_get;
        public Program2()
        {
            Start();
            num_get = 0;
        }
        private class MyObject : IServerContract
        {
            public List<int> Get(int i)
            {
                Incr();
                List<int> list = Simp(i);
                return list;
            }
            public void Want_Me()
            {
                Incr_num_get();
            }
            public uint Client_Num()
            {
                return num_get;
            }
        }
        public void Start()
        {
            good_num = new List<int>();
            good_num.Add(1);
            max_num = 1;
            ServiceHost host = new ServiceHost(typeof(MyObject), new Uri("http://localhost:1050/TestService"));
            host.AddServiceEndpoint(typeof(IServerContract), new BasicHttpBinding(), "");
            host.Open();
            Console.WriteLine("Сервер запущен");
            Console.ReadLine();
            //host.Close();
        }
        private static List<int> Simp(int i)
        {
            List<int> list;
            if (max_num >= i)
            {
                list = new List<int>(good_num);
                list.RemoveAll(EndS);
            }
            else
            {
                list = new List<int>(good_num);
                for (int j = 1; j < i - max_num + 1; j++)
                {
                    if (IsSimp(max_num + j))
                    {
                        list.Add(max_num + j);
                    }
                }
            }
            /*list = new List<int>();
            for (int j = 1; j < i + 1; j++)
            {
                if (IsSimp(j))
                {
                    Thread.Sleep(2);
                    list.Add(j);
                }
            }*/
            return list;
        }
        private static bool IsSimp(int num)
        {
            int chek = 0;
            for (int i = 1; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    chek++;
                }
            }
            if (chek > 1) return false;
            return true;
        }
        private int FindOutNumOfEnd(int num)
        {
            int end = -1;
            for (int i = 0; i < good_num.Count; i++)
            {
                if (num < good_num[i]) end++;
            }
            return end;
        }
        private static bool EndS(int i)
        {
            return i < max_num;
        }
        public static void Incr()
        {
            num_answer++;
            Console.WriteLine("Запрос " + num_answer + " раз");
        }
        public static void Incr_num_get()
        {
            num_get++;
            Console.WriteLine("Запрос num_get " + num_get + " раз");
        }
    }
}