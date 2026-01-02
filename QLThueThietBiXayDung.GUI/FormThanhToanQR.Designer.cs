namespace QLThueThietBiXayDung.GUI
{
    partial class FormThanhToanQR
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.picQR = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).BeginInit();
            this.SuspendLayout();
            // 
            // picQR
            // 
            this.picQR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picQR.Location = new System.Drawing.Point(50, 60);
            this.picQR.Name = "picQR";
            this.picQR.Size = new System.Drawing.Size(300, 300);
            this.picQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQR.TabIndex = 0;
            this.picQR.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(80, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(240, 22);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "QUÉT MÃ ĐỂ THANH TOÁN";
            // 
            // lblAmount
            // 
            this.lblAmount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblAmount.ForeColor = System.Drawing.Color.Red;
            this.lblAmount.Location = new System.Drawing.Point(12, 380);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(376, 23);
            this.lblAmount.TabIndex = 2;
            this.lblAmount.Text = "0 VNĐ";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDesc
            // 
            this.lblDesc.ForeColor = System.Drawing.Color.Gray;
            this.lblDesc.Location = new System.Drawing.Point(12, 410);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(376, 40);
            this.lblDesc.TabIndex = 3;
            this.lblDesc.Text = "Description";
            this.lblDesc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(130, 460);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(140, 40);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Xác nhận đã thanh toán";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormThanhToanQR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 520);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.picQR);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormThanhToanQR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thanh Toán QR";
            this.Load += new System.EventHandler(this.FormThanhToanQR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picQR)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.PictureBox picQR;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.Button btnClose;
    }
}
