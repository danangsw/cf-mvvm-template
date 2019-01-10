using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace DSW.Core.Extensions
{
    public static class DateTimeExtension
    {
        public static DateTime ConvertToDateTime(this string dateString)
        {
            CultureInfo MyCultureInfo = new CultureInfo("en-US");
            try
            {
                DateTime dt = DateTime.ParseExact(dateString, "dd/MM/yyyy HH:mm:ss", MyCultureInfo);

                return dt;
            }
            catch (FormatException)
            {
                return DateTime.Now;
            }
        }

        public static string ConvertToDateString(this DateTime datetime)
        {
            return string.Format("{0:dd/MM/yyyy HH:mm:ss}", datetime);
        }

        public static string ConvertToDateShortString(this DateTime datetime)
        {
            return string.Format("{0:dd/MM/yyyy}", datetime);
        }

        public static Guid ConvertToGuid(this string guidString)
        {
            try
            {
                return new Guid(guidString);
            }
            catch (Exception)
            {
                return Guid.Empty;
            }
        }
    }
}
