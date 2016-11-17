using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;
using Util.CustomException;

namespace Business.Logic
{
    public class PlanLogic : BusinessLogic
    {

        private PlanAdapter planData;

        public PlanLogic()
        {
            planData = new PlanAdapter();
        }

        public Plan GetOne(int id)
        {
            try
            {
                Plan plan = this.planData.GetOne(id);
                return plan;
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

        public List<Plan> GetAll()
        {
            try
            {
                List<Plan> planes = this.planData.GetAll();
                return planes;
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

        public bool Save(Plan p)
        {

            try
            {
                if (p.State == Util.TiposDatos.States.Modified || p.State == Util.TiposDatos.States.Deleted)
                {
                    if (this.PuedeBorrarsePlan(p.Id) == false)
                    {
                        return false;
                    }
                }

                this.planData.Save(p);
                return true;

            }
            catch (InsertException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Delete(int id)
        {
            try
            {
                this.planData.Delete(id);
            }
            catch (DeleteException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new CustomException(ex);
            }
        }

        public List<Plan> GetByEspecialidad(int idEspecialidad)
        {
            try
            {
                return this.planData.GetByEspecialidad(idEspecialidad);
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

        private bool PuedeBorrarsePlan(int idPlan)
        {
            try
            {

                //Para borrar o modificar un plan verificamos que no tenga comisiones asociadas al plan o cursos asociados a la materia del plan
                //Ni alumnos
                //Traer todas las materias del plan
                //Por cada materia que tiene fijarme si tiene un curso
                MateriaLogic ml = new MateriaLogic();
                List<Materia> listaMaterias = ml.GetMateriasPorPlan(idPlan);
                CursoLogic cl = new CursoLogic();
                foreach (Materia m in listaMaterias)
                {
                    List<Curso> cursosPorMateria = cl.GetCursosPorMateria(m.Id);
                    if (cursosPorMateria.Count > 0)
                    {
                        return false;
                    }
                }

                //Traer todas las comisiones que tiene el plan
                ComisionLogic cml = new ComisionLogic();
                List<Comision> listaComisiones = cml.GetComisionPorPlan(idPlan);
                if (listaComisiones.Count > 0)
                {
                    return false;
                }

                //Traer todas las personas con ese idPlan
                AlumnoLogic al = new AlumnoLogic();
                List<Alumno> listaAlumnos = al.GetAlumnosPorPlan(idPlan);
                if (listaAlumnos.Count > 0)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

