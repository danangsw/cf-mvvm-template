using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DSW.Core.Utility.Services;
using DSW.Database;
using DSW.Service.ApiClient;
using DSW.Service.ApiModels;

namespace DSW.Service.Business
{
    public interface IInitialSetupService
    {
        ResponseResult InitialSetup();
    }

    public class InitialSetupService : BaseService, IInitialSetupService
    {
        private IUnitOfWork _unitOfWork;
        private IApiClientService _apiClientService;

        public InitialSetupService(
            IUnitOfWork unitOfWork,
            IApiClientService apiClientService
        )
        {
            this._unitOfWork = unitOfWork;
            this._apiClientService = apiClientService;
        }

        #region IInitialSetupService Members

        public ResponseResult InitialSetup()
        {
            var response = CallApiInitialSetup();
            
            if (response == null)
            {
                return ResponseResult.Failed("Calling API is failed.");
            }

            if (this.InsertMstItemToDB(response.MasterItems))
            {
                return ResponseResult.Failed("Insert MstItem to DB is failed.");
            }

            if (this.InsertAppSettingToDB(response.AppSettingInfo))
            {
                return ResponseResult.Failed("Insert AppSetting to DB is failed.");
            }

            return ResponseResult.Succeed();
        }

        #endregion

        #region Private Methods

        private InitialSetupApiResponseModel CallApiInitialSetup()
        {
            try
            {
                var response = new InitialSetupApiResponseModel();

                response = _apiClientService.Get<InitialSetupApiResponseModel>(ApiAddress, ApiClientConstant.StocktakeUri.InitialSetup);

                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private bool InsertMstItemToDB(List<MasterItemApiModel> models)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool InsertAppSettingToDB(AppSettingApiModel model)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
    }
}
