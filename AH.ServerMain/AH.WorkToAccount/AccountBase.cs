using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AH.WorkToAccount
{
    public class AccountBase
    {
        public AccountBase()
        {
        }

        protected bool onLine { set; get; }
        public string Login { set; get; }
        public string Password { set; get; }
        public int Type { set; get; }
    }
}
