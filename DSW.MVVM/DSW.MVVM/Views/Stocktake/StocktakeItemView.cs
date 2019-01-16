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
    public partial class StocktakeItemView : StocktakeItemViewBase
    {
        public StocktakeItemView()
        {
            InitializeComponent();

            this.Menu = null;
        }
    }

    public class StocktakeItemViewBase : ViewBase<StocktakeItemViewModel>
    {
        public StocktakeItemViewBase() : base() { }
    }
}