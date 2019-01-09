using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DSW.Core.Utility.Services;
using System.Resources;

namespace DSW.Core.MVVM
{

    public interface IViewModelBase : INotifyPropertyChanged {
        void SetData(object data);
        void OnPropertyChanged([CallerMemberName] string propertyName);
        void HandleLoadingProcess();
        void HandleCloseLoadingProcess();
        event NotifyEventHandler NotifyViewEventHandler;
        event NotifyEventHandler NotifyViewModelChildHandler;
        event NotifyEventHandler NotifyViewModelParentHandler;
        void ViewModel_NotifyViewModelChildHandler(object sender, NotifyEventArgs args);
        void ViewModel_NotifyViewModelParentHandler(object sender, NotifyEventArgs args);
        void ClosedView();
        void IsChildActiveEvent();
    }

    public class ViewModelBase : IViewModelBase
    {

        public event PropertyChangedEventHandler PropertyChanged;
        public event NotifyEventHandler NotifyViewEventHandler = delegate { };
        public event NotifyEventHandler NotifyViewModelChildHandler = delegate { };
        public event NotifyEventHandler NotifyViewModelParentHandler = delegate { };

        public ResourceManager ResxLabels { get { return MultiLanguageManager.Labels; } }
        public ResourceManager ResxMessages { get { return MultiLanguageManager.Messages; } }
        public string CurrentTypeHandleLoadingProcess { get; set; }
   
        private bool isChildActive;
        public bool IsChildActive
        {
            get
            {
                return isChildActive;
            }
            set
            {
                isChildActive = value;
                IsChildActiveEvent();
                OnPropertyChanged("IsChildActive");
            }
        }

        public virtual void IsChildActiveEvent()
        {

        }

        public void OnPropertyChanged([CallerMemberName] string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public void NotifyViewModelChild(NotifyEventArgs e)
        {
            NotifyEventHandler handler = NotifyViewModelChildHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void NotifyViewModelParent(NotifyEventArgs e)
        {
            NotifyEventHandler handler = NotifyViewModelParentHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        
        public void NotifyView(NotifyEventArgs e)
        {
            NotifyEventHandler handler = NotifyViewEventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void NotifyView(string tag, string captionResourceName, string contentResourceName)
        {
            var messages = new Dictionary<string, object>();

            if (!string.IsNullOrEmpty(captionResourceName) && !string.IsNullOrEmpty(contentResourceName))
            {
                var caption = GetResxMessagesString(captionResourceName);
                var content = GetResxMessagesString(contentResourceName);
                messages.Add(caption, content);
            }

            NotifyView(new NotifyEventArgs(tag, messages));
        }
        
        public virtual void ViewModel_NotifyViewModelChildHandler(object sender, NotifyEventArgs args)
        {

        }

        public virtual void ViewModel_NotifyViewModelParentHandler(object sender, NotifyEventArgs args)
        {

        }

        public virtual void HandleLoadingProcess()
        {

        }

        public virtual void HandleCloseLoadingProcess()
        {

        }

        public virtual void SetData(object data)
        {
        }

        public virtual void ClosedView()
        {

        }

        private string GetResxMessagesString(string key)
        {
            string value = String.Empty;

            try
            {
                value = ResxMessages.GetString(key);

                if (string.IsNullOrEmpty(value))
                {
                    value = key;
                }
            }
            catch (Exception)
            {
                value = key;
            }

            return value;
        }
    }
}
