using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace DSW.Core.Utility.Forms
{
    public class AnimateCtl : System.Windows.Forms.Control
    {
        Timer fTimer;
        int frameWidth = 48;
        int frameHeight = 48;
        int loopCount = 0;
        int loopCounter = 0;
        int frameCount;
        int currentFrame = 0;
        Graphics graphics;

        private Bitmap bitmap;
        public Bitmap Bitmap
        {
            get
            {
                return bitmap;
            }
            set
            {
                bitmap = value;
            }
        }


        public AnimateCtl()
        {
            //Cache the Graphics object
            graphics = this.CreateGraphics();
            //Instantiate the Timer
            fTimer = new System.Windows.Forms.Timer();
            //Hook up to the Timer's Tick event
            fTimer.Tick += new System.EventHandler(this.timer1_Tick);
        }

        /// <summary>
        /// Start animation
        /// </summary>
        /// <param name="frWidth"></param>
        /// <param name="DelayInterval"></param>
        /// <param name="LoopCount"></param>
        public void StartAnimation(int frWidth, int DelayInterval, int LoopCount)
        {

            frameWidth = frWidth;
            //How many times to loop
            loopCount = LoopCount;
            //Reset loop counter
            loopCounter = 0;
            //Calculate the frameCount
            frameCount = bitmap.Width / frameWidth;
            frameHeight = bitmap.Height;
            //Resize the control
            //this.Size(frameWidth, frameHeight);
            //Assign delay interval to the timer
            fTimer.Interval = DelayInterval;
            //Start the timer
            fTimer.Enabled = true;
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            if (loopCount == -1) //loop continuously
            {
                this.DrawFrame();
            }
            else
            {
                if (loopCount == loopCounter) //stop the animation
                    fTimer.Enabled = false;
                else
                    this.DrawFrame();
            }
        }

        private void DrawFrame()
        {
            if (currentFrame < frameCount - 1)
            {
                currentFrame++;
            }
            else
            {
                loopCounter++;
                currentFrame = 0;
            }
            this.Invalidate();
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            int XLocation = currentFrame * frameWidth;
            Rectangle rect = new Rectangle(XLocation, 0, frameWidth, frameHeight);
            e.Graphics.DrawImage(bitmap, 0, 0, rect, GraphicsUnit.Pixel);
        }
    }
}
