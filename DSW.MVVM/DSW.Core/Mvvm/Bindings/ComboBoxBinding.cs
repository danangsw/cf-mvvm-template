using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq.Expressions;

namespace DSW.Core.MVVM.Bindings
{
    internal sealed class ComboBoxBinding<TView, TViewModel> : TwoWayBinding<TView, ComboBox, TViewModel>
        where TViewModel : INotifyPropertyChanged
    {

        public ComboBoxBinding(TView view, ComboBox control, Expression<Func<ComboBox, object>> viewProperty,
            TViewModel viewModel,
            Expression<Func<TViewModel, object>> viewModelProperty)
            : base(view, control, viewProperty, viewModel, viewModelProperty)
        {
            Debug.Assert(ViewPropertyInfo.Name == "SelectedIndex");
        }


        protected internal override void HookEvents()
        {
            base.HookEvents();
            Control.SelectedIndexChanged += Control_SelectedIndexChanged;
        }

        private void Control_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateViewModel();
        }

        protected override void UpdateViewModel()
        {
            if (Configuration.IsTwoWay)
            {
                base.UpdateViewModel();
            }
        }

        protected override void UnhookEvents()
        {
            Control.SelectedIndexChanged -= Control_SelectedIndexChanged;
            base.UnhookEvents();
        }

        internal override void Unbind()
        {
            UnhookEvents();
            base.Unbind();
        }
    }
}
