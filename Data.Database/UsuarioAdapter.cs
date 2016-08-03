using System.Collections.Generic;
using System.Configuration;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;
using System;


namespace Data.Database
{
    public class UsuarioAdapter:Adapter
    {
        #region DatosEnMemoria
        // Esta región solo se usa en esta etapa donde los datos se mantienen en memoria.
        // Al modificar este proyecto para que acceda a la base de datos esta será eliminada
       // private static List<Usuario> _Usuarios;

       /* private static List<Usuario> Usuarios
        {
            get
            {
                if (_Usuarios == null)
                {
                    _Usuarios = new List<Usuario>();
                    Usuario usr;
                    usr = new Usuario();
                    usr.Id = 1;
                    usr.State = BusinessEntity.States.Unmodified;
                    usr.Nombre = "Casimiro";
                    usr.Apellido = "Cegado";
                    usr.NombreUsuario = "casicegado";
                    usr.Clave = "miro";
                    usr.Email = "casimirocegado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Business.Entities.Usuario();
                    usr.Id = 2;
                    usr.State = BusinessEntity.States.Unmodified;
                    usr.Nombre = "Armando Esteban";
                    usr.Apellido = "Quito";
                    usr.NombreUsuario = "aequito";
                    usr.Clave = "carpintero";
                    usr.Email = "armandoquito@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                    usr = new Business.Entities.Usuario();
                    usr.Id = 3;
                    usr.State = Business.Entities.BusinessEntity.States.Unmodified;
                    usr.Nombre = "Alan";
                    usr.Apellido = "Brado";
                    usr.NombreUsuario = "alanbrado";
                    usr.Clave = "abrete sesamo";
                    usr.Email = "alanbrado@gmail.com";
                    usr.Habilitado = true;
                    _Usuarios.Add(usr);

                }
                return _Usuarios;
            }
        }*/
        #endregion

        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM usuarios;", sqlConn);
                SqlDataReader reader = cmd.ExecuteReader();
                
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
                    usuarios.Add(currentUser);

                }
                reader.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
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

                SqlCommand cmd = new SqlCommand("SELECT * FROM usuarios WHERE id_usuario = @ID", sqlConn);
                cmd.Parameters.AddWithValue("@ID", Id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    currentUser.Id = (int)reader["id_usuario"];
                    currentUser.NombreUsuario = (string)reader["nombre_usuario"];
                    currentUser.Clave = (string)reader["clave"];
                    currentUser.Habilitado = (bool)reader["habilitado"];
                    currentUser.Nombre = (string)reader["nombre"];
                    currentUser.Apellido = (string)reader["apellido"];
                    currentUser.Email = (string)reader["email"];
                }
                reader.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar el usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return currentUser;
        }

        public void Delete(int Id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("DELETE FROM usuarios WHERE id_usuario = @ID", sqlConn);
                cmd.Parameters.AddWithValue("@ID", Id);
                cmd.ExecuteNonQuery();

            }
            catch(Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el usuarios", Ex);
                throw ExcepcionManejada;
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
                SqlCommand cmd = new SqlCommand("UPDATE usuarios SET nombre_usuario = @nombre_usuario, clave=@clave, habilitado=@habilitado, nombre=@nombre, apellido=@apellido, " +
                "email=@email WHERE id_usuario = @ID", sqlConn);
                cmd.Parameters.AddWithValue("@nombre_usuario", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@clave", usuario.Clave);
                cmd.Parameters.AddWithValue("@habilitado", usuario.Habilitado);
                cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@email", usuario.Email);
                cmd.Parameters.AddWithValue("@ID", usuario.Id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar el usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        protected void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO usuarios (nombre_usuario, clave, habilitado, nombre, apellido, email)" +
                    "VALUES (@nombre_usuario, @clave, @habilitado, @nombre, @apellido, @email) SELECT @@IDENTITY", sqlConn);
                cmd.Parameters.AddWithValue("@nombre_usuario", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@clave", usuario.Clave);
                cmd.Parameters.AddWithValue("@habilitado", usuario.Habilitado);
                cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@apellido", usuario.Apellido);
                cmd.Parameters.AddWithValue("@email", usuario.Email);
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al guardar el usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(Usuario usuario)
        {
            if (usuario.State == BusinessEntity.States.New)
            {
                this.Insert(usuario);
            }
            else if (usuario.State == BusinessEntity.States.Deleted)
            {
                this.Delete(usuario.Id);
            }
            else if (usuario.State == BusinessEntity.States.Modified)
            {
                this.Update(usuario);
            }
            else 
            {
                usuario.State = BusinessEntity.States.Unmodified; 
            }
        }
    }
}
