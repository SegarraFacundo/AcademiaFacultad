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
            Plan currentPlan;

            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM planes WHERE id_plan = @ID", MySqlConn);
                cmd.Parameters.AddWithValue("@ID", Id);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    currentPlan = new Plan();
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

            MySqlTransaction transaction = null;


            try
            {
                this.OpenConnection();
                transaction = MySqlConn.BeginTransaction();

                //borramos los cursos
                CursoAdapter ca = new CursoAdapter();


                //borramos las materias
                MateriaAdapter ma = new MateriaAdapter();
                ma.DeleteMateriasPlan(Id, transaction);


                MySqlCommand cmd = new MySqlCommand("DELETE FROM planes WHERE id_plan = @ID", MySqlConn);
                cmd.Parameters.AddWithValue("@ID", Id);
                cmd.ExecuteNonQuery();


            }
            catch (Exception Ex)
            {
                transaction.Rollback();
                throw new DeleteException("plan", Ex);
            }

            try
            {
                transaction.Commit();
             }
            catch (Exception Ex)
            {
                transaction.Rollback();
                throw new DeleteException("Error al guardar los cambios", Ex);
            }
            finally
            {
                transaction.Dispose();
                CloseConnection();
            };

        }

        protected void Update(Plan plan)
        {
            MySqlTransaction transaction = null;

            try
            {

                //Para hacerlo mas simple, borramos las materias que tenia antes el plan e insertamos las que va a tener ahora
                
                
                this.OpenConnection();
                transaction = MySqlConn.BeginTransaction();


                MateriaAdapter ma = new MateriaAdapter();
                ma.DeleteMateriasPlan(plan.Id, transaction);
                foreach (Materia m in plan.ListaMaterias)
                {
                    m.IdPlan = plan.Id;
                    MateriaAdapter materiaData = new MateriaAdapter();
                    materiaData.Save(m, transaction);
                }


                MySqlCommand cmd = new MySqlCommand("UPDATE planes SET desc_plan = @desc_plan, id_especialidad = @id_especialidad WHERE id_plan = @ID", transaction.Connection);
                cmd.Parameters.AddWithValue("@desc_plan", plan.Descripcion);
                cmd.Parameters.AddWithValue("@id_especialidad", plan.IdEspecialidad);
                cmd.Parameters.AddWithValue("@ID", plan.Id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                transaction.Rollback();
                throw new UpdateException("plan", Ex);                
            }

            try
            {
                transaction.Commit();
            }
            catch (Exception Ex)
            {
                transaction.Rollback();
                throw new UpdateException("plan", Ex);    
            }
            finally
            {
                transaction.Dispose();
                this.CloseConnection();
            }
        }

        protected void Insert(Plan plan)
        {
            MySqlTransaction transaction = null;
            //Guardamos el plan
            try
            {   
                this.OpenConnection();
                transaction = MySqlConn.BeginTransaction();

                MySqlCommand cmd = new MySqlCommand("INSERT INTO planes (desc_plan, id_especialidad)" +
                    "VALUES (@desc_plan, @id_especialidad);  SELECT @@IDENTITY AS ID", transaction.Connection);
                cmd.Parameters.AddWithValue("@desc_plan", plan.Descripcion);
                cmd.Parameters.AddWithValue("@id_especialidad", plan.IdEspecialidad);             
                //Recuperamos el ID para ponerlo en la materia
                plan.Id = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                //Guardamos las materias
                foreach (Materia m in plan.ListaMaterias)
                {
                    m.IdPlan = plan.Id;
                    MateriaAdapter materiaData = new MateriaAdapter();
                    materiaData.Save(m, transaction);
                }
            }
            catch (Exception Ex)
            {
                transaction.Rollback();
                throw new InsertException("plan", Ex);
            }

            try
            {
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Exception handledException = new Exception("Error al guardar los cambios:", ex);
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                transaction.Dispose();
                CloseConnection();
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
