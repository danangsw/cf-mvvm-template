namespace DSW.MVVM.Views.Stocktake
{
    partial class StocktakeNewView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.lblLocation = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnContinue = new System.Windows.Forms.Button();
            this.lblItemLocationCount = new System.Windows.Forms.Label();
            this.btnSync = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLocation
            // 
            this.lblLocation.Location = new System.Drawing.Point(8, 186);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(299, 20);
            this.lblLocation.Text = "lblLocation";
            this.lblLocation.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // comboBox1
            // 
            this.comboBox1.Location = new System.Drawing.Point(8, 210);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(299, 22);
            this.comboBox1.TabIndex = 2;
            // 
            // btnContinue
            // 
            this.btnContinue.ForeColor = System.Drawing.Color.Black;
            this.btnContinue.Location = new System.Drawing.Point(108, 427);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(105, 20);
            this.btnContinue.TabIndex = 3;
            this.btnContinue.Text = "btnContinue";
            // 
            // lblItemLocationCount
            // 
            this.lblItemLocationCount.Location = new System.Drawing.Point(8, 248);
            this.lblItemLocationCount.Name = "lblItemLocationCount";
            this.lblItemLocationCount.Size = new System.Drawing.Size(299, 20);
            this.lblItemLocationCount.Text = "lblItemLocationCount";
            this.lblItemLocationCount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(5, 427);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(91, 20);
            this.btnSync.TabIndex = 6;
            this.btnSync.Text = "btnSync";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(223, 427);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 20);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "btnCancel";
            // 
            // StocktakeNewView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(318, 455);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSync);
            this.Controls.Add(this.lblItemLocationCount);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblLocation);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StocktakeNewView";
            this.Text = "Sync";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Label lblItemLocationCount;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.Button btnCancel;
    }
}