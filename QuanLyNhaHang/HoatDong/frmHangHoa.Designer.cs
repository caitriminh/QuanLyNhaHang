namespace QuanLyNhaHang.HoatDong
{
    partial class frmHangHoa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHangHoa));
            this.cboNhomHang = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnNapLai = new DevExpress.XtraBars.BarButtonItem();
            this.btnIn = new DevExpress.XtraBars.BarButtonItem();
            this.btnExcel = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.dgvHangHoa = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboNhomHang2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboDVT = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboLoaiHangHoa = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.label1A = new DevExpress.XtraEditors.LabelControl();
            this.xtraSaveFileDialog1 = new DevExpress.XtraEditors.XtraSaveFileDialog(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cboNhomHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhomHang2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiHangHoa)).BeginInit();
            this.SuspendLayout();
            // 
            // cboNhomHang
            // 
            this.cboNhomHang.AutoHeight = false;
            this.cboNhomHang.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNhomHang.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("nhomhang", "Nhóm hàng")});
            this.cboNhomHang.Name = "cboNhomHang";
            this.cboNhomHang.NullText = "";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Images = this.imageCollection1;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThem,
            this.btnLuu,
            this.btnXoa,
            this.btnNapLai,
            this.btnExcel,
            this.btnIn});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 7;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThem, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLuu, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnNapLai, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnIn, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnExcel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnThem
            // 
            this.btnThem.Caption = "&Thêm";
            this.btnThem.Id = 0;
            this.btnThem.ImageOptions.ImageIndex = 0;
            this.btnThem.Name = "btnThem";
            this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem_ItemClick);
            // 
            // btnLuu
            // 
            this.btnLuu.Caption = "Lưu";
            this.btnLuu.Id = 1;
            this.btnLuu.ImageOptions.ImageIndex = 3;
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLuu_ItemClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "Xóa";
            this.btnXoa.Id = 2;
            this.btnXoa.ImageOptions.ImageIndex = 1;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoa_ItemClick);
            // 
            // btnNapLai
            // 
            this.btnNapLai.Caption = "Nạp lại";
            this.btnNapLai.Id = 3;
            this.btnNapLai.ImageOptions.ImageIndex = 2;
            this.btnNapLai.Name = "btnNapLai";
            this.btnNapLai.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNapLai_ItemClick);
            // 
            // btnIn
            // 
            this.btnIn.Caption = "&In";
            this.btnIn.Id = 6;
            this.btnIn.ImageOptions.ImageIndex = 5;
            this.btnIn.Name = "btnIn";
            // 
            // btnExcel
            // 
            this.btnExcel.Caption = "&Excel";
            this.btnExcel.Id = 5;
            this.btnExcel.ImageOptions.ImageIndex = 4;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExcel_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1210, 34);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 437);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1210, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 34);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 403);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1210, 34);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 403);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "additem_16x16.png");
            this.imageCollection1.Images.SetKeyName(1, "close_16x16.png");
            this.imageCollection1.Images.SetKeyName(2, "refresh_16x16.png");
            this.imageCollection1.Images.SetKeyName(3, "saveas_16x16.png");
            this.imageCollection1.Images.SetKeyName(4, "exporttoxlsx_16x16.png");
            this.imageCollection1.Images.SetKeyName(5, "print_16x16.png");
            // 
            // dgvHangHoa
            // 
            this.dgvHangHoa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHangHoa.Location = new System.Drawing.Point(0, 34);
            this.dgvHangHoa.MainView = this.gridView1;
            this.dgvHangHoa.MenuManager = this.barManager1;
            this.dgvHangHoa.Name = "dgvHangHoa";
            this.dgvHangHoa.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cboDVT,
            this.cboNhomHang2,
            this.repositoryItemTextEdit1,
            this.cboLoaiHangHoa});
            this.dgvHangHoa.Size = new System.Drawing.Size(1210, 403);
            this.dgvHangHoa.TabIndex = 4;
            this.dgvHangHoa.UseEmbeddedNavigator = true;
            this.dgvHangHoa.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13});
            this.gridView1.DetailHeight = 372;
            this.gridView1.GridControl = this.dgvHangHoa;
            this.gridView1.GroupCount = 1;
            this.gridView1.GroupFormat = "{0}: [#image]{1}";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 55;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupedColumns = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn2, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.gridColumn1.Caption = "Mã hàng";
            this.gridColumn1.FieldName = "mahang";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 100;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Nhóm hàng";
            this.gridColumn2.ColumnEdit = this.cboNhomHang2;
            this.gridColumn2.FieldName = "nhomhang";
            this.gridColumn2.MinWidth = 25;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.FixedWidth = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 252;
            // 
            // cboNhomHang2
            // 
            this.cboNhomHang2.AutoHeight = false;
            this.cboNhomHang2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNhomHang2.Name = "cboNhomHang2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Người tạo";
            this.gridColumn3.FieldName = "nguoitd";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.FixedWidth = true;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 9;
            this.gridColumn3.Width = 125;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Ngày tạo";
            this.gridColumn4.FieldName = "thoigian";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.FixedWidth = true;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 10;
            this.gridColumn4.Width = 150;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Người sửa";
            this.gridColumn5.FieldName = "nguoitd2";
            this.gridColumn5.MinWidth = 25;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.FixedWidth = true;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 11;
            this.gridColumn5.Width = 125;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Ngày sửa";
            this.gridColumn6.FieldName = "thoigian2";
            this.gridColumn6.MinWidth = 25;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.FixedWidth = true;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 12;
            this.gridColumn6.Width = 150;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Tên mặt hàng";
            this.gridColumn7.FieldName = "tenhang";
            this.gridColumn7.MinWidth = 25;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.FixedWidth = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            this.gridColumn7.Width = 250;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.Caption = "ĐVT";
            this.gridColumn8.ColumnEdit = this.cboDVT;
            this.gridColumn8.FieldName = "madvt";
            this.gridColumn8.MinWidth = 25;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.FixedWidth = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            this.gridColumn8.Width = 55;
            // 
            // cboDVT
            // 
            this.cboDVT.AutoHeight = false;
            this.cboDVT.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboDVT.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tendvt", "Đơn vị tính")});
            this.cboDVT.Name = "cboDVT";
            this.cboDVT.NullText = "";
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn9.Caption = "Đơn giá nhập";
            this.gridColumn9.ColumnEdit = this.repositoryItemTextEdit1;
            this.gridColumn9.DisplayFormat.FormatString = "{0:#,##0}";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn9.FieldName = "gianhap";
            this.gridColumn9.MinWidth = 25;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.FixedWidth = true;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 7;
            this.gridColumn9.Width = 100;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Mask.EditMask = "n0";
            this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // gridColumn10
            // 
            this.gridColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn10.Caption = "Đơn giá xuất";
            this.gridColumn10.ColumnEdit = this.repositoryItemTextEdit1;
            this.gridColumn10.DisplayFormat.FormatString = "{0:#,##0}";
            this.gridColumn10.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn10.FieldName = "giaban";
            this.gridColumn10.MinWidth = 25;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.FixedWidth = true;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 6;
            this.gridColumn10.Width = 100;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Ghi chú";
            this.gridColumn11.FieldName = "ghichu";
            this.gridColumn11.MinWidth = 25;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.FixedWidth = true;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 8;
            this.gridColumn11.Width = 250;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "gridColumn12";
            this.gridColumn12.FieldName = "manhomhang";
            this.gridColumn12.MinWidth = 25;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Width = 94;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Loại hàng";
            this.gridColumn13.ColumnEdit = this.cboLoaiHangHoa;
            this.gridColumn13.FieldName = "loaihanghoa";
            this.gridColumn13.MinWidth = 25;
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.FixedWidth = true;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 2;
            this.gridColumn13.Width = 140;
            // 
            // cboLoaiHangHoa
            // 
            this.cboLoaiHangHoa.AutoHeight = false;
            this.cboLoaiHangHoa.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLoaiHangHoa.Name = "cboLoaiHangHoa";
            // 
            // label1A
            // 
            this.label1A.AutoEllipsis = true;
            this.label1A.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.label1A.Location = new System.Drawing.Point(396, 255);
            this.label1A.Name = "label1A";
            this.label1A.Size = new System.Drawing.Size(0, 17);
            this.label1A.TabIndex = 9;
            this.label1A.TextChanged += new System.EventHandler(this.label1A_TextChanged);
            // 
            // xtraSaveFileDialog1
            // 
            this.xtraSaveFileDialog1.FileName = "xtraSaveFileDialog1";
            // 
            // frmHangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 437);
            this.Controls.Add(this.label1A);
            this.Controls.Add(this.dgvHangHoa);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.Name = "frmHangHoa";
            this.Text = "Hàng Hóa";
            this.Load += new System.EventHandler(this.frmHangHoa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cboNhomHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhomHang2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboDVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiHangHoa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarButtonItem btnLuu;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraBars.BarButtonItem btnNapLai;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraGrid.GridControl dgvHangHoa;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.LabelControl label1A;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cboNhomHang;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cboDVT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox cboNhomHang2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox cboLoaiHangHoa;
        private DevExpress.XtraBars.BarButtonItem btnExcel;
        private DevExpress.XtraEditors.XtraSaveFileDialog xtraSaveFileDialog1;
        private DevExpress.XtraBars.BarButtonItem btnIn;
    }
}
