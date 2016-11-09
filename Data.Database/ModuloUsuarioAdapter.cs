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
    public class ModuloUsuarioAdapter:Adapter
    {
        public List<ModuloUsuario> GetAll()
        {
            List<ModuloUsuario> listaModulosUsuarios = new List<ModuloUsuario>();
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM modulos_usuarios", MySqlConn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ModuloUsuario mu = new ModuloUsuario();
                    mu.Id = (int)reader["id_modulo_usuario"];
                    mu.IdModulo = (int)reader["id_modulo"];
                    mu.IdUsuario = (int)reader["id_usuario"];
                    mu.PermiteAlta = (bool)reader["alta"];
                    mu.PermiteBaja = (bool)reader["baja"];
                    mu.PermiteModificacion = (bool)reader["modificacion"];
                    mu.PermiteConsulta = (bool)reader["consulta"];
                    listaModulosUsuarios.Add(mu);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new NotFoundException("modulo_usuario", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return listaModulosUsuarios;
        }
        public ModuloUsuario GetOne(int id)
        {
            ModuloUsuario mu;
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM modulos_usuarios WHERE id_modulo_usuario = @id", MySqlConn);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    mu = new ModuloUsuario();
                    mu.Id = id;
                    mu.IdModulo = (int)reader["id_modulo"];
                    mu.IdUsuario = (int)reader["id_usuario"];
                    mu.PermiteAlta = (bool)reader["alta"];
                    mu.PermiteBaja = (bool)reader["baja"];
                    mu.PermiteModificacion = (bool)reader["modificacion"];
                    mu.PermiteConsulta = (bool)reader["consulta"];
                    reader.Close();
                    return mu;
                }
            }
            catch (Exception ex)
            {
                throw new NotFoundException("modulo_usuario", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return null;
        }
        public void Insert(ModuloUsuario mu)
        {
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO modulos_usuarios (id_modulo, id_usuario, alta, baja, modificacion, consulta) VALUES (@idModulo, @idUsuario, @alta, @baja, @modificacion, @consulta); SELECT @@IDENTITY;", MySqlConn);
                cmd.Parameters.AddWithValue("@idModulo", mu.IdModulo);
                cmd.Parameters.AddWithValue("@idUsuario", mu.IdUsuario);
                cmd.Parameters.AddWithValue("@alta", mu.PermiteAlta);
                cmd.Parameters.AddWithValue("@baja", mu.PermiteBaja);
                cmd.Parameters.AddWithValue("@modificacion", mu.PermiteModificacion);
                cmd.Parameters.AddWithValue("@consulta", mu.PermiteConsulta);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new InsertException("modulo_usuario", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Update(ModuloUsuario mu)
        {
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("UPDATE modulos_usuarios SET " +
                    "id_modulo = @idModule, id_usuario = @idUsuario, alta = @alta, baja = @baja, modificacion = @modificacion, consulta = @consulta " +
                    "WHERE id_modulo_usuario = @id", MySqlConn);
                cmd.Parameters.AddWithValue("@id", mu.Id);
                cmd.Parameters.AddWithValue("@idModulo", mu.IdModulo);
                cmd.Parameters.AddWithValue("@idUsuario", mu.IdUsuario);
                cmd.Parameters.AddWithValue("@alta", mu.PermiteAlta);
                cmd.Parameters.AddWithValue("@baja", mu.PermiteBaja);
                cmd.Parameters.AddWithValue("@modificacion", mu.PermiteModificacion);
                cmd.Parameters.AddWithValue("@consulta", mu.PermiteConsulta);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new UpdateException("modulo_usuario", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Delete(int id)
        {
            try
            {
                this.OpenConnection();

                MySqlCommand cmd = new MySqlCommand("DELETE FROM modulos_usuarios WHERE id_modulo_usuario = @id", MySqlConn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DeleteException("modulo_usuario", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(ModuloUsuario mu)
        {

            if (mu.State == TiposDatos.States.New)
            {
                this.Insert(mu);
            }
            else if (mu.State == TiposDatos.States.Modified)
            {
                this.Update(mu);
            }
            else if (mu.State == TiposDatos.States.Deleted)
            {
                this.Delete(mu.Id);
            }
            else
            {
                mu.State = TiposDatos.States.Unmodified;
            }

        }
    }
}
