using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;

namespace DSW.Core.Utility.Services
{
    public class DateAndTime
    {
        // Declarations
        [DllImport("coredll.dll", SetLastError = true)]
        static extern bool SetLocalTime(ref SYSTEMTIME time);

        private struct SYSTEMTIME
        {
            public short Year;
            public short Month;
            public short DayOfWeek;
            public short Day;
            public short Hour;
            public short Minute;
            public short Second;
            public short Milliseconds;
        }

        public static void SetDeviceTime(DateTime date)
        {
            SYSTEMTIME s = new SYSTEMTIME();
            s.Year = (short)date.Year;
            s.Month = (short)date.Month;
            s.DayOfWeek = (short)date.DayOfWeek;
            s.Day = (short)date.Day;
            s.Hour = (short)date.Hour;
            s.Minute = (short)date.Minute;
            s.Second = (short)date.Second;
            s.Milliseconds = (short)date.Millisecond;

            SetLocalTime(ref s);
            //SetLocalTime(ref systime);
        }
    }
}
