using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.CustomException
{
    public class InsertException : Exception
    {
        const string message = "No logro guardar: {0} ";

        public InsertException(string nameEntity) : base(String.Format(message, nameEntity)) { }

        public InsertException(string nameEntity, System.Exception ex) : base(String.Format(message, nameEntity), ex) { }
    }
}
