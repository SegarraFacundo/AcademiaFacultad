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
    public class AlumnoAdapter : PersonaAdapter
    {

        private List<Alumno> ListaAlumnos;

        public List<Alumno> GetAll()
        {
            ListaAlumnos = new List<Alumno>();

            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM personas WHERE tipo_persona = 'alumno'", MySqlConn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Alumno a = new Alumno();
                    a.Id = (int)reader["id_persona"];
                    a.Nombre = (string)reader["nombre"];
                    a.Apellido = (string)reader["apellido"];
                    a.Direccion = (string)reader["direccion"];
                    a.Email = (string)reader["email"];
                    a.Telefono = (string)reader["telefono"];
                    a.FechaNacimiento = (DateTime)reader["fecha_nac"];
                    a.Legajo = (int)reader["legajo"];
                    a.IdPlan = (int)reader["id_plan"];

                    ListaAlumnos.Add(a);
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
            return ListaAlumnos;
        }

        public Alumno GetOne(int ID)
        {
            Alumno a;

            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM personas WHERE id_persona = @ID AND tipo_persona = 'alumno'", MySqlConn);
                cmd.Parameters.AddWithValue("@ID", ID);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    a = new Alumno();
                    a.Id = (int)reader["id_persona"];
                    a.Nombre = (string)reader["nombre"];
                    a.Apellido = (string)reader["apellido"];
                    a.Direccion = (string)reader["direccion"];
                    a.Email = (string)reader["email"];
                    a.Telefono = (string)reader["telefono"];
                    a.FechaNacimiento = (DateTime)reader["fecha_nac"];
                    a.Legajo = (int)reader["legajo"];
                    a.IdPlan = (int)reader["id_plan"];
                    reader.Close();
                    return a;

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

        protected void Insert(Alumno a)
        {
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO personas (nombre, apellido, direccion, email, telefono, fecha_nac, legajo, id_plan, tipo_persona) " +
                "VALUES (@nombre, @apellido, @direccion, @email, @telefono, @fecha_nac, @legajo, @id_plan, 'alumno');", MySqlConn);
                cmd.Parameters.AddWithValue("@nombre", a.Nombre);
                cmd.Parameters.AddWithValue("@apellido", a.Apellido);
                cmd.Parameters.AddWithValue("@direccion", a.Direccion);
                cmd.Parameters.AddWithValue("@email", a.Email);
                cmd.Parameters.AddWithValue("@telefono", a.Telefono);
                cmd.Parameters.AddWithValue("@fecha_nac", a.FechaNacimiento.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@legajo", a.Legajo);
                cmd.Parameters.AddWithValue("@id_plan", a.IdPlan);
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

        protected void Update(Alumno a)
        {
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("UPDATE personas SET id_persona=@id_persona, nombre=@nombre, apellido=@apellido, direccion=@direccion, email=@email, telefono=@telefono, " +
                "fecha_nac=@fecha_nac, legajo=@legajo, id_plan=@id_plan WHERE id_persona=@id_persona AND tipo_persona='alumno'", MySqlConn);
                cmd.Parameters.AddWithValue("@id_persona", a.Id);
                cmd.Parameters.AddWithValue("@nombre", a.Nombre);
                cmd.Parameters.AddWithValue("@apellido", a.Apellido);
                cmd.Parameters.AddWithValue("@direccion", a.Direccion);
                cmd.Parameters.AddWithValue("@email", a.Email);
                cmd.Parameters.AddWithValue("@telefono", a.Telefono);
                cmd.Parameters.AddWithValue("@fecha_nac", a.FechaNacimiento.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@legajo", a.Legajo);
                cmd.Parameters.AddWithValue("@id_plan", a.IdPlan);

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
                MySqlCommand cmd = new MySqlCommand("DELETE FROM personas WHERE id_persona = @id_persona AND tipo_persona='alumno'", MySqlConn);
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

        public void Save(Alumno a)
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
