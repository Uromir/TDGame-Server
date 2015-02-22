using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using SharpDX;
namespace AH.Internet
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class Session : ISession
    {
        // функция логинизации
        public void login(string log, string Pass)
        {
           Server.SetAdressat(this, log, Pass, this.Callback);
        }

        // функция регистрации
        public void Registration(string login, string password)
        {
            Server.Registration(login, password, this);
        }

        // отправка сообщения в общий чат
        public void EnterMessage(string message, int receiver)
        {
            if (receiver == 1)
            {
                Server.MessageToAll(message, this);
                Console.WriteLine(message);
            }
        }

        // отправка сообщения в приватный чат
        public void MessageToPlayer(string message, string receiver)
        {
            Server.MessageToPlayer(message, receiver, this);
        }

        // функция просто для проверки работоспособности сервера
        public void DoWork()
        {
            Console.WriteLine("DoWork...");
        }

        // изменить направление движения
        public void SetDirection(Vector3 NewDirection)
        {
            Server.SetDirectionPlayer(NewDirection, this);
        }

        public ISessionCallback Callback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<ISessionCallback>();
            }
        }
    }
}
