using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter
    {
        //private MySqlConnection MySqlConnection = new MySqlConnection("ConnectionString;");
        const string consKeyDefaultCnnString = "ConnStringLocal";

        public MySqlConnection MySqlConn;
        protected void OpenConnection()
        {
            var conString = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            MySqlConn = new MySqlConnection(conString);
            MySqlConn.Open();
        }

        protected void CloseConnection()
        {
            MySqlConn.Close();
            MySqlConn = null;
        }


        protected MySqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
