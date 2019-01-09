using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using DSW.Core.Utility.Services;
using DSW.Core.Utility.Forms;
using DSW.Core.Utility.BHT;

namespace DSW.Core.MVVM
{
    public interface IViewBase<TViewModel> where TViewModel : IViewModelBase
    {
         void BindViewModel(TViewModel viewModel);
         void SetData(object data);
         void Loading_EventHandler(object sender, EventArgs args);
         void LoadingClose_EventHandler(object sender, EventArgs args);
    }

    public partial class ViewBase<TViewModel> : Form, IViewBase<TViewModel> where TViewModel : IViewModelBase
    {
        protected TViewModel ViewModel;
        protected CeHotKeys hotKeys;

        public ViewBase()
        {
            InitializeComponent();
            
            FormUtility.EnterFullScreenMode(this);
            this.Closed += new EventHandler(ViewBase_Closed);
            this.Activated += new EventHandler(ViewBase_Activated);
            this.Deactivate += new EventHandler(ViewBase_Deactivate);
        }

        void ViewBase_Deactivate(object sender, EventArgs e)
        {
            UnregisterHotKeys();
        }

        void ViewBase_Activated(object sender, EventArgs e)
        {
            InitializeHotKeys();
        }

        private void UnregisterHotKeys()
        {
            if (hotKeys != null)
            {
                hotKeys.UnRegister(Keys.Enter);
                hotKeys.UnRegister(Keys.F1);
                hotKeys.UnRegister(Keys.F2);
                hotKeys.UnRegister(Keys.F3);
                hotKeys.UnRegister(Keys.F4);
                hotKeys.KeyPressed -= hotKeys_KeyPressed;
            }
        }

        protected void InitializeHotKeys()
        {
            hotKeys = new CeHotKeys();

            hotKeys.Register(Keys.Enter);
            hotKeys.Register(Keys.F1);
            hotKeys.Register(Keys.F2);
            hotKeys.Register(Keys.F3);
            hotKeys.Register(Keys.F4);
            hotKeys.KeyPressed += hotKeys_KeyPressed;
        }


        public virtual void hotKeys_KeyPressed(Keys key)
        {
            if (key == Keys.F4)
            {
                this.CapturerSnapshot();
            }
        }

        public virtual void CapturerSnapshot() {
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            Capturer.SnapshotWithMessageBox(this.Name + "_" + DateTime.Now.ToString("yyyy-MM-ddTHH_mm_ss") + DateTime.Now.TimeOfDay.TotalMilliseconds.ToString() + ".jpg", bounds);
        }
       
        void ViewBase_Closed(object sender, EventArgs e)
        {
            ViewModel.ClosedView();
        }

        public ResourceManager ResxLabels { get { return MultiLanguageManager.Labels; } }
        public ResourceManager ResxMessages { get { return MultiLanguageManager.Messages ; }}

        public virtual void SetLanguage()
        {

        }

        public virtual void ViewModel_NotifyViewEventHandler(object sender, NotifyEventArgs args)
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

        public virtual void BindViewModel(TViewModel viewModel)
        {
            ViewModel = viewModel;
            ViewModel.NotifyViewEventHandler += ViewModel_NotifyViewEventHandler;
        }

        public virtual void SetData(object data)
        {
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            ViewModel.NotifyViewEventHandler -= ViewModel_NotifyViewEventHandler;
        }

        protected bool ShowConfirmationMsgWithSound(string caption, string body, BHTController bhtController)
        {
            bhtController.SoundConfirm();
            return ShowConfirmationMsg(caption, body);
        }

        protected bool ShowConfirmationMsgWithSound(NotifyEventArgs args, BHTController bhtController)
        {
            bhtController.SoundConfirm();
            return ShowConfirmationMsg(args);
        }

        protected bool ShowConfirmationMsg(NotifyEventArgs args)
        {
            var getResult = ShowConfirmationMsg(args.Content.Keys.First().ToString(), args.Content.Values.First().ToString());
            return getResult;
        }

        protected bool ShowConfirmationMsg(string caption, string body)
        {
            return MessageUtility.DisplayConfirmationMsg(body, caption);
        }

        protected void ShowErrorMsgWithSound(string caption, string body, BHTController bhtController)
        {
            bhtController.SoundWarning();
            ShowErrorMsg(caption, body);
        }

        protected void ShowErrorMsgWithSound(NotifyEventArgs args, BHTController bhtController)
        {
            bhtController.SoundWarning();
            ShowErrorMsg(args);
        }

        protected void ShowErrorMsg(NotifyEventArgs args)
        {
            ShowErrorMsg(args.Content.Keys.First().ToString(), args.Content.Values.First().ToString());
        }

        protected void ShowErrorMsg(string caption, string body)
        {
            MessageUtility.DisplayErrorMsg(body, caption);
        }

        protected void ShowSuccessMsgWithSound(string caption, string body, BHTController bhtController)
        {
            bhtController.SoundOK();
            ShowSuccessMsg(caption, body);
        }

        protected void ShowSuccessMsgWithSound(NotifyEventArgs args, BHTController bhtController)
        {
            bhtController.SoundOK();
            ShowSuccessMsg(args);
        }

        protected void ShowSuccessMsg(NotifyEventArgs args)
        {
            ShowSuccessMsg(args.Content.Keys.First().ToString(), args.Content.Values.First().ToString());
        }

        protected void ShowSuccessMsg(string caption, string body)
        {
            MessageUtility.DisplayErrorMsg(body, caption);
        }
    }
}