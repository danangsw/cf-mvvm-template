using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DSW.Core.MVVM;
using DSW.MVVM.ViewModels.Stocktake;

namespace DSW.HT.Views.Stocktake
{
    public partial class StocktakeNewView : StocktakeNewViewBase
    {
        public StocktakeNewView()
        {
            InitializeComponent();

            this.Menu = null;

            this.SetLanguage();
        }

        public override void SetLanguage()
        {
            btnContinue.Text = ResxLabels.GetString(DSW.Localisation.Labels.Dictionary.Stocktake.HT_BTN_STT001);
            lblLocation.Text = ResxLabels.GetString(DSW.Localisation.Labels.Dictionary.Stocktake.HT_LBL_STT001);
            lblItemLocationCount.Text = String.Format(ResxLabels.GetString(DSW.Localisation.Labels.Dictionary.Stocktake.HT_LBL_STT002), 0);
        }
    }

    public class StocktakeNewViewBase : ViewBase<StocktakeNewViewModel>
    {
        public StocktakeNewViewBase() : base() { }
    }
}