using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class ValidationManager
    {
        public static bool Number(string value)
        {
            Int32.Parse(value);
            return true;
        }

        public static bool Min()
        {
            return true;
        }

        public static bool Max()
        {
            return true;
        }

        public static bool Required(Object value)
        {
            if (value.ToString() == "")
                return false;
            return true;
        }

        public static bool Equal(Object value1, Object value2)
        {
            return (value1.Equals(value2));
        }

    }
}
