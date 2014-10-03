using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using MySql.Web;


namespace JFLatest.Util
{


    public class DBConnectionManager
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnectionManager()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            server = "localhost";
            database = "jobfair";
            uid = "sello";
            password = "Ningiza";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }



        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:

                        break;

                    case 1045:

                        break;
                }
                return false;
            }
        }


        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                string message = ex.ToString();
                return false;
            }
        }


        public void InsertRow()
        {
            string myInsertQuery = "INSERT INTO Employer (email, address, password, name, contactNumber) VALUES ('giza182@gmail', '111 joburg', '123456789', 'sello', '0113332256')";
            MySqlCommand myCommand = new MySqlCommand(myInsertQuery);
            myCommand.Connection = connection;
            myCommand.ExecuteNonQuery();
            myCommand.Connection.Close();
        }


        public void Insert()
        {
            string query = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        public void execute(MySqlCommand command)
        {
            //open connection
            if (this.OpenConnection() == true)
            {
                command.Connection = connection;
                //Execute command
                command.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Update statement
        public void Update()
        {
            string query = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete()
        {
            string query = "DELETE FROM tableinfo WHERE name='John Smith'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }



        internal List<Dictionary<string, object>> executeSelect(MySqlCommand command)
        {

            //open connection
            MySqlDataReader resultReader = null;
            List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();

            if (this.OpenConnection() == true)
            {
                command.Connection = connection;

                //Execute command
                resultReader = command.ExecuteReader();

                try
                {
                    while (resultReader.Read())
                    {
                        Dictionary<string, object> row = new Dictionary<string, object>();
                        for (int i = 0; i < resultReader.FieldCount; i++)
                        {
                            row.Add(resultReader.GetName(i), resultReader.GetValue(i));
                        }
                        results.Add(row);
                    }
                }
                finally
                {
                    resultReader.Close();
                }

                //close connection
                this.CloseConnection();

            }
            return results;


        }
    }


}