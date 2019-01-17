using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DSW.MVVM.Messages.Stocktake
{
    public class StocktakeNewMessage
    {
        public const string Cancel = "StocktakeNewMessage.Cancel";
        public const string InitialSetup = "StocktakeNewMessage.InitialSetup";
        public const string InitialSetupSucceded = "StocktakeNewMessage.InitialSetupSucceded";
        public const string InitialSetupFailed = "StocktakeNewMessage.InitialSetupFailed";
        public const string Sync = "StocktakeNewMessage.Sync";
        public const string SyncSucceded = "StocktakeNewMessage.SyncSucceded";
        public const string SyncFailed = "StocktakeNewMessage.SyncFailed";
        public const string GetLocation = "StocktakeNewMessage.GetLocation";
        public const string GetLocationSucceded = "StocktakeNewMessage.GetLocationSucceded";
        public const string GetLocationFailed = "StocktakeNewMessage.GetLocationFailed";
        public const string ShowLoading = "StocktakeNewMessage.ShowLoading";
        public const string CloseLoading = "StocktakeNewMessage.CloseLoading";

    }
}
