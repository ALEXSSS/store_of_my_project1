using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;


namespace SpaceClient
{
    [ServiceContract] // Говорим WCF что это интерфейс для запросов сервису
    interface IContractMethodForClient
    {
        [OperationContract] // Делегируемый метод.
        bool IsAlive();
        
        [OperationContract]
        void ServerMessage(string name,string mess);
    }
}

