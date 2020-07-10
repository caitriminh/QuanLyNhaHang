namespace QuanLyNhaHang.NhanSu
{
    partial class frmThemNhanVien
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThemNhanVien));
            this.btn_nhaplai = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.cboCaLamViec = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.cboChucVu = new DevExpress.XtraEditors.LookUpEdit();
            this.txtDiaChi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtNoiSinh = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btn_Thoat = new DevExpress.XtraEditors.SimpleButton();
            this.dateNgaySinh = new DevExpress.XtraEditors.DateEdit();
            this.cboGioiTinh = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtHoTen = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtGhiChu = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtMaNV = new DevExpress.XtraEditors.TextEdit();
            this.LabelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btn_Luu = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.GroupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.cboCaLamViec.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboChucVu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiSinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgaySinh.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgaySinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGioiTinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl1)).BeginInit();
            this.GroupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_nhaplai
            // 
            this.btn_nhaplai.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_nhaplai.ImageOptions.Image")));
            this.btn_nhaplai.Location = new System.Drawing.Point(403, 312);
            this.btn_nhaplai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_nhaplai.Name = "btn_nhaplai";
            this.btn_nhaplai.Size = new System.Drawing.Size(87, 28);
            this.btn_nhaplai.TabIndex = 7;
            this.btn_nhaplai.Text = "&Nhập lại";
            this.btn_nhaplai.Click += new System.EventHandler(this.btn_nhaplai_Click);
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(15, 245);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(69, 17);
            this.labelControl9.TabIndex = 14;
            this.labelControl9.Text = "Ca làm việc";
            // 
            // cboCaLamViec
            // 
            this.cboCaLamViec.Location = new System.Drawing.Point(123, 242);
            this.cboCaLamViec.Name = "cboCaLamViec";
            this.cboCaLamViec.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboCaLamViec.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("calamviec", "Ca làm việc")});
            this.cboCaLamViec.Properties.NullText = "";
            this.cboCaLamViec.Size = new System.Drawing.Size(461, 22);
            this.cboCaLamViec.TabIndex = 15;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(15, 217);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(53, 17);
            this.labelControl8.TabIndex = 12;
            this.labelControl8.Text = "Chức vụ";
            // 
            // cboChucVu
            // 
            this.cboChucVu.Location = new System.Drawing.Point(123, 214);
            this.cboChucVu.Name = "cboChucVu";
            this.cboChucVu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboChucVu.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("chucvu", "Chức vụ")});
            this.cboChucVu.Properties.NullText = "";
            this.cboChucVu.Size = new System.Drawing.Size(461, 22);
            this.cboChucVu.TabIndex = 13;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(123, 185);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Properties.Mask.EditMask = "[A-Z].*";
            this.txtDiaChi.Size = new System.Drawing.Size(461, 22);
            this.txtDiaChi.TabIndex = 11;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(14, 188);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(40, 17);
            this.labelControl7.TabIndex = 10;
            this.labelControl7.Text = "Địa chỉ";
            // 
            // txtNoiSinh
            // 
            this.txtNoiSinh.Location = new System.Drawing.Point(123, 155);
            this.txtNoiSinh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNoiSinh.Name = "txtNoiSinh";
            this.txtNoiSinh.Properties.Mask.EditMask = "[A-Z].*";
            this.txtNoiSinh.Size = new System.Drawing.Size(461, 22);
            this.txtNoiSinh.TabIndex = 9;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(14, 158);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(45, 16);
            this.labelControl6.TabIndex = 8;
            this.labelControl6.Text = "Nơi sinh";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(14, 129);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(55, 16);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Ngày sinh";
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Thoat.ImageOptions.Image")));
            this.btn_Thoat.Location = new System.Drawing.Point(497, 312);
            this.btn_Thoat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(87, 28);
            this.btn_Thoat.TabIndex = 6;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // dateNgaySinh
            // 
            this.dateNgaySinh.EditValue = null;
            this.dateNgaySinh.Location = new System.Drawing.Point(123, 126);
            this.dateNgaySinh.Name = "dateNgaySinh";
            this.dateNgaySinh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgaySinh.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgaySinh.Size = new System.Drawing.Size(461, 22);
            this.dateNgaySinh.TabIndex = 7;
            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.EditValue = "Nam";
            this.cboGioiTinh.Location = new System.Drawing.Point(123, 94);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboGioiTinh.Properties.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cboGioiTinh.Size = new System.Drawing.Size(461, 22);
            this.cboGioiTinh.TabIndex = 5;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(123, 65);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Properties.Mask.EditMask = "\\p{Ll}+";
            this.txtHoTen.Properties.Mask.ShowPlaceHolders = false;
            this.txtHoTen.Size = new System.Drawing.Size(461, 22);
            this.txtHoTen.TabIndex = 3;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(14, 67);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(41, 17);
            this.labelControl5.TabIndex = 2;
            this.labelControl5.Text = "Họ tên";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(123, 271);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Properties.Mask.EditMask = "[A-Z].*";
            this.txtGhiChu.Size = new System.Drawing.Size(461, 22);
            this.txtGhiChu.TabIndex = 17;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(14, 274);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(42, 16);
            this.labelControl2.TabIndex = 16;
            this.labelControl2.Text = "Ghi chú";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(123, 35);
            this.txtMaNV.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Properties.Mask.EditMask = "\\p{Ll}+";
            this.txtMaNV.Size = new System.Drawing.Size(461, 22);
            this.txtMaNV.TabIndex = 1;
            // 
            // LabelControl4
            // 
            this.LabelControl4.Location = new System.Drawing.Point(14, 37);
            this.LabelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LabelControl4.Name = "LabelControl4";
            this.LabelControl4.Size = new System.Drawing.Size(76, 16);
            this.LabelControl4.TabIndex = 0;
            this.LabelControl4.Text = "Mã nhân viên";
            // 
            // btn_Luu
            // 
            this.btn_Luu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Luu.ImageOptions.Image")));
            this.btn_Luu.Location = new System.Drawing.Point(310, 312);
            this.btn_Luu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(87, 28);
            this.btn_Luu.TabIndex = 4;
            this.btn_Luu.Text = "&Lưu";
            this.btn_Luu.Click += new System.EventHandler(this.btn_Luu_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 97);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(48, 17);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Giới tính";
            // 
            // GroupControl1
            // 
            this.GroupControl1.Controls.Add(this.labelControl9);
            this.GroupControl1.Controls.Add(this.cboCaLamViec);
            this.GroupControl1.Controls.Add(this.labelControl8);
            this.GroupControl1.Controls.Add(this.cboChucVu);
            this.GroupControl1.Controls.Add(this.txtDiaChi);
            this.GroupControl1.Controls.Add(this.labelControl7);
            this.GroupControl1.Controls.Add(this.txtNoiSinh);
            this.GroupControl1.Controls.Add(this.labelControl6);
            this.GroupControl1.Controls.Add(this.labelControl3);
            this.GroupControl1.Controls.Add(this.dateNgaySinh);
            this.GroupControl1.Controls.Add(this.labelControl1);
            this.GroupControl1.Controls.Add(this.cboGioiTinh);
            this.GroupControl1.Controls.Add(this.txtHoTen);
            this.GroupControl1.Controls.Add(this.labelControl5);
            this.GroupControl1.Controls.Add(this.txtGhiChu);
            this.GroupControl1.Controls.Add(this.labelControl2);
            this.GroupControl1.Controls.Add(this.txtMaNV);
            this.GroupControl1.Controls.Add(this.LabelControl4);
            this.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupControl1.Location = new System.Drawing.Point(0, 0);
            this.GroupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GroupControl1.Name = "GroupControl1";
            this.GroupControl1.Size = new System.Drawing.Size(598, 304);
            this.GroupControl1.TabIndex = 5;
            this.GroupControl1.Text = "Thông tin nhân viên";
            // 
            // frmThemNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 357);
            this.Controls.Add(this.btn_nhaplai);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_Luu);
            this.Controls.Add(this.GroupControl1);
            this.Name = "frmThemNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhân Viên";
            this.Load += new System.EventHandler(this.frmThemNhanVien_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmThemNhanVien_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.cboCaLamViec.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboChucVu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiSinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgaySinh.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgaySinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGioiTinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl1)).EndInit();
            this.GroupControl1.ResumeLayout(false);
            this.GroupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal DevExpress.XtraEditors.SimpleButton btn_nhaplai;
        internal DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LookUpEdit cboCaLamViec;
        internal DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LookUpEdit cboChucVu;
        internal DevExpress.XtraEditors.TextEdit txtDiaChi;
        internal DevExpress.XtraEditors.LabelControl labelControl7;
        internal DevExpress.XtraEditors.TextEdit txtNoiSinh;
        internal DevExpress.XtraEditors.LabelControl labelControl6;
        internal DevExpress.XtraEditors.LabelControl labelControl3;
        internal DevExpress.XtraEditors.SimpleButton btn_Thoat;
        private DevExpress.XtraEditors.DateEdit dateNgaySinh;
        private DevExpress.XtraEditors.ComboBoxEdit cboGioiTinh;
        internal DevExpress.XtraEditors.TextEdit txtHoTen;
        internal DevExpress.XtraEditors.LabelControl labelControl5;
        internal DevExpress.XtraEditors.TextEdit txtGhiChu;
        internal DevExpress.XtraEditors.LabelControl labelControl2;
        internal DevExpress.XtraEditors.TextEdit txtMaNV;
        internal DevExpress.XtraEditors.LabelControl LabelControl4;
        internal DevExpress.XtraEditors.SimpleButton btn_Luu;
        internal DevExpress.XtraEditors.LabelControl labelControl1;
        internal DevExpress.XtraEditors.GroupControl GroupControl1;
    }
}