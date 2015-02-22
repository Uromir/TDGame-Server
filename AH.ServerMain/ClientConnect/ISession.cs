using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace AH.ClientConnect
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(ISessionCallback))]
    public interface ISession
    {
        [OperationContract(IsOneWay = true)]
        void DoWork();
        [OperationContract(IsOneWay = true)]
        void login(string log, string Pass);
    }

    [ServiceContract]
    public interface ISessionCallback
    {
        [OperationContract(IsOneWay = true)]
        void Print(string text);
    }
}
