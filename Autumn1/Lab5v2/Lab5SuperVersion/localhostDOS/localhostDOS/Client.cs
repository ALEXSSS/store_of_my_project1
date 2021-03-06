﻿using System;
using System.Collections.Generic;
using System.ServiceModel;
using ContractForMyLab;

namespace Client
{
    [ServiceContract]
    public interface IServerContract
    {
        [OperationContract]
        List<int> Get(int i);
    }

    class Program1
    {
        int diff;
        int iter_num;
        public Program1(int diff, int iter_num)
        {
            this.diff = diff;
            this.iter_num = iter_num;
        }
        public void Main1()
        {
            Uri tcpUri = new Uri("http://localhost:1050/TestService");
            EndpointAddress address = new EndpointAddress(tcpUri);
            BasicHttpBinding binding = new BasicHttpBinding();
            ChannelFactory<IServerContract> factory = new ChannelFactory<IServerContract>(binding, address);
            IServerContract service = factory.CreateChannel();
            for (int i = 0; i < iter_num; i++) service.Get(diff);
            //List<int> a3 = service.Get(diff); foreach (int b in a3) Console.Write(b + " ");
        }
    }
}