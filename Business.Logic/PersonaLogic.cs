using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PersonaLogic:BusinessLogic
    {

        private PersonaAdapter PersonaData;

        public PersonaLogic()
        {
            PersonaData = new PersonaAdapter();
        }

        public Persona GetOne(int ID)
        {
            Persona p = PersonaData.GetOne(ID);
            return p;
        }

        public List<Persona> GetAll()
        {   
            List<Persona> ListaPersona = PersonaData.GetAll();
            return ListaPersona;
        }

        public void Delete(int ID)
        {
           PersonaData.Delete(ID);
        }
        public void Save(Persona p)
        {

            //Obtenemos el ultimo plan
            Plan plan = new Plan();
            

            PersonaData.Save(p);
        }

        public int obtenerProximoLegajo()
        {
            PersonaData = new PersonaAdapter();
            int legajo = PersonaData.obtenerUltimoLegajo();
            legajo = +1;
            return legajo;
        }
    }
}
