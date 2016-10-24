using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

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
                    else
                    {
                        legajo = 0;
                    }
                }
                reader.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar el legajo de " + tipoPersona, Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return legajo;

        }
    }
}
