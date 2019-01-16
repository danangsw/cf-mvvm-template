using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DSW.Core.Utility.Services
{
    public class AppDataService
    {
        public const string SettingsApiAddress = "DSW.HT.Session.Settings.ApiAddress";

        public static void SetSettingApiAddress(string apiAddress) {
            if (!ThreadManager.DoesNamedDataSlotsExist(SettingsApiAddress))
            {
                ThreadManager.SetData(SettingsApiAddress, apiAddress);
            }
        }

        public static string GetSettingApiAddress() {
            var data = ThreadManager.GetData(SettingsApiAddress);

            return (string)data;
        }
    }
}
