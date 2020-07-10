using DevExpress.XtraEditors;
using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace QuanLyNhaHang.DanhMuc
{
    public partial class frmThemChucVu : XtraForm
    {
        public frmThemChucVu()
        {
            InitializeComponent();
        }

        public frmChucVu frm1_copy;
        public delegate void PassDataB2A(string text);
        public void funObjectB(frmChucVu frm1)
        {
            this.frm1_copy = frm1;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtChucVu.Text.Length > 0)
            {
                string sql = $@"insert into tbl_chucvu(chucvu, nguoitd, thoigian) values(@chucvu, @nguoitd, @thoigian)";

                SQLiteCommand sqlCom = new SQLiteCommand(sql, Data.strconnect);
                sqlCom.Parameters.AddWithValue("@chucvu", txtChucVu.Text);
                sqlCom.Parameters.AddWithValue("@nguoitd", Data._strtendangnhap.ToUpper());
                sqlCom.Parameters.AddWithValue("@thoigian", DateTime.Now);
                Data.open_connect();
                sqlCom.ExecuteNonQuery();
                Data.close_connect();
                //Ghi lại log
                Data.HistoryLog("Đã thêm tên chức vụ " + txtChucVu.Text + ".", "Danh mục chức vụ");
                //Xóa text
                txtChucVu.Text = "";
                //Gửi dữ liệu load form chính
                PassDataB2A datasend = new PassDataB2A(frm1_copy.funDataA);
                datasend(DateTime.Now.ToString());
            }
            else
            {
                XtraMessageBox.Show("Bạn phải nhập vào tên kho.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChucVu.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void frmThemKho_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btnLuu_Click(sender, e);
                    break;
                case Keys.Escape:
                    Application.Exit();
                    break;
            }
        }
    }
}
