using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using log4net;
using DSW.HT.Utility;
using System.Windows.Forms;
using DSW.HT.Views.Stocktake;
using DSW.Core.Utility.Services;
using DSW.Core.Utility.Forms;
using DSW.HT;
using DSW.Core.MVVM;

namespace DSW.Main
{
    static class Program
    {
        [MTAThread]
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure();
            ILog log = LogManager.GetLogger(typeof(Program));

            try
            {
                log.Info(LogFormat.Message("", "Application_start", LogStatus.Success, ""));

                MultiLanguageManager.SetDefaultLabelsDictionary<DSW.Localisation.Labels.Dictionary>();
                MultiLanguageManager.SetDefaultMessageDictionary<DSW.Localisation.Messages.Dictionary>();

                if (SingleInstanceApplication.IsExist())
                {
                    FormUtility.EnableTaskBar(false);
                    FormUtility.EnableTaskBar(true);

                    MessageUtility.DisplayErrorMsg(DSW.Localisation.Messages.Dictionary.Common.HT_COM_MS029,
                        DSW.Localisation.Messages.Dictionary.Common.HT_COM_CAP001);

                    log.Info(LogFormat.Message("", "Application_end", LogStatus.Failed, DSW.Localisation.Messages.Dictionary.Common.HT_COM_MS029));

                    Application.Exit();

                    return;
                }

                FormUtility.EnableTaskBar(false);

                var appModule = new AppModule();
                var mvvmApplication = new MvvmApplication(appModule);

                mvvmApplication.Run<StocktakeNewView>();

                FormUtility.EnableTaskBar(true);

                log.Info(LogFormat.Message("", "Application_end", LogStatus.Success, ""));

                LogManager.Shutdown();
            }
            catch (Exception ex)
            {
                log.Info(LogFormat.Message("", "Application_end", LogStatus.Failed, ex.Message + Environment.NewLine + ex.StackTrace));

                LogManager.Shutdown();

                Application.Exit();
            }
        }
    }
}
