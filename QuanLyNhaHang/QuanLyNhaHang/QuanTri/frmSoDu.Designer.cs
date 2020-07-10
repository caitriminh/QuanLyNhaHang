namespace QuanLyNhaHang.QuanTri
{
    partial class frmSoDu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSoDu));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnThem = new DevExpress.XtraBars.BarButtonItem();
            this.btnLuu = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btnNapLai = new DevExpress.XtraBars.BarButtonItem();
            this.btn_in = new DevExpress.XtraBars.BarButtonItem();
            this.btn_excel = new DevExpress.XtraBars.BarButtonItem();
            this.dateTuNgay = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.dateDenNgay = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.btnTim = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.xtraSaveFileDialog1 = new DevExpress.XtraEditors.XtraSaveFileDialog(this.components);
            this.dgvTonKhoBanDau = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cboKho = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colXoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this._btn_xoa = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.label1A = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonKhoBanDau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._btn_xoa)).BeginInit();
            this.SuspendLayout();
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
            this.btnNapLai,
            this.btn_excel,
            this.btn_in,
            this.dateTuNgay,
            this.dateDenNgay,
            this.btnTim,
            this.btnThem,
            this.btnXoa,
            this.btnLuu});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 15;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryItemDateEdit2});
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_in, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_excel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle | DevExpress.XtraBars.BarLinkUserDefines.Width))), this.dateTuNgay, "", true, true, true, 100, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle | DevExpress.XtraBars.BarLinkUserDefines.Width))), this.dateDenNgay, "", false, true, true, 96, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnTim)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnThem
            // 
            this.btnThem.Caption = "&Thêm";
            this.btnThem.Id = 12;
            this.btnThem.ImageOptions.ImageIndex = 0;
            this.btnThem.Name = "btnThem";
            this.btnThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThem_ItemClick);
            // 
            // btnLuu
            // 
            this.btnLuu.Caption = "&Lưu";
            this.btnLuu.Id = 14;
            this.btnLuu.ImageOptions.ImageIndex = 3;
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLuu_ItemClick);
            // 
            // btnXoa
            // 
            this.btnXoa.Caption = "&Xóa";
            this.btnXoa.Id = 13;
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
            // 
            // btn_in
            // 
            this.btn_in.Caption = "In";
            this.btn_in.Id = 7;
            this.btn_in.ImageOptions.ImageIndex = 5;
            this.btn_in.Name = "btn_in";
            // 
            // btn_excel
            // 
            this.btn_excel.Caption = "&Excel";
            this.btn_excel.Id = 5;
            this.btn_excel.ImageOptions.ImageIndex = 4;
            this.btn_excel.Name = "btn_excel";
            // 
            // dateTuNgay
            // 
            this.dateTuNgay.Caption = "Từ";
            this.dateTuNgay.Edit = this.repositoryItemDateEdit1;
            this.dateTuNgay.Id = 8;
            this.dateTuNgay.Name = "dateTuNgay";
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // dateDenNgay
            // 
            this.dateDenNgay.Caption = "Đến";
            this.dateDenNgay.Edit = this.repositoryItemDateEdit2;
            this.dateDenNgay.Id = 9;
            this.dateDenNgay.Name = "dateDenNgay";
            // 
            // repositoryItemDateEdit2
            // 
            this.repositoryItemDateEdit2.AutoHeight = false;
            this.repositoryItemDateEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit2.Name = "repositoryItemDateEdit2";
            // 
            // btnTim
            // 
            this.btnTim.Caption = "&Tim";
            this.btnTim.Id = 10;
            this.btnTim.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTim.ImageOptions.Image")));
            this.btnTim.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnTim.ImageOptions.LargeImage")));
            this.btnTim.Name = "btnTim";
            this.btnTim.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTim_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1249, 34);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 543);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1249, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 34);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 509);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1249, 34);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 509);
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
            this.imageCollection1.Images.SetKeyName(6, "edittask_16x16.png");
            // 
            // xtraSaveFileDialog1
            // 
            this.xtraSaveFileDialog1.FileName = "xtraSaveFileDialog1";
            // 
            // dgvTonKhoBanDau
            // 
            this.dgvTonKhoBanDau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTonKhoBanDau.Location = new System.Drawing.Point(0, 34);
            this.dgvTonKhoBanDau.MainView = this.gridView1;
            this.dgvTonKhoBanDau.MenuManager = this.barManager1;
            this.dgvTonKhoBanDau.Name = "dgvTonKhoBanDau";
            this.dgvTonKhoBanDau.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this._btn_xoa,
            this.cboKho,
            this.repositoryItemTextEdit1});
            this.dgvTonKhoBanDau.Size = new System.Drawing.Size(1249, 509);
            this.dgvTonKhoBanDau.TabIndex = 34;
            this.dgvTonKhoBanDau.UseEmbeddedNavigator = true;
            this.dgvTonKhoBanDau.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn1,
            this.gridColumn24,
            this.gridColumn25,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn11,
            this.gridColumn12,
            this.colXoa});
            this.gridView1.DetailHeight = 372;
            this.gridView1.GridControl = this.dgvTonKhoBanDau;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 55;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupedColumns = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Ngày tháng";
            this.gridColumn2.FieldName = "ngaynhap";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.FixedWidth = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 100;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã hàng";
            this.gridColumn1.FieldName = "mahang";
            this.gridColumn1.MinWidth = 25;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            this.gridColumn1.Width = 100;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "Ghi chú";
            this.gridColumn24.FieldName = "ghichu";
            this.gridColumn24.MinWidth = 25;
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.OptionsColumn.FixedWidth = true;
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 9;
            this.gridColumn24.Width = 180;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "Người tạo";
            this.gridColumn25.FieldName = "nguoitd";
            this.gridColumn25.MinWidth = 25;
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.OptionsColumn.FixedWidth = true;
            this.gridColumn25.OptionsColumn.ReadOnly = true;
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 11;
            this.gridColumn25.Width = 130;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Tên hàng";
            this.gridColumn3.FieldName = "tenhang";
            this.gridColumn3.MinWidth = 25;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.FixedWidth = true;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 5;
            this.gridColumn3.Width = 225;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Nhóm hàng";
            this.gridColumn4.FieldName = "nhomhang";
            this.gridColumn4.MinWidth = 25;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.FixedWidth = true;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 241;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn6.Caption = "Tiền đầu";
            this.gridColumn6.ColumnEdit = this.repositoryItemTextEdit1;
            this.gridColumn6.DisplayFormat.FormatString = "{0:#,##0.0}";
            this.gridColumn6.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn6.FieldName = "tiendau";
            this.gridColumn6.MinWidth = 25;
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.FixedWidth = true;
            this.gridColumn6.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "tiendau", "{0:#,##0.0}")});
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 8;
            this.gridColumn6.Width = 130;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Mask.EditMask = "n1";
            this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "ĐVT";
            this.gridColumn7.FieldName = "tendvt";
            this.gridColumn7.MinWidth = 25;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.FixedWidth = true;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            this.gridColumn7.Width = 50;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn8.Caption = "Số dư";
            this.gridColumn8.ColumnEdit = this.repositoryItemTextEdit1;
            this.gridColumn8.DisplayFormat.FormatString = "{0:#,##0.0}";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "sodu";
            this.gridColumn8.MinWidth = 25;
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.FixedWidth = true;
            this.gridColumn8.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "sodu", "{0:#,##0.0}")});
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            this.gridColumn8.Width = 100;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Ngày tạo";
            this.gridColumn9.FieldName = "thoigian";
            this.gridColumn9.MinWidth = 25;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.FixedWidth = true;
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 10;
            this.gridColumn9.Width = 150;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Người sửa";
            this.gridColumn10.FieldName = "nguoitd2";
            this.gridColumn10.MinWidth = 25;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.FixedWidth = true;
            this.gridColumn10.OptionsColumn.ReadOnly = true;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 13;
            this.gridColumn10.Width = 130;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Ngày sửa";
            this.gridColumn11.FieldName = "thoigian2";
            this.gridColumn11.MinWidth = 25;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.FixedWidth = true;
            this.gridColumn11.OptionsColumn.ReadOnly = true;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 12;
            this.gridColumn11.Width = 150;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Kho hàng";
            this.gridColumn12.ColumnEdit = this.cboKho;
            this.gridColumn12.FieldName = "makho";
            this.gridColumn12.MinWidth = 25;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 2;
            this.gridColumn12.Width = 184;
            // 
            // cboKho
            // 
            this.cboKho.AutoHeight = false;
            this.cboKho.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboKho.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("tenkho", "Kho")});
            this.cboKho.Name = "cboKho";
            this.cboKho.NullText = "";
            // 
            // colXoa
            // 
            this.colXoa.AppearanceHeader.Options.UseTextOptions = true;
            this.colXoa.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colXoa.Caption = "Xóa";
            this.colXoa.ColumnEdit = this._btn_xoa;
            this.colXoa.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Right;
            this.colXoa.MinWidth = 25;
            this.colXoa.Name = "colXoa";
            this.colXoa.OptionsColumn.AllowEdit = false;
            this.colXoa.Visible = true;
            this.colXoa.VisibleIndex = 14;
            this.colXoa.Width = 35;
            // 
            // _btn_xoa
            // 
            this._btn_xoa.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this._btn_xoa.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this._btn_xoa.Name = "_btn_xoa";
            this._btn_xoa.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // label1A
            // 
            this.label1A.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.label1A.Location = new System.Drawing.Point(430, 310);
            this.label1A.Name = "label1A";
            this.label1A.Size = new System.Drawing.Size(75, 0);
            this.label1A.TabIndex = 39;
            this.label1A.TextChanged += new System.EventHandler(this.label1A_TextChanged);
            // 
            // frmSoDu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 543);
            this.Controls.Add(this.label1A);
            this.Controls.Add(this.dgvTonKhoBanDau);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.Name = "frmSoDu";
            this.Text = "Tồn Kho Ban Đầu";
            this.Load += new System.EventHandler(this.frmSoDu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonKhoBanDau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboKho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._btn_xoa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnNapLai;
        private DevExpress.XtraBars.BarButtonItem btn_in;
        private DevExpress.XtraBars.BarButtonItem btn_excel;
        private DevExpress.XtraBars.BarEditItem dateTuNgay;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarEditItem dateDenNgay;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
        private DevExpress.XtraBars.BarButtonItem btnTim;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.XtraSaveFileDialog xtraSaveFileDialog1;
        private DevExpress.XtraBars.BarButtonItem btnThem;
        private DevExpress.XtraBars.BarButtonItem btnXoa;
        private DevExpress.XtraGrid.GridControl dgvTonKhoBanDau;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit _btn_xoa;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.LabelControl label1A;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit cboKho;
        private DevExpress.XtraBars.BarButtonItem btnLuu;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colXoa;
    }
}
