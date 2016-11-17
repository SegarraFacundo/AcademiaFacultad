using System;
using System.Collections.Generic;
using Business.Entities;
using MySql.Data.MySqlClient;
using Util;
using Util.CustomException;
using System.Data;

namespace Data.Database
{
    public class AlumnoInscripcionAdapter : Adapter
    {
        public List<AlumnoInscripto> GetAll()
        {
            List<AlumnoInscripto> inscripciones = new List<AlumnoInscripto>();
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM alumnos_inscripciones", MySqlConn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AlumnoInscripto inscripcion = new AlumnoInscripto();
                    inscripcion.Id = (int)reader["id_inscripcion"];
                    inscripcion.IdAlumno = (int)reader["id_alumno"];
                    inscripcion.IdCurso = (int)reader["id_curso"];
                    inscripcion.Condicion = (string)reader["condicion"];
                    inscripcion.Nota = (int)reader["nota"];
                    inscripciones.Add(inscripcion);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new NotFoundException("inscripción", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return inscripciones;
        }

        public AlumnoInscripto GetOne(int ID)
        {
            AlumnoInscripto inscripcion;
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM alumnos_inscripciones WHERE id_inscripcion = @ID", MySqlConn);
                cmd.Parameters.AddWithValue("@ID", ID);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    inscripcion = new AlumnoInscripto();
                    inscripcion.Id = (int)reader["id_inscripcion"];
                    inscripcion.IdAlumno = (int)reader["id_alumno"];
                    inscripcion.IdCurso = (int)reader["id_curso"];
                    inscripcion.Condicion = (string)reader["condicion"];
                    inscripcion.Nota = (int)reader["nota"];
                    reader.Close();
                    return inscripcion;
                }
            }

            catch (Exception ex)
            {
                throw new NotFoundException("inscripción", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return null;
        }

        protected void Insert(AlumnoInscripto inscripcion)
        {
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO alumnos_inscripciones (id_alumno, id_curso, condicion, nota) " +
                "VALUES (@id_alumno, @id_curso, @condicion, @nota);", MySqlConn);
                cmd.Parameters.AddWithValue("@id_alumno", inscripcion.IdAlumno);
                cmd.Parameters.AddWithValue("@id_curso", inscripcion.IdCurso);
                cmd.Parameters.AddWithValue("@condicion", inscripcion.Condicion);
                cmd.Parameters.AddWithValue("@nota", inscripcion.Nota);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new InsertException("inscripción", ex);
            }
            finally
            {
                this.OpenConnection();
            }
        }

        protected void Update(AlumnoInscripto inscripcion)
        {
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("UPDATE alumnos_inscripciones SET id_alumno=@idAlumno, id_curso=@idCurso, condicion=@condicion, nota=@nota WHERE id_inscripcion=@id", MySqlConn);
                cmd.Parameters.AddWithValue("@id", inscripcion.Id);
                cmd.Parameters.AddWithValue("@idAlumno", inscripcion.IdAlumno);
                cmd.Parameters.AddWithValue("@idCurso", inscripcion.IdCurso);
                cmd.Parameters.AddWithValue("@condicion", inscripcion.Condicion);
                cmd.Parameters.AddWithValue("@nota", inscripcion.Nota);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new UpdateException("inscripción", ex);
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
                MySqlCommand cmd = new MySqlCommand("DELETE FROM alumnos_inscripciones WHERE id_inscripcion = @id", MySqlConn);
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DeleteException("inscripción", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(AlumnoInscripto inscripcion) {

            switch (inscripcion.State ) {
                case TiposDatos.States.New:
                    this.Insert(inscripcion);
                    break;
                case TiposDatos.States.Modified:
                    this.Update(inscripcion);
                    break;
                case TiposDatos.States.Deleted:
                    this.Delete(inscripcion.Id);
                    break;
                default:
                    inscripcion.State = TiposDatos.States.Unmodified;
                    break;
            }
        }

        public List<AlumnoInscripto> GetAllByIdAlumno(int IdAlumno)
        {
            List<AlumnoInscripto> inscripciones = new List<AlumnoInscripto>();
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM alumnos_inscripciones WHERE id_alumno = @ID", MySqlConn);
                cmd.Parameters.AddWithValue("@ID", IdAlumno);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AlumnoInscripto inscripto = new AlumnoInscripto();
                    inscripto.Id = (int)reader["id_inscripcion"];
                    inscripto.IdAlumno = (int)reader["id_alumno"];
                    inscripto.IdCurso = (int)reader["id_curso"];
                    inscripto.Condicion = (string)reader["condicion"];
                    inscripto.Nota = (int)reader["nota"];
                    inscripciones.Add(inscripto);
                }
                reader.Close();
            }

            catch (Exception ex)
            {
                throw new NotFoundException("inscripción", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return inscripciones;
        }

        public List<AlumnoInscripto> GetAllByIdCurso(int IdCurso)
        {
            List<AlumnoInscripto> inscripciones = new List<AlumnoInscripto>();
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM alumnos_inscripciones WHERE id_curso = @ID", MySqlConn);
                cmd.Parameters.AddWithValue("@ID", IdCurso);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AlumnoInscripto inscripto = new AlumnoInscripto();
                    inscripto.Id = (int)reader["id_inscripcion"];
                    inscripto.IdAlumno = (int)reader["id_alumno"];
                    inscripto.IdCurso = (int)reader["id_curso"];
                    inscripto.Condicion = (string)reader["condicion"];
                    inscripto.Nota = (int)reader["nota"];
                    inscripciones.Add(inscripto);
                }
                reader.Close();
            }

            catch (Exception ex)
            {
                throw new NotFoundException("inscripción", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return inscripciones;
        }
        public DataTable GetInscripto(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT  cursos.desc_curso, alumnos_inscripciones.id_inscripcion, alumnos_inscripciones.condicion " +
                                "FROM alumnos_inscripciones " +
                                "INNER JOIN cursos " +
                                    "ON alumnos_inscripciones.id_curso = cursos.id_curso " +
                                "WHERE condicion = 'inscripto' AND id_alumno = @id_alumno";

                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(query, MySqlConn);
                cmd.Parameters.AddWithValue("@id_alumno", id);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);               
            }

            catch (Exception ex)
            {
                throw new NotFoundException("inscripción", ex);
            }
            finally 
            {
                this.CloseConnection();
            }
            return dt;
        }
        public DataTable GetAlumnosCurso(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "SELECT  alumnos_inscripciones.id_inscripcion, alumnos_inscripciones.condicion, alumnos_inscripciones.nota, personas.nombre, personas.apellido, personas.legajo " +
                                "FROM alumnos_inscripciones " +
                                "INNER JOIN personas " +
                                    "ON alumnos_inscripciones.id_alumno = personas.id_persona " +
                                "WHERE tipo_persona = 'alumno' AND id_curso = @id_curso";

                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand(query, MySqlConn);
                cmd.Parameters.AddWithValue("@id_curso", id);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
            }

            catch (Exception ex)
            {
                throw new NotFoundException("inscripción", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return dt;
        }
        
    }
}