using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Ninject.Modules;
using DSW.Database;
using DSW.Service.ApiClient;
using DSW.Service.Business;

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
        }
    }
}
