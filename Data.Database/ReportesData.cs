using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace Data.Database
{
    public class ReportesData : Adapter
    {

        public DataSet GetDatos()
        {
            DataSet ds = new DataSet();
            try
            {
                OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM cursos", MySqlConn);
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

    }
}
