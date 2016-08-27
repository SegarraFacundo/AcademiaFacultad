using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;

namespace Data.Database
{
   public  class EspecialidadAdapter : Adapter
    {

       public List<Especialidad> GetAll()
       {
           List<Especialidad> listaEspecialidades = new List<Especialidad>();

           try
           {
               this.OpenConnection();
               SqlCommand cmd = new SqlCommand("SELECT * FROM especialidades", sqlConn);
               SqlDataReader reader = cmd.ExecuteReader();
               while(reader.Read())
               {
                   Especialidad e = new Especialidad();
                   e.Id = (int)reader["id_especialidad"];
                   e.Descripcion = (string)reader["desc_especialidad"];
                   listaEspecialidades.Add(e);
               }
               reader.Close();
           }
           catch (Exception ex)
           {
               Exception excepcionManejada = new Exception("Error al recuperar las especialidades: ", ex);
               throw ex;
           }
           finally
           {
               this.CloseConnection();
           }

           return listaEspecialidades;
       }

       public Especialidad GetOne(int id)
       {
           Especialidad e = new Especialidad();
           try
           {
               this.OpenConnection();
               SqlCommand cmd = new SqlCommand("SELECT * FROM especialidades WHERE id_especialidad = @id", sqlConn);
               cmd.Parameters.AddWithValue("@id", id);
               SqlDataReader reader = cmd.ExecuteReader();
               if (reader.Read())
               {                   
                   e.Id = id;
                   e.Descripcion = (string)reader["desc_especialidad"];
               }
               reader.Close();
           }
           catch (Exception ex)
           {
               Exception excepcionManejada = new Exception("Error al recuperar los datos: ", ex);
               throw excepcionManejada;
           }
           finally
           {
               this.CloseConnection();
           }
           return e;
       }
       public void Save(Especialidad e){

           if (e.State == BusinessEntity.States.New)
           {
               this.Insert(e);
           }
           else if(e.State== BusinessEntity.States.Modified){
               this.Update(e);
           }
           else if (e.State == BusinessEntity.States.Deleted)
           {
               this.Delete(e.Id);
           }
           else
           {
               e.State = BusinessEntity.States.Unmodified;
           }

       }
       public void Insert(Especialidad e)
       {
           try
           {
               this.OpenConnection();
               SqlCommand cmd = new SqlCommand("INSERT INTO especialidades (desc_especialidad) VALUES (@descripcion); SELECT @@IDENTITY;", sqlConn);
               cmd.Parameters.AddWithValue("@descripcion", e.Descripcion);
               cmd.ExecuteNonQuery();                           
           }
           catch (Exception ex)
           {
               Exception excepcionManejada = new Exception("Error al guardar los datos: ", ex);
               throw excepcionManejada;
           }
           finally
           {
               this.CloseConnection();
           }
       }
       public void Update(Especialidad e)
       {
           try
           {
               this.OpenConnection();
               SqlCommand cmd = new SqlCommand("UPDATE especialidades SET desc_especialidad = @descripcion WHERE id_especialidad = @idEspecialidad", sqlConn);
               cmd.Parameters.AddWithValue("@descripcion", e.Descripcion);
               cmd.Parameters.AddWithValue("@idESpecialidad", e.Id);
               cmd.ExecuteNonQuery();
           }
           catch (Exception ex)
           {
               Exception excepcionManejada = new Exception("Error al guardar los datos: ", ex);
               throw excepcionManejada;
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

               SqlCommand cmd = new SqlCommand("DELETE FROM especialidades WHERE id_especialidad = @id", sqlConn);
               cmd.Parameters.AddWithValue("@id", id);
               cmd.ExecuteNonQuery();
           }
           catch (Exception ex)
           {
               Exception excepcionManejada = new Exception("Error al guardar los datos: ", ex);
               throw excepcionManejada;
           }
           finally
           {
               this.CloseConnection();
           }
       }
    }
}
