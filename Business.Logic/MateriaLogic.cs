using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;
using Util.CustomException;
using Util;

namespace Business.Logic
{
    public class MateriaLogic
    {
         private MateriaAdapter materiaData;

        public MateriaLogic()
        {
            materiaData = new MateriaAdapter();
        }

        public Materia GetOne(int id)
        {
            try
            {
                Materia materia = this.materiaData.GetOne(id);
                return materia;
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

        public List<Materia> GetAll()
        {
            try
            {
                List<Materia> materias = this.materiaData.GetAll();
                return materias;
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
        public List<Materia> GetMateriasPorPlan(int idPlan)
        {
            try
            {
                List<Materia> materias = this.materiaData.GetMateriaPorPlan(idPlan);
                return materias;
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
        public void Save(Materia m)
        {
            this.materiaData.Save(m);
        }


    }
}
