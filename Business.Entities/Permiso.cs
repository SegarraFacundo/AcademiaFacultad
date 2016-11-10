using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Permiso:BusinessEntity
    {
        public Permiso() : base() { }

        private string _descripcion;
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
   
        private string _ejecuta;
        public string Ejecuta
        {
            get { return _ejecuta; }
            set { _ejecuta = value; }
        }

        private bool _alta;
        public bool Alta
        {
            get { return _alta; }
            set { _alta = value; }
        }

        private bool _baja;
        public bool Baja
        {
            get { return _baja; }
            set { _baja = value; }
        }

        private bool _consulta;
        public bool Consulta
        {
            get { return _consulta; }
            set { _consulta = value; }
        }

        private bool _modificacion;
        public bool Modificacion
        {
            get { return _modificacion; }
            set { _modificacion = value; }
        }
    }
}
