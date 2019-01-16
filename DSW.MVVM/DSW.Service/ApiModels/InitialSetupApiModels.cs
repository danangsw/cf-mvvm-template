using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DSW.Service.ApiModels
{
    public class InitialSetupApiResponseModel {
        public AppSettingApiModel AppSettingInfo { get; set; }
        public List<MasterItemApiModel> MasterItems { get; set; }

        public InitialSetupApiResponseModel() {
            MasterItems = new List<MasterItemApiModel>();
        }
    }

    public class AppSettingApiModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class MasterItemApiModel
    {
        public string ItemNo { get; set; }
        public string ItemDesc { get; set; }
    }
}
