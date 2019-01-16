using System.Windows.Forms;
namespace DSW.MVVM.Views.Loading
{
    partial class LoadingView : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.timer1 = new System.Windows.Forms.Timer();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDotRight = new System.Windows.Forms.Label();
            this.lblDotLeft = new System.Windows.Forms.Label();
            this.lblPleaseWait = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.marqueeTimer_Tick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(110)))), ((int)(((byte)(165)))));
            this.label1.Location = new System.Drawing.Point(127, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 53);
            this.label1.Text = "...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDotRight
            // 
            this.lblDotRight.BackColor = System.Drawing.Color.Transparent;
            this.lblDotRight.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold);
            this.lblDotRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(110)))), ((int)(((byte)(165)))));
            this.lblDotRight.Location = new System.Drawing.Point(186, 156);
            this.lblDotRight.Name = "lblDotRight";
            this.lblDotRight.Size = new System.Drawing.Size(125, 50);
            this.lblDotRight.Text = "...";
            // 
            // lblDotLeft
            // 
            this.lblDotLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDotLeft.BackColor = System.Drawing.Color.Transparent;
            this.lblDotLeft.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold);
            this.lblDotLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(110)))), ((int)(((byte)(165)))));
            this.lblDotLeft.Location = new System.Drawing.Point(21, 155);
            this.lblDotLeft.Name = "lblDotLeft";
            this.lblDotLeft.Size = new System.Drawing.Size(108, 50);
            this.lblDotLeft.Text = "...";
            this.lblDotLeft.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblPleaseWait
            // 
            this.lblPleaseWait.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lblPleaseWait.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lblPleaseWait.Location = new System.Drawing.Point(0, 201);
            this.lblPleaseWait.Name = "lblPleaseWait";
            this.lblPleaseWait.Size = new System.Drawing.Size(318, 38);
            this.lblPleaseWait.Text = "loading";
            this.lblPleaseWait.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LoadingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(318, 455);
            this.Controls.Add(this.lblPleaseWait);
            this.Controls.Add(this.lblDotLeft);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDotRight);
            this.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoadingView";
            this.Text = "Loading";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDotRight;
        private System.Windows.Forms.Label lblDotLeft;
        private System.Windows.Forms.Label lblPleaseWait;



    }
}