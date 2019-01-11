using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using log4net;
using DSW.HT.Utility;
using System.Windows.Forms;
using DSW.HT.Views.Stocktake;
using DSW.Core.Utility.Services;

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

                if (SingleInstanceApplication.IsExist())
                {
                    Application.Exit();

                    return;
                }

                Application.Run(new StocktakeNewView());

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
