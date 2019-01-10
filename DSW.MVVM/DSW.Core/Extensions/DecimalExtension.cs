using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace DSW.Core.Extensions
{
    public static class DecimalExtension
    {
        public static string ConvertToString(this decimal numeric)
        {
            return numeric.ToString("N2", CultureInfo.InvariantCulture);
        }

        public static string ConvertToDecimalFormat(this string numericStr)
        {
            decimal numeric = 0M;

            if (string.IsNullOrEmpty(numericStr))
            {
                return numeric.ConvertToString();
            }

            numeric = decimal.Parse(numericStr);

            return numeric.ConvertToString();
        }

        public static decimal ConvertToDecimal(this string numericStr)
        {
            try
            {
                return decimal.Parse(numericStr);
            }
            catch (Exception)
            {
                return 0M;
            }
        }
    }
}
