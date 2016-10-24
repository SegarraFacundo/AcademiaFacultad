using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class AlumnoLogic : BusinessLogic
    {

        private AlumnoAdapter AlumnoData;

        public AlumnoLogic()
        {
            AlumnoData = new AlumnoAdapter();
        }

        public Alumno GetOne(int ID)
        {
            Alumno a = AlumnoData.GetOne(ID);
            return a;
        }

        public List<Alumno> GetAll()
        {   
            List<Alumno> ListaAlumno = AlumnoData.GetAll();
            return ListaAlumno;
        }

        public void Delete(int ID)
        {
           AlumnoData.Delete(ID);
        }
        public void Save(Alumno a)
        {
            AlumnoData.Save(a);
        }

        public int obtenerProximoLegajo()
        {
            AlumnoData = new AlumnoAdapter();
            int legajo = AlumnoData.obtenerUltimoLegajo("alumno");
            legajo = +1;
            return legajo;
        }
    }
}
