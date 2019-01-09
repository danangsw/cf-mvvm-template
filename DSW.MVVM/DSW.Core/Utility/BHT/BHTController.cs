using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DNWA.BHTCL;
using System.Windows.Forms;

namespace DSW.Core.Utility.BHT
{
    public class BHTController
    {

        private Beep MyBeep;
        private LED MyLed;
        private LED.EN_COLOR activeLedColor;
        private Scanner MyScanner;
        private ScannerCodeType CodeType;
        private ScannerReadMode Mode;
        public event EventHandler ScannerDoneHandler = delegate { };
        private TextBox LabelScan;

        public BHTController()
        {
            try
            {
                MyBeep = new Beep();
                MyLed = new LED();
                
            }
            catch (Exception ex)
            {
                MyScanner = (Scanner)null;
                MessageBox.Show("Error: Please make sure kbif software is not running " + ex.Message, "Scan Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }

        private void MyScanner_OnDone(object sender, EventArgs e)
        {
            SoundConfirm();
            LabelScan.Text = string.Empty;
            LabelScan.Text = MyScanner.Input(Scanner.ALL_BUFFER);
        }

        public static BHTController Create(TextBox labelScan)
        {
            var bhtController = new BHTController();
            
            var myScanner = new Scanner();
            myScanner.RdMode = myScanner.DEFAULT_RD_MODE;
            myScanner.RdType = myScanner.DEFAULT_RD_TYPE;
            myScanner.OnDone += bhtController.MyScanner_OnDone;
            bhtController.MyScanner = myScanner;
            bhtController.LabelScan = labelScan;
            return bhtController;
        }

        public static BHTController Create()
        {
            var bhtController = new BHTController();
            return bhtController;
        }


        public void DisposeScanner()
        {
            ScannerPortMgmt(false);
            MyScanner.OnDone -= ScannerDoneHandler;
            MyScanner.Dispose();
            MyScanner = null;
        }

        public void SetScannerReadType(String readType)
        {
            ScannerPortMgmt(false);
            MyScanner.RdType = readType;
            ScannerPortMgmt(true);
        }

        public void ScannerPortMgmt(Boolean portIsOpen)
        {
            if (MyScanner == null)
            {
                return;
            }
            try
            {
                if (MyScanner.PortOpen)
                {
                    MyScanner.PortOpen = false;
                }
                MyScanner.PortOpen = portIsOpen;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Scan Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }
       
        public void SoundWarning()
        {
            ActiveBeeper((int)BeeperFrequency.F,2,4);
        }

        public void SoundOK()
        {
            ActiveBeeper((int)BeeperFrequency.D,1,2);
        }

        public void SoundConfirm()
        {
            ActiveBeeper((int)BeeperFrequency.D,1,1);
        }

        public void SoundError()
        {
            ActiveBeeper((int)BeeperFrequency.G, 2, 4);
        }

        public void ActiveBeeper(int frequency, int onTime, int count)
        {
            MyBeep.Frequency = frequency;
            MyBeep.OnTime = onTime;
            MyBeep.Count = count;
            Beep.Settings.Volume = Beep.Settings.EN_VOLUME.LEVEL2; 
            MyBeep[Beep.Settings.EN_DEVICE.BUZZER |
                Beep.Settings.EN_DEVICE.VIBRATOR] = Beep.EN_CTRL.ON;    
        }

        public enum BeeperFrequency{
            C = 261,
            D = 2349,
            E = 2637,
            F = 2793,
            G = 3135,
            A = 3520,
            B = 3951,
        }
        
        public enum ScannerCodeType
        {
            Code39,
            QrCode
        }

        public enum ScannerReadMode
        {
            Momentary,
            AutoOff,
            Alternate,
            Continous,
            TriggerRelease
        }



    }
}
