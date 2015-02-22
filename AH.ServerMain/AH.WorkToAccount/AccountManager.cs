using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using AH.DataBaseWorker;

namespace AH.WorkToAccount
{
    public class AccountManager
    {
        public List<AccountBase> AccountOnline;
        public DBWorker WorkerToAccounts;

        public AccountManager()
        {
            AccountOnline = new List<AccountBase>();
            WorkerToAccounts = new DBWorker();
        }
        
        // проверка существует ли аккаунт с данным логином
        public bool IsUsernameAlready(string EnteringLogin)
        {
            bool YourNameIsAlready = SearchToAllForName(EnteringLogin);
            return YourNameIsAlready;
        }

        // попытка аккаунта залогиниться
        public bool AccountIsLogon(AccountBase EntAccount)
        {
            // проверка существует ли аккаунт с данным логином и паролем
            bool YouExist = SearchToAll(EntAccount);
            // если существует, то добавляем его с список залогинившихся
            // и возвращаем флажок об успешной логинизации
            if (YouExist == true)
            {
                AccountOnline.Add(EntAccount);
                return true;
            }
            // иначе возвращаем флажок об отсутствии такого аккаунта
            else return false;
        }

        // выход аккаунта из игры
        public void AccountLeftTheGame(AccountBase LeftAccount)
        {
            AccountOnline.Remove(LeftAccount);
        }

        // поиск среди всех залогинившихся аккаунтов
        public bool FiendToPlayersOnline(AccountBase FiendAccount)
        {
            int YouOnline = 0;
            YouOnline = AccountOnline.FindIndex(i => i.Login == FiendAccount.Login);
            if (YouOnline != -1) return true;
            else return false;
        }

        // поиск среди всех существующих аккаунтов по логину и паролю
        public bool SearchToAll(AccountBase SearchAccount)
        {
            return WorkerToAccounts.SearchForLoginAndPassword(SearchAccount.Login, SearchAccount.Password);
        }

        // поиск среди всех существующих аккаунтов по логину
        public bool SearchToAllForName(string SearchLogin)
        {
            return WorkerToAccounts.SearchForName(SearchLogin);
        }

        // регистрация нового аккаунта
        public bool CreateNewAccount(string Login, string Password, int Type)
        {
            return WorkerToAccounts.WritheNewAccount(Login, Password, Type);
        }
    }
}
