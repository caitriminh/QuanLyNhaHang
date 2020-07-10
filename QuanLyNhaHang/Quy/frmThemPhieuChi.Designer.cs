namespace QuanLyNhaHang.Quy
{
    partial class frmThemPhieuChi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThemPhieuChi));
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.label1A = new DevExpress.XtraEditors.LabelControl();
            this.dropDownButton1 = new DevExpress.XtraEditors.DropDownButton();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btnNhanVien = new DevExpress.XtraBars.BarButtonItem();
            this.btnKhachHang = new DevExpress.XtraBars.BarButtonItem();
            this.btnNCC = new DevExpress.XtraBars.BarButtonItem();
            this.btnDoiTuongKhac = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btn_Thoat = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Luu = new DevExpress.XtraEditors.SimpleButton();
            this.txtNguoiNop = new DevExpress.XtraEditors.TextEdit();
            this.GroupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtMaPhieu = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtGhiChu = new DevExpress.XtraEditors.MemoEdit();
            this.cboLoaiPhieu = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dateNgayLap = new DevExpress.XtraEditors.DateEdit();
            this.txtSoTien = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.LabelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNguoiNop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl1)).BeginInit();
            this.GroupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaPhieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiPhieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayLap.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayLap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(337, 275);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(84, 28);
            this.simpleButton1.TabIndex = 12;
            this.simpleButton1.Text = "&In phiếu";
            // 
            // label1A
            // 
            this.label1A.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.label1A.Location = new System.Drawing.Point(31, 208);
            this.label1A.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.label1A.Name = "label1A";
            this.label1A.Size = new System.Drawing.Size(42, 0);
            this.label1A.TabIndex = 15;
            this.label1A.TextChanged += new System.EventHandler(this.label1A_TextChanged);
            // 
            // dropDownButton1
            // 
            this.dropDownButton1.DropDownControl = this.popupMenu1;
            this.dropDownButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("dropDownButton1.ImageOptions.Image")));
            this.dropDownButton1.Location = new System.Drawing.Point(483, 145);
            this.dropDownButton1.Name = "dropDownButton1";
            this.dropDownButton1.Size = new System.Drawing.Size(127, 29);
            this.dropDownButton1.TabIndex = 14;
            this.dropDownButton1.Text = "Nhân viên";
            this.dropDownButton1.TextChanged += new System.EventHandler(this.dropDownButton1_Click);
            this.dropDownButton1.Click += new System.EventHandler(this.dropDownButton1_Click);
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNhanVien),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnKhachHang),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnNCC),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDoiTuongKhac)});
            this.popupMenu1.Manager = this.barManager1;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.Caption = "Nhân viên";
            this.btnNhanVien.Id = 0;
            this.btnNhanVien.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNhanVien.ImageOptions.Image")));
            this.btnNhanVien.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNhanVien.ImageOptions.LargeImage")));
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNhanVien_ItemClick);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.Caption = "Khách hàng";
            this.btnKhachHang.Id = 1;
            this.btnKhachHang.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKhachHang.ImageOptions.Image")));
            this.btnKhachHang.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnKhachHang.ImageOptions.LargeImage")));
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnKhachHang_ItemClick);
            // 
            // btnNCC
            // 
            this.btnNCC.Caption = "Nhà cung cấp";
            this.btnNCC.Id = 2;
            this.btnNCC.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNCC.ImageOptions.Image")));
            this.btnNCC.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNCC.ImageOptions.LargeImage")));
            this.btnNCC.Name = "btnNCC";
            this.btnNCC.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNCC_ItemClick);
            // 
            // btnDoiTuongKhac
            // 
            this.btnDoiTuongKhac.Caption = "Đối tượng khác";
            this.btnDoiTuongKhac.Id = 3;
            this.btnDoiTuongKhac.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDoiTuongKhac.ImageOptions.Image")));
            this.btnDoiTuongKhac.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDoiTuongKhac.ImageOptions.LargeImage")));
            this.btnDoiTuongKhac.Name = "btnDoiTuongKhac";
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnNhanVien,
            this.btnKhachHang,
            this.btnNCC,
            this.btnDoiTuongKhac});
            this.barManager1.MaxItemId = 4;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(622, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 316);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(622, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 316);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(622, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 316);
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Thoat.ImageOptions.Image")));
            this.btn_Thoat.Location = new System.Drawing.Point(534, 275);
            this.btn_Thoat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(76, 28);
            this.btn_Thoat.TabIndex = 11;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // btn_Luu
            // 
            this.btn_Luu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Luu.ImageOptions.Image")));
            this.btn_Luu.Location = new System.Drawing.Point(427, 275);
            this.btn_Luu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(100, 28);
            this.btn_Luu.TabIndex = 10;
            this.btn_Luu.Text = "&Ghi dữ liệu";
            this.btn_Luu.Click += new System.EventHandler(this.btn_Luu_Click);
            // 
            // txtNguoiNop
            // 
            this.txtNguoiNop.EditValue = "";
            this.txtNguoiNop.Location = new System.Drawing.Point(108, 147);
            this.txtNguoiNop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNguoiNop.Name = "txtNguoiNop";
            this.txtNguoiNop.Size = new System.Drawing.Size(369, 22);
            this.txtNguoiNop.TabIndex = 13;
            // 
            // GroupControl1
            // 
            this.GroupControl1.Controls.Add(this.label1A);
            this.GroupControl1.Controls.Add(this.dropDownButton1);
            this.GroupControl1.Controls.Add(this.txtNguoiNop);
            this.GroupControl1.Controls.Add(this.labelControl5);
            this.GroupControl1.Controls.Add(this.txtMaPhieu);
            this.GroupControl1.Controls.Add(this.labelControl3);
            this.GroupControl1.Controls.Add(this.txtGhiChu);
            this.GroupControl1.Controls.Add(this.cboLoaiPhieu);
            this.GroupControl1.Controls.Add(this.labelControl1);
            this.GroupControl1.Controls.Add(this.dateNgayLap);
            this.GroupControl1.Controls.Add(this.txtSoTien);
            this.GroupControl1.Controls.Add(this.labelControl7);
            this.GroupControl1.Controls.Add(this.labelControl2);
            this.GroupControl1.Controls.Add(this.LabelControl4);
            this.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupControl1.Location = new System.Drawing.Point(0, 0);
            this.GroupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GroupControl1.Name = "GroupControl1";
            this.GroupControl1.Size = new System.Drawing.Size(622, 267);
            this.GroupControl1.TabIndex = 9;
            this.GroupControl1.Text = "Thông tin phiếu thu";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(11, 150);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(71, 17);
            this.labelControl5.TabIndex = 12;
            this.labelControl5.Text = "Người nhận";
            // 
            // txtMaPhieu
            // 
            this.txtMaPhieu.EditValue = "";
            this.txtMaPhieu.Location = new System.Drawing.Point(108, 31);
            this.txtMaPhieu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaPhieu.Name = "txtMaPhieu";
            this.txtMaPhieu.Size = new System.Drawing.Size(502, 22);
            this.txtMaPhieu.TabIndex = 11;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(11, 34);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(79, 17);
            this.labelControl3.TabIndex = 10;
            this.labelControl3.Text = "Mã phiếu thu";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(108, 180);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(502, 82);
            this.txtGhiChu.TabIndex = 9;
            // 
            // cboLoaiPhieu
            // 
            this.cboLoaiPhieu.Location = new System.Drawing.Point(108, 88);
            this.cboLoaiPhieu.Name = "cboLoaiPhieu";
            this.cboLoaiPhieu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLoaiPhieu.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("loaiphieu", "Lý do thu")});
            this.cboLoaiPhieu.Properties.NullText = "";
            this.cboLoaiPhieu.Size = new System.Drawing.Size(502, 22);
            this.cboLoaiPhieu.TabIndex = 8;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(11, 63);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(53, 17);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Ngày lập";
            // 
            // dateNgayLap
            // 
            this.dateNgayLap.EditValue = null;
            this.dateNgayLap.Location = new System.Drawing.Point(108, 60);
            this.dateNgayLap.Name = "dateNgayLap";
            this.dateNgayLap.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgayLap.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgayLap.Size = new System.Drawing.Size(502, 22);
            this.dateNgayLap.TabIndex = 5;
            this.dateNgayLap.TextChanged += new System.EventHandler(this.dateNgayLap_TextChanged);
            // 
            // txtSoTien
            // 
            this.txtSoTien.EditValue = "0";
            this.txtSoTien.Location = new System.Drawing.Point(108, 117);
            this.txtSoTien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Properties.Mask.EditMask = "n0";
            this.txtSoTien.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSoTien.Size = new System.Drawing.Size(502, 22);
            this.txtSoTien.TabIndex = 3;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(11, 120);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(42, 17);
            this.labelControl7.TabIndex = 2;
            this.labelControl7.Text = "Số tiền";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(11, 182);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(42, 16);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Ghi chú";
            // 
            // LabelControl4
            // 
            this.LabelControl4.Location = new System.Drawing.Point(11, 91);
            this.LabelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LabelControl4.Name = "LabelControl4";
            this.LabelControl4.Size = new System.Drawing.Size(50, 16);
            this.LabelControl4.TabIndex = 0;
            this.LabelControl4.Text = "Lý do chi";
            // 
            // frmThemPhieuChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 316);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_Luu);
            this.Controls.Add(this.GroupControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmThemPhieuChi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu Chi";
            this.Load += new System.EventHandler(this.frmThemPhieuChi_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmThemPhieuChi_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNguoiNop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl1)).EndInit();
            this.GroupControl1.ResumeLayout(false);
            this.GroupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaPhieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiPhieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayLap.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayLap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal DevExpress.XtraEditors.SimpleButton simpleButton1;
        internal DevExpress.XtraEditors.LabelControl label1A;
        private DevExpress.XtraEditors.DropDownButton dropDownButton1;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem btnNhanVien;
        private DevExpress.XtraBars.BarButtonItem btnKhachHang;
        private DevExpress.XtraBars.BarButtonItem btnNCC;
        private DevExpress.XtraBars.BarButtonItem btnDoiTuongKhac;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        internal DevExpress.XtraEditors.SimpleButton btn_Thoat;
        internal DevExpress.XtraEditors.SimpleButton btn_Luu;
        internal DevExpress.XtraEditors.GroupControl GroupControl1;
        internal DevExpress.XtraEditors.TextEdit txtNguoiNop;
        internal DevExpress.XtraEditors.LabelControl labelControl5;
        internal DevExpress.XtraEditors.TextEdit txtMaPhieu;
        internal DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.MemoEdit txtGhiChu;
        private DevExpress.XtraEditors.LookUpEdit cboLoaiPhieu;
        internal DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dateNgayLap;
        internal DevExpress.XtraEditors.TextEdit txtSoTien;
        internal DevExpress.XtraEditors.LabelControl labelControl7;
        internal DevExpress.XtraEditors.LabelControl labelControl2;
        internal DevExpress.XtraEditors.LabelControl LabelControl4;
    }
}