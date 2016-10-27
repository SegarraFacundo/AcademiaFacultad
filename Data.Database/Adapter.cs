using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Configuration;
using Util.CustomException;

namespace Data.Database
{
    public abstract class Adapter
    {
        //private MySqlConnection MySqlConnection = new MySqlConnection("ConnectionString;");
        const string consKeyDefaultCnnString = "ConnStringLocal";

        public MySqlConnection MySqlConn;

        protected void OpenConnection()
        {
            try
            {
                var conString = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
                this.MySqlConn = new MySqlConnection(conString);
                this.MySqlConn.Open();
            }
            catch (MySqlException ex)
            {
                throw new CustomException(ex);
            }
            catch (Exception ex)
            {
                throw new CustomException(ex);
            }
        }

        protected void CloseConnection()
        {
            try
            {
                MySqlConn.Close();
            }
            catch ( Exception ex )
            {
                throw new CustomException(ex);
            }
            finally
            {
                MySqlConn = null;
            }           
        }

        protected MySqlDataReader ExecuteReader(String commandText)
        {
            throw new CustomException();
        }
    }
}
