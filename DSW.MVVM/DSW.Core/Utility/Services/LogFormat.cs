using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DSW.Core.Utility.Services
{
    public static class LogFormat
    {
        public static string Message(string user, string action, string status, string error)
        {
            string InfoDate = string.Format("{0:dd-MM-yyy hh:mm:ss}", DateTime.Now);
            string Info = InfoDate + " " + user + " Action = " + action + " Status = " + status;

            if (!string.IsNullOrEmpty(error))
            {
                Info += " Error = " + error;
            }

            return Info;
        }
    }

    public static class LogStatus
    {
        public const string Success = "Success";
        public const string Failed = "Failed";
    }
}
