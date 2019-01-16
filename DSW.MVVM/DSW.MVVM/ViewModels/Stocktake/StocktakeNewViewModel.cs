using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DSW.Core.MVVM;
using DSW.MVVM.Commands.Stocktake;
using DSW.MVVM.Models.Stocktake;
using DSW.Core.Mvvm;
using DSW.MVVM.Views.Stocktake;

namespace DSW.MVVM.ViewModels.Stocktake
{
    public class StocktakeNewViewModel : ViewModelBase
    {
        protected IMvvmNavigator MvvmNavigator;

        public StocktakeNewViewModel(
            IMvvmNavigator mvvmNavigator
            )
        {
            this.MvvmNavigator = mvvmNavigator;

            continueCommand = new ContinueCommand(this);
            continueCommand.CanExecuteProperty = true;
        }

        public StocktakeNewModel StocktakeNewModel { get; set; }

        private ContinueCommand continueCommand;
        public ContinueCommand ContinueCommand
        {
            get
            {
                return continueCommand;
            }
        }

        public void Continue() {
            var vMMessage = new ViewModelMessage<StocktakeNewViewModel, StocktakeNewModel>
                        (this, this.StocktakeNewModel);

            this.MvvmNavigator.ShowView<StocktakeItemView>(vMMessage);
        }
    }
}
