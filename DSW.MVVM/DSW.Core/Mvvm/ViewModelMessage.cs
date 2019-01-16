using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DSW.Core.MVVM;

namespace DSW.Core.Mvvm
{
    public class ViewModelMessage<T, Y>
        where T : IViewModelBase
        where Y : class
    {
        public T ViewModelParent { get; private set; }
        public Y Data { get; private set; }

        public ViewModelMessage(T viewModelParent, Y data)
        {
            ViewModelParent = viewModelParent;
            Data = data;
        }
    }
}
