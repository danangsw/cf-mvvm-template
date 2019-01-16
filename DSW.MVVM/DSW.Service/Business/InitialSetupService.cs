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

    public class InitialSetupService : IInitialSetupService
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
            return ResponseResult.Succeed();
        }

        #endregion

        #region Private Methods

        private InitialSetupApiResponseModel CallApiInitialSetup()
        {
            try
            {
                var response = new InitialSetupApiResponseModel();

                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private bool InsertMstItemToDB()
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

        private bool InsertAppSettingToDB()
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
