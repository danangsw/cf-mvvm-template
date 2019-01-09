using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.WindowsCE.Forms;
using System.Windows.Forms;

namespace DSW.Core.Utility.Services
{
    public class CeHotKeys
    {
        #region dll imports
        [DllImport("coredll.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);

        [DllImport("coredll.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        #endregion

        public enum KeyModifiers
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            Windows = 8,
            Modkeyup = 0x1000
        }

        public delegate void KeyPressedEventHandler(Keys key);

        public event KeyPressedEventHandler KeyPressed;

        private readonly HotKeyMessageWindow wnd;

        public CeHotKeys()
        {
            wnd = new HotKeyMessageWindow(this);
        }

        public void Register(Keys key, KeyPressedEventHandler keyPressed)
        {
            Register(key);
            keyPressed += keyPressed;
        }

        public void Register(Keys key)
        {
            RegisterHotKey(wnd.Hwnd, (int)key, 0, (int)key);
        }

        public void UnRegister(Keys key)
        {
            UnregisterHotKey(wnd.Hwnd, (int)key);
        }

        public void Register(Keys key, KeyModifiers Modifier)
        {
            RegisterHotKey(wnd.Hwnd, (int)key, (int)Modifier, (int)key);
        }

        public void OnKeyPressed(Keys key)
        {
            //forward the keypress event to the outside world.
            if (KeyPressed != null)
            {
                KeyPressed(key);
            }
        }
    }

    public class HotKeyMessageWindow : MessageWindow
    {
        private const int WM_HOTKEY = 0x312;
        private readonly CeHotKeys parent;

        public HotKeyMessageWindow(CeHotKeys h)
        {
            parent = h;
        }

        protected override void WndProc(ref Message msg)
        {
            switch (msg.Msg)
            {
                case WM_HOTKEY:
                    {
                        int keyNum = msg.WParam.ToInt32();
                        Keys key = (Keys)keyNum;
                        parent.OnKeyPressed(key);
                        break;
                    }
                default:
                    {
                        base.WndProc(ref msg);
                        break;
                    }
            }
        }
    }
}
