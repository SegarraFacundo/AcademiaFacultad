using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.CustomException
{
    public class UpdateException : Exception
    {
        const string message = "No logro actualizar: {0} ";

        public UpdateException(string nameEntity) : base(String.Format(message, nameEntity)) { }

        public UpdateException(string nameEntity, System.Exception ex) : base(String.Format(message, nameEntity), ex) { }
    }
}
