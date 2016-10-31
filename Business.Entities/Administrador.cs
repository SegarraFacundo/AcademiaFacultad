using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace Business.Entities
{
    public class Administrador : Persona
    {
        public Administrador() : base()
        {
            this.TipoDePersona = TiposDatos.TiposDePersona.Administrador;
        }
    }
}
