using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;
using Util;
using Util.CustomException;

namespace Business.Logic
{
    public class DocenteLogic : BusinessLogic
    {

        private DocenteAdapter DocenteData;

        public DocenteLogic()
        {
            DocenteData = new DocenteAdapter();
        }

        public Docente GetOne(int ID)
        {
            try
            {
                Docente d = DocenteData.GetOne(ID);
                return d;
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

        public List<Docente> GetAll()
        {
            try
            {
                List<Docente> ListaDocentes = DocenteData.GetAll();
                return ListaDocentes;
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

        public void Save(Docente d)
        {
            DocenteData.Save(d);
        }

        public int obtenerProximoLegajo()
        {
            try
            {
                AlumnoAdapter ad = new AlumnoAdapter();
                int legajo = ad.obtenerUltimoLegajo("alumno");
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
    }
}
