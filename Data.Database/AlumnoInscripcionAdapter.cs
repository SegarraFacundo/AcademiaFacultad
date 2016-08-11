﻿using System;
using System.Collections.Generic;
using Business.Entities;
using System.Data.SqlClient;

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
                SqlCommand cmd = new SqlCommand("SELECT * FROM alumnos_inscripciones", sqlConn);
                SqlDataReader reader = cmd.ExecuteReader();
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
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al buscar inscripciones: ", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return inscripciones;
        }

        public AlumnoInscripto GetOne(int ID)
        {
            AlumnoInscripto inscripcion = new AlumnoInscripto();
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM alumnos_inscripciones WHERE id_inscripcion = @ID", sqlConn);
                cmd.Parameters.AddWithValue("@ID", ID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    inscripcion.Id = (int)reader["id_inscripcion"];
                    inscripcion.IdAlumno = (int)reader["id_alumno"];
                    inscripcion.IdCurso = (int)reader["id_curso"];
                    inscripcion.Condicion = (string)reader["condicion"];
                    inscripcion.Nota = (int)reader["nota"];
                }
                reader.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al buscar la Persona: ", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return inscripcion;
        }

        protected void Insert(AlumnoInscripto inscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO alumnos_inscripciones (id_inscripciones, id_alumno, id_curso, condicion, nota) " +
                "VALUES (@id, @aidAlumno, @idCurso, @condicion, @nota) SELECT @@IDENTITY;", sqlConn);
                cmd.Parameters.AddWithValue("@id", inscripcion.Id);
                cmd.Parameters.AddWithValue("@idAlumno", inscripcion.IdAlumno);
                cmd.Parameters.AddWithValue("@idCurso", inscripcion.IdCurso);
                cmd.Parameters.AddWithValue("@condicion", inscripcion.Condicion);
                cmd.Parameters.AddWithValue("@nota", inscripcion.Nota);
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al guardar inscripción: ", Ex);
                throw ExcepcionManejada;
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
                SqlCommand cmd = new SqlCommand("UPDATE alumnos_inscripciones SET id_alumno=@idAlumno, id_curso=@idCurso, condicion=@condicion, nota=@nota WHERE id_inscripcion=@id", sqlConn);
                cmd.Parameters.AddWithValue("@id", inscripcion.Id);
                cmd.Parameters.AddWithValue("@idAlumno", inscripcion.IdAlumno);
                cmd.Parameters.AddWithValue("@idCurso", inscripcion.IdCurso);
                cmd.Parameters.AddWithValue("@condicion", inscripcion.Condicion);
                cmd.Parameters.AddWithValue("@nota", inscripcion.Nota);
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar inscripción:", Ex);
                throw ExcepcionManejada;
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
                SqlCommand cmd = new SqlCommand("DELETE FROM alumnos_inscripciones WHERE id_inscripcion = @id", sqlConn);
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar inscripción: ", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(AlumnoInscripto inscripcion) {

            switch (inscripcion.State ) {
                case BusinessEntity.States.New:
                    this.Insert(inscripcion);
                    break;
                case BusinessEntity.States.Modified:
                    this.Update(inscripcion);
                    break;
                case BusinessEntity.States.Deleted:
                    this.Delete(inscripcion.Id);
                    break;
                default:
                    inscripcion.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }

        public List<AlumnoInscripto> GetAllByIdAlumno(int IdAlumno)
        {
            List<AlumnoInscripto> inscripciones = new List<AlumnoInscripto>();
            try
            {
                this.OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM alumnos_inscripciones WHERE id_alumno = @ID", sqlConn);
                cmd.Parameters.AddWithValue("@ID", IdAlumno);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
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

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al buscar inscripciones por alumno: ", Ex);
                throw ExcepcionManejada;
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM alumnos_inscripciones WHERE id_curso = @ID", sqlConn);
                cmd.Parameters.AddWithValue("@ID", IdCurso);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
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

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al buscar inscripciones por curso: ", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return inscripciones;
        }
    }
}