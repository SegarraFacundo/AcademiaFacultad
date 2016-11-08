using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using MySql.Data.MySqlClient;
using Util.CustomException;
using Util;

namespace Data.Database
{
    class ComisionAdapter: Adapter
    {
        
        public List<Comision> GetAll()
        {
            List<Comision> listaComisiones = new List<Comision>();
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM comisiones", MySqlConn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Comision c = new Comision();
                    c.Id = (int)reader["id_comision"];
                    c.IdPlan = (int)reader["id_plan"];
                    c.Descripcion = (string)reader["desc_comision"];
                    c.AnioEspecialidad = (int)reader["anio_especialidad"];
                    listaComisiones.Add(c);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new NotFoundException("comision", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return listaComisiones;
        }
        public Comision GetOne(int id)
        {
            Comision c;
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM comisiones WHERE id_comision = @id", MySqlConn);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    c = new Comision();
                    c.Id = id;
                    c.IdPlan = (int)reader["id_plan"];
                    c.Descripcion = (string)reader["desc_comision"];
                    c.AnioEspecialidad = (int)reader["anio_especialidad"];
                    reader.Close();
                    return c;
                }
            }
            catch (Exception ex)
            {
                throw new NotFoundException("comision", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return null;
        }

        public void Insert(Comision c)
        {
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO comisiones (desc_comision) VALUES (@comision); SELECT @@IDENTITY;", MySqlConn);
                cmd.Parameters.AddWithValue("@comision", c.Descripcion);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new InsertException("comision", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(Comision c)
        {
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("UPDATE comisiones SET desc_comision = @comision WHERE id_comision = @idcomision", MySqlConn);
                cmd.Parameters.AddWithValue("@descripcion", c.Descripcion);
                cmd.Parameters.AddWithValue("@idcomision", c.Id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new UpdateException("comision", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Delete(int id)
        {
            try
            {
                this.OpenConnection();

                MySqlCommand cmd = new MySqlCommand("DELETE FROM comisiones WHERE id_comision = @id", MySqlConn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DeleteException("comision", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(Comision c)
        {

            if (c.State == TiposDatos.States.New)
            {
                this.Insert(c);
            }
            else if (c.State == TiposDatos.States.Modified)
            {
                this.Update(c);
            }
            else if (c.State == TiposDatos.States.Deleted)
            {
                this.Delete(c.Id);
            }
            else
            {
                c.State = TiposDatos.States.Unmodified;
            }

        }
    }
}


