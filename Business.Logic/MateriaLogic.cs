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
                List<Materia> materias = this.materiaData.GetAll();
                List<Materia> materiasNuevas = new List<Materia>();
                foreach (Materia m in materias)
                {
                    if (m.IdPlan == idPlan)
                    {
                      
                        materiasNuevas.Add(m);
                    }
                }
                return materiasNuevas;
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

        public Materia SearchByName(int idPlan, string nombre)
        {
            //Este metodo esta por el hecho de que manejamos las materias sin id_plan para poder asignarlas a un plan al darlo de alta, a travez de esa lista.
            //Tal vez el nombre no sea el mas representativo del mundo, lo admito
            //De esta forma, cuando queremos una materia que YA esta asignada a un plan, con el idPlan y el nombre (porque puede haber mas de una materia con ese id)
            //Encontramos la materia que queriamos.
            List<Materia> materias = this.GetMateriasPorPlan(idPlan);
            foreach (Materia m in materias)
            {
                if (m.Descripcion == nombre)
                {
                    return m;
                }
            }
            return null;
        }
    }
}
