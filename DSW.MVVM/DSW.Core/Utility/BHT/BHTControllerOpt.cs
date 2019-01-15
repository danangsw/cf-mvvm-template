using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DNWA.BHTCL;
using System.Windows.Forms;

namespace DSW.Core.Utility.BHT
{
    public class BHTControllerOpt : BHTController
    {
        private static BHTControllerOpt _BHTControllerOpt;

        // Lock synchronization object
        private static object syncLock = new object();
        private static object syncLockScanner = new object();

        protected BHTControllerOpt() 
        {
        }

        public static BHTController Create()
        {
            // Support multithreaded applications through
            // 'Double checked locking' pattern which (once
            // the instance exists) avoids locking each
            // time the method is invoked
            if (_BHTControllerOpt == null)
            {
                lock (syncLock)
                {
                    if (_BHTControllerOpt == null)
                    {
                        _BHTControllerOpt = new BHTControllerOpt();
                    }
                }
            }

            return _BHTControllerOpt;
        }

        public static BHTController Create(TextBox labelScan)
        {
            if (_BHTControllerOpt == null)
            {
                lock (syncLock)
                {
                    if (_BHTControllerOpt == null)
                    {
                        _BHTControllerOpt = new BHTControllerOpt();

                        if (_BHTControllerOpt.MyScanner == null)
                        {
                            lock (syncLockScanner)
                            {
                                _BHTControllerOpt.MyScanner = new Scanner();
                                _BHTControllerOpt.MyScanner.RdMode = _BHTControllerOpt.MyScanner.DEFAULT_RD_MODE;
                                _BHTControllerOpt.MyScanner.RdType = _BHTControllerOpt.MyScanner.DEFAULT_RD_TYPE;
                                _BHTControllerOpt.MyScanner.OnDone += _BHTControllerOpt.MyScanner_OnDone;
                                _BHTControllerOpt.LabelScan = labelScan;
                            }
                        }
                    }
                }
            }

            return _BHTControllerOpt;
        }
    }
}
