using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DSW.Core.Utility.Services;
using DSW.Database;

namespace DSW.Service.Business
{
    public class BaseService
    {
        protected IUnitOfWork _unitOfWork;
        protected string ApiAddress;

        public BaseService(IUnitOfWork unitOfWork) {
            this._unitOfWork = unitOfWork;
            this.ApiAddress = Helpers.UrlBuilder(AppDataService.GetSettingApiAddress());
        }
    }
}
