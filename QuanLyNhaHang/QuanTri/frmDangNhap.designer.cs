namespace QuanLyNhaHang.QuanTri
{
    partial class frmDangNhap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDangNhap));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_tendangnhap = new DevExpress.XtraEditors.TextEdit();
            this.txt_matkhau = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btn_dangnhap = new DevExpress.XtraEditors.SimpleButton();
            this.btn_thoat = new DevExpress.XtraEditors.SimpleButton();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_tendangnhap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_matkhau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 146);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(93, 17);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Tên đăng nhập";
            // 
            // txt_tendangnhap
            // 
            this.txt_tendangnhap.EditValue = "admin";
            this.txt_tendangnhap.Location = new System.Drawing.Point(121, 143);
            this.txt_tendangnhap.Name = "txt_tendangnhap";
            this.txt_tendangnhap.Properties.Mask.EditMask = "\\p{Ll}+";
            this.txt_tendangnhap.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txt_tendangnhap.Size = new System.Drawing.Size(327, 22);
            this.txt_tendangnhap.TabIndex = 2;
            // 
            // txt_matkhau
            // 
            this.txt_matkhau.EditValue = "123";
            this.txt_matkhau.Location = new System.Drawing.Point(121, 171);
            this.txt_matkhau.Name = "txt_matkhau";
            this.txt_matkhau.Properties.PasswordChar = '●';
            this.txt_matkhau.Size = new System.Drawing.Size(327, 22);
            this.txt_matkhau.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 174);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(56, 17);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Mật khẩu";
            // 
            // btn_dangnhap
            // 
            this.btn_dangnhap.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_dangnhap.ImageOptions.Image")));
            this.btn_dangnhap.Location = new System.Drawing.Point(251, 204);
            this.btn_dangnhap.Name = "btn_dangnhap";
            this.btn_dangnhap.Size = new System.Drawing.Size(101, 28);
            this.btn_dangnhap.TabIndex = 5;
            this.btn_dangnhap.Text = "Đăng nhập";
            this.btn_dangnhap.Click += new System.EventHandler(this.btn_dangnhap_Click);
            // 
            // btn_thoat
            // 
            this.btn_thoat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_thoat.ImageOptions.Image")));
            this.btn_thoat.Location = new System.Drawing.Point(358, 204);
            this.btn_thoat.Name = "btn_thoat";
            this.btn_thoat.Size = new System.Drawing.Size(90, 28);
            this.btn_thoat.TabIndex = 6;
            this.btn_thoat.Text = "&Thoát";
            this.btn_thoat.Click += new System.EventHandler(this.btn_thoat_Click);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(-2, 0);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Size = new System.Drawing.Size(460, 130);
            this.pictureEdit1.TabIndex = 0;
            // 
            // frm_dangnhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 248);
            this.ControlBox = false;
            this.Controls.Add(this.btn_thoat);
            this.Controls.Add(this.btn_dangnhap);
            this.Controls.Add(this.txt_matkhau);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txt_tendangnhap);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.pictureEdit1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_dangnhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng Nhập";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frm_dangnhap_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_dangnhap_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.txt_tendangnhap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_matkhau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txt_tendangnhap;
        private DevExpress.XtraEditors.TextEdit txt_matkhau;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btn_dangnhap;
        private DevExpress.XtraEditors.SimpleButton btn_thoat;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}
