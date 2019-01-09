using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Ninject;
using Ninject.Modules;
using System.Windows.Forms;

namespace DSW.Core.MVVM
{
    public class MvvmApplication
    {
        public readonly StandardKernel Kernel;

        public MvvmApplication(NinjectModule appNinjectModule)
        {
            this.Kernel = new StandardKernel(new MvvmModule(), appNinjectModule);
        }


        public void Run<T>() where T : Form
        {
            var viewType = typeof(T);
            var getNavigator = Kernel.Get<IMvvmNavigator>();
            var getForm = getNavigator.CreateView(viewType,null);
            Application.Run(getForm);
            
        }
    }
}
