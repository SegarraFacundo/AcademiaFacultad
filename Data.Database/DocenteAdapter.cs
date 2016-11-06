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
    public class DocenteAdapter : Adapter
    {       
        private List<Docente> ListaDocente;

        public List<Docente> GetAll()
        {
            ListaDocente = new List<Docente>();

            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM personas WHERE tipo_persona = 'docente'", MySqlConn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Docente d = new Docente();
                    d.Id = (int)reader["id_persona"];
                    d.Nombre = (string)reader["nombre"];
                    d.Apellido = (string)reader["apellido"];
                    d.Direccion = (string)reader["direccion"];
                    d.Email = (string)reader["email"];
                    d.Telefono = (string)reader["telefono"];
                    d.FechaNacimiento = (DateTime)reader["fecha_nac"];
                    d.Legajo = (int)reader["legajo"];
                    ListaDocente.Add(d);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new NotFoundException("alumno", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return ListaDocente;
        }

        public Docente GetOne(int ID)
        {
            Docente d;

            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM personas WHERE id_persona = @ID AND tipo_persona = 'docente'", MySqlConn);
                cmd.Parameters.AddWithValue("@ID", ID);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    d = new Docente();
                    d.Id = (int)reader["id_persona"];
                    d.Nombre = (string)reader["nombre"];
                    d.Apellido = (string)reader["apellido"];
                    d.Direccion = (string)reader["direccion"];
                    d.Email = (string)reader["email"];
                    d.Telefono = (string)reader["telefono"];
                    d.FechaNacimiento = (DateTime)reader["fecha_nac"];
                    d.Legajo = (int)reader["legajo"];
                    reader.Close();
                    return d;                    
                }
            }
            catch (Exception ex)
            {
                throw new NotFoundException("alumno", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return null;
        }

        protected void Insert(Docente d)
        {
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO personas (nombre, apellido, direccion, email, telefono, fecha_nac, legajo, tipo_persona) " +
                "VALUES (@nombre, @apellido, @direccion, @email, @telefono, @fecha_nac, @legajo, 'docente');", MySqlConn);
                cmd.Parameters.AddWithValue("@nombre", d.Nombre);
                cmd.Parameters.AddWithValue("@apellido", d.Apellido);
                cmd.Parameters.AddWithValue("@direccion", d.Direccion);
                cmd.Parameters.AddWithValue("@email", d.Email);
                cmd.Parameters.AddWithValue("@telefono", d.Telefono);
                cmd.Parameters.AddWithValue("@fecha_nac", d.FechaNacimiento.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@legajo", d.Legajo);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new InsertException("alumno", ex);
            }
            finally
            {
                this.OpenConnection();
            }
        }

        protected void Update(Docente d)
        {
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("UPDATE personas SET id_persona=@id_persona, nombre=@nombre, apellido=@apellido, direccion=@direccion, email=@email, telefono=@telefono, " +
                "fecha_nac=@fecha_nac, legajo=@legajo WHERE id_persona=@id_persona AND tipo_persona='docente'", MySqlConn);
                cmd.Parameters.AddWithValue("@id_persona", d.Id);
                cmd.Parameters.AddWithValue("@nombre", d.Nombre);
                cmd.Parameters.AddWithValue("@apellido", d.Apellido);
                cmd.Parameters.AddWithValue("@direccion", d.Direccion);
                cmd.Parameters.AddWithValue("@email", d.Email);
                cmd.Parameters.AddWithValue("@telefono", d.Telefono);
                cmd.Parameters.AddWithValue("@fecha_nac", d.FechaNacimiento.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@legajo", d.Legajo);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new UpdateException("alumno", ex);
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
                MySqlCommand cmd = new MySqlCommand("DELETE FROM personas WHERE id_persona = @id_persona AND tipo_persona='docente'", MySqlConn);
                cmd.Parameters.AddWithValue("@id_persona", ID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DeleteException("alumno", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Docente d)
        {
            if (d.State == TiposDatos.States.New)
            {
                this.Insert(d);
            }
            else if (d.State == TiposDatos.States.Modified)
            {
                this.Update(d);
            }
            else if (d.State == TiposDatos.States.Deleted)
            {
                this.Delete(d.Id);
            }
            else
            {
                d.State = TiposDatos.States.Unmodified;
            }
        }

    }
}

