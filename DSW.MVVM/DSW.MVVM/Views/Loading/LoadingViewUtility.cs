using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DSW.Core.MVVM;

namespace DSW.MVVM.Views.Loading
{
    public static class LoadingUtility
    {
        public static LoadingView loadingForm;

        public static void ShowLoading<TViewModel>(this ViewBase<TViewModel> caller) where TViewModel : IViewModelBase
        {

            if (loadingForm == null)
            {
                loadingForm = new LoadingView();
            }
            else if (loadingForm.IsDisposed)
            {
                loadingForm = new LoadingView();
            }

            loadingForm.RunTaskEventHandler += caller.Loading_EventHandler;
            loadingForm.NotifyLoadingCloseHandler += caller.LoadingClose_EventHandler;
            caller.Invoke(new Action(() => loadingForm.ShowDialog()));

            //loadingForm.ShowDialog();


            ////caller.Invoke(new Action(() => loadingForm.ShowDialog()));

            //var callTask = Task.Factory.StartNew(() =>
            //    caller.Invoke(new Action(() => loadingForm.Show()))
            //    );

            //Task.WaitAll(callTask);

            //var callTask = Task.Factory.StartNew(() =>
            //    caller.BeginInvoke(new Action(() => loadingForm.Show()))
            //    );

            //Task.WaitAll(callTask);

            //var op = caller.BeginInvoke(new Action(() => loadingForm.Show()));
            //op.AsyncWaitHandle.WaitOne();
            //while (op.CompletedSynchronously != true)
            //{
            //    Task.Delay(25).RunSynchronously();
            //}

            //op.AsyncWaitHandle.WaitOne();
            //var result = callBack.EndInvoke(op);



            //op.
            //DispatcherOperationStatus status = op.CompletedSynchronously;
            //while (status != DispatcherOperationStatus.Completed)
            //{
            //    status = op.w(TimeSpan.FromMilliseconds(1000));
            //    if (status == DispatcherOperationStatus.Aborted)
            //    {
            //        // Alert Someone
            //    }
            //}
        }

        public static void CloseLoading<TViewModel>(this ViewBase<TViewModel> caller) where TViewModel : IViewModelBase
        {
            //if (!loadingForm.IsDisposed)
            //{
            //    caller.Invoke(new Action(() => loadingForm.Close()));
            //}

            if (loadingForm == null)
            {
                return;
            }
            else if (loadingForm.IsDisposed)
            {
                return;
            }

            loadingForm.InvokeClose();
            loadingForm = null;
        }
    }
}
