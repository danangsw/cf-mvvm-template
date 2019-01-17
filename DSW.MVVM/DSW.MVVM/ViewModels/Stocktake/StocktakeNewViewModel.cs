using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DSW.Core.MVVM;
using DSW.MVVM.Commands.Stocktake;
using DSW.MVVM.Models.Stocktake;
using DSW.Core.Mvvm;
using DSW.MVVM.Views.Stocktake;
using DSW.MVVM.Messages.Stocktake;
using DSW.Service.Business;

namespace DSW.MVVM.ViewModels.Stocktake
{
    public class StocktakeNewViewModel : ViewModelBase
    {
        protected IMvvmNavigator MvvmNavigator;
        protected IInitialSetupService InitialSetupService;
        public const string SetInitialDataSyncExecution = "StocktakeNewViewModel.SetInitialDataSyncExecution";
        public const string GetLocationDataSyncExecution = "StocktakeNewViewModel.GetLocationDataSyncExecution";

        public StocktakeNewViewModel(
            IMvvmNavigator mvvmNavigator,
            IInitialSetupService initialSetupService
            )
        {
            this.MvvmNavigator = mvvmNavigator;
            this.InitialSetupService = initialSetupService;

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

        public override void HandleCloseLoadingProcess()
        {
            switch (CurrentTypeHandleLoadingProcess)
            {
                case StocktakeNewViewModel.SetInitialDataSyncExecution:
                    break;
                default:
                    break;
            }
        }

        public override void HandleLoadingProcess()
        {
            switch (CurrentTypeHandleLoadingProcess)
            {
                case StocktakeNewViewModel.SetInitialDataSyncExecution:
                    this.InitialSetupProcess();
                    break;
                case StocktakeNewViewModel.GetLocationDataSyncExecution:
                    this.GetLocationProcess();
                    break;
                default:
                    break;
            }
        }

        public void Continue() {
            var vMMessage = new ViewModelMessage<StocktakeNewViewModel, StocktakeNewModel>
                        (this, this.StocktakeNewModel);

            this.MvvmNavigator.ShowView<StocktakeItemView>(vMMessage);
        }

        public void GetLocations() {
            CurrentTypeHandleLoadingProcess = StocktakeNewViewModel.GetLocationDataSyncExecution;

            NotifyView(StocktakeNewMessage.GetLocation,
                    null,
                    null);
        }

        public void GetLocationProcess()
        {
        }

        public void InitialSetup() {
            CurrentTypeHandleLoadingProcess = StocktakeNewViewModel.SetInitialDataSyncExecution;

            NotifyView(StocktakeNewMessage.InitialSetup,
                    null,
                    null);
        }

        public void InitialSetupProcess() {
            var response = this.InitialSetupService.InitialSetup();

            if (!response.Succeeded)
            {
                NotifyView(StocktakeNewMessage.InitialSetupFailed,
                    null,
                    null);
            }
        }
    }
}
