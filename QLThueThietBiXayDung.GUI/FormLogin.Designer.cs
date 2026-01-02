namespace QLThueThietBiXayDung.GUI
{
    partial class FormLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.btnOK = new Guna.UI2.WinForms.Guna2Button();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.pnlOuter = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlInner = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.pnlOuter.SuspendLayout();
            this.pnlInner.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnOK.BorderRadius = 5;
            this.btnOK.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnOK.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnOK.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnOK.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnOK.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnOK.Font = new System.Drawing.Font("Arial", 11F);
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnOK.ImageOffset = new System.Drawing.Point(25, 0);
            this.btnOK.Location = new System.Drawing.Point(17, 108);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(157, 34);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 10;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.TargetForm = this;
            // 
            // pnlOuter
            // 
            this.pnlOuter.Controls.Add(this.pnlInner);
            this.pnlOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOuter.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(191)))));
            this.pnlOuter.Location = new System.Drawing.Point(0, 0);
            this.pnlOuter.Name = "pnlOuter";
            this.pnlOuter.Size = new System.Drawing.Size(423, 171);
            this.pnlOuter.TabIndex = 1;
            // 
            // pnlInner
            // 
            this.pnlInner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(77)))), ((int)(((byte)(191)))));
            this.pnlInner.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.pnlInner.BorderRadius = 5;
            this.pnlInner.BorderThickness = 1;
            this.pnlInner.Controls.Add(this.btnOK);
            this.pnlInner.Controls.Add(this.btnCancel);
            this.pnlInner.Controls.Add(this.guna2HtmlLabel2);
            this.pnlInner.Controls.Add(this.guna2HtmlLabel1);
            this.pnlInner.Controls.Add(this.txtPassword);
            this.pnlInner.Controls.Add(this.txtUsername);
            this.pnlInner.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.pnlInner.Location = new System.Drawing.Point(5, 6);
            this.pnlInner.Name = "pnlInner";
            this.pnlInner.Size = new System.Drawing.Size(411, 159);
            this.pnlInner.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnCancel.BorderRadius = 5;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnCancel.Font = new System.Drawing.Font("Arial", 11F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCancel.ImageOffset = new System.Drawing.Point(25, 0);
            this.btnCancel.Location = new System.Drawing.Point(210, 108);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(178, 34);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Arial", 11F);
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(17, 68);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(64, 19);
            this.guna2HtmlLabel2.TabIndex = 1;
            this.guna2HtmlLabel2.Text = "Mật Khẩu";
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Arial", 11F);
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(17, 20);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(105, 19);
            this.guna2HtmlLabel1.TabIndex = 1;
            this.guna2HtmlLabel1.Text = "Tên Đăng Nhập";
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.txtPassword.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(78)))), ((int)(((byte)(100)))));
            this.txtPassword.BorderRadius = 5;
            this.txtPassword.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "123";
            this.txtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.Font = new System.Drawing.Font("Arial", 11F);
            this.txtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtPassword.IconLeft")));
            this.txtPassword.Location = new System.Drawing.Point(155, 64);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.PlaceholderText = "Mật khẩu";
            this.txtPassword.SelectedText = "";
            this.txtPassword.Size = new System.Drawing.Size(233, 26);
            this.txtPassword.TabIndex = 0;
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.txtUsername.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(78)))), ((int)(((byte)(100)))));
            this.txtUsername.BorderRadius = 5;
            this.txtUsername.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.txtUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsername.DefaultText = "tk001";
            this.txtUsername.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUsername.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUsername.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsername.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsername.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUsername.Font = new System.Drawing.Font("Arial", 11F);
            this.txtUsername.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUsername.IconLeft = ((System.Drawing.Image)(resources.GetObject("txtUsername.IconLeft")));
            this.txtUsername.Location = new System.Drawing.Point(155, 16);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PasswordChar = '\0';
            this.txtUsername.PlaceholderText = "Tên đăng nhập";
            this.txtUsername.SelectedText = "";
            this.txtUsername.Size = new System.Drawing.Size(233, 26);
            this.txtUsername.TabIndex = 0;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.pnlOuter;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 171);
            this.Controls.Add(this.pnlOuter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormLogin";
            this.pnlOuter.ResumeLayout(false);
            this.pnlInner.ResumeLayout(false);
            this.pnlInner.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnOK;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel pnlOuter;
        private Guna.UI2.WinForms.Guna2Panel pnlInner;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}