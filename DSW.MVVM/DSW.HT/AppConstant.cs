using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DSW.Core.Utility.Services;

namespace DSW.HT
{
    public static class AppConstant
    {
        public static class Session
        {
            public const string CultureInfo = MultiLanguageManager.Id;
        }

        public static class CultureInfo
        {
            public const string CodeLanguage = "language";
            public static class Lang
            {
                public const string Indonesia = "id-ID";
                public const string English = "en-US";
            }
        }
    }
}
