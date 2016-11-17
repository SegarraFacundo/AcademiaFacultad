using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;
using System.Data;
using System.Configuration;

namespace Business.Logic
{
   public  class ReportesLogic
    {
       private ReportesData rd = new ReportesData();
       public dsCursos GetDataCursos()
       {
           dsCursos ds = rd.GetDatosCursos();
           return ds;

       }

       public dsPlanes GetDataPlanes()
       {
           dsPlanes ds = rd.GetDatosPlanes();
           return ds;
       }


    }
}
