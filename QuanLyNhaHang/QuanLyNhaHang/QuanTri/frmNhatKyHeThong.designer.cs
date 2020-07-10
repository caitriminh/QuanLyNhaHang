namespace QuanLyNhaHang.QuanTri
{
    partial class frmNhatKyHeThong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNhatKyHeThong));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnXoaTatCa = new DevExpress.XtraBars.BarButtonItem();
            this.btn_xoa = new DevExpress.XtraBars.BarButtonItem();
            this.btn_lammoi = new DevExpress.XtraBars.BarButtonItem();
            this.btn_excel = new DevExpress.XtraBars.BarButtonItem();
            this.dateTuNgay = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.dateDenNgay = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.btn_tim = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.dgvNhatKyHeThong = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_xoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this._brn_xoa = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraSaveFileDialog1 = new DevExpress.XtraEditors.XtraSaveFileDialog(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhatKyHeThong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._brn_xoa)).BeginInit();
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
            this.btn_xoa,
            this.btn_lammoi,
            this.btn_excel,
            this.dateTuNgay,
            this.dateDenNgay,
            this.btn_tim,
            this.btnXoaTatCa});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 9;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoaTatCa, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_xoa, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_lammoi, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btn_excel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle | DevExpress.XtraBars.BarLinkUserDefines.Width))), this.dateTuNgay, "", true, true, true, 116, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(((DevExpress.XtraBars.BarLinkUserDefines)((DevExpress.XtraBars.BarLinkUserDefines.PaintStyle | DevExpress.XtraBars.BarLinkUserDefines.Width))), this.dateDenNgay, "", false, true, true, 106, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_tim)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnXoaTatCa
            // 
            this.btnXoaTatCa.Caption = "Xóa tất cả nhật ký";
            this.btnXoaTatCa.Id = 8;
            this.btnXoaTatCa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnXoaTatCa.ImageOptions.Image")));
            this.btnXoaTatCa.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnXoaTatCa.ImageOptions.LargeImage")));
            this.btnXoaTatCa.Name = "btnXoaTatCa";
            this.btnXoaTatCa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoaTatCa_ItemClick);
            // 
            // btn_xoa
            // 
            this.btn_xoa.Caption = "Xóa";
            this.btn_xoa.Id = 2;
            this.btn_xoa.ImageOptions.ImageIndex = 1;
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_xoa_ItemClick);
            // 
            // btn_lammoi
            // 
            this.btn_lammoi.Caption = "&Nạp lại";
            this.btn_lammoi.Id = 3;
            this.btn_lammoi.ImageOptions.ImageIndex = 2;
            this.btn_lammoi.Name = "btn_lammoi";
            this.btn_lammoi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_lammoi_ItemClick);
            // 
            // btn_excel
            // 
            this.btn_excel.Caption = "Excel";
            this.btn_excel.Id = 4;
            this.btn_excel.ImageOptions.ImageIndex = 4;
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_excel_ItemClick);
            // 
            // dateTuNgay
            // 
            this.dateTuNgay.Caption = "Từ";
            this.dateTuNgay.Edit = this.repositoryItemDateEdit1;
            this.dateTuNgay.Id = 5;
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
            this.dateDenNgay.Id = 6;
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
            // btn_tim
            // 
            this.btn_tim.Caption = "&Tìm";
            this.btn_tim.Id = 7;
            this.btn_tim.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_tim.ImageOptions.Image")));
            this.btn_tim.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_tim.ImageOptions.LargeImage")));
            this.btn_tim.Name = "btn_tim";
            this.btn_tim.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_tim_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1170, 34);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 560);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1170, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 34);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 526);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1170, 34);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 526);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "additem_16x16.png");
            this.imageCollection1.Images.SetKeyName(1, "close_16x16.png");
            this.imageCollection1.Images.SetKeyName(2, "refresh_16x16.png");
            this.imageCollection1.Images.SetKeyName(3, "saveas_16x16.png");
            this.imageCollection1.Images.SetKeyName(4, "exporttoxlsx_16x16.png");
            // 
            // dgvNhatKyHeThong
            // 
            this.dgvNhatKyHeThong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNhatKyHeThong.Location = new System.Drawing.Point(0, 34);
            this.dgvNhatKyHeThong.MainView = this.gridView1;
            this.dgvNhatKyHeThong.MenuManager = this.barManager1;
            this.dgvNhatKyHeThong.Name = "dgvNhatKyHeThong";
            this.dgvNhatKyHeThong.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this._brn_xoa});
            this.dgvNhatKyHeThong.Size = new System.Drawing.Size(1170, 526);
            this.dgvNhatKyHeThong.TabIndex = 5;
            this.dgvNhatKyHeThong.UseEmbeddedNavigator = true;
            this.dgvNhatKyHeThong.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn10,
            this.gridColumn11,
            this.col_xoa,
            this.gridColumn2});
            this.gridView1.DetailHeight = 372;
            this.gridView1.GridControl = this.dgvNhatKyHeThong;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 35;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tên người dùng";
            this.gridColumn1.FieldName = "tendangnhap";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            this.gridColumn1.Width = 151;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Ngày cập nhật";
            this.gridColumn3.FieldName = "thoigian";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.FixedWidth = true;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 8;
            this.gridColumn3.Width = 160;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Form";
            this.gridColumn4.FieldName = "form";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.FixedWidth = true;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 150;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Hệ điều hành";
            this.gridColumn5.FieldName = "hedieuhanh";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.FixedWidth = true;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 6;
            this.gridColumn5.Width = 250;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Chức năng";
            this.gridColumn10.FieldName = "thaotac";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.FixedWidth = true;
            this.gridColumn10.OptionsColumn.ReadOnly = true;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 4;
            this.gridColumn10.Width = 400;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Tên máy";
            this.gridColumn11.FieldName = "tenmay";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.FixedWidth = true;
            this.gridColumn11.OptionsColumn.ReadOnly = true;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 7;
            this.gridColumn11.Width = 150;
            // 
            // col_xoa
            // 
            this.col_xoa.AppearanceHeader.Options.UseTextOptions = true;
            this.col_xoa.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_xoa.Caption = "Xóa";
            this.col_xoa.ColumnEdit = this._brn_xoa;
            this.col_xoa.Name = "col_xoa";
            this.col_xoa.OptionsColumn.AllowEdit = false;
            this.col_xoa.Visible = true;
            this.col_xoa.VisibleIndex = 1;
            this.col_xoa.Width = 35;
            // 
            // _brn_xoa
            // 
            this._brn_xoa.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this._brn_xoa.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this._brn_xoa.Name = "_brn_xoa";
            this._brn_xoa.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Ngày hệ thống";
            this.gridColumn2.FieldName = "ngaycapnhat";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.FixedWidth = true;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 110;
            // 
            // xtraSaveFileDialog1
            // 
            this.xtraSaveFileDialog1.FileName = "xtraSaveFileDialog1";
            // 
            // frmNhatKyHeThong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 560);
            this.Controls.Add(this.dgvNhatKyHeThong);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.Name = "frmNhatKyHeThong";
            this.Text = "Nhật Ký Hệ Thống";
            this.Load += new System.EventHandler(this.frm_nhatky_hethong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhatKyHeThong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._brn_xoa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btn_xoa;
        private DevExpress.XtraBars.BarButtonItem btn_lammoi;
        private DevExpress.XtraBars.BarButtonItem btn_excel;
        private DevExpress.XtraBars.BarEditItem dateTuNgay;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarEditItem dateDenNgay;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit2;
        private DevExpress.XtraBars.BarButtonItem btn_tim;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl dgvNhatKyHeThong;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn col_xoa;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit _brn_xoa;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.XtraSaveFileDialog xtraSaveFileDialog1;
        private DevExpress.XtraBars.BarButtonItem btnXoaTatCa;
    }
}