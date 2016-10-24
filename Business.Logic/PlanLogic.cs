using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class PlanLogic : BusinessLogic
    {

        private PlanAdapter PlanData;

        public PlanLogic()
        {
            PlanData = new PlanAdapter();
        }

        public Plan GetOne(int id)
        {
            Plan plan = PlanData.GetOne(id);
            return plan;
        }

        public List<Plan> GetAll()
        {
            List<Plan> planes = PlanData.GetAll();
            return planes;
        }

        public void Save(Plan p)
        {
            PlanData.Save(p);
        }

        public void Delete(int id)
        {
            PlanData.Delete(id);
        }

        public List<Plan> GetByEspecialidad(int idEspecialidad)
        {
            return PlanData.GetByEspecialidad(idEspecialidad);
        }

    }
}
