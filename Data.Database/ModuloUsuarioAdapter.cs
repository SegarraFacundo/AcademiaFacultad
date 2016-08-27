using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;

namespace Data.Database
{
    public class ModuloUsuarioAdapter:Adapter
    {
        public  List<ModuloUsuario> getPermisosUsuario(int idUsuario)
        {
            List<ModuloUsuario> listaModulosUsuario = new List<ModuloUsuario>();
            try
            {
                this.OpenConnection();                
                SqlCommand cmd = new SqlCommand("SELECT * FROM modulos_usuarios WHERE idUsuario = @idUsuario", sqlConn);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ModuloUsuario moduloUsuario = new ModuloUsuario();
                    moduloUsuario.Id = (int)reader["id_modulo_usuario"];
                    moduloUsuario.IdModulo = (int)reader["id_modulo"];
                    moduloUsuario.IdUsuario = idUsuario;
                    moduloUsuario.PermiteAlta = (bool)reader["alta"];
                    moduloUsuario.PermiteBaja = (bool)reader["baja"];
                    moduloUsuario.PermiteConsulta = (bool)reader["consulta"];
                    moduloUsuario.PermiteModificacion = (bool)reader["modificacion"];
                    listaModulosUsuario.Add(moduloUsuario);
                }
                reader.Close(); 
            }
            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al buscar los permisos: ", ex);
                throw excepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return listaModulosUsuario;
        }
    }
}
