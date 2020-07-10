namespace QuanLyNhaHang.DanhMuc
{
    partial class frmThemDonViTinh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThemDonViTinh));
            this.GroupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txt_tendvt = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnThoat = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl1)).BeginInit();
            this.GroupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tendvt.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupControl1
            // 
            this.GroupControl1.Controls.Add(this.txt_tendvt);
            this.GroupControl1.Controls.Add(this.labelControl1);
            this.GroupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupControl1.Location = new System.Drawing.Point(0, 0);
            this.GroupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GroupControl1.Name = "GroupControl1";
            this.GroupControl1.Size = new System.Drawing.Size(431, 63);
            this.GroupControl1.TabIndex = 0;
            this.GroupControl1.Text = "Thông tin";
            // 
            // txt_tendvt
            // 
            this.txt_tendvt.Location = new System.Drawing.Point(90, 33);
            this.txt_tendvt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_tendvt.Name = "txt_tendvt";
            this.txt_tendvt.Size = new System.Drawing.Size(329, 22);
            this.txt_tendvt.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 35);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(67, 17);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Đơn vị tính";
            // 
            // btnThoat
            // 
            this.btnThoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Thoat.ImageOptions.Image")));
            this.btnThoat.Location = new System.Drawing.Point(343, 71);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(76, 28);
            this.btnThoat.TabIndex = 2;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Luu.ImageOptions.Image")));
            this.btnLuu.Location = new System.Drawing.Point(260, 71);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(76, 28);
            this.btnLuu.TabIndex = 1;
            this.btnLuu.Text = "&Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // frmThemDonViTinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(431, 114);
            this.Controls.Add(this.GroupControl1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnLuu);
            this.KeyPreview = true;
            this.Name = "frmThemDonViTinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đơn Vị Tính";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmThemDonViTinh_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.GroupControl1)).EndInit();
            this.GroupControl1.ResumeLayout(false);
            this.GroupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tendvt.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal DevExpress.XtraEditors.GroupControl GroupControl1;
        internal DevExpress.XtraEditors.SimpleButton btnThoat;
        internal DevExpress.XtraEditors.SimpleButton btnLuu;
        internal DevExpress.XtraEditors.TextEdit txt_tendvt;
        internal DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
