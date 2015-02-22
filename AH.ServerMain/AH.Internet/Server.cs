using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Description;
using AH.WorkToAccount;
using SharpDX;
using AH.Core;

namespace AH.Internet
{
    public static class Server
    {
        static AdressatManager AdressatManagerThisServer;
        static AccountManager AllAccountToThisServer;
        static CoreServer MainCoreServer;
        public static void Open()
        {
            string command;
            AdressatManagerThisServer = new AdressatManager();
            AllAccountToThisServer = new AccountManager();
            
            using (System.ServiceModel.ServiceHost host = new System.ServiceModel.ServiceHost(typeof(Session)))
            {
                host.Open();

                Console.WriteLine("Service running.");
                Console.WriteLine("Endpoints:");

                foreach (ServiceEndpoint se in host.Description.Endpoints)
                    Console.WriteLine(se.Address.ToString());

                while (true)
                {
                    command = Console.ReadLine();

                    if (command == "print")
                    {
                        MessageToAll("print", null);
                    }
                }

                host.Close();
            }
        }

        // отправка сообщения для всех
        public static void MessageToAll(string Message, Session sender)
        {
            // имя отправителя
            string NameSender;

            // если сессия отправителя не пустая, то получаем имя отправителя
            if (sender != null)
            {
                NameSender = AdressatManagerThisServer.SearchNameAccountInSession(sender);
            }

            // иначе это сообщения от сервера
            else
            {
                NameSender = "server";
            }
            for (int i = 0; i < AdressatManagerThisServer.AllAdressat.Count(); i++)
            {
                AdressatManagerThisServer.AllAdressat[i].CollbackThisPlayer.MessageToMe(Message, NameSender);
            }
        }

        // отправка сообщения конкретному игроку
        public static void MessageToPlayer(string Mesage, string receiver, Session MySession)
        {
            // получаем колбэк пользователя которому отправляют сообщение по его имени
            ISessionCallback CallbackReceiver = AdressatManagerThisServer.SearchCallbackInNameAccount(receiver);

            // получаем имя отправителя по его сессии
            string NameSender = AdressatManagerThisServer.SearchNameAccountInSession(MySession);

            // если колбэк получателя удалось получить, значит отправляем ему сообщение
            // и копию самому отправителю
            if (CallbackReceiver != null)
            {
                MySession.Callback.MessageToMe(Mesage, NameSender);
                CallbackReceiver.MessageToMe(Mesage, NameSender);
            }
            // иначе выводим сообщение об ошибке
            else
            {
                MySession.Callback.MessageToMe("sorry, but the user with that name is not found", "server");
            }
        }

        public static void Registration(string login, string password, Session SetSes)
        {
            // заводим новый аккаунт и заполняем его данными
            AccountBase NewAccount = new AccountBase();
            NewAccount.Login = login;
            NewAccount.Password = password;
            NewAccount.Type = 1;

            // если аккаунт с таким именем уже находится в сети выводим ошибку
            if (AllAccountToThisServer.IsUsernameAlready(NewAccount.Login))
            {
                SetSes.Callback.Print("sorry, this username already exists");
            }
            else
            {
                // добавляем аккаунт в базу данных
                AllAccountToThisServer.CreateNewAccount(NewAccount.Login, NewAccount.Password, NewAccount.Type);

                // создаём новый адресат и отправляем сообщение об успешном завершении регистрации
                Adressat temp = new Adressat(SetSes, NewAccount, SetSes.Callback, 
                    AdressatManagerThisServer.AllAdressat.Count() + 1);
                AdressatManagerThisServer.AllAdressat.Add(temp);
                SetSes.Callback.Print("congratulations " + login + " Your account has been successfully created");
            }
        }

        public static void SetAdressat(Session SetSes, string SetLog, string SetPass, ISessionCallback SetCall)
        {
            // заводим новый аккаунт и заполняем его данными
            AccountBase LoginingPlayer = new AccountBase();
            LoginingPlayer.Login = SetLog;
            LoginingPlayer.Password = SetPass;

            // если аккаунт с такими логином и паролем существует
            if (AllAccountToThisServer.AccountIsLogon(LoginingPlayer))
            {
                // добавляем его в список залогинившихся и добавляем ему соответствующий адресат
                // в список адресатов
                AllAccountToThisServer.AccountOnline.Add(LoginingPlayer);
                Adressat temp = new Adressat(SetSes, LoginingPlayer, SetCall,
                    AdressatManagerThisServer.AllAdressat.Count() + 1);
                AdressatManagerThisServer.AllAdressat.Add(temp);

                // отправляем сообщение об успешной логинизации
                SetSes.Callback.Print("Hello " + SetLog + " . Welcom to Angry Hamsters");
            }
            // иначе отправляем сообщение об ошибке
            else
            {
                SetSes.Callback.Print("sorry, invalid login or password");
            }
        }

        // установить герою игрока направление движения
        public static int SetDirectionPlayer(Vector3 NewDirection, Session MySession)
        {
            int Id = AdressatManagerThisServer.SearchIdInSession(MySession);
            // если герой был найден и найдено его Id присваиваем направление иначе возвращаем признак неудачи
            if (Id != -1)
                MainCoreServer.SetDirectionPlayer(NewDirection, Id);
            else
                return 0;
            return 1;
        }
    }
}
