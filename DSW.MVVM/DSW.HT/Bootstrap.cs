using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Ninject.Modules;
using DSW.Database;
using DSW.Service.ApiClient;

namespace DSW.HT
{
    public class Bootstrap : NinjectModule
    {
        public override void Load()
        {
            Bind<IApiClientService>().To<ApiClientService>();
            Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
        }
    }
}
