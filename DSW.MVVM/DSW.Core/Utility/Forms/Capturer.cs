using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using DSW.Core.Utility.Forms;

namespace DSW.Core.Utility.Forms
{
    public class Capturer
    {
        // Declarations
        [DllImport("coredll.dll")]
        public static extern int BitBlt(IntPtr hdcDest, int nXDest, int nYDest,
            int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);

        [DllImport("coredll.dll")]
        private static extern IntPtr GetDC(IntPtr hwnd);

        const int SRCCOPY = 0x00CC0020;

        public static void SnapshotWithMessageBox(string fileName, Rectangle rectangle)
        {
            var filename = Capturer.Snapshot(fileName, rectangle);

            if (!String.IsNullOrEmpty(filename))
            {
                MessageUtility.DisplaySuccessMsg(string.Format("Screen captured file '{0}' saved successfully!", filename), "Success");
            }
            else
            {
                MessageUtility.DisplayErrorMsg("Screen capture failed!", "Error");
            }
        }

        public static string Snapshot(string fileName, Rectangle rectangle)
        {
            try
            {
                //Use a zeropointer to get hold of the screen context
                IntPtr deviceContext = GetDC(IntPtr.Zero);

                using (Bitmap capture = new Bitmap(rectangle.Width, rectangle.Height))
                //Get screen context
                using (Graphics deviceGraphics = Graphics.FromHdc(deviceContext))
                //Get graphics from bitmap
                using (Graphics captureGraphics = Graphics.FromImage(capture))
                {
                    // Blit the image data
                    BitBlt(captureGraphics.GetHdc(), 0, 0,
                        rectangle.Width, rectangle.Height, deviceGraphics.GetHdc(),
                        rectangle.Left, rectangle.Top, SRCCOPY);

                    //Save to disk
                    capture.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
                }

                return fileName;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
