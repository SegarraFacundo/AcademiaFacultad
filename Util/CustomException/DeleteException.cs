using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.CustomException
{
    public class DeleteException : Exception
    {
        const string message = "No logro eliminar: {0} ";

        public DeleteException(string nameEntity) : base(String.Format(message, nameEntity)) { }

        public DeleteException(string nameEntity, System.Exception ex) : base(String.Format(message, nameEntity), ex) { }
    }
}
