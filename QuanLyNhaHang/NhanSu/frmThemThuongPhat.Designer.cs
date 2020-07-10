namespace QuanLyNhaHang.NhanSu
{
    partial class frmThemThuongPhat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThemThuongPhat));
            this.GroupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dateNgayThang = new DevExpress.XtraEditors.DateEdit();
            this.cboNhanVien = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtSoTien = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtLyDo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.LabelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btn_nhaplai = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Thoat = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Luu = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl1)).BeginInit();
            this.GroupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayThang.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayThang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhanVien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLyDo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupControl1
            // 
            this.GroupControl1.Controls.Add(this.labelControl1);
            this.GroupControl1.Controls.Add(this.dateNgayThang);
            this.GroupControl1.Controls.Add(this.cboNhanVien);
            this.GroupControl1.Controls.Add(this.txtSoTien);
            this.GroupControl1.Controls.Add(this.labelControl7);
            this.GroupControl1.Controls.Add(this.txtLyDo);
            this.GroupControl1.Controls.Add(this.labelControl2);
            this.GroupControl1.Controls.Add(this.LabelControl4);
            this.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupControl1.Location = new System.Drawing.Point(0, 0);
            this.GroupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GroupControl1.Name = "GroupControl1";
            this.GroupControl1.Size = new System.Drawing.Size(523, 165);
            this.GroupControl1.TabIndex = 4;
            this.GroupControl1.Text = "Thông tin thưởng phạt";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(15, 101);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(64, 16);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Ngày tháng";
            // 
            // dateNgayThang
            // 
            this.dateNgayThang.EditValue = null;
            this.dateNgayThang.Location = new System.Drawing.Point(118, 98);
            this.dateNgayThang.Name = "dateNgayThang";
            this.dateNgayThang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgayThang.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNgayThang.Size = new System.Drawing.Size(393, 22);
            this.dateNgayThang.TabIndex = 5;
            // 
            // cboNhanVien
            // 
            this.cboNhanVien.Location = new System.Drawing.Point(118, 36);
            this.cboNhanVien.Name = "cboNhanVien";
            this.cboNhanVien.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNhanVien.Properties.NullText = "";
            this.cboNhanVien.Properties.PopupView = this.gridLookUpEdit1View;
            this.cboNhanVien.Size = new System.Drawing.Size(393, 22);
            this.cboNhanVien.TabIndex = 1;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Nhân viên";
            this.gridColumn1.FieldName = "tennv";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.FixedWidth = true;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // txtSoTien
            // 
            this.txtSoTien.EditValue = "0";
            this.txtSoTien.Location = new System.Drawing.Point(118, 67);
            this.txtSoTien.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Properties.Mask.EditMask = "n0";
            this.txtSoTien.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtSoTien.Size = new System.Drawing.Size(393, 22);
            this.txtSoTien.TabIndex = 3;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(15, 70);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(90, 17);
            this.labelControl7.TabIndex = 2;
            this.labelControl7.Text = "Thưởng / phạt";
            // 
            // txtLyDo
            // 
            this.txtLyDo.Location = new System.Drawing.Point(118, 129);
            this.txtLyDo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.Properties.Mask.EditMask = "[A-Z].*";
            this.txtLyDo.Size = new System.Drawing.Size(393, 22);
            this.txtLyDo.TabIndex = 7;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(15, 132);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(30, 16);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Lý do";
            // 
            // LabelControl4
            // 
            this.LabelControl4.Location = new System.Drawing.Point(15, 39);
            this.LabelControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LabelControl4.Name = "LabelControl4";
            this.LabelControl4.Size = new System.Drawing.Size(56, 16);
            this.LabelControl4.TabIndex = 0;
            this.LabelControl4.Text = "Nhân viên";
            // 
            // btn_nhaplai
            // 
            this.btn_nhaplai.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_nhaplai.ImageOptions.Image")));
            this.btn_nhaplai.Location = new System.Drawing.Point(346, 173);
            this.btn_nhaplai.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_nhaplai.Name = "btn_nhaplai";
            this.btn_nhaplai.Size = new System.Drawing.Size(83, 30);
            this.btn_nhaplai.TabIndex = 7;
            this.btn_nhaplai.Text = "&Nhập lại";
            this.btn_nhaplai.Click += new System.EventHandler(this.btn_nhaplai_Click);
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Thoat.ImageOptions.Image")));
            this.btn_Thoat.Location = new System.Drawing.Point(435, 173);
            this.btn_Thoat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(76, 30);
            this.btn_Thoat.TabIndex = 6;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // btn_Luu
            // 
            this.btn_Luu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Luu.ImageOptions.Image")));
            this.btn_Luu.Location = new System.Drawing.Point(264, 173);
            this.btn_Luu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(76, 30);
            this.btn_Luu.TabIndex = 5;
            this.btn_Luu.Text = "&Lưu";
            this.btn_Luu.Click += new System.EventHandler(this.btn_Luu_Click);
            // 
            // frmThemThuongPhat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 221);
            this.Controls.Add(this.GroupControl1);
            this.Controls.Add(this.btn_nhaplai);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_Luu);
            this.Name = "frmThemThuongPhat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thưởng / Phạt";
            this.Load += new System.EventHandler(this.frmThemThuongPhat_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmThemThuongPhat_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl1)).EndInit();
            this.GroupControl1.ResumeLayout(false);
            this.GroupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayThang.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayThang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhanVien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLyDo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal DevExpress.XtraEditors.GroupControl GroupControl1;
        internal DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit dateNgayThang;
        private DevExpress.XtraEditors.GridLookUpEdit cboNhanVien;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        internal DevExpress.XtraEditors.TextEdit txtSoTien;
        internal DevExpress.XtraEditors.LabelControl labelControl7;
        internal DevExpress.XtraEditors.TextEdit txtLyDo;
        internal DevExpress.XtraEditors.LabelControl labelControl2;
        internal DevExpress.XtraEditors.LabelControl LabelControl4;
        internal DevExpress.XtraEditors.SimpleButton btn_nhaplai;
        internal DevExpress.XtraEditors.SimpleButton btn_Thoat;
        internal DevExpress.XtraEditors.SimpleButton btn_Luu;
    }
}