using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.ComponentModel;

namespace DSW.Core.MVVM
{
    /// <summary>
    /// Command binding builder.
    /// </summary>
    /// <typeparam name="TView">Type of view to bind to.</typeparam>
    /// <typeparam name="TControl">Type of control to bind to.</typeparam>
    public class CommandBindingBuilder<TView, TControl> : BindingBuilder<TView>
    {
        /// <summary>
        /// Gets the control.
        /// </summary>

        private TControl _Control;
        protected TControl Control { get { return _Control; } }

        /// <summary>
        /// Creates a new isntance of the CommandBindingBuilder class.
        /// </summary>
        /// <param name="view">The view to bind to.</param>
        /// <param name="control">The control to bind to.</param>
        /// <exception cref="ArgumentNullException">Thrown when control is null.</exception>
        internal CommandBindingBuilder(TView view, TControl control)
            : base(view)
        {
            if (control == null)
            {
                throw new ArgumentNullException("Extensions.nameof(()=>control)");
            }

            _Control = control;
        }

        /// <summary>
        /// Configures the binding to bind to the specified viewmodel.
        /// </summary>
        /// <typeparam name="TViewModel">Type of the viewmodel to bind to.</typeparam>
        /// <param name="viewModel">The viewmodel to bind to.</param>
        /// <param name="viewModelProperty">The viewmodel' property to bind to.</param>
        /// <exception cref="ArgumentNullException">Thrown when the viewModel or viewModelProperty is null.</exception>
        /// <returns>The constructed command binding.</returns>
        public Binding To<TViewModel>(TViewModel viewModel, Expression<Func<TViewModel, ICommand>> viewModelProperty) where TViewModel : INotifyPropertyChanged
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException("Extensions.nameof(() => viewModel)");
            }

            if (viewModelProperty == null)
            {
                throw new ArgumentNullException("Extensions.nameof(() => viewModelProperty)");
            }

            var binding = BindingFactory.BuildCommand(View, Control, viewModel, viewModelProperty);

            BindingManager.AddBinding(binding);

            return binding;
        }
    }
}
