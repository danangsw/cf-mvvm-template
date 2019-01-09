using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Ninject;
using System.Windows.Forms;

namespace DSW.Core.MVVM
{
    public interface IMvvmNavigator
    {
        void ShowView<T>() where T : Form;
        void ShowView<T>(object data) where T : Form;
        Form CreateView(Type viewType, object data);
    }

    public class MvvmNavigator : IMvvmNavigator
    {
        private readonly IKernel Kernel;
        public MvvmNavigator(IKernel kernel)
        {
            Kernel = kernel;
        }

        public Form CreateView(Type viewType,object data)
        {
            var setBindViewModelMethodInfo = viewType.GetMethod("BindViewModel");
            var viewModelType = GetViewModelType(viewType);
            var viewModel = Kernel.Get(viewModelType);

            if (data != null)
            {
                var setDataMethodInfo = viewModelType.GetMethod("SetData");
                setDataMethodInfo.Invoke(viewModel, new[] { data });
            }

            Form form = Activator.CreateInstance(viewType) as Form;
            setBindViewModelMethodInfo.Invoke(form, new[] { viewModel });

            return form;
        }

        public void ShowView<T>() where T:Form
        {
            var viewTypeForm = typeof(T);
            var view = CreateView(viewTypeForm, null);
            view.Show();
        }

        public void ShowView<T>(object data) where T : Form
        {
            var viewTypeForm = typeof(T);
            var view = CreateView(viewTypeForm, data);
            view.Show();
        }

        private Type GetViewModelType(Type viewType)
        {
            Stack<Type> baseTypes = new Stack<Type>();
            baseTypes.Push(viewType);

            Type baseType;
            Type currentType = viewType;
            while ((baseType = currentType.BaseType).Name != "Object")
            {
                baseTypes.Push(baseType);
                currentType = baseType;
            }

            while ((currentType = baseTypes.Pop()) != viewType)
            {
                if (currentType.Name.StartsWith("ViewBase") && currentType.IsGenericType)
                {
                    return currentType.GetGenericArguments()[0];
                }
            }
            return null;
        }
    }
}
