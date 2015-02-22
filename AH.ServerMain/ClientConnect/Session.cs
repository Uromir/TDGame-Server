using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace AH.ClientConnect
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class Session : ISession
    {
        public void login(string log, string Pass)
        {

        }

        public void DoWork()
        {
            Console.WriteLine("DoWork...");
            //Callback.Print(string.Format("hello {0}", 0));
            for (int i = 0; i < 1000; i++)
            {
                System.Threading.Thread.Sleep(1000);
                Callback.Print(string.Format("hello {0}", i));
            }
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
