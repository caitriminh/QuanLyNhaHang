using DevExpress.XtraEditors;
using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace QuanLyNhaHang.NhanSu
{
    public partial class frmThemCaLamViec : XtraForm
    {
        public frmThemCaLamViec()
        {
            InitializeComponent();
        }

        public frmCaLamViec frm1_copy;
        public delegate void PassDataB2A(string text);
        public void funObjectB(frmCaLamViec frm1)
        {
            this.frm1_copy = frm1;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtCaLamViec.Text.Length > 0)
            {
                string sql = $@"insert into tbl_calamviec(calamviec, nguoitd, thoigian) values(@calamviec, @nguoitd, @thoigian)";

                SQLiteCommand sqlCom = new SQLiteCommand(sql, Data.strconnect);
                sqlCom.Parameters.AddWithValue("@calamviec", txtCaLamViec.Text);
                sqlCom.Parameters.AddWithValue("@nguoitd", Data._strtendangnhap.ToUpper());
                sqlCom.Parameters.AddWithValue("@thoigian", DateTime.Now);
                Data.open_connect();
                sqlCom.ExecuteNonQuery();
                Data.close_connect();
                //Ghi lại log
                Data.HistoryLog("Đã thêm ca làm việc " + txtCaLamViec.Text + ".", "Danh mục ca làm việc");
                //Xóa text
                txtCaLamViec.Text = "";
                //Gửi dữ liệu load form chính
                PassDataB2A datasend = new PassDataB2A(frm1_copy.funDataA);
                datasend(DateTime.Now.ToString());
            }
            else
            {
                XtraMessageBox.Show("Bạn phải nhập vào ca làm việc.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCaLamViec.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmThemCaLamViec_KeyDown(object sender, KeyEventArgs e)
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
