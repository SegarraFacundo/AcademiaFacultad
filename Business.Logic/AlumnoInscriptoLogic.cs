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
    
    public class AlumnoInscriptoLogic : BusinessLogic
    {
        AlumnoInscripcionAdapter inscripcionAdapter = new AlumnoInscripcionAdapter();

        public void Save(AlumnoInscripto ai)
        {
            inscripcionAdapter.Save(ai);
        }
        public string ValidarInscripcion(Alumno a, Curso c)
        {
            string valor = "";

            //Verificamos que el curso tenga cupo
            if (c.CupoDisponible == 0)
            {
                return "Sin cupo";
            }
            //Validamos que el alumno no este inscripto a ese curso ya
            //Recuperamos todas las incripciones que tiene ese alumno
            List<AlumnoInscripto> listaInscripciones = inscripcionAdapter.GetAllByIdAlumno(a.Id);
            foreach (AlumnoInscripto inscripcion in listaInscripciones)
            {
                if (inscripcion.IdCurso == c.Id)
                {
                    return "Ya inscripto";
                }

            }

            return valor;
        }

        public List<AlumnoInscripto> GetAllByIdAlumno(int id)
        {
            List<AlumnoInscripto> lista = inscripcionAdapter.GetAllByIdAlumno(id);
            return lista;

        }

        public System.Data.DataTable GetInscripto(int id)
        {
            System.Data.DataTable dt = inscripcionAdapter.GetInscripto(id);
            return dt;
        }
    }
}
