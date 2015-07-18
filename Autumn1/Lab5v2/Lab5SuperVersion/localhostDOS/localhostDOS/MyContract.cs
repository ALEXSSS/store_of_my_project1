using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ContractForMyLab
{
    [ServiceContract] // Говорим WCF что это интерфейс для запросов сервису
    public interface IServerContract
    {
        [OperationContract] // Делегируемый метод.
        List<int> Get(int i);
    }
}
