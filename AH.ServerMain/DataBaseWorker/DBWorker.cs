using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Npgsql;

namespace AH.DataBaseWorker
{

    public class DBWorker
    {

        protected NpgsqlConnection MainDBConnection { set; get; }

        public DBWorker()
        {
            // задаём строку подключения к бд
            MainDBConnection = new NpgsqlConnection("Server=127.0.0.1;Port=5432;User Id=postgres;"+
            "Password=postgres;Database=MainServer");

            // подключаемся к бд
            MainDBConnection.Open();
        }

        // добавить новый аккаунт в базу данных
        public bool WritheNewAccount(string Login, string Password, int Type)
        {
            // пытаемся добавить новую запись в таблицу аккаунтов
            try
            {
                NpgsqlCommand SqlCommandInsert = new NpgsqlCommand("INSERT INTO Accounts(" +
                    '"' + "Login" + '"' + ", " + '"' + "Password" + '"' + ", " + '"' + "Type" + '"' + ")" +
                    "VALUES ('" + Login + "', '" + Password + "', '" + Type + "')", MainDBConnection);
                SqlCommandInsert.ExecuteNonQuery();
                return true;
            }

            // в случае если выпала ошибка исключение не обрабатываем, но возвращаем сигнал о неудаче записи
            catch (Exception error)
            {
                return false;
            }
        }

        // получить все зарегестрированные аккаунты
        // в качестве основного результата вернётся, были ли они получены
        // через ref передадутся сами массивы с полями таблицы
        public bool GetAllAccount(ref List<string> Logins, ref List<string> Passwords, ref List<int> Types)
        {
            // задаём sql запрос
            NpgsqlCommand SqlCommandSelect = new NpgsqlCommand("SELECT * FROM Accounts", MainDBConnection);

            // выполняем его
            NpgsqlDataReader DataReader = SqlCommandSelect.ExecuteReader();

            // обрабатываем результат
            if (DataReader.HasRows)
            {
                foreach (DbDataRecord DataRecord in DataReader)
                {
                    Logins.Add((string)(DataRecord["Login"]));
                    Passwords.Add((string)(DataRecord["Password"]));
                    Types.Add((int)(DataRecord["Type"]));
                }
            }
            else
                return false;
            return true;
        }

        // ищем среди всех аккаунтов по логину
        public bool SearchForName(string Login)
        {
            // задаём sql запрос
            NpgsqlCommand SqlCommandSelect = new NpgsqlCommand("SELECT * FROM Accounts WHERE " + '"' + "Login" + 
                '"' + " = '" + Login + "'", MainDBConnection);
            // выполняем его
            NpgsqlDataReader DataReader = SqlCommandSelect.ExecuteReader();

            // обрабатываем результат
            if (DataReader.HasRows)
            {
                return true;
            }
            else
                return false;
        }

        // ищем среди всех аккаунтов по логину и паролю
        public bool SearchForLoginAndPassword(string Login, string Password)
        {
            // задаём sql запрос
            NpgsqlCommand SqlCommandSelect = new NpgsqlCommand("SELECT * FROM Accounts WHERE " + '"' + "Login" +
                '"' + " = '" + Login + "' AND " + '"' + "Password" + '"' + " = '" + Password + "'", MainDBConnection);
            // выполняем его
            NpgsqlDataReader DataReader = SqlCommandSelect.ExecuteReader();

            // обрабатываем результат
            if (DataReader.HasRows)
            {
                return true;
            }
            else
                return false;
        }
    }
}
