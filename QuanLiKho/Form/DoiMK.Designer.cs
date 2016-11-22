namespace QuanLiKho
{
    partial class DoiMK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoiMK));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtMKHT = new DevExpress.XtraEditors.TextEdit();
            this.txtMKMoi = new DevExpress.XtraEditors.TextEdit();
            this.txtNLMK = new DevExpress.XtraEditors.TextEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.checkHienMK = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMKHT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMKMoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNLMK.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkHienMK.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 1;
            this.ribbon.Name = "ribbon";
            this.ribbon.Size = new System.Drawing.Size(430, 49);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 245);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(430, 31);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(35, 92);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(82, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Mật khẩu hiện tại";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(35, 134);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(63, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Mật khẩu mới";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(35, 175);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(85, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Nhập lại mật khẩu";
            // 
            // txtMKHT
            // 
            this.txtMKHT.Location = new System.Drawing.Point(148, 85);
            this.txtMKHT.MenuManager = this.ribbon;
            this.txtMKHT.Name = "txtMKHT";
            this.txtMKHT.Properties.PasswordChar = '*';
            this.txtMKHT.Size = new System.Drawing.Size(201, 20);
            this.txtMKHT.TabIndex = 5;
            // 
            // txtMKMoi
            // 
            this.txtMKMoi.Location = new System.Drawing.Point(148, 126);
            this.txtMKMoi.MenuManager = this.ribbon;
            this.txtMKMoi.Name = "txtMKMoi";
            this.txtMKMoi.Properties.PasswordChar = '*';
            this.txtMKMoi.Size = new System.Drawing.Size(201, 20);
            this.txtMKMoi.TabIndex = 6;
            // 
            // txtNLMK
            // 
            this.txtNLMK.Location = new System.Drawing.Point(148, 169);
            this.txtNLMK.MenuManager = this.ribbon;
            this.txtNLMK.Name = "txtNLMK";
            this.txtNLMK.Properties.PasswordChar = '*';
            this.txtNLMK.Size = new System.Drawing.Size(201, 20);
            this.txtNLMK.TabIndex = 7;
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(246, 206);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 33);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(332, 206);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 33);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // checkHienMK
            // 
            this.checkHienMK.Location = new System.Drawing.Point(36, 209);
            this.checkHienMK.MenuManager = this.ribbon;
            this.checkHienMK.Name = "checkHienMK";
            this.checkHienMK.Properties.Caption = "Hiện mật khẩu";
            this.checkHienMK.Size = new System.Drawing.Size(95, 19);
            this.checkHienMK.TabIndex = 12;
            this.checkHienMK.CheckedChanged += new System.EventHandler(this.checkEdit1_CheckedChanged);
            // 
            // DoiMK
            // 
            this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 276);
            this.Controls.Add(this.checkHienMK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtNLMK);
            this.Controls.Add(this.txtMKMoi);
            this.Controls.Add(this.txtMKHT);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "DoiMK";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Đổi Mật Khẩu";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMKHT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMKMoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNLMK.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkHienMK.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtMKHT;
        private DevExpress.XtraEditors.TextEdit txtMKMoi;
        private DevExpress.XtraEditors.TextEdit txtNLMK;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.CheckEdit checkHienMK;
    }
}