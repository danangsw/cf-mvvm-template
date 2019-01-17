using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DSW.Core.Utility.Services;
using DSW.Database;
using DSW.Service.ApiClient;
using DSW.Service.ApiModels;
using DSW.Database.Entity;

namespace DSW.Service.Business
{
    public interface IInitialSetupService
    {
        ResponseResult InitialSetup();
    }

    public class InitialSetupService : BaseService, IInitialSetupService
    {
        private IApiClientService _apiClientService;

        public InitialSetupService(
            IUnitOfWork unitOfWork,
            IApiClientService apiClientService
        )
            : base(unitOfWork)
        {
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

            if (this.InsertAppSettingToDB(response.AppSettingInfos))
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
                this._unitOfWork.MstItemRepository.DeleteAll();
                List<MstItem> entities = new List<MstItem>();

                foreach (var item in models)
                {
                    var entity = Mappers.Map<MasterItemApiModel, MstItem>(item);

                    entities.Add(entity);
                }

                var tran = this._unitOfWork.BeginTransaction();
                this._unitOfWork.MstItemRepository.BulkInsert(entities);
                this._unitOfWork.EndTransaction();
                
                return true;
            }
            catch (Exception ex)
            {
                this._unitOfWork.Rollback();
                return false;
            }
        }

        private bool InsertAppSettingToDB(List<AppSettingApiModel> models)
        {
            try
            {
                this._unitOfWork.AppSettingRepository.DeleteAll();

                List<AppSetting> entities = new List<AppSetting>();

                foreach (var item in models)
                {
                    var entity = Mappers.Map<AppSettingApiModel, AppSetting>(item);

                    entities.Add(entity);
                }

                var tran = this._unitOfWork.BeginTransaction();
                this._unitOfWork.AppSettingRepository.BulkInsert(entities);
                this._unitOfWork.EndTransaction();

                return true;
            }
            catch (Exception ex)
            {
                this._unitOfWork.Rollback();
                return false;
            }
        }
        #endregion
    }
}
