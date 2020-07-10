namespace QuanLyNhaHang.DanhMuc
{
    partial class frmThemNhomHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThemNhomHang));
            this.GroupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnChonHinh = new DevExpress.XtraEditors.SimpleButton();
            this.lblDuongDan = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtNhomKH = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl1)).BeginInit();
            this.GroupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNhomKH.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupControl1
            // 
            this.GroupControl1.Controls.Add(this.btnChonHinh);
            this.GroupControl1.Controls.Add(this.lblDuongDan);
            this.GroupControl1.Controls.Add(this.labelControl2);
            this.GroupControl1.Controls.Add(this.txtNhomKH);
            this.GroupControl1.Controls.Add(this.labelControl1);
            this.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupControl1.Location = new System.Drawing.Point(0, 0);
            this.GroupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GroupControl1.Name = "GroupControl1";
            this.GroupControl1.Size = new System.Drawing.Size(471, 97);
            this.GroupControl1.TabIndex = 0;
            this.GroupControl1.Text = "Thông tin";
            // 
            // btnChonHinh
            // 
            this.btnChonHinh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnChonHinh.ImageOptions.Image")));
            this.btnChonHinh.Location = new System.Drawing.Point(362, 59);
            this.btnChonHinh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnChonHinh.Name = "btnChonHinh";
            this.btnChonHinh.Size = new System.Drawing.Size(97, 28);
            this.btnChonHinh.TabIndex = 3;
            this.btnChonHinh.Text = "&Chọn hình";
            this.btnChonHinh.Click += new System.EventHandler(this.btnChonHinh_Click);
            // 
            // lblDuongDan
            // 
            this.lblDuongDan.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDuongDan.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblDuongDan.Location = new System.Drawing.Point(120, 61);
            this.lblDuongDan.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblDuongDan.Name = "lblDuongDan";
            this.lblDuongDan.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblDuongDan.Size = new System.Drawing.Size(236, 25);
            this.lblDuongDan.TabIndex = 5;
            this.lblDuongDan.Text = "Bạn vui lòng chọn hình ...";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 65);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(63, 17);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Chọn hình";
            // 
            // txtNhomKH
            // 
            this.txtNhomKH.Location = new System.Drawing.Point(120, 33);
            this.txtNhomKH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNhomKH.Name = "txtNhomKH";
            this.txtNhomKH.Size = new System.Drawing.Size(339, 22);
            this.txtNhomKH.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 35);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(102, 16);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Nhóm khách hàng";
            // 
            // btnThoat
            // 
            this.btnThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.Image")));
            this.btnThoat.Location = new System.Drawing.Point(383, 105);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(76, 28);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.ImageOptions.Image")));
            this.btnLuu.Location = new System.Drawing.Point(300, 105);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(76, 28);
            this.btnLuu.TabIndex = 1;
            this.btnLuu.Text = "&Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmThemNhomHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 150);
            this.Controls.Add(this.GroupControl1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnLuu);
            this.KeyPreview = true;
            this.Name = "frmThemNhomHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhóm Khách Hàng";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmThemNhomHang_FormClosing);
            this.Load += new System.EventHandler(this.frmThemNhomHang_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmThemNhomHang_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl1)).EndInit();
            this.GroupControl1.ResumeLayout(false);
            this.GroupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNhomKH.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal DevExpress.XtraEditors.GroupControl GroupControl1;
        internal DevExpress.XtraEditors.SimpleButton btnThoat;
        internal DevExpress.XtraEditors.SimpleButton btnLuu;
        internal DevExpress.XtraEditors.TextEdit txtNhomKH;
        internal DevExpress.XtraEditors.LabelControl labelControl1;
        internal DevExpress.XtraEditors.SimpleButton btnChonHinh;
        internal DevExpress.XtraEditors.LabelControl lblDuongDan;
        internal DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
