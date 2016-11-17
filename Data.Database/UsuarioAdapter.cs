using System.Collections.Generic;
using System.Configuration;
using Business.Entities;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using Util;
using Util.CustomException;

namespace Data.Database
{
    public class UsuarioAdapter : Adapter
    {
        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM usuarios;", MySqlConn);
                MySqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    Usuario currentUser = new Usuario();
                    currentUser.Id = (int)reader["id_usuario"];
                    currentUser.NombreUsuario = (string)reader["nombre_usuario"];
                    currentUser.Clave = (string)reader["clave"];
                    currentUser.Habilitado = (bool)reader["habilitado"];
                    currentUser.Nombre = (string)reader["nombre"];
                    currentUser.Apellido = (string)reader["apellido"];
                    currentUser.Email = (string)reader["email"];
                    if (reader["id_persona"].Equals(DBNull.Value))
                    {
                        currentUser.IdPersona = 0;
                    }
                    else
                    {
                        currentUser.IdPersona = (int)reader["id_persona"];
                    }
                    usuarios.Add(currentUser);
                }
                reader.Close();

            }
            catch (Exception Ex)
            {
                throw new NotFoundException("usuario", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return usuarios;
            
        }

        public Usuario GetOne(int Id)
        {
            Usuario currentUser = new Usuario();

            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM usuarios WHERE id_usuario = @ID", MySqlConn);
                cmd.Parameters.AddWithValue("@ID", Id);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    currentUser.Id = (int)reader["id_usuario"];
                    currentUser.NombreUsuario = (string)reader["nombre_usuario"];
                    currentUser.Clave = (string)reader["clave"];
                    currentUser.Habilitado = (bool)reader["habilitado"];
                    currentUser.Nombre = (string)reader["nombre"];
                    currentUser.Apellido = (string)reader["apellido"];
                    currentUser.Email = (string)reader["email"];
                    if (reader["id_persona"].Equals(DBNull.Value))
                    {
                        currentUser.IdPersona = 0;
                    }
                    else
                    {
                        currentUser.IdPersona = (int)reader["id_persona"];
                    }
                    reader.Close();
                    return currentUser;

                }

            }
            catch (Exception ex)
            {
                throw new NotFoundException("usuario", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return null;
        }

        public void Delete(int Id)
        {
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM usuarios WHERE id_usuario = @ID", MySqlConn);
                cmd.Parameters.AddWithValue("@ID", Id);
                cmd.ExecuteNonQuery();

            }
            catch(Exception ex)
            {
                throw new DeleteException("usuario", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("UPDATE usuarios SET nombre_usuario = @nombre_usuario, clave=@clave, habilitado=@habilitado, nombre=@nombre, apellido=@apellido, " +
                "email=@email WHERE id_usuario = @ID", MySqlConn);
                cmd.Parameters.AddWithValue("@nombre_usuario", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@clave", usuario.Clave);
                cmd.Parameters.AddWithValue("@habilitado", usuario.Habilitado);
                cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@email", usuario.Email);
                cmd.Parameters.AddWithValue("@ID", usuario.Id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new UpdateException("usuario", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Usuario usuario, MySqlTransaction transaction = null)
        {

            string query = "INSERT INTO usuarios (nombre_usuario, clave, habilitado, nombre, apellido, email, cambia_clave, id_persona)" +
                    "VALUES (@nombre_usuario, @clave, @habilitado, @nombre, @apellido, @email, @cambia_clave, @id_persona); SELECT @@IDENTITY";

            try
            {
                MySqlCommand cmd;
                if (transaction == null)
                {
                    this.OpenConnection();
                    cmd = new MySqlCommand(query, MySqlConn);
                }
                else
                {
                    cmd = new MySqlCommand(query, transaction.Connection);
                }                 

                cmd.Parameters.AddWithValue("@nombre_usuario", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@clave", usuario.Clave);
                if (usuario.Habilitado) { cmd.Parameters.AddWithValue("@habilitado", 1); }
                else { cmd.Parameters.AddWithValue("@habilitado", 0); }
                cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@email", usuario.Email);
                if (usuario.CambiaClave) { cmd.Parameters.AddWithValue("@cambia_clave", 1); }
                else { cmd.Parameters.AddWithValue("@cambia_clave", 0); }
                if (usuario.IdPersona == 0) { cmd.Parameters.AddWithValue("@id_persona", DBNull.Value); }
                else { cmd.Parameters.AddWithValue("@id_persona", usuario.IdPersona); }
               
                usuario.Id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                throw new InsertException("usuario", ex);
            }
            finally
            {
                if (transaction == null)
                {
                    this.CloseConnection();

                }
            }
        }

        public void Save(Usuario usuario, MySqlTransaction transaction =null)
        {
            if (usuario.State == TiposDatos.States.New)
            {
                this.Insert(usuario, transaction);
            }
            else if (usuario.State == TiposDatos.States.Deleted)
            {
                this.Delete(usuario.Id);
            }
            else if (usuario.State == TiposDatos.States.Modified)
            {
                this.Update(usuario);
            }
            else 
            {
                usuario.State = TiposDatos.States.Unmodified; 
            }
        }

        public Usuario LogIn(string user, string pass)
        {
            Usuario u;
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM usuarios WHERE nombre_usuario = @user AND clave=@pass", MySqlConn);
                cmd.Parameters.AddWithValue("@user", user);
                cmd.Parameters.AddWithValue("@pass", pass);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    u = new Usuario();
                    u.Id = (int)reader["id_usuario"];
                    u.NombreUsuario = (string)reader["nombre_usuario"];
                    u.Clave = (string)reader["clave"];
                    u.Habilitado = (bool)reader["habilitado"];
                    u.Nombre = (string)reader["nombre"];
                    u.Apellido = (string)reader["apellido"];
                    u.Email = (string)reader["email"];
                    u.CambiaClave = (bool)reader["cambia_clave"];

                    if (!(reader["id_persona"].Equals(System.DBNull.Value)))
                    {
                        u.IdPersona = (int)reader["id_persona"];
                    }
                    else
                    {
                        u.IdPersona = 0;
                    }

                    reader.Close();
                    return u;
                }                               
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar el usuarios", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return null;
        }

    }
}
