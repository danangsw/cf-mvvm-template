using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Ninject.Modules;
using DSW.Database;
using DSW.Service.ApiClient;
using DSW.Service.Business;
using DSW.MVVM.ViewModels.Stocktake;

namespace DSW.HT
{
    public class AppModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IApiClientService>().To<ApiClientService>();
            Bind<IAppSettingService>().To<AppSettingService>();
            Bind<IMstItemService>().To<MstItemService>();
            Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
            Bind<StocktakeNewViewModel>().ToSelf();
            Bind<StocktakeItemViewModel>().ToSelf();
            Bind<StocktakeDetailViewModel>().ToSelf();
        }
    }
}
