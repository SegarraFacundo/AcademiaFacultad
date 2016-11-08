using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Util.CustomException;
using Util;
using MySql.Data.MySqlClient;

namespace Data.Database
{
    public class MateriaAdapter : Adapter
    {

        public List<Materia> GetAll()
        {
            List<Materia> materias = new List<Materia>();
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM materias;", MySqlConn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Materia currentMateria = new Materia();
                    currentMateria.Id = (int)reader["id_materia"];
                    currentMateria.HsSemanales = (int)reader["horas_semanales"];
                    currentMateria.Descripcion = (string)reader["desc_materia"];
                    currentMateria.HsTotales = (int)reader["hs_totales"];
                    currentMateria.IdPlan = (int)reader["id_plan"];
                    materias.Add(currentMateria);
                }
                reader.Close();

            }
            catch (Exception Ex)
            {
                throw new NotFoundException("materia", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return materias;
        }
        public Materia GetOne(int Id)
        {
            Materia currentMateria;
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM materias WHERE id_materia = @ID", MySqlConn);
                cmd.Parameters.AddWithValue("@ID", Id);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    currentMateria = new Materia();
                    currentMateria.Id = (int)reader["id_plan"];
                    currentMateria.HsSemanales = (int)reader["horas_semanales"];
                    currentMateria.Descripcion = (string)reader["desc_materia"];
                    currentMateria.HsTotales = (int)reader["hs_totales"];
                    currentMateria.IdPlan = (int)reader["id_plan"];
                    reader.Close();
                    return currentMateria;
                }
            }
            catch (Exception ex)
            {
                throw new NotFoundException("materia", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return null;
        }
        public void Delete(int Id)
        {
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM materias WHERE id_materia = @ID", MySqlConn);
                cmd.Parameters.AddWithValue("@ID", Id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new DeleteException("materia", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Materia materia)
        {
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("UPDATE materias SET desc_materia = @desc_materia, horas_semanales = @horas_semanales, hs_totales = @hs_totales, " +
                "id_plan = @id_plan WHERE id_materia = @ID", MySqlConn);
                cmd.Parameters.AddWithValue("@ID", materia.Id);
                cmd.Parameters.AddWithValue("@desc_materia", materia.Descripcion);
                cmd.Parameters.AddWithValue("@horas_semanales", materia.HsSemanales);
                cmd.Parameters.AddWithValue("@hs_totales", materia.HsTotales);
                cmd.Parameters.AddWithValue("@id_plan", materia.IdPlan);
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new UpdateException("materia", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Materia materia, MySqlTransaction transaction = null)
        {

            MySqlCommand cmd;
            string query = "INSERT INTO materias (desc_materia, horas_semanales, hs_totales, id_plan)" +
                    "VALUES (@desc_materia, @horas_semanales, @hs_totales, @id_plan);";
            try
            {
                if (transaction == null)
                {
                    //Esto es en caso de que querramos hacer un INSERT solo por una materia, sin planes
                    this.OpenConnection();
                    cmd = new MySqlCommand(query, MySqlConn);                    
                }
                else
                {
                    //Aca es por si grabamos un Plan primero, como hay que hacerlo en una transaccion lo trabajamos asi
                    cmd = new MySqlCommand(query, transaction.Connection);
                }                
                cmd.Parameters.AddWithValue("@desc_materia", materia.Descripcion);
                cmd.Parameters.AddWithValue("@horas_semanales", materia.HsSemanales);
                cmd.Parameters.AddWithValue("@hs_totales", materia.HsTotales);
                cmd.Parameters.AddWithValue("@id_plan", materia.IdPlan);
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new InsertException("materia", Ex);
            }
            finally
            {
                if (transaction == null) { this.CloseConnection(); }
            }
        }

        public void Save(Materia materia, MySqlTransaction transaction = null)
        {
            if (materia.State == TiposDatos.States.New)
            {
                this.Insert(materia, transaction);
            }
            else if (materia.State == TiposDatos.States.Deleted)
            {
                this.Delete(materia.Id);
            }
            else if (materia.State == TiposDatos.States.Modified)
            {
                this.Update(materia);
            }
            else
            {
                materia.State = TiposDatos.States.Unmodified;
            }
        }
    }
}

