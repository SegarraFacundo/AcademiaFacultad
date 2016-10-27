using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace Business.Entities
{
    public class DocenteCurso:BusinessEntity
    {
        public DocenteCurso() : base() { }

        private int _IdCurso;

        public int IdCurso
        {
            get { return _IdCurso; }
            set { _IdCurso = value; }
        }

        private int _IdDocente;

        public int IdDocente
        {
            get { return _IdDocente; }
            set { _IdDocente = value; }
        }

        private TiposDatos.TiposCargos _Cargo;

        public TiposDatos.TiposCargos Cargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }
        }
    }
}
