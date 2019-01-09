using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DSW.Core.Utility.Services;
using DSW.Core.MVVM;
using System.Resources;

namespace DSW.Core.MVVM
{
    public interface IUserControlBase<TViewModel> where TViewModel : IViewModelBase
    {
        void BindViewModel(TViewModel viewModel);
        void SetData(object data);
        void Loading_EventHandler(object sender, EventArgs args);
        void LoadingClose_EventHandler(object sender, EventArgs args);
    }

    public partial class UserControlBase<TViewModel> : UserControl, IUserControlBase<TViewModel> where TViewModel : IViewModelBase
    {
        protected TViewModel ViewModel;

        public UserControlBase()
        {
            InitializeComponent();
        }

        public ResourceManager ResxLabels { get { return MultiLanguageManager.Labels; } }
        public ResourceManager ResxMessages { get { return MultiLanguageManager.Messages; } }

        public virtual void ViewModel_NotifyViewEventHandler(object sender, NotifyEventArgs args)
        {
        }

        #region IUserControlBase<TViewModel> Members

        public virtual void Load() { 
        }

        public virtual void BindViewModel(TViewModel viewModel)
        {
            ViewModel = viewModel;
            ViewModel.NotifyViewEventHandler += ViewModel_NotifyViewEventHandler;
        }

        public virtual void SetData(object data)
        {
        }

        public virtual void Loading_EventHandler(object sender, EventArgs args)
        {
            ViewModel.HandleLoadingProcess();
        }

        public virtual void LoadingClose_EventHandler(object sender, EventArgs args)
        {
            ViewModel.HandleCloseLoadingProcess();
        }

        #endregion
    }
}
