using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DSW.Core.MVVM
{
     /// <summary>
    /// Binding configuration.
    /// </summary>
    public sealed class BindingConfiguration
    {
        /// <summary>
        /// Gets or sets the value indicating whether this binding should be a two-way binding. Default: false
        /// </summary>
        /// 
        private bool _IsTwoWay = false;
        public bool IsTwoWay { 
            get {
                return _IsTwoWay;
            }
            set {
                _IsTwoWay = value;
            }
        }

        /// <summary>
        /// Gets or sets the update source trigger  to use with the binding. Default: UpdateSourceType.OnPropertyChanged
        /// </summary>
        /// 
        private UpdateSourceType _UpdateSourceTrigger = UpdateSourceType.OnPropertyChanged;
        public UpdateSourceType UpdateSourceTrigger { 
            get {
                return _UpdateSourceTrigger;
            } set{
            
                _UpdateSourceTrigger =value;
            }
        }

    }

        /// <summary>
        /// The update source trigger type.
        /// </summary>
        public enum UpdateSourceType
        {
            /// <summary>
            /// The binding source is updated every time the current value changes in the view.
            /// </summary>
            OnPropertyChanged,

            /// <summary>
            /// The binding source is updated when the target control loses focus.
            /// </summary>
            LostFocus
        }
}
