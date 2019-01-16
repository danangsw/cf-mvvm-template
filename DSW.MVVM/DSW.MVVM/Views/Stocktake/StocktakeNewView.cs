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

namespace DSW.MVVM.Views.Stocktake
{
    public partial class StocktakeNewView : StocktakeNewViewBase
    {
        public StocktakeNewView()
        {
            InitializeComponent();

            this.Activated += new EventHandler(StocktakeNewView_Activated);
            this.Load += new EventHandler(StocktakeNewView_Load);
            this.Deactivate += new EventHandler(StocktakeNewView_Deactivate);

            this.Menu = null;
        }

        void StocktakeNewView_Activated(object sender, EventArgs e)
        {
            this.SetLanguage();
        }

        void StocktakeNewView_Load(object sender, EventArgs e)
        {
            this.SetLanguage();
        }

        void StocktakeNewView_Deactivate(object sender, EventArgs e)
        {
        }

        public override void BindViewModel(StocktakeNewViewModel viewModel)
        {
            base.BindViewModel(viewModel);

            BindingManager.Bind(this).To(viewModel);

            BindingManager.For(this).BindCommand(btnContinue).To(viewModel, _ => _.ContinueCommand);
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