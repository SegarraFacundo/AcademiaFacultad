using System.Collections.Generic;
using System.Configuration;
using Business.Entities;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using Util;
using Util.CustomException;

namespace Data.Database
{
    public class PlanAdapter : Adapter
    {
        public List<Plan> GetAll()
        {
            List<Plan> planes = new List<Plan>();
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM planes;", MySqlConn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Plan currentPlan = new Plan();
                    currentPlan.Id = (int)reader["id_plan"];
                    currentPlan.IdEspecialidad = (int)reader["id_especialidad"];
                    currentPlan.Descripcion = (string)reader["desc_plan"];
                    planes.Add(currentPlan);
                }
                reader.Close();

            }
            catch (Exception Ex)
            {
                throw new NotFoundException("plan", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return planes;

        }

        public Plan GetOne(int Id)
        {
            Plan currentPlan = new Plan();

            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM planes WHERE id_plan = @ID", MySqlConn);
                cmd.Parameters.AddWithValue("@ID", Id);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    currentPlan.Id = (int)reader["id_plan"];
                    currentPlan.IdEspecialidad = (int)reader["id_especialidad"];
                    currentPlan.Descripcion = (string)reader["desc_plan"];
                    reader.Close();
                    return currentPlan;

                }

            }
            catch (Exception ex)
            {
                throw new NotFoundException("plan", ex);
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
                MySqlCommand cmd = new MySqlCommand("DELETE FROM planes WHERE id_plan = @ID", MySqlConn);
                cmd.Parameters.AddWithValue("@ID", Id);
                cmd.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                throw new DeleteException("plan", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Plan plan)
        {
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("UPDATE planes SET desc_plan = @desc_plan, id_especialidad = @id_especialidad WHERE id_plan = @ID", MySqlConn);
                cmd.Parameters.AddWithValue("@desc_plan", plan.Descripcion);
                cmd.Parameters.AddWithValue("@id_especialidad", plan.IdEspecialidad);
                cmd.Parameters.AddWithValue("@ID", plan.Id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new UpdateException("plan", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Plan plan)
        {
            try
            {
                this.OpenConnection();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO planes (desc_plan, id_especialidad)" +
                    "VALUES ( @desc_plan, @id_especialidad) SELECT @@IDENTITY", MySqlConn);

                cmd.Parameters.AddWithValue("@desc_plan", plan.Descripcion);
                cmd.Parameters.AddWithValue("@id_especialidad", plan.IdEspecialidad);
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                throw new InsertException("plan", Ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Plan plan)
        {
            if (plan.State == TiposDatos.States.New)
            {
                this.Insert(plan);
            }
            else if (plan.State == TiposDatos.States.Deleted)
            {
                this.Delete(plan.Id);
            }
            else if (plan.State == TiposDatos.States.Modified)
            {
                this.Update(plan);
            }
            else
            {
                plan.State = TiposDatos.States.Unmodified;
            }
        }

        public List<Plan> GetByEspecialidad(int idEspecialidad)
        {
            List<Plan> planes = new List<Plan>();
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM planes WHERE id_especialidad = @idEspecialidad;", MySqlConn);
                cmd.Parameters.AddWithValue("@idEspecialidad", idEspecialidad);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Plan currentPlan = new Plan();
                    currentPlan.Id = (int)reader["id_plan"];
                    currentPlan.IdEspecialidad = (int)reader["id_especialidad"];
                    currentPlan.Descripcion = (string)reader["desc_plan"];
                    planes.Add(currentPlan);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw new NotFoundException("planes por la especialidad", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return planes;

        }

    }
}
