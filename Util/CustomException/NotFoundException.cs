using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.CustomException
{
    public class NotFoundException : Exception
    {
        const string message = "No logro obtener {0} ";

        public NotFoundException(string nameEntity) : base(String.Format(message, nameEntity)) { }

        public NotFoundException(string nameEntity, System.Exception ex) : base(String.Format(message, nameEntity), ex) { }
    }
}
