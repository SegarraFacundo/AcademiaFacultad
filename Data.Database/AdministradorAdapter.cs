using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using MySql.Data.MySqlClient;
using Util;
using Util.CustomException;

namespace Data.Database
{
    public class AdministradorAdapter : PersonaAdapter
    {

        private List<Administrador> listaAdministradores;

        public List<Administrador> GetAll()
        {
            this.listaAdministradores = new List<Administrador>();

            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM personas WHERE tipo_persona = 'admin'", MySqlConn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Administrador a = new Administrador();
                    a.Id = (int)reader["id_persona"];
                    a.Nombre = (string)reader["nombre"];
                    a.Apellido = (string)reader["apellido"];
                    a.Direccion = (string)reader["direccion"];
                    a.Email = (string)reader["email"];
                    a.Telefono = (string)reader["telefono"];
                    a.FechaNacimiento = (DateTime)reader["fecha_nac"];
                    a.Legajo = (int)reader["legajo"];

                    this.listaAdministradores.Add(a);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new NotFoundException("administrador", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return this.listaAdministradores;
        }

        public Administrador GetOne(int ID)
        {
            Administrador a;

            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM personas WHERE id_persona = @ID AND tipo_persona = 'admin'", MySqlConn);
                cmd.Parameters.AddWithValue("@ID", ID);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {   a = new Administrador();
                    a.Id = (int)reader["id_persona"];
                    a.Nombre = (string)reader["nombre"];
                    a.Apellido = (string)reader["apellido"];
                    a.Direccion = (string)reader["direccion"];
                    a.Email = (string)reader["email"];
                    a.Telefono = (string)reader["telefono"];
                    a.FechaNacimiento = (DateTime)reader["fecha_nac"];
                    a.Legajo = (int)reader["legajo"];

                    reader.Close();
                    return a;
                }
            }
            catch (Exception ex)
            {
                throw new NotFoundException("administrador", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return null;
        }

        protected void Insert(Administrador a)
        {
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO personas (nombre, apellido, direccion, email, telefono, fecha_nac, legajo, id_plan, tipo_persona) " +
                "VALUES (@nombre, @apellido, @direccion, @email, @telefono, @fecha_nac, @legajo, @id_plan, 'admin');", MySqlConn);
                cmd.Parameters.AddWithValue("@nombre", a.Nombre);
                cmd.Parameters.AddWithValue("@apellido", a.Apellido);
                cmd.Parameters.AddWithValue("@direccion", a.Direccion);
                cmd.Parameters.AddWithValue("@email", a.Email);
                cmd.Parameters.AddWithValue("@telefono", a.Telefono);
                cmd.Parameters.AddWithValue("@fecha_nac", a.FechaNacimiento.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@legajo", a.Legajo);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new InsertException("administrador", ex);
            }
            finally
            {
                this.OpenConnection();
            }
        }

        protected void Update(Administrador a)
        {
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("UPDATE personas SET id_persona=@id_persona, nombre=@nombre, apellido=@apellido, direccion=@direccion, email=@email, telefono=@telefono, " +
                "fecha_nac=@fecha_nac, legajo=@legajo, id_plan=@id_plan WHERE id_persona=@id_persona AND tipo_persona='admin'", MySqlConn);
                cmd.Parameters.AddWithValue("@id_persona", a.Id);
                cmd.Parameters.AddWithValue("@nombre", a.Nombre);
                cmd.Parameters.AddWithValue("@apellido", a.Apellido);
                cmd.Parameters.AddWithValue("@direccion", a.Direccion);
                cmd.Parameters.AddWithValue("@email", a.Email);
                cmd.Parameters.AddWithValue("@telefono", a.Telefono);
                cmd.Parameters.AddWithValue("@fecha_nac", a.FechaNacimiento.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@legajo", a.Legajo);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new UpdateException("administrador", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM personas WHERE id_persona = @id_persona AND tipo_persona='admin'", MySqlConn);
                cmd.Parameters.AddWithValue("@id_persona", ID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DeleteException("administrador", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Administrador a)
        {
            if (a.State == TiposDatos.States.New)
            {
                this.Insert(a);
            }
            else if (a.State == TiposDatos.States.Modified)
            {
                this.Update(a);
            }
            else if (a.State == TiposDatos.States.Deleted)
            {
                this.Delete(a.Id);
            }
            else
            {
                a.State = TiposDatos.States.Unmodified;
            }
        }


    }
}