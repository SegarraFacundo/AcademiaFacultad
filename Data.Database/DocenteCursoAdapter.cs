using System;
using System.Collections.Generic;
using Business.Entities;
using MySql.Data.MySqlClient;
using Util;
using Util.CustomException;

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
            catch (Exception ex)
            {
                throw new NotFoundException("dictado", ex);
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

            catch (Exception ex)
            {
                throw new NotFoundException("dictado", ex);
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
            catch (Exception ex)
            {
                throw new InsertException("dictado", ex);
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
            catch (Exception ex)
            {
                throw new UpdateException("dictado", ex);
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
            catch (Exception ex)
            {
                throw new DeleteException("dictado", ex);
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

            catch (Exception ex)
            {
                throw new NotFoundException("dictado", ex);
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

            catch (Exception ex)
            {
                throw new NotFoundException("dictado", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return dictados;
        }

        private int GetIdCargo(TiposDatos.TiposCargos tipoCargo) {

            int idCargo;

            switch (tipoCargo)
            {
                case TiposDatos.TiposCargos.ProfesorTeoria:
                    idCargo = 1;
                    break;
                case TiposDatos.TiposCargos.ProfesorPractica:
                    idCargo = 2;
                    break;
                case TiposDatos.TiposCargos.AyudanteCatedra:
                    idCargo = 3;
                    break;
                default:
                    throw new NotFoundException("cargo");
            }

            return idCargo;
        }

        private TiposDatos.TiposCargos GetTipoCargo(int idCargo) {

            TiposDatos.TiposCargos tipoCargo;

            switch (idCargo)
            {
                case 1:
                    tipoCargo = TiposDatos.TiposCargos.ProfesorTeoria;
                    break;
                case 2:
                    tipoCargo = TiposDatos.TiposCargos.ProfesorPractica;
                    break;
                case 3:
                    tipoCargo = TiposDatos.TiposCargos.AyudanteCatedra;
                    break;
                default:
                    throw new NotFoundException("cargo");
            }

            return tipoCargo;
        }
    }
}