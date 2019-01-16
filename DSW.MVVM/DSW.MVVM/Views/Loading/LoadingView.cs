using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Resources;
using System.IO;
using System.Threading;
using DSW.Core.Utility.Services;
using DSW.Core.Utility.Forms;

namespace DSW.MVVM.Views.Loading
{
    public partial class LoadingView : Form
    {
        public bool isAdd;
        public event EventHandler RunTaskEventHandler = delegate { };
        public event EventHandler NotifyLoadingCloseHandler = delegate { };
        protected CeHotKeys hotKeys;

        public LoadingView():base()
        {
            InitializeComponent();
            this.Menu = null;
            this.Activated += new EventHandler(LoginView_Activated);
            this.Load += new EventHandler(LoginView_OnLoad);
            this.Closing += new CancelEventHandler(LoadingView_Closing);
            this.Closed += new EventHandler(LoadingView_Closed);
            lblDotLeft.Text = string.Empty;
            lblDotRight.Text = string.Empty;
            isAdd = true;
            this.Deactivate += new EventHandler(LoadingView_Deactivate);

            MultiLanguageManager.SetDefaultLabelsDictionary<DSW.Localisation.Labels.Dictionary>();
        }

        void LoadingView_Deactivate(object sender, EventArgs e)
        {
            UnregisterHotKeys();
        }


        private void UnregisterHotKeys()
        {
            if (hotKeys != null)
            {
                //hotKeys.UnRegister(Keys.Enter);
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

            //hotKeys.Register(Keys.Enter);
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

        public virtual void CapturerSnapshot()
        {
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            Capturer.SnapshotWithMessageBox(this.Name + "_" + DateTime.Now.ToString("yyyy-MM-ddTHH_mm_ss") + DateTime.Now.TimeOfDay.TotalMilliseconds.ToString() + ".jpg", bounds);
        }

        void LoadingView_Closed(object sender, EventArgs e)
        {
            this.NotifyClosed();
        }

        void LoadingView_Closing(object sender, CancelEventArgs e)
        {
            timer1.Enabled = false;
        }

        void LoginView_Activated(object sender, EventArgs e)
        {
            InitializeHotKeys();
            SetLanguage();
        }

        void LoginView_OnLoad(object sender, EventArgs e)
        {
            Thread myThread = new Thread(new ThreadStart(RunTask));
            myThread.Start();

            this.SetLanguage();
        }

        public void RunTask()
        {
            EventHandler handler = RunTaskEventHandler;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        public void NotifyClosed()
        {
            EventHandler handler = NotifyLoadingCloseHandler;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }


        public void InvokeClose()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => this.Close()));
            }
            else
            {
                this.Close();
            }
        }

        public void SetLanguage()
        {
            lblPleaseWait.Text = MultiLanguageManager.Messages.GetString(DSW.Localisation.Labels.Dictionary.Common.HT_LBL_COM001);
        }

        private void marqueeTimer_Tick(object sender, EventArgs e)
        {
            if (isAdd)
            {
                lblDotLeft.Text = lblDotLeft.Text+ ".";
                lblDotRight.Text = lblDotRight.Text + ".";

                if (lblDotLeft.Text.Length == 5)
                {
                    isAdd = false;
                }
            }
            else
            {
                lblDotLeft.Text = lblDotLeft.Text.Remove(lblDotLeft.Text.Length -1);
                lblDotRight.Text = lblDotRight.Text.Remove(lblDotRight.Text.Length - 1);

                if (lblDotLeft.Text.Length == 0)
                {
                    isAdd = true;
                }
            }
        }
    }
}