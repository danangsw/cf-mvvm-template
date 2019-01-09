using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DSW.Core.Utility.Forms
{
    public class FormUtility
    {
        public static void EnterFullScreenMode(Form targetForm)
        {
            targetForm.Height = Screen.PrimaryScreen.Bounds.Height;
            targetForm.Width = Screen.PrimaryScreen.Bounds.Width;
        }

        [DllImport("Coredll")]
        internal static extern IntPtr FindWindow(String lpClassName, String lpWindowName);

        [DllImport("coredll.dll")]
        internal static extern bool EnableWindow(IntPtr hwnd, Boolean bEnable);

        [DllImport("coredll.dll")]
        private static extern bool MoveWindow(IntPtr hWnd, int x, int y, int cx, int cy, bool repaint);

        public static bool EnableTaskBar(Boolean enable)
        {
            IntPtr hwnd;
            hwnd = FindWindow("HHTaskBar", "");

            if (enable) SetHHTaskBar();
            else HideHHTaskBar();

            return EnableWindow(hwnd, enable);
        }

        public static void HideHHTaskBar()
        {
            IntPtr iptrTB = FindWindow("HHTaskBar", null);
            MoveWindow(iptrTB, 0, Screen.PrimaryScreen.Bounds.Height,
            Screen.PrimaryScreen.Bounds.Width, 26, true);
        }

        public static void SetHHTaskBar()
        {
            IntPtr iptrTB = FindWindow("HHTaskBar", null);
            MoveWindow(iptrTB, 0, Screen.PrimaryScreen.Bounds.Height - 26,
            Screen.PrimaryScreen.Bounds.Width, 26, true);
        }

    }
}
