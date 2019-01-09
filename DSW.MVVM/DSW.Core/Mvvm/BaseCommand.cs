using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DSW.Core.MVVM
{
    public class BaseCommand<T> : ICommand where T : IViewModelBase
    {
        protected readonly T _vm;
        private bool _canExecuteProperty;

        public BaseCommand(T vm)
        {
            _vm = vm;
        }

        public virtual event EventHandler CanExecuteChanged;

        public virtual bool CanExecuteProperty
        {
            get
            {
                return _canExecuteProperty;
            }

            set
            {
                _canExecuteProperty = value;
                OnCanExecuteChanged();
            }
        }

        public virtual bool CanExecute()
        {
            return _canExecuteProperty;
        }

        public virtual void Execute()
        {
            // call view model property here
        }

        public virtual void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged();
        }

        protected virtual void OnCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
