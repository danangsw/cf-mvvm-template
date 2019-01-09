using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Resources;
using System.Threading;
using System.Reflection;
using System.Globalization;

namespace DSW.Core.Utility.Services
{
    public static class MultiLanguageManager 
    {
        public static ResourceManager Labels;
        public static ResourceManager Messages;
        private static Assembly AssemblyResouces;
        private static string LabelsNamespace;
        private static string MessagesNamespace;
        public const string Id = "TRAD.CF.NET_CultureUI";


        public static void SetDefaultMessageDictionary<T>() where T : class
        {
            var currentUICulture = "en-US";
            var type = typeof(T);
            MessagesNamespace = type.Namespace;
            AssemblyResouces = Assembly.LoadFrom(type.Assembly.ManifestModule.Name);
            Messages = new ResourceManager(string.Format("{0}.{1}", type.Namespace, currentUICulture), AssemblyResouces);
        }

        public static void SetDefaultLabelsDictionary<T>() where T : class
        {
            var type = typeof(T);
            LabelsNamespace = type.Namespace;
            var currentUICulture = "en-US";
            AssemblyResouces = Assembly.LoadFrom(type.Assembly.ManifestModule.Name);
            Labels = new ResourceManager(string.Format("{0}.{1}", type.Namespace, currentUICulture), AssemblyResouces);
        }

        public static void SetLabelsDictionary<T>() where T:class
        {
            var type = typeof(T);
            LabelsNamespace = type.Namespace;
            var currentUICulture = ThreadManager.GetData(Id) as string;
            AssemblyResouces = Assembly.LoadFrom(type.Assembly.ManifestModule.Name);
            Labels = new ResourceManager(string.Format("{0}.{1}", type.Namespace, currentUICulture), AssemblyResouces); 
        }

        public static void SetMessagesDictionary<T>() where T : class
        {
            var type = typeof(T);
            MessagesNamespace = type.Namespace;
            var currentUICulture = ThreadManager.GetData(Id) as string;
            AssemblyResouces = Assembly.LoadFrom(type.Assembly.ManifestModule.Name);
            Messages = new ResourceManager(string.Format("{0}.{1}", type.Namespace, currentUICulture), AssemblyResouces);
        }

        public static void SetCultureForLabelAndMessage()
        {
            var currentUICulture = ThreadManager.GetData(Id) as string;
            Messages = new ResourceManager(string.Format("{0}.{1}", MessagesNamespace, currentUICulture), AssemblyResouces);
            Labels = new ResourceManager(string.Format("{0}.{1}", LabelsNamespace, currentUICulture), AssemblyResouces);
        }
    }

}
