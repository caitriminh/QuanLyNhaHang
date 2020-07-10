namespace QuanLyNhaHang.QuanTri
{
    partial class frmThemSoDu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThemSoDu));
            this.GroupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtGhiChu = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.cboKhoHang = new DevExpress.XtraEditors.LookUpEdit();
            this.lblThanhTien = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtDonGia = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.date_ngaythang = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cboTenHang = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.txtSoLuong = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl1)).BeginInit();
            this.GroupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboKhoHang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonGia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_ngaythang.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_ngaythang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTenHang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuong.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupControl1
            // 
            this.GroupControl1.Controls.Add(this.txtGhiChu);
            this.GroupControl1.Controls.Add(this.labelControl7);
            this.GroupControl1.Controls.Add(this.labelControl6);
            this.GroupControl1.Controls.Add(this.cboKhoHang);
            this.GroupControl1.Controls.Add(this.lblThanhTien);
            this.GroupControl1.Controls.Add(this.labelControl4);
            this.GroupControl1.Controls.Add(this.labelControl5);
            this.GroupControl1.Controls.Add(this.txtDonGia);
            this.GroupControl1.Controls.Add(this.labelControl2);
            this.GroupControl1.Controls.Add(this.date_ngaythang);
            this.GroupControl1.Controls.Add(this.labelControl1);
            this.GroupControl1.Controls.Add(this.cboTenHang);
            this.GroupControl1.Controls.Add(this.txtSoLuong);
            this.GroupControl1.Controls.Add(this.labelControl3);
            this.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupControl1.Location = new System.Drawing.Point(0, 0);
            this.GroupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GroupControl1.Name = "GroupControl1";
            this.GroupControl1.Size = new System.Drawing.Size(521, 264);
            this.GroupControl1.TabIndex = 0;
            this.GroupControl1.Text = "Thông tin";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.EditValue = "";
            this.txtGhiChu.Location = new System.Drawing.Point(102, 228);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Properties.Mask.EditMask = "n1";
            this.txtGhiChu.Size = new System.Drawing.Size(410, 24);
            this.txtGhiChu.TabIndex = 13;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(13, 232);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(43, 17);
            this.labelControl7.TabIndex = 12;
            this.labelControl7.Text = "Ghi chú";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(13, 71);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(56, 17);
            this.labelControl6.TabIndex = 2;
            this.labelControl6.Text = "Kho hàng";
            // 
            // cboKhoHang
            // 
            this.cboKhoHang.Location = new System.Drawing.Point(102, 68);
            this.cboKhoHang.Name = "cboKhoHang";
            this.cboKhoHang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboKhoHang.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenkho", "Kho hàng")});
            this.cboKhoHang.Properties.NullText = "";
            this.cboKhoHang.Size = new System.Drawing.Size(409, 24);
            this.cboKhoHang.TabIndex = 3;
            // 
            // lblThanhTien
            // 
            this.lblThanhTien.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblThanhTien.Appearance.Options.UseFont = true;
            this.lblThanhTien.Appearance.Options.UseTextOptions = true;
            this.lblThanhTien.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblThanhTien.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblThanhTien.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblThanhTien.Location = new System.Drawing.Point(102, 196);
            this.lblThanhTien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblThanhTien.Name = "lblThanhTien";
            this.lblThanhTien.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.lblThanhTien.Size = new System.Drawing.Size(409, 24);
            this.lblThanhTien.TabIndex = 11;
            this.lblThanhTien.Text = "0";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(13, 200);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(65, 19);
            this.labelControl4.TabIndex = 10;
            this.labelControl4.Text = "Thành tiền";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(13, 132);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(54, 19);
            this.labelControl5.TabIndex = 6;
            this.labelControl5.Text = "Số lượng";
            // 
            // txtDonGia
            // 
            this.txtDonGia.EditValue = "0";
            this.txtDonGia.Location = new System.Drawing.Point(102, 160);
            this.txtDonGia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Properties.Mask.EditMask = "n1";
            this.txtDonGia.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDonGia.Size = new System.Drawing.Size(410, 24);
            this.txtDonGia.TabIndex = 9;
            this.txtDonGia.TextChanged += new System.EventHandler(this.txtDonGia_TextChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 40);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(68, 17);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Ngày tháng";
            // 
            // date_ngaythang
            // 
            this.date_ngaythang.EditValue = null;
            this.date_ngaythang.Location = new System.Drawing.Point(102, 37);
            this.date_ngaythang.Name = "date_ngaythang";
            this.date_ngaythang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_ngaythang.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.date_ngaythang.Size = new System.Drawing.Size(410, 24);
            this.date_ngaythang.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 164);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(46, 17);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Đơn giá";
            // 
            // cboTenHang
            // 
            this.cboTenHang.Location = new System.Drawing.Point(102, 98);
            this.cboTenHang.Name = "cboTenHang";
            this.cboTenHang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTenHang.Properties.NullText = "";
            this.cboTenHang.Properties.PopupView = this.gridLookUpEdit1View;
            this.cboTenHang.Size = new System.Drawing.Size(410, 24);
            this.cboTenHang.TabIndex = 5;
            this.cboTenHang.Click += new System.EventHandler(this.cbo_tenhanghoa_Click);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.EditValue = "0";
            this.txtSoLuong.Location = new System.Drawing.Point(102, 129);
            this.txtSoLuong.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Properties.Mask.EditMask = "n1";
            this.txtSoLuong.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSoLuong.Size = new System.Drawing.Size(409, 24);
            this.txtSoLuong.TabIndex = 7;
            this.txtSoLuong.TextChanged += new System.EventHandler(this.txt_soluong_TextChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(13, 101);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(80, 17);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Tên hàng hóa";
            // 
            // btnThoat
            // 
            this.btnThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.Image")));
            this.btnThoat.Location = new System.Drawing.Point(435, 272);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(76, 30);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.ImageOptions.Image")));
            this.btnLuu.Location = new System.Drawing.Point(353, 272);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(76, 30);
            this.btnLuu.TabIndex = 1;
            this.btnLuu.Text = "&Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btn_Luu_Click);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Nhóm hàng";
            this.gridColumn1.FieldName = "nhomhang";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 180;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên hàng hóa";
            this.gridColumn2.FieldName = "tenhang";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.FixedWidth = true;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 200;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "ĐVT";
            this.gridColumn3.FieldName = "tendvt";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.FixedWidth = true;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 45;
            // 
            // frmThemSoDu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 316);
            this.Controls.Add(this.GroupControl1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnLuu);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.KeyPreview = true;
            this.Name = "frmThemSoDu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Số Dư Đầu Kỳ";
            this.Load += new System.EventHandler(this.frmThemSoDu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmThemSoDu_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl1)).EndInit();
            this.GroupControl1.ResumeLayout(false);
            this.GroupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboKhoHang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDonGia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_ngaythang.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date_ngaythang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTenHang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuong.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal DevExpress.XtraEditors.GroupControl GroupControl1;
        internal DevExpress.XtraEditors.SimpleButton btnThoat;
        internal DevExpress.XtraEditors.SimpleButton btnLuu;
        internal DevExpress.XtraEditors.TextEdit txtSoLuong;
        internal DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.GridLookUpEdit cboTenHang;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        internal DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit date_ngaythang;
        internal DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        internal DevExpress.XtraEditors.LabelControl lblThanhTien;
        internal DevExpress.XtraEditors.LabelControl labelControl4;
        internal DevExpress.XtraEditors.LabelControl labelControl5;
        internal DevExpress.XtraEditors.TextEdit txtDonGia;
        internal DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LookUpEdit cboKhoHang;
        internal DevExpress.XtraEditors.TextEdit txtGhiChu;
        internal DevExpress.XtraEditors.LabelControl labelControl7;
    }
}
