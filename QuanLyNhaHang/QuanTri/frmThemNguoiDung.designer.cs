namespace QuanLyNhaHang.QuanTri
{
    partial class frmThemNguoiDung
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThemNguoiDung));
            this.GroupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.lblTenNV = new DevExpress.XtraEditors.LabelControl();
            this.txtMaNV = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtMatKhau2 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtMatKhau = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtGhiChu = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtTenDangNhap = new DevExpress.XtraEditors.TextEdit();
            this.LabelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btn_Thoat = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Luu = new DevExpress.XtraEditors.SimpleButton();
            this.btn_nhaplai = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl1)).BeginInit();
            this.GroupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhau2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDangNhap.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupControl1
            // 
            this.GroupControl1.Controls.Add(this.labelControl7);
            this.GroupControl1.Controls.Add(this.lblTenNV);
            this.GroupControl1.Controls.Add(this.txtMaNV);
            this.GroupControl1.Controls.Add(this.labelControl6);
            this.GroupControl1.Controls.Add(this.txtMatKhau2);
            this.GroupControl1.Controls.Add(this.labelControl3);
            this.GroupControl1.Controls.Add(this.txtMatKhau);
            this.GroupControl1.Controls.Add(this.labelControl1);
            this.GroupControl1.Controls.Add(this.txtGhiChu);
            this.GroupControl1.Controls.Add(this.labelControl2);
            this.GroupControl1.Controls.Add(this.txtTenDangNhap);
            this.GroupControl1.Controls.Add(this.LabelControl4);
            this.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupControl1.Location = new System.Drawing.Point(0, 0);
            this.GroupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GroupControl1.Name = "GroupControl1";
            this.GroupControl1.Size = new System.Drawing.Size(523, 228);
            this.GroupControl1.TabIndex = 0;
            this.GroupControl1.Text = "Thông tin người dùng";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(12, 105);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(42, 19);
            this.labelControl7.TabIndex = 4;
            this.labelControl7.Text = "Họ tên";
            // 
            // lblTenNV
            // 
            this.lblTenNV.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTenNV.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblTenNV.Location = new System.Drawing.Point(130, 101);
            this.lblTenNV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblTenNV.Name = "lblTenNV";
            this.lblTenNV.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblTenNV.Size = new System.Drawing.Size(381, 24);
            this.lblTenNV.TabIndex = 5;
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(130, 69);
            this.txtMaNV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Properties.Mask.EditMask = "\\p{Ll}+";
            this.txtMaNV.Properties.Mask.ShowPlaceHolders = false;
            this.txtMaNV.Size = new System.Drawing.Size(381, 24);
            this.txtMaNV.TabIndex = 3;
            this.txtMaNV.Leave += new System.EventHandler(this.txtMaNV_Leave);
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(12, 71);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(78, 17);
            this.labelControl6.TabIndex = 2;
            this.labelControl6.Text = "Mã nhân viên";
            // 
            // txtMatKhau2
            // 
            this.txtMatKhau2.Location = new System.Drawing.Point(130, 166);
            this.txtMatKhau2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMatKhau2.Name = "txtMatKhau2";
            this.txtMatKhau2.Properties.PasswordChar = '•';
            this.txtMatKhau2.Size = new System.Drawing.Size(381, 24);
            this.txtMatKhau2.TabIndex = 9;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 168);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(112, 19);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "Nhập lại mật khẩu";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(130, 134);
            this.txtMatKhau.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Properties.PasswordChar = '•';
            this.txtMatKhau.Size = new System.Drawing.Size(381, 24);
            this.txtMatKhau.TabIndex = 7;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 136);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 19);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Mật khẩu";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(130, 198);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Properties.Mask.EditMask = "[A-Z].*";
            this.txtGhiChu.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtGhiChu.Size = new System.Drawing.Size(381, 24);
            this.txtGhiChu.TabIndex = 11;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 201);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(43, 17);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Ghi chú";
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Location = new System.Drawing.Point(130, 37);
            this.txtTenDangNhap.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Properties.Mask.EditMask = "\\p{Ll}+";
            this.txtTenDangNhap.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtTenDangNhap.Size = new System.Drawing.Size(381, 24);
            this.txtTenDangNhap.TabIndex = 1;
            this.txtTenDangNhap.Leave += new System.EventHandler(this.txt_tendanhnhap_Leave);
            // 
            // LabelControl4
            // 
            this.LabelControl4.Location = new System.Drawing.Point(12, 39);
            this.LabelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LabelControl4.Name = "LabelControl4";
            this.LabelControl4.Size = new System.Drawing.Size(91, 19);
            this.LabelControl4.TabIndex = 0;
            this.LabelControl4.Text = "Tên đăng nhập";
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Thoat.ImageOptions.Image")));
            this.btn_Thoat.Location = new System.Drawing.Point(435, 237);
            this.btn_Thoat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(76, 30);
            this.btn_Thoat.TabIndex = 2;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // btn_Luu
            // 
            this.btn_Luu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Luu.ImageOptions.Image")));
            this.btn_Luu.Location = new System.Drawing.Point(271, 237);
            this.btn_Luu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(76, 30);
            this.btn_Luu.TabIndex = 1;
            this.btn_Luu.Text = "&Lưu";
            this.btn_Luu.Click += new System.EventHandler(this.btn_Luu_Click);
            // 
            // btn_nhaplai
            // 
            this.btn_nhaplai.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_nhaplai.ImageOptions.Image")));
            this.btn_nhaplai.Location = new System.Drawing.Point(353, 237);
            this.btn_nhaplai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_nhaplai.Name = "btn_nhaplai";
            this.btn_nhaplai.Size = new System.Drawing.Size(76, 30);
            this.btn_nhaplai.TabIndex = 3;
            this.btn_nhaplai.Text = "&Nhập lại";
            this.btn_nhaplai.Click += new System.EventHandler(this.btn_nhaplai_Click);
            // 
            // frmThemNguoiDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 283);
            this.Controls.Add(this.btn_nhaplai);
            this.Controls.Add(this.GroupControl1);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_Luu);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.KeyPreview = true;
            this.Name = "frmThemNguoiDung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Người Dùng";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmThemNguoiDung_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl1)).EndInit();
            this.GroupControl1.ResumeLayout(false);
            this.GroupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhau2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDangNhap.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal DevExpress.XtraEditors.GroupControl GroupControl1;
        internal DevExpress.XtraEditors.TextEdit txtTenDangNhap;
        internal DevExpress.XtraEditors.LabelControl LabelControl4;
        internal DevExpress.XtraEditors.SimpleButton btn_Thoat;
        internal DevExpress.XtraEditors.SimpleButton btn_Luu;
        internal DevExpress.XtraEditors.TextEdit txtGhiChu;
        internal DevExpress.XtraEditors.LabelControl labelControl2;
        internal DevExpress.XtraEditors.SimpleButton btn_nhaplai;
        internal DevExpress.XtraEditors.TextEdit txtMatKhau;
        internal DevExpress.XtraEditors.LabelControl labelControl1;
        internal DevExpress.XtraEditors.TextEdit txtMatKhau2;
        internal DevExpress.XtraEditors.LabelControl labelControl3;
        internal DevExpress.XtraEditors.LabelControl labelControl7;
        internal DevExpress.XtraEditors.LabelControl lblTenNV;
        internal DevExpress.XtraEditors.TextEdit txtMaNV;
        internal DevExpress.XtraEditors.LabelControl labelControl6;
    }
}
