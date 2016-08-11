using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;

namespace Data.Database
{
    public class CursoAdapter : Adapter
    {
        public List<Curso> GetAll()
        {
            List<Curso> ListaCursos = new List<Curso>();
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM cursos", sqlConn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Curso curso = new Curso();
                    curso.AnioCalendario = (int)reader["anio_calendario"];
                    curso.Cupo = (int)reader["cupo"];
                    curso.IdComision = (int)reader["id_comision"];
                    curso.IdMateria = (int)reader["id_materia"];
                    curso.Id = (int)reader["id_curso"];
                    ListaCursos.Add(curso);
                }
                reader.Close();
                
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la Lista de usuarios: ", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return ListaCursos;
        }

        public Curso GetOne(int Id)
        {
            Curso curso = new Curso();
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM cursos WHERE id_curso = @id_curso", sqlConn);
                cmd.Parameters.AddWithValue("@id_curso", Id);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    curso.AnioCalendario = (int)reader["anio_calendario"];
                    curso.Cupo = (int)reader["cupo"];
                    curso.IdComision = (int)reader["id_comision"];
                    curso.IdMateria = (int)reader["id_materia"];
                    curso.Id = (int)reader["id_curso"];
                }
                reader.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar el curso: ", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return curso;
        }

        public void Delete(int Id)
        {
            Curso curso = new Curso();
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("DELETE FROM cursos WHERE id_curso=@id_curso", sqlConn);
                cmd.Parameters.AddWithValue("@id_curso", Id);
                cmd.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el curso: ", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        protected void Update(Curso curso)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("UPDATE cursos SET anio_calendario=@anio_calendario, cupo=@cupo, id_comision=@id_comision, id_materia=@id_materia " +
                "WHERE id_curso= @id_curso", sqlConn);
                cmd.Parameters.AddWithValue("@id_curso", curso.Id);
                cmd.Parameters.AddWithValue("@anio_calendario", curso.AnioCalendario);
                cmd.Parameters.AddWithValue("@cupo", curso.Cupo);
                cmd.Parameters.AddWithValue("@id_comision", curso.IdComision);
                cmd.Parameters.AddWithValue("@id_materia", curso.IdMateria);
                cmd.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar el curso: ", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(Curso curso)
        {

            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO cursos (anio_calendario, cupo, id_comision, id_materia) VALUES (@anio_calendario, @cupo,@id_comision, @id_materia) " +
                    " SELECT @@IDENTITY", sqlConn);
                cmd.Parameters.AddWithValue("@anio_calendario", curso.AnioCalendario);
                cmd.Parameters.AddWithValue("@cupo", curso.Cupo);
                cmd.Parameters.AddWithValue("@id_comision", curso.IdComision);
                cmd.Parameters.AddWithValue("@id_materia", curso.IdMateria);
                cmd.ExecuteNonQuery();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al guardar curso: ", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Curso curso)
        {
            if (curso.State == BusinessEntity.States.New)
            {
                this.Insert(curso);
            }
            else if(curso.State == BusinessEntity.States.Modified)
            {
                this.Update(curso);
            }
            else if (curso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(curso.Id);
            }
            else
            {
                curso.State = BusinessEntity.States.Unmodified;
            }
        }

    }
}
