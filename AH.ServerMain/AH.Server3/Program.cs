using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Description;
using AH.Internet;
using AH.Core;

namespace AH.Server3
{
    class Program
    {
        static void Main(string[] args)
        {
            CoreServer CoreThisServer = new CoreServer();
            Server.Open();
        }
    }
}
