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
    public class CursoAdapter : Adapter
    {
        public List<Curso> GetAll()
        {
            List<Curso> ListaCursos = new List<Curso>();
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM cursos", MySqlConn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Curso curso = new Curso();
                    curso.Descripcion = (string)reader["desc_curso"];
                    curso.AnioCalendario = (int)reader["anio_calendario"];
                    curso.Cupo = (int)reader["cupo"];
                    curso.IdComision = (int)reader["id_comision"];
                    curso.IdMateria = (int)reader["id_materia"];
                    curso.Id = (int)reader["id_curso"];
                    ListaCursos.Add(curso);
                }
                reader.Close();
                
            }
            catch (Exception ex)
            {
                throw new NotFoundException("curso", ex);
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
                string query = "SELECT cursos.*, COUNT(alumnos_inscripciones.id_inscripcion) AS CantidadInscripciones " +
                                "FROM cursos " +
                                "INNER JOIN alumnos_inscripciones " +
                                    "ON cursos.id_curso = alumnos_inscripciones.id_curso " +
                                "WHERE cursos.id_curso = @id_curso";
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(query, MySqlConn);
                cmd.Parameters.AddWithValue("@id_curso", Id);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    curso.Descripcion = (string)reader["desc_curso"];
                    curso.AnioCalendario = (int)reader["anio_calendario"];
                    curso.Cupo = (int)reader["cupo"];
                    curso.IdComision = (int)reader["id_comision"];
                    curso.IdMateria = (int)reader["id_materia"];
                    curso.Id = (int)reader["id_curso"];
                    curso.CupoDisponible = Convert.ToInt32(reader["CantidadInscripciones"]);
                    
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new NotFoundException("curso", ex);
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
                MySqlCommand cmd = new MySqlCommand("DELETE FROM cursos WHERE id_curso=@id_curso", MySqlConn);
                cmd.Parameters.AddWithValue("@id_curso", Id);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new DeleteException("curso", ex);
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
                MySqlCommand cmd = new MySqlCommand("UPDATE cursos SET desc_curso = @desc_curso, anio_calendario=@anio_calendario, cupo=@cupo, id_comision=@id_comision, id_materia=@id_materia " +
                "WHERE id_curso= @id_curso", MySqlConn);
                cmd.Parameters.AddWithValue("@id_curso", curso.Id);
                cmd.Parameters.AddWithValue("@anio_calendario", curso.AnioCalendario);
                cmd.Parameters.AddWithValue("@cupo", curso.Cupo);
                cmd.Parameters.AddWithValue("@id_comision", curso.IdComision);
                cmd.Parameters.AddWithValue("@id_materia", curso.IdMateria);
                cmd.Parameters.AddWithValue("@desc_curso", curso.Descripcion);

                cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                throw new UpdateException("curso", ex);
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
                MySqlCommand cmd = new MySqlCommand("INSERT INTO cursos (desc_curso, anio_calendario, cupo, id_comision, id_materia) VALUES " + 
                    "(@desc_curso, @anio_calendario, @cupo,@id_comision, @id_materia); " +
                    " SELECT @@IDENTITY", MySqlConn);
                cmd.Parameters.AddWithValue("@anio_calendario", curso.AnioCalendario);
                cmd.Parameters.AddWithValue("@cupo", curso.Cupo);
                cmd.Parameters.AddWithValue("@id_comision", curso.IdComision);
                cmd.Parameters.AddWithValue("@id_materia", curso.IdMateria);
                cmd.Parameters.AddWithValue("@desc_curso", curso.Descripcion);
                cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                throw new InsertException("curso", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Curso curso)
        {
            if (curso.State == TiposDatos.States.New)
            {
                this.Insert(curso);
            }
            else if(curso.State == TiposDatos.States.Modified)
            {
                this.Update(curso);
            }
            else if (curso.State == TiposDatos.States.Deleted)
            {
                this.Delete(curso.Id);
            }
            else
            {
                curso.State = TiposDatos.States.Unmodified;
            }
        }

    }
}
