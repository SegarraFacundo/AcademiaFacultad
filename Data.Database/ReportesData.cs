using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using Business.Entities;

namespace Data.Database
{
    public class ReportesData : Adapter
    {

        public dsCursos GetDatos()
        {
            try
            {
                OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM cursos", MySqlConn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                using (dsCursos dsCursos = new dsCursos())
                {
                    da.Fill(dsCursos, "cursos");
                    return dsCursos;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
