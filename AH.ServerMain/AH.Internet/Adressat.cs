using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AH.WorkToAccount;

namespace AH.Internet
{
    // класс для управления подключениями и обратной связью
    public class Adressat
    {
        // сессия подключившегося
        public Session SessionThisPlayer { set; get; } 
        // аккаунт подключившегося
        public AccountBase AccountThisPlayer { set; get; }
        // колбэк для обратной связи
        public ISessionCallback CollbackThisPlayer { set; get; }
        // нынешний ид подключившегося среди всего списка подключившихся
        public int IdThisPlayer { set; get; }

        public Adressat(Session getss, AccountBase getac, ISessionCallback getcb, int getid)
        {
            SessionThisPlayer = getss;
            AccountThisPlayer = getac;
            CollbackThisPlayer = getcb;
            IdThisPlayer = getid;
        }
    }
}
