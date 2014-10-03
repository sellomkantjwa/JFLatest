using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JFLatest.Util
{
    public class AccountHelper
    {
        DBConnectionManager connectionManager = new DBConnectionManager();
        internal void registerEmployer(Models.RegisterEmployer model)
        {
            string email = model.email;
            string password = model.Password;
            MySqlCommand command = new MySqlCommand();
            command.CommandText = "INSERT INTO employer (email, password, address, name, contactNumber) VALUES (@email, @password, 'home', 'sello', '0799931634');";
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password);
            connectionManager.execute(command);
        }



        internal bool login(string email, string password, bool persistCookie)
        {

            if (verifyPassword(email, password))
            {
                return true;
            }
            return false;
        }

        internal bool login(Models.LoginModel model, bool persistCookie)
        {
            string email = model.email;
            string password = model.Password;
            if (verifyPassword(email, password))
            {
                return true;
            }
            return false;
        }

        private bool verifyPassword(string email, string password)
        {
            bool isCorrectPassword = false;

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM employer where email = @email && password=@password";
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password);
            List<Dictionary<string, object>> results;
            results = connectionManager.executeSelect(command);
            if (results != null && results.Count > 0)
            {
                isCorrectPassword = true;
            }
            return isCorrectPassword;
        }

        private bool userExists(string email)
        {
            bool userExists = false;

            MySqlCommand command = new MySqlCommand();
            command.CommandText = "SELECT * FROM employer where email = @email";
            command.Parameters.AddWithValue("@email", email);
            List<Dictionary<string, object>> results;
            results = connectionManager.executeSelect(command);

            if (results != null && results.Count > 0)
            {
                userExists = true;
            }

            return userExists;
        }
    }
}