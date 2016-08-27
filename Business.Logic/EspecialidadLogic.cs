using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class EspecialidadLogic:BusinessLogic
    {
        private EspecialidadAdapter especialidadData;

        public List<Especialidad> getAll()
        {
            List<Especialidad> listaEspecialidades = new List<Especialidad>();
            especialidadData = new EspecialidadAdapter();
            listaEspecialidades = especialidadData.GetAll();
            return listaEspecialidades;
        }

        public void Save(Especialidad e)
        {
            especialidadData = new EspecialidadAdapter();
            especialidadData.Save(e);

        }

        public Especialidad GetOne(int id)
        {
            Especialidad e = new Especialidad();
            especialidadData = new EspecialidadAdapter();
            e = especialidadData.GetOne(id);
            return e;
        }
    }
}
