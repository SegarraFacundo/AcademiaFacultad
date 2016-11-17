using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;
using Util.CustomException;

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
            try
            {
                Alumno a = AlumnoData.GetOne(ID);
                return a;
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch ( Exception ex)
            {
                throw new CustomException(ex);
            }

        }

        public List<Alumno> GetAll()
        {
            try
            {
                List<Alumno> ListaAlumno = AlumnoData.GetAll();
                return ListaAlumno;
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch ( Exception ex)
            {
                throw new CustomException(ex);
            }
        }

        public void Delete(int ID)
        {
            try
            { 
                AlumnoData.Delete(ID);
            }
            catch ( DeleteException ex )
            {
                throw ex;
            }
            catch ( Exception ex )
            {
                throw new CustomException(ex);
            }
        }

        public void Save(Alumno a)
        {
            AlumnoData.Save(a);
            
        }

        public int obtenerProximoLegajo()
        {
            try
            { 
                int legajo = AlumnoData.obtenerUltimoLegajo("alumno");
                if (legajo.Equals(0))
                    throw new NotFoundException("legajo");
                legajo += 1;
                return legajo;
            }
            catch (NotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new CustomException(ex);
            }
        }

        public List<Alumno> GetAlumnosPorPlan(int idPlan)
        {
            List<Alumno> ListaAlumno = AlumnoData.GetAll();
            List<Alumno> ListaAlumnosPorPlan = new List<Alumno>();
            foreach (Alumno a in ListaAlumno)
            {
                if (a.IdPlan == idPlan)
                {
                    ListaAlumnosPorPlan.Add(a);
                }
            }
            return ListaAlumnosPorPlan;
        }
    }
}
