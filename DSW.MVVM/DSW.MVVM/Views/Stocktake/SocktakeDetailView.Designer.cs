namespace DSW.MVVM.Views.Stocktake
{
    partial class SocktakeDetailView
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblLocation = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblItemNo = new System.Windows.Forms.Label();
            this.lblItemDesc = new System.Windows.Forms.Label();
            this.lblItemQty = new System.Windows.Forms.Label();
            this.txtActualQty = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(223, 426);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 20);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "btnCancel";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(3, 426);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(91, 20);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "btnBack";
            // 
            // lblLocation
            // 
            this.lblLocation.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblLocation.Location = new System.Drawing.Point(4, 82);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(311, 20);
            this.lblLocation.Text = "lblLocation";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(112, 426);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 20);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "btnSave";
            // 
            // lblItemNo
            // 
            this.lblItemNo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblItemNo.Location = new System.Drawing.Point(4, 165);
            this.lblItemNo.Name = "lblItemNo";
            this.lblItemNo.Size = new System.Drawing.Size(311, 20);
            this.lblItemNo.Text = "lblItemNo";
            // 
            // lblItemDesc
            // 
            this.lblItemDesc.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblItemDesc.Location = new System.Drawing.Point(4, 203);
            this.lblItemDesc.Name = "lblItemDesc";
            this.lblItemDesc.Size = new System.Drawing.Size(311, 20);
            this.lblItemDesc.Text = "lblItemDesc";
            // 
            // lblItemQty
            // 
            this.lblItemQty.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblItemQty.Location = new System.Drawing.Point(4, 242);
            this.lblItemQty.Name = "lblItemQty";
            this.lblItemQty.Size = new System.Drawing.Size(311, 20);
            this.lblItemQty.Text = "lblItemQty";
            // 
            // txtActualQty
            // 
            this.txtActualQty.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtActualQty.Location = new System.Drawing.Point(4, 284);
            this.txtActualQty.Name = "txtActualQty";
            this.txtActualQty.Size = new System.Drawing.Size(310, 26);
            this.txtActualQty.TabIndex = 14;
            // 
            // SocktakeDetailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(318, 455);
            this.Controls.Add(this.txtActualQty);
            this.Controls.Add(this.lblItemQty);
            this.Controls.Add(this.lblItemDesc);
            this.Controls.Add(this.lblItemNo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBack);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SocktakeDetailView";
            this.Text = "Detail Item Stocktake";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblItemNo;
        private System.Windows.Forms.Label lblItemDesc;
        private System.Windows.Forms.Label lblItemQty;
        private System.Windows.Forms.TextBox txtActualQty;
    }
}