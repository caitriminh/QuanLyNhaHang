using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace QuanLyNhaHang.HoatDong
{
    public partial class frmDoiMatKhau : DevExpress.XtraEditors.XtraForm
    {
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_tendangnhap.Text))
            {
                XtraMessageBox.Show("Bạn phải nhập vào tên đăng nhập.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_tendangnhap.Focus();
                return;
            }
            //so sanh tên đăng nhâp vs password
            int i = Data.CheckID("select count(*) from tbl_nguoidung where tendangnhap='" + txt_tendangnhap.Text.ToLower() + "' and matkhau='" + txt_matkhau.Text + "'");
            if (i > 0)
            {
                if (txt_matkhaumoi.Text == txt_nhaplai_matkhaumoi.Text)
                {
                    Data.RunCMD("update tbl_nguoidung set matkhau='" + Data.Md5(txt_matkhaumoi.Text) + "' where tendangnhap='" + txt_tendangnhap.Text + "'");
                    //Ghi lại log
                    Data.HistoryLog("Đổi mật khẩu.", "Đổi mật khẩu");
                    XtraMessageBox.Show("Bạn đã đổi mật khẩu thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Mật khẩu bạn nhập vào không khớp.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_matkhaumoi.Text = "";
                    txt_nhaplai_matkhaumoi.Text = "";
                    txt_matkhaumoi.Focus();
                }
            }
            else
            {
                XtraMessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_matkhaumoi.Text = "";
                txt_nhaplai_matkhaumoi.Text = "";
                txt_matkhau.Text = "";
                txt_tendangnhap.Text = "";
                txt_tendangnhap.Focus();
            }
        }

        private void frm_doimatkhau_Load(object sender, EventArgs e)
        {
            txt_tendangnhap.Text = Data._strtendangnhap.ToUpper();
        }
    }
}
