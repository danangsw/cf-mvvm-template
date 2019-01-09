using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Linq.Expressions;

namespace DSW.Core.MVVM
{
    /// <summary>
    /// Base class for all two-way bindings.
    /// </summary>
    /// <typeparam name="TView">Type of view to bind to.</typeparam>
    /// <typeparam name="TControl">Type of control to bind to.</typeparam>
    /// <typeparam name="TViewModel">Type of viewmodel to bind to.</typeparam>
    internal abstract class TwoWayBinding<TView, TControl, TViewModel> : Binding<TView, TControl, TViewModel> where TViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <param name="view">The view to bind to.</param>
        /// <param name="control">The control to bind to.</param>
        /// <param name="viewProperty">The view property expression.</param>
        /// <param name="viewModel">The viewmodel to bind to.</param>
        /// <param name="viewModelProperty">The viewmodel property expression.</param>
        protected TwoWayBinding(TView view, TControl control, Expression<Func<TControl, object>> viewProperty,
            TViewModel viewModel,
            Expression<Func<TViewModel, object>> viewModelProperty)
            : base(view, control, viewProperty, viewModel, viewModelProperty)
        {
        }

        /// <summary>
        /// Updates the viewmodel with the curent value from the view.
        /// </summary>
        protected override void UpdateViewModel()
        {
            base.UpdateViewModel();
            var viewModel = BindingManager.GetViewModelFor<TViewModel>(View);

            var valueToSet = ViewPropertyInfo.GetValue(Control,null);
            ViewModelPropertyInfo.SetValue(viewModel, valueToSet,null);
        }
    }
}
