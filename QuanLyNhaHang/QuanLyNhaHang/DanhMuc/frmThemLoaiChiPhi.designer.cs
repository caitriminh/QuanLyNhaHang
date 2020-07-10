namespace QuanLyNhaHang.DanhMuc
{
    partial class frmThemLoaiChiPhi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThemLoaiChiPhi));
            this.GroupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cboNhomPhieu = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtLoaiPhieu = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl1)).BeginInit();
            this.GroupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhomPhieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoaiPhieu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupControl1
            // 
            this.GroupControl1.Controls.Add(this.labelControl2);
            this.GroupControl1.Controls.Add(this.cboNhomPhieu);
            this.GroupControl1.Controls.Add(this.txtLoaiPhieu);
            this.GroupControl1.Controls.Add(this.labelControl1);
            this.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupControl1.Location = new System.Drawing.Point(0, 0);
            this.GroupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GroupControl1.Name = "GroupControl1";
            this.GroupControl1.Size = new System.Drawing.Size(431, 89);
            this.GroupControl1.TabIndex = 0;
            this.GroupControl1.Text = "Thông tin";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 33);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(74, 17);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Nhóm phiếu";
            // 
            // cboNhomPhieu
            // 
            this.cboNhomPhieu.Location = new System.Drawing.Point(92, 30);
            this.cboNhomPhieu.Name = "cboNhomPhieu";
            this.cboNhomPhieu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboNhomPhieu.Properties.Items.AddRange(new object[] {
            "THU",
            "CHI"});
            this.cboNhomPhieu.Size = new System.Drawing.Size(327, 22);
            this.cboNhomPhieu.TabIndex = 1;
            // 
            // txtLoaiPhieu
            // 
            this.txtLoaiPhieu.Location = new System.Drawing.Point(92, 59);
            this.txtLoaiPhieu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtLoaiPhieu.Name = "txtLoaiPhieu";
            this.txtLoaiPhieu.Size = new System.Drawing.Size(327, 22);
            this.txtLoaiPhieu.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 62);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(61, 17);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Loại phiếu";
            // 
            // btnThoat
            // 
            this.btnThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.ImageOptions.Image")));
            this.btnThoat.Location = new System.Drawing.Point(343, 97);
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
            this.btnLuu.Location = new System.Drawing.Point(260, 97);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(76, 28);
            this.btnLuu.TabIndex = 1;
            this.btnLuu.Text = "&Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // frmThemLoaiChiPhi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 143);
            this.Controls.Add(this.GroupControl1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnLuu);
            this.KeyPreview = true;
            this.Name = "frmThemLoaiChiPhi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loại Phiếu Thu Chi";
            this.Load += new System.EventHandler(this.frmThemLoaiChiPhi_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmThemKho_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl1)).EndInit();
            this.GroupControl1.ResumeLayout(false);
            this.GroupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboNhomPhieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoaiPhieu.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal DevExpress.XtraEditors.GroupControl GroupControl1;
        internal DevExpress.XtraEditors.SimpleButton btnThoat;
        internal DevExpress.XtraEditors.SimpleButton btnLuu;
        internal DevExpress.XtraEditors.TextEdit txtLoaiPhieu;
        internal DevExpress.XtraEditors.LabelControl labelControl1;
        internal DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cboNhomPhieu;
    }
}
