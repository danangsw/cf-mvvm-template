using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DSW.Core.MVVM.Exceptions
{
    public class InvalidBindingException : Exception
    {
        public InvalidBindingException()
        {
        }

        public InvalidBindingException(string message)
            : base(message)
        {
        }

        public InvalidBindingException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
