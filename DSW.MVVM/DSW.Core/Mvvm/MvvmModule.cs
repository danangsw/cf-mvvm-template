using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Ninject.Modules;

namespace DSW.Core.MVVM
{
    public class MvvmModule : NinjectModule 
    {
        public override void Load()
        {
            Bind<IMvvmNavigator>().To<MvvmNavigator>();
        }
    }
}
