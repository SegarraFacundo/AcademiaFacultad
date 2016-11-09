using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using MySql.Data.MySqlClient;
using Util.CustomException;

namespace Data.Database
{
    public class ModuloUsuarioAdapter:Adapter
    {
        public  ModuloUsuario getPermisosUsuario(int idUsuario)
        {
            ModuloUsuario moduloUsuario;

            try
            {
                this.OpenConnection();                
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM modulos_usuarios WHERE id_usuario = @idUsuario", MySqlConn);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {   
                    moduloUsuario = new ModuloUsuario();
                    moduloUsuario.Id = (int)reader["id_modulo_usuario"];
                    moduloUsuario.IdModulo = (int)reader["id_modulo"];
                    moduloUsuario.IdUsuario = idUsuario;
                    moduloUsuario.PermiteAlta = (bool)reader["alta"];
                    moduloUsuario.PermiteBaja = (bool)reader["baja"];
                    moduloUsuario.PermiteConsulta = (bool)reader["consulta"];
                    moduloUsuario.PermiteModificacion = (bool)reader["modificacion"];
                    reader.Close();
                    return moduloUsuario;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar los permisos: ", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return null;
        }
    }
}
