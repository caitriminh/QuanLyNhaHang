using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace QuanLyNhaHang.DanhMuc
{
    public partial class frmThemKhuVuc : XtraForm
    {
        public frmThemKhuVuc()
        {
            InitializeComponent();
        }

        public frmKhuVuc frm1_copy;
        public delegate void PassDataB2A(string text);
        public void funObjectB(frmKhuVuc frm1)
        {
            this.frm1_copy = frm1;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtKhuVuc.Text.Length > 0)
            {
                Data.RunCMD($@"insert into tbl_khuvuc(khuvuc, nguoitd, thoigian) values ('{ txtKhuVuc.Text }', '{ Data._strtendangnhap.ToUpper() }', '{ DateTime.Now}')");

                //Ghi lại log
                Data.HistoryLog("Đã thêm khu vực " + txtKhuVuc.Text + ".", "Danh mục khu vực");
                //Xóa text
                txtKhuVuc.Text = "";
                //Gửi dữ liệu load form chính
                PassDataB2A datasend = new PassDataB2A(frm1_copy.funDataA);
                datasend(DateTime.Now.ToString());
            }
            else
            {
                XtraMessageBox.Show("Bạn phải nhập vào tên khu vực.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKhuVuc.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmThemDonViTinh_KeyDown(object sender, KeyEventArgs e)
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
