using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DSW.Core.Utility.Services;

namespace DSW.Service.Business
{
    public class BaseService
    {
        protected string ApiAddress;

        public BaseService() {
            ApiAddress = Helpers.UrlBuilder(AppDataService.GetSettingApiAddress());
        }
    }
}
