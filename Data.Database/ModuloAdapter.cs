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
    public class ModuloAdapter : Adapter
    {

        public List<Modulo> GetAll()
        {
            List<Modulo> listaModulos = new List<Modulo>();
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM modulos", MySqlConn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Modulo m = new Modulo();
                    m.Id = (int)reader["id_modulo"];
                    m.Descripcion = (string)reader["desc_modulo"];
                    listaModulos.Add(m);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw new NotFoundException("modulo", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return listaModulos;
        }
        public Modulo GetOne(int id)
        {
            Modulo m;
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM modulos WHERE id_modulo = @id", MySqlConn);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    m = new Modulo();
                    m.Id = id;
                    m.Descripcion = (string)reader["desc_modulo"];
                    reader.Close();
                    return m;
                }
            }
            catch (Exception ex)
            {
                throw new NotFoundException("modulo", ex);
            }
            finally
            {
                this.CloseConnection();
            }
            return null;
        }

        public void Insert(Modulo m)
        {
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO modulos (desc_modulo) VALUES (@desc_modulo); SELECT @@IDENTITY;", MySqlConn);
                cmd.Parameters.AddWithValue("@desc_modulo", m.Descripcion);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new InsertException("modulo", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(Modulo m)
        {
            try
            {
                this.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("UPDATE modulos SET desc_modulo = @descripcion " +
                    "WHERE id_modulo = @id", MySqlConn);
                cmd.Parameters.AddWithValue("@id", m.Id);
                cmd.Parameters.AddWithValue("@descripcion", m.Descripcion);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new UpdateException("modulo", ex);
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

                MySqlCommand cmd = new MySqlCommand("DELETE FROM modulos WHERE id_modulo = @id", MySqlConn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new DeleteException("modulo", ex);
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(Modulo m)
        {

            if (m.State == TiposDatos.States.New)
            {
                this.Insert(m);
            }
            else if (m.State == TiposDatos.States.Modified)
            {
                this.Update(m);
            }
            else if (m.State == TiposDatos.States.Deleted)
            {
                this.Delete(m.Id);
            }
            else
            {
                m.State = TiposDatos.States.Unmodified;
            }

        }
    }
}


