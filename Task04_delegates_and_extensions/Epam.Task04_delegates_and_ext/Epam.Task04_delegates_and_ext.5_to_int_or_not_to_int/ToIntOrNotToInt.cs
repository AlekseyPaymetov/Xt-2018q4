using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Task04_delegates_and_ext._5_to_int_or_not_to_int
{
    public static class ToIntOrNotToInt
    {
        public static bool IsInt(this string str)
        {
            bool itsIsInt = true;
            for (int i = 0; i < str.Length; i++)
            {
                if (!char.IsNumber(str[i]))
                {
                    itsIsInt = false;
                    break;
                }
            }

            if (itsIsInt)
            {
                return true;
            }

            Mantissa mantissa = new Mantissa(str);
            bool t = mantissa.IsInt();
            return t;
        }
    }
}
