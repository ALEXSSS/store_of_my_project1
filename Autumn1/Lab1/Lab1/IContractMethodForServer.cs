using System.ServiceModel;


namespace SpaceServer
{
    [ServiceContract] // Говорим WCF что это интерфейс для запросов сервису
    public interface IContractMethodForServer
    {
        [OperationContract] // Делегируемый метод.
        void ClientMessage(string name,string message,int localhost,int start);
        [OperationContract] // Делегируемый метод.
        void Exit(int localhost,string name,int start);
        [OperationContract] // Делегируемый метод.
        string Connect(int localhost);
    }
}
