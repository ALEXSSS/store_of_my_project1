using System;
using System.Collections;
using System.Collections.Generic;
using System.ServiceModel;


namespace Server
{
    [ServiceContract]
    interface ISimpleNum
    {
        [OperationContract]
        List<int> GetNum(int n);
    }
}
