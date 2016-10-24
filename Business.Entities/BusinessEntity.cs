using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Util;

namespace Business.Entities
{
    public class BusinessEntity
    {
        public BusinessEntity()
        {
            this.State = TiposDatos.States.New;
        }

        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private TiposDatos.States _State;
        public TiposDatos.States State
        {
            get { return _State; }
            set { _State = value; }
        }
    }

}
