using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DSW.HT.Utility
{
    public static class SingleInstanceApplication
    {
        [DllImport("coredll.dll", SetLastError = true)]
        public static extern IntPtr CreateMutex(IntPtr Attr, bool Own, string Name);

        [DllImport("coredll.dll", SetLastError = true)]
        public static extern bool ReleaseMutex(IntPtr hMutex);

        const long ERROR_ALREADY_EXISTS = 183;

        public static bool IsExist()
        {
            var result = false;
            string name = Assembly.GetExecutingAssembly().GetName().Name;
            IntPtr mutexHandle = CreateMutex(IntPtr.Zero, true, name);
            long error = Marshal.GetLastWin32Error();

            if (error == ERROR_ALREADY_EXISTS)
            {
                result = true;
            }

            ReleaseMutex(mutexHandle);
            return result;
        }
    }
}
