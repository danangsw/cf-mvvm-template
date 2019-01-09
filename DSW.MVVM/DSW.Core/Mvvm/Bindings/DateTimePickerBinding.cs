using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;
using System.Linq.Expressions;

namespace DSW.Core.MVVM.Bindings
{

    internal sealed class DateTimePickerBinding<TView, TViewModel> : TwoWayBinding<TView, DateTimePicker, TViewModel>
        where TViewModel : INotifyPropertyChanged
    {

        public DateTimePickerBinding(TView view, DateTimePicker control, Expression<Func<DateTimePicker, object>> viewProperty,
            TViewModel viewModel,
            Expression<Func<TViewModel, object>> viewModelProperty)
            : base(view, control, viewProperty, viewModel, viewModelProperty)
        {
            Debug.Assert(ViewPropertyInfo.Name == "Value");
        }


        protected internal override void HookEvents()
        {
            base.HookEvents();
            Control.ValueChanged += Control_ValueChanged;
        }

        private void Control_ValueChanged(object sender, EventArgs e)
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
            Control.ValueChanged -= Control_ValueChanged;
            base.UnhookEvents();
        }

        internal override void Unbind()
        {
            UnhookEvents();
            base.Unbind();
        }
    }
}
