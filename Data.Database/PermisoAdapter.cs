using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using MySql.Data.MySqlClient;
using Util.CustomException;
using Util;

namespace Data.Database
{
    public class PermisoAdapter : Adapter
    {
        public List<Permiso> GetPorIdUsuario(int idUsuario)
        {
            List<Permiso> permisos = new List<Permiso>();
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(
                    "SELECT " +
                        "ms.id_modulo_usuario AS id, ms.id_modulo, ms.id_usuario, ms.alta, ms.baja, ms.modificacion, ms.consulta, " +
                        "m.id_modulo, m.desc_modulo, m.ejecuta " + 
                    "FROM " +
                        "modulos_usuarios AS ms " +
                    "INNER JOIN " +
                        "modulos AS m " +
                    "ON " + 
                        "ms.id_modulo = m.id_modulo " + 
                    "WHERE " +
                        "ms.id_usuario = @id_usuario"
                    , MySqlConn);
                cmd.Parameters.AddWithValue("@id_usuario", idUsuario);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Permiso p = new Permiso();
                    p.Id = (int)reader["id"];
                    p.Alta = (bool)reader["alta"];
                    p.Baja = (bool)reader["baja"];
                    p.Modificacion = (bool)reader["modificacion"];
                    p.Consulta = (bool)reader["consulta"];
                    p.Descripcion = (string)reader["desc_modulo"];
                    p.Ejecuta = (string)reader["ejecuta"];
                    if (p.Alta)
                    {
                        permisos.Add(p);
                    }
                    else if(p.Baja)
                    {
                        permisos.Add(p);
                    } 
                    else if(p.Consulta)
                    {
                        permisos.Add(p);
                    }
                    else if(p.Modificacion)
                    {   
                        permisos.Add(p);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new NotFoundException("permisos", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return permisos;
        }
    }
}
