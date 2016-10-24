using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace Business.Entities
{
    public class Docente : Persona
    {
        public Docente()
        {
            this.TipoDePersona = TiposDatos.TiposDePersona.Docente;
        }
    }
}
