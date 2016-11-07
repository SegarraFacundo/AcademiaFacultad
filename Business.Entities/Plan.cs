using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Plan : BusinessEntity
    {
        public Plan() : base() { }

        private string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private int _IdEspecialidad;
        public int IdEspecialidad
        {
            get { return _IdEspecialidad; }
            set { _IdEspecialidad = value; }
        }

        private List<Materia> _ListMaterias;

        public List<Materia> ListaMaterias
        {
            get { return _ListMaterias; }
            set { _ListMaterias = value; }
        }
    }
}
