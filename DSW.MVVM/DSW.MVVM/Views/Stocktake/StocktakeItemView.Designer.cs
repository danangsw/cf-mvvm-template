namespace DSW.MVVM.Views.Stocktake
{
    partial class StocktakeItemView
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
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.gridItem = new System.Windows.Forms.DataGrid();
            this.SuspendLayout();
            // 
            // lblLocation
            // 
            this.lblLocation.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblLocation.Location = new System.Drawing.Point(4, 4);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(311, 20);
            this.lblLocation.Text = "lblLocation";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(4, 427);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(91, 20);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "btnBack";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(224, 427);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 20);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "btnCancel";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(113, 427);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(91, 20);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "btnSubmit";
            // 
            // gridItem
            // 
            this.gridItem.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.gridItem.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.gridItem.Location = new System.Drawing.Point(4, 40);
            this.gridItem.Name = "gridItem";
            this.gridItem.Size = new System.Drawing.Size(311, 365);
            this.gridItem.TabIndex = 4;
            // 
            // StocktakeItemView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(318, 455);
            this.Controls.Add(this.gridItem);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblLocation);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StocktakeItemView";
            this.Text = "Item Stocktake";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DataGrid gridItem;

    }
}