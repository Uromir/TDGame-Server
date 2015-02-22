using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AH.WorkToAccount;
using SharpDX;

namespace AH.Internet
{
    class AdressatManager
    {
        // список всех адресатов
        public List<Adressat> AllAdressat;

        public AdressatManager()
        {
            AllAdressat = new List<Adressat>();
        }

        // вернуть колбэк по сессии
        public ISessionCallback SearchCallbackInSession(Session searching)
        {
            for (int i = 0; i < AllAdressat.Count(); i++)
            {
                if (AllAdressat[i].SessionThisPlayer == searching)
                {
                    return AllAdressat[i].CollbackThisPlayer;
                }
            }
            return null;
        }

        // вернуть колбэк по имени аккаунта
        public ISessionCallback SearchCallbackInNameAccount(string searching)
        {
            for (int i = 0; i < AllAdressat.Count(); i++)
            {
                if (AllAdressat[i].AccountThisPlayer.Login == searching)
                {
                    return AllAdressat[i].CollbackThisPlayer;
                }
            }
            return null;
        }

        // вернуть имя аккаунта по сессии
        public string SearchNameAccountInSession(Session searching)
        {
            for (int i = 0; i < AllAdressat.Count(); i++)
            {
                if(AllAdressat[i].SessionThisPlayer == searching)
                {
                    return AllAdressat[i].AccountThisPlayer.Login;
                }
            }
            return null;
        }

        // вернуть весь аккаунт по сессии
        public AccountBase SearchAccountInSession(Session searching)
        {
            for (int i = 0; i < AllAdressat.Count(); i++)
            {
                if (AllAdressat[i].SessionThisPlayer == searching)
                {
                    return AllAdressat[i].AccountThisPlayer;
                }
            }
            return null;
        }

        // вернуть ид по сессии
        public int SearchIdInSession(Session searching)
        {
            for (int i = 0; i < AllAdressat.Count(); i++)
            {
                if (AllAdressat[i].SessionThisPlayer == searching)
                {
                    return AllAdressat[i].IdThisPlayer;
                }
            }
            return -1;
        }
    }
}
