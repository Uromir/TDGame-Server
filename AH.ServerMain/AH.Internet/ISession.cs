using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using SharpDX;

namespace AH.Internet
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(ISessionCallback))]
    public interface ISession
    {
        [OperationContract(IsOneWay = true)]
        // функция просто для проверки работоспособности сервера
        void DoWork();

        [OperationContract(IsOneWay = true)]
        // функция логинизации
        void login(string log, string Pass);

        [OperationContract(IsOneWay = true)]
        // функция регистрации
        void Registration(string login, string password);

        [OperationContract(IsOneWay = true)]
        // отправка сообщения в общий чат
        void EnterMessage(string message, int receiver);

        [OperationContract(IsOneWay = true)]
        // отправка сообщения в приватный чат
        void MessageToPlayer(string message, string receiver);

        [OperationContract(IsOneWay = true)]
        // изменить направление движения
        void SetDirection(Vector3 NewDirection);

        [OperationContract(IsOneWay = true)]
        // создать новую башню
        void CreateNewTower(Vector3 NewDirection, int TowerType);
    }

    [ServiceContract]
    public interface ISessionCallback
    {
        [OperationContract(IsOneWay = true)]
        // отправить системное сообщение пользователю
        void Print(string text);

        [OperationContract(IsOneWay = true)]
        // отправить сообщение пользователю от другого пользователя
        void MessageToMe(string message, string sender);
    }
}
