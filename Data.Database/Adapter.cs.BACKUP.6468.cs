using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
<<<<<<< HEAD
using System.Configuration;
=======
>>>>>>> AcademiaFacultad/Facu

namespace Data.Database
{
    public class Adapter
    {
        //private SqlConnection sqlConnection = new SqlConnection("ConnectionString;");
<<<<<<< HEAD
        const string consKeyDefaultCnnString = "ConnStringLocal";

        public SqlConnection sqlConn;
        protected void OpenConnection()
        {
            var conString = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            sqlConn = new SqlConnection(conString);
            sqlConn.Open();
=======

        protected void OpenConnection()
        {
            throw new Exception("Metodo no implementado");
>>>>>>> AcademiaFacultad/Facu
        }

        protected void CloseConnection()
        {
<<<<<<< HEAD
            sqlConn.Close();
            sqlConn = null;
        }


=======
            throw new Exception("Metodo no implementado");
        }

>>>>>>> AcademiaFacultad/Facu
        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
