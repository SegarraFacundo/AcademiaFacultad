using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.CustomException
{
    public class CustomException : Exception
    {
        const string message = "Error interno en el sistema, sepa disculpar.";
        public CustomException() : base(message) {}

        public CustomException(string message) : base(message) { }

        public CustomException(string message, System.Exception inner) : base(message, inner) { }

        public CustomException(System.Exception inner) : base(message, inner) { }

        protected CustomException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context
        ) { }
    }
}
