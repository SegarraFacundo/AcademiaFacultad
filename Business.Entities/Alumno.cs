using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace Business.Entities
{
    public class Alumno : Persona
    {
        public Alumno() : base()
        {
            this.TipoDePersona = TiposDatos.TiposDePersona.Alumno;
        }

        private int _IdPlan;
        public int IdPlan
        {
            get { return _IdPlan; }
            set { _IdPlan = value; }
        }
    }
}
