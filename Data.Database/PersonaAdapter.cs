using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Util.CustomException;

namespace Data.Database
{
    public abstract class PersonaAdapter : Adapter
    {
        public int obtenerUltimoLegajo(string tipoPersona)
        {
            int legajo = 0;

            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT MAX(legajo) AS legajo FROM personas WHERE tipo_persona=@tipoPersona", MySqlConn);
                cmd.Parameters.AddWithValue("@tipoPersona", tipoPersona);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (!(reader["legajo"].Equals(DBNull.Value)))
                    {
                        legajo = (int)reader["legajo"];
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new NotFoundException("legajo, tipo: " + tipoPersona, ex);
            }
            finally
            {
                this.CloseConnection();
            }

            return legajo;

        }
    }
}
