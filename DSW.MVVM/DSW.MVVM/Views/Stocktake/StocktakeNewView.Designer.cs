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
            this.lblTenantInfo = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnContinue = new System.Windows.Forms.Button();
            this.lblItemLocationCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTenantInfo
            // 
            this.lblTenantInfo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblTenantInfo.Location = new System.Drawing.Point(8, 11);
            this.lblTenantInfo.Name = "lblTenantInfo";
            this.lblTenantInfo.Size = new System.Drawing.Size(299, 20);
            this.lblTenantInfo.Text = "lblTenantInfo";
            this.lblTenantInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblLocation
            // 
            this.lblLocation.Location = new System.Drawing.Point(8, 123);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(299, 20);
            this.lblLocation.Text = "lblLocation";
            this.lblLocation.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // comboBox1
            // 
            this.comboBox1.Location = new System.Drawing.Point(8, 147);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(299, 23);
            this.comboBox1.TabIndex = 2;
            // 
            // btnContinue
            // 
            this.btnContinue.BackColor = System.Drawing.Color.Green;
            this.btnContinue.ForeColor = System.Drawing.Color.White;
            this.btnContinue.Location = new System.Drawing.Point(8, 276);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(299, 20);
            this.btnContinue.TabIndex = 3;
            this.btnContinue.Text = "btnContinue";
            // 
            // lblItemLocationCount
            // 
            this.lblItemLocationCount.Location = new System.Drawing.Point(8, 185);
            this.lblItemLocationCount.Name = "lblItemLocationCount";
            this.lblItemLocationCount.Size = new System.Drawing.Size(299, 20);
            this.lblItemLocationCount.Text = "lblItemLocationCount";
            this.lblItemLocationCount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // StocktakeNewView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(318, 455);
            this.Controls.Add(this.lblItemLocationCount);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblTenantInfo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StocktakeNewView";
            this.Text = "New Stocktake";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTenantInfo;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Label lblItemLocationCount;
    }
}