using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFS.DB.Application.Utilities
{
    public static class ConvertHelper
    {
        public static int ConvertStringToInt(string value)
        {
            int result = 0;

            if (!int.TryParse(value, out result))
                result = 0;

            return result;
        }

        public static long ConvertStringToLong(string value)
        {
            long result = 0;

            if (!long.TryParse(value, out result))
                result = 0;

            return result;
        }

        public static decimal ConvertStringToDecimal(string value)
        {
            decimal result = 0;

            if (!decimal.TryParse(value, out result))
                result = 0;

            return result;
        }

        public static byte ConvertStringToByte(string value)
        {
            byte result = 0;

            if (!byte.TryParse(value, out result))
                result = 0;

            return result;
        }
    }
}
