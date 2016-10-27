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
    public class EspecialidadLogic:BusinessLogic
    {
        private EspecialidadAdapter especialidadData;

        public EspecialidadLogic()
        {
            this.especialidadData = new EspecialidadAdapter();
        }

        public List<Especialidad> GetAll()
        {
            try
            { 
                List<Especialidad> listaEspecialidades = new List<Especialidad>();
                listaEspecialidades = this.especialidadData.GetAll();
                return listaEspecialidades;
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

        public void Save(Especialidad e)
        {
            this.especialidadData.Save(e);

        }

        public Especialidad GetOne(int id)
        {
            try
            {
                Especialidad e = new Especialidad();
                e = this.especialidadData.GetOne(id);
                return e;
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
