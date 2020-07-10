using DevExpress.XtraEditors;
using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace QuanLyNhaHang.QuanTri
{
    public partial class frmThemNguoiDung : DevExpress.XtraEditors.XtraForm
    {
        public frmThemNguoiDung()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDangNhap.Text))
            {
                XtraMessageBox.Show("Bạn phải nhập vào tên đăng nhập.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                XtraMessageBox.Show("Bạn phải nhập vào mật khẩu đăng nhập.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }
            if (txtMatKhau.Text != txtMatKhau2.Text)
            {
                XtraMessageBox.Show("Mật khẩu nhập lại không đúng.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau2.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                XtraMessageBox.Show("Bạn vui lòng nhập vào mã nhân viên.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return;
            }
            if (Data.CheckID("select count(*) from tbl_nguoidung where tendangnhap='" + txtTenDangNhap.Text.ToUpper() + "'") == 0)
            {
                string sql = $@"insert into tbl_nguoidung(tendangnhap, manv, matkhau, ghichu, nguoitd, thoigian) values (@tendangnhap, @manv, @matkhau, @ghichu, @nguoitd, @thoigian)";

                SQLiteCommand sqlCom = new SQLiteCommand(sql, Data.strconnect);
                sqlCom.Parameters.AddWithValue("@tendangnhap", txtTenDangNhap.Text.ToUpper());
                sqlCom.Parameters.AddWithValue("@manv", txtMaNV.Text.ToUpper());
                sqlCom.Parameters.AddWithValue("@matkhau", Data.Md5(txtMatKhau.Text));
                sqlCom.Parameters.AddWithValue("@ghichu", txtGhiChu.Text);
                sqlCom.Parameters.AddWithValue("@nguoitd", Data._strtendangnhap.ToUpper());
                sqlCom.Parameters.AddWithValue("@thoigian", DateTime.Now);
                Data.open_connect();
                sqlCom.ExecuteNonQuery();
                Data.close_connect();
                //Ghi lại log
                Data.HistoryLog("Đã thêm người dùng có tên là " + txtTenDangNhap.Text + ".", "Danh mục người dùng");
                XoaText();
                //Gửi dữ liệu load form chính
                PassDataB2A datasend = new PassDataB2A(frm1_copy.funDataA);
                datasend(DateTime.Now.ToString());
            }
            else
            {
                XtraMessageBox.Show("Tên người dùng này đã tồn tại.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDangNhap.Text = "";
                txtTenDangNhap.Focus();
            }
        }


        public frmNguoiDung frm1_copy;
        public delegate void PassDataB2A(string text);
        public void funObjectB(frmNguoiDung frm1)
        {
            this.frm1_copy = frm1;
        }


        public void XoaText()
        {
            txtTenDangNhap.Text = "";
            txtMaNV.Text = "";
            lblTenNV.Text = "";
            txtGhiChu.Text = "";
            txtMatKhau.Text = "";
            txtMatKhau2.Text = "";
            txtTenDangNhap.Focus();
        }
        private void btn_nhaplai_Click(object sender, EventArgs e)
        {
            XoaText();
        }

        private void txt_tendanhnhap_Leave(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = txtTenDangNhap.Text.ToUpper();
        }

        private void txtMaNV_Leave(object sender, EventArgs e)
        {
            txtMaNV.Text = txtMaNV.Text.ToUpper();
            lblTenNV.Text = Data.GetData($@"select tennv from tbl_nhanvien where manv='{txtMaNV.Text}'");
        }

        private void frmThemNguoiDung_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btn_Luu_Click(sender, e);
                    break;
                case Keys.Escape:
                    Application.Exit();
                    break;
            }
        }
    }
}
