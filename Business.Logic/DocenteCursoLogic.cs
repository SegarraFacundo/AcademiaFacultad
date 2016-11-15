using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Business.Entities;
using Business.Logic;
using Util;
using Util.CustomException;
using Data.Database;

namespace Business.Logic
{
    
    public class DocenteCursoLogic 
    {
        DocenteCursoAdapter dca = new DocenteCursoAdapter();
        public DataTable GetCursosPorDocente(int id)
        {
            DataTable dt = new DataTable();

            dt = dca.GetCursosPorDocente(id);

            return dt;


        }

    }
}
