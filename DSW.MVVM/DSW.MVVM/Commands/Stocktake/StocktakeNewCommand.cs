using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DSW.MVVM.ViewModels.Stocktake;
using DSW.Core.MVVM;

namespace DSW.MVVM.Commands.Stocktake
{
    public class ContinueCommand : BaseCommand<StocktakeNewViewModel>
    {
        public ContinueCommand(StocktakeNewViewModel vm)
            : base(vm)
        {
        }

        public override void Execute()
        {
            _vm.Continue();
        }
    }
}
