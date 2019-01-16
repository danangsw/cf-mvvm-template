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
    public partial class SocktakeDetailView : SocktakeDetailViewBase
    {
        public SocktakeDetailView()
        {
            InitializeComponent();

            this.Menu = null;
        }
    }

    public class SocktakeDetailViewBase : ViewBase<StocktakeDetailViewModel>
    {
        public SocktakeDetailViewBase() : base() { }
    }
}