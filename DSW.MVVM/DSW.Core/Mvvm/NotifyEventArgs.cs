using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DSW.Core.MVVM
{

    public delegate void NotifyEventHandler(object sender, NotifyEventArgs args);

    public class NotifyEventArgs
    {
        public NotifyEventArgs(string tag, Dictionary<string, object> content)
        {
            _tag = tag;
            _content = content;
        }
        private string _tag;

        public string Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }

        private Dictionary<string, object> _content;

        public Dictionary<string, object> Content
        {
            get { return _content; }
            set { _content = value; }
        }
    }
}
