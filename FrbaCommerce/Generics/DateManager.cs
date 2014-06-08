using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Generics
{
    public static class DateManager
    {
        public static string DateTimeFormat
        {
            get
            {
                return AppConfigReader.Get("DateTimeFormatString");
            }
        }
        public static string TimeFormat
        {
            get
            {
                return AppConfigReader.Get("TimeFormatString");
            }
        }
        public static string DateFormat
        {
            get
            {
                return AppConfigReader.Get("DateFormatString");
            }
        }

        public static string Format(DateTime dt)
        {
            return Format(dt, DateTimeFormat);
        }

        public static string Format(DateTime dt, string format)
        {
            return dt.ToString(format);
        }

        public static DateTime Ahora()
        {
            var ahora = AppConfigReader.Get("DateTimeNow");
            return DateTime.Parse(ahora);
        }
    }
}
