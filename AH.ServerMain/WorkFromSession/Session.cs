using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
namespace WorkFromSession
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class Session : ISession
    {
        public void login(string log, string Pass)
        {
           Server.SetAdressat(this, log, Pass, this.Callback);
        }

        public void RewriteBD(int key)
        {
            if (key == 404)
            {
                Server.RewriteBD(this);
            }
        }

        public void Registration(string login, string password)
        {
            Server.Registration(login, password, this);
        }

        public void EnterMessage(string message, int receiver)
        {
            if (receiver == 1)
            {
                Server.MessageToAll(message, this);
                Console.WriteLine(message);
            }
        }

        public void MessageToPlayer(string message, string receiver)
        {
            Server.MessageToPlayer(message, receiver, this);
        }

        public void DoWork()
        {
            Console.WriteLine("DoWork...");
        }

        public ISessionCallback Callback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<ISessionCallback>();
            }
        }

        public void GetPlayer()
        {
            Server.GetHeroPosotoin(this);
        }

        public void GetInfoHero(int id)
        {
            Server.GetAllInfo(this, id);
        }
    }
}
