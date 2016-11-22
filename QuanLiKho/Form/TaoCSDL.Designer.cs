namespace QuanLiKho
{
    partial class TaoCSDL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaoCSDL));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnSaoLuu = new DevExpress.XtraBars.BarButtonItem();
            this.btnPhucHoi = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textUser = new DevExpress.XtraEditors.TextEdit();
            this.textPas = new DevExpress.XtraEditors.TextEdit();
            this.btnConnec = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.comboServer = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPas.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboServer.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.barButtonItem1,
            this.btnSaoLuu,
            this.btnPhucHoi});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 4;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(506, 144);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Tạo CSDL";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // btnSaoLuu
            // 
            this.btnSaoLuu.Caption = "Sao Lưu CSDL";
            this.btnSaoLuu.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSaoLuu.Glyph")));
            this.btnSaoLuu.Id = 2;
            this.btnSaoLuu.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnSaoLuu.LargeGlyph")));
            this.btnSaoLuu.Name = "btnSaoLuu";
            this.btnSaoLuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaoLuu_ItemClick);
            // 
            // btnPhucHoi
            // 
            this.btnPhucHoi.Caption = "Phục Hồi CSDL";
            this.btnPhucHoi.Glyph = ((System.Drawing.Image)(resources.GetObject("btnPhucHoi.Glyph")));
            this.btnPhucHoi.Id = 3;
            this.btnPhucHoi.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnPhucHoi.LargeGlyph")));
            this.btnPhucHoi.Name = "btnPhucHoi";
            this.btnPhucHoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPhucHoi_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Quản Lí CSDL";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnSaoLuu);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPhucHoi);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Thao Tác";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 363);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(506, 31);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(54, 177);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(66, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Server Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Login:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 278);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Password:";
            // 
            // textUser
            // 
            this.textUser.EditValue = "sa";
            this.textUser.Location = new System.Drawing.Point(154, 234);
            this.textUser.MenuManager = this.ribbon;
            this.textUser.Name = "textUser";
            this.textUser.Size = new System.Drawing.Size(204, 20);
            this.textUser.TabIndex = 10;
            // 
            // textPas
            // 
            this.textPas.Location = new System.Drawing.Point(154, 270);
            this.textPas.MenuManager = this.ribbon;
            this.textPas.Name = "textPas";
            this.textPas.Size = new System.Drawing.Size(204, 20);
            this.textPas.TabIndex = 11;
            // 
            // btnConnec
            // 
            this.btnConnec.Location = new System.Drawing.Point(154, 310);
            this.btnConnec.Name = "btnConnec";
            this.btnConnec.Size = new System.Drawing.Size(75, 23);
            this.btnConnec.TabIndex = 12;
            this.btnConnec.Text = "Connect";
            this.btnConnec.Click += new System.EventHandler(this.btnConnec_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(249, 310);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // comboServer
            // 
            this.comboServer.EditValue = ".\\SQLEXPRESS";
            this.comboServer.Location = new System.Drawing.Point(154, 177);
            this.comboServer.MenuManager = this.ribbon;
            this.comboServer.Name = "comboServer";
            this.comboServer.Size = new System.Drawing.Size(204, 20);
            this.comboServer.TabIndex = 16;
            // 
            // TaoCSDL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 394);
            this.Controls.Add(this.comboServer);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConnec);
            this.Controls.Add(this.textPas);
            this.Controls.Add(this.textUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "TaoCSDL";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Quản Lí CSDL";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPas.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboServer.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnSaoLuu;
        private DevExpress.XtraBars.BarButtonItem btnPhucHoi;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit textUser;
        private DevExpress.XtraEditors.TextEdit textPas;
        private DevExpress.XtraEditors.SimpleButton btnConnec;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.TextEdit comboServer;
    }
}