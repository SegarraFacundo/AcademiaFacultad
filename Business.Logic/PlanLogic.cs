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

        public void Save(Plan p)
        {
            try
            {
                this.planData.Save(p);
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

    }
}
