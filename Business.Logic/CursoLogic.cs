using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;


namespace Business.Logic
{
    public class CursoLogic:BusinessLogic
    {

        private CursoAdapter CursoData;

        public CursoLogic()
        {
            CursoData = new CursoAdapter();
        }

        public Curso GetOne(int ID)
        {
            Curso curso = CursoData.GetOne(ID);
            return curso;
        }

        public void Save(Curso c)
        {
            CursoData.Save(c);
        }
        public void Delete(int ID) 
        {
            CursoData.Delete(ID);
        }
    }
}
