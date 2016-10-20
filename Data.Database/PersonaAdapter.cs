using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using MySql.Data.MySqlClient;

namespace Data.Database
{
   public class PersonaAdapter:Adapter
    {

       private List<Persona> ListaPersonas;
       public List<Persona> GetAll()
       {
           ListaPersonas = new List<Persona>();

           try
           {
               this.OpenConnection();
               MySqlCommand cmd = new MySqlCommand("SELECT * FROM personas", MySqlConn);
               MySqlDataReader reader = cmd.ExecuteReader();
               while (reader.Read())
               {
                   Persona p = new Persona();
                   p.Id = (int)reader["id_persona"];
                   p.Nombre = (string)reader["nombre"];
                   p.Apellido = (string)reader["apellido"];
                   p.Direccion = (string)reader["direccion"];
                   p.Email = (string)reader["email"];
                   p.FechaNacimiento = (DateTime)reader["fecha_nac"];
                   p.Legajo = (int)reader["legajo"];
                   p.Telefono = (string)reader["telefono"];
                   ListaPersonas.Add(p);
               }
               reader.Close();
           }
           catch(Exception Ex)
           {
               Exception ExcepcionManejada = new Exception("Error al buscar personas: ", Ex);
               throw ExcepcionManejada;
           }
           finally
           {
               this.CloseConnection();
           }
           return ListaPersonas;
       }

       public Persona GetOne(int ID)
       {
           Persona p = new Persona();
           try
           {
               this.OpenConnection();
               MySqlCommand cmd = new MySqlCommand("SELECT * FROM personas WHERE id_persona = @ID", MySqlConn);
               cmd.Parameters.AddWithValue("@ID", ID);
               MySqlDataReader reader = cmd.ExecuteReader();
               if (reader.Read())
               {
                   p.Id = (int)reader["id_persona"];
                   p.Nombre = (string)reader["nombre"];
                   p.Apellido = (string)reader["apellido"];
                   p.Direccion = (string)reader["direccion"];
                   p.Email = (string)reader["email"];
                   p.FechaNacimiento = (DateTime)reader["fecha_nac"];
                   p.Legajo = (int)reader["legajo"];
                   p.Telefono = (string)reader["telefono"];
               }
               reader.Close();
           }

           catch (Exception Ex)
           {
               Exception ExcepcionManejada = new Exception("Error al buscar la Persona: ", Ex);
               throw ExcepcionManejada;
           }
           finally {
               this.CloseConnection();
           }
           return p;
       }

       protected void Insert(Persona p) 
       {
           try
           {
               this.OpenConnection();
               MySqlCommand cmd = new MySqlCommand("INSERT INTO personas (nombre, apellido, direccion, email, telefono, fecha_nac, legajo, tipo_persona, id_plan) " +
               "VALUES (@nombre, @apellido, @direccion, @email, @telefono, @fecha_nac, @legajo, @tipo_persona, @id_plan) SELECT @@IDENTITY;", MySqlConn);               
               cmd.Parameters.AddWithValue("@nombre", p.Nombre);
               cmd.Parameters.AddWithValue("@apellido", p.Apellido);
               cmd.Parameters.AddWithValue("@direccion", p.Direccion);
               cmd.Parameters.AddWithValue("@email", p.Email);
               cmd.Parameters.AddWithValue("@telefono", p.Telefono);
               cmd.Parameters.AddWithValue("@fecha_nac", p.FechaNacimiento);
               cmd.Parameters.AddWithValue("@tipo_persona", p.TipoPersona);
               cmd.Parameters.AddWithValue("@id_plan", p.IdPlan);
               cmd.Parameters.AddWithValue("@legajo", p.Legajo);
               cmd.ExecuteNonQuery();
          }
           catch (Exception Ex)
           {
               Exception ExcepcionManejada = new Exception("Error al guardar: ", Ex);
               throw ExcepcionManejada;
           }
           finally 
           {
               this.OpenConnection();
           }
       }
       protected void Update(Persona p) 
       {
           try
           {
               this.OpenConnection();
               MySqlCommand cmd = new MySqlCommand("UPDATE personas SET id_persona=@id_persona, nombre=@nombre, apellido=@apellido, direccion=@direccion, email=@email, telefono=@telefono" +
               "fecha_nac=@fecha_nac, legajo=@legajo, tipo_persona=@tipo_persona, id_plan=@id_plan WHERE id_persona=@id_persona", MySqlConn);
               cmd.Parameters.AddWithValue("@id_persona", p.Id);
               cmd.Parameters.AddWithValue("@nombre", p.Nombre);
               cmd.Parameters.AddWithValue("@apellido", p.Apellido);
               cmd.Parameters.AddWithValue("@direccion", p.Direccion);
               cmd.Parameters.AddWithValue("@email", p.Email);
               cmd.Parameters.AddWithValue("@telefono", p.Telefono);
               cmd.Parameters.AddWithValue("@fecha_nac", p.FechaNacimiento);
               cmd.Parameters.AddWithValue("@tipo_persona", p.TipoPersona);
               cmd.Parameters.AddWithValue("@id_plan", p.IdPlan);
               cmd.Parameters.AddWithValue("@legajo", p.Legajo);
               cmd.ExecuteNonQuery();
           }
           catch (Exception Ex) 
           {
               Exception ExcepcionManejada = new Exception("Error al modificar:", Ex);
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
               MySqlCommand cmd = new MySqlCommand("DELETE FROM personas WHERE id_persona = @id_persona", MySqlConn);
               cmd.Parameters.AddWithValue("@id_persona", ID);
               cmd.ExecuteNonQuery();
           }
           catch(Exception Ex)
           {               
               Exception ExcepcionManejada = new Exception("Error al eliminar: ", Ex);
               throw ExcepcionManejada;
           }
           finally
           {
               this.CloseConnection();
           }
       }
       public void Save(Persona p)
       {
           if (p.State == BusinessEntity.States.New)
           {
               this.Insert(p);
           }
           else if (p.State == BusinessEntity.States.Modified)
           {
               this.Update(p);
           }
           else if (p.State == BusinessEntity.States.Deleted)
           {
               this.Delete(p.Id);
           }
           else
           {
               p.State = BusinessEntity.States.Unmodified;
           }
       }

       public int obtenerUltimoLegajo()
       {
           int legajo = 0;

           try
           {
               this.OpenConnection();
               MySqlCommand cmd = new MySqlCommand("SELECT MAX(legajo) FROM personas", MySqlConn);
               MySqlDataReader reader = cmd.ExecuteReader();
               if (reader.Read())
               {
                   legajo = (int)reader["legajo"];
               }
               reader.Close();
           }
           catch (Exception Ex)
           {
               Exception ExcepcionManejada = new Exception("Error al recuperar el legajo: ", Ex);
               throw ExcepcionManejada;
           }
           finally
           {
               this.CloseConnection();
           }

           return legajo;

       }
    }
}
