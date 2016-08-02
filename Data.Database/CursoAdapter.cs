using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;


namespace Data.Database
{
    class CursoAdapter : Adapter
    {
        public List<Curso> GetAll()
        {
            List<Curso> ListaCursos = new List<Curso>();
            this.OpenConnection();

            return ListaCursos;
        }

        public Curso GetOne(int Id)
        {

            Curso curso = new Curso();

            return curso;
        }

        public void Delete(int Id)
        {

        }

        public void Save(Curso curso)
        {

        }

    }
}
