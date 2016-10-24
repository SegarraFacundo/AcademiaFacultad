using System;
using System.Collections.Generic;
using Business.Entities;
using MySql.Data.MySqlClient;
using Util;

namespace Data.Database
{
    public class DocenteCursoAdapter : Adapter
    {
        public List<DocenteCurso> GetAll()
        {
            List<DocenteCurso> dictados = new List<DocenteCurso>();
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM docentes_cursos", MySqlConn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DocenteCurso dictado = new DocenteCurso();
                    dictado.Id = (int)reader["id_dictado"];
                    dictado.IdCurso = (int)reader["id_curso"];
                    dictado.IdDocente = (int)reader["id_docente"];
                    int idCargo = (int)reader["cargo"];
                    dictado.Cargo = this.GetTipoCargo(idCargo);
                    dictados.Add(dictado);
                }
                reader.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al buscar dictados: ", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return dictados;
        }

        public DocenteCurso GetOne(int ID)
        {
            DocenteCurso dictado = new DocenteCurso();
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM docentes_cursos WHERE id_dictado = @ID", MySqlConn);
                cmd.Parameters.AddWithValue("@ID", ID);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    dictado.Id = (int)reader["id_dictado"];
                    dictado.IdCurso = (int)reader["id_curso"];
                    dictado.IdDocente = (int)reader["id_docente"];
                    int idCargo = (int)reader["cargo"];
                    dictado.Cargo = this.GetTipoCargo(idCargo);
                }
                reader.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al buscar dictado: ", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return dictado;
        }

        protected void Insert(DocenteCurso dictado)
        {
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO docentes_cursos (id_dictado, id_curso, id_docente, cargo) " +
                "VALUES (@id, @aidCurso, @idDocente, @cargo) SELECT @@IDENTITY;", MySqlConn);
                cmd.Parameters.AddWithValue("@id", dictado.Id);
                cmd.Parameters.AddWithValue("@idCursos", dictado.IdCurso);
                cmd.Parameters.AddWithValue("@idDocente", dictado.IdDocente);
                cmd.Parameters.AddWithValue("@cargo", this.GetIdCargo(dictado.Cargo));
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al guardar dictado: ", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.OpenConnection();
            }
        }

        protected void Update(DocenteCurso dictado)
        {
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("UPDATE docentes_cursos SET id_curso=@idCurso, id_docente=@idDocente, cargo=@cargo WHERE id_dictado=@id", MySqlConn);
                cmd.Parameters.AddWithValue("@id", dictado.Id);
                cmd.Parameters.AddWithValue("@idCurso", dictado.IdCurso);
                cmd.Parameters.AddWithValue("@idDocente", dictado.IdDocente);
                cmd.Parameters.AddWithValue("@cargo", this.GetIdCargo(dictado.Cargo));
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar dictado:", Ex);
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
                MySqlCommand cmd = new MySqlCommand("DELETE FROM docentes_cursos WHERE id_dictado = @id", MySqlConn);
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar dictado: ", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(DocenteCurso dictado)
        {

            switch (dictado.State)
            {
                case TiposDatos.States.New:
                    this.Insert(dictado);
                    break;
                case TiposDatos.States.Modified:
                    this.Update(dictado);
                    break;
                case TiposDatos.States.Deleted:
                    this.Delete(dictado.Id);
                    break;
                default:
                    dictado.State = TiposDatos.States.Unmodified;
                    break;
            }
        }

        public List<DocenteCurso> GetAllByIdDocente(int idDocente)
        {
            List<DocenteCurso> dictados = new List<DocenteCurso>();
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM docentes_cursos WHERE id_docente = @ID", MySqlConn);
                cmd.Parameters.AddWithValue("@ID", idDocente);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    DocenteCurso dictado = new DocenteCurso();
                    dictado.Id = (int)reader["id_dictado"];
                    dictado.IdCurso = (int)reader["id_curso"];
                    dictado.IdDocente = (int)reader["id_docente"];
                    dictado.Cargo = this.GetTipoCargo((int)reader["cargo"]);
                    dictados.Add(dictado);
                }
                reader.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al buscar dictados por docente: ", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return dictados;
        }

        public List<DocenteCurso> GetAllByIdCurso(int idCurso)
        {
            List<DocenteCurso> dictados = new List<DocenteCurso>();
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM docentes_cursos WHERE id_curso = @ID", MySqlConn);
                cmd.Parameters.AddWithValue("@ID", idCurso);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    DocenteCurso dictado = new DocenteCurso();
                    dictado.Id = (int)reader["id_dictado"];
                    dictado.IdCurso = (int)reader["id_curso"];
                    dictado.IdDocente = (int)reader["id_docente"];
                    dictado.Cargo = this.GetTipoCargo((int)reader["cargo"]);
                    dictados.Add(dictado);
                }
                reader.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al buscar dictados por curso: ", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return dictados;
        }

        private int GetIdCargo(DocenteCurso.TiposCargos tipoCargo) {

            int idCargo;

            switch (tipoCargo)
            {
                case DocenteCurso.TiposCargos.ProfesorTeoria:
                    idCargo = 1;
                    break;
                case DocenteCurso.TiposCargos.ProfesorPractica:
                    idCargo = 2;
                    break;
                case DocenteCurso.TiposCargos.AyudanteCatedra:
                    idCargo = 3;
                    break;
                default:
                    Exception ExcepcionManejada = new Exception("Error al obtener id de cargo.");
                    throw ExcepcionManejada;
            }

            return idCargo;
        }

        private DocenteCurso.TiposCargos GetTipoCargo(int idCargo) {

            DocenteCurso.TiposCargos tipoCargo;

            switch (idCargo)
            {
                case 1:
                    tipoCargo = DocenteCurso.TiposCargos.ProfesorTeoria;
                    break;
                case 2:
                    tipoCargo = DocenteCurso.TiposCargos.ProfesorPractica;
                    break;
                case 3:
                    tipoCargo = DocenteCurso.TiposCargos.AyudanteCatedra;
                    break;
                default:
                    Exception ExcepcionManejada = new Exception("Error al obtener tipo de cargo");
                    throw ExcepcionManejada;
            }

            return tipoCargo;
        }
    }
}