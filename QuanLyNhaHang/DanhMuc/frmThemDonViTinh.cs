using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace QuanLyNhaHang.DanhMuc
{
    public partial class frmThemDonViTinh : XtraForm
    {
        public frmThemDonViTinh()
        {
            InitializeComponent();
        }

        public frmDonViTinh frm1_copy;
        public delegate void PassDataB2A(string text);
        public void funObjectB(frmDonViTinh frm1)
        {
            this.frm1_copy = frm1;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txt_tendvt.Text.Length > 0)
            {
                Data.RunCMD($@"insert into tbl_donvitinh (tendvt, nguoitd, thoigian) values ('{ txt_tendvt.Text }', '{ Data._strtendangnhap.ToUpper() }', '{ DateTime.Now}')");

                //Ghi lại log
                Data.HistoryLog("Đã thêm đơn vị tính " + txt_tendvt.Text + ".", "Danh mục đơn vị tính");

                txt_tendvt.Text = "";
                //Gửi dữ liệu load form chính
                PassDataB2A datasend = new PassDataB2A(frm1_copy.funDataA);
                datasend(DateTime.Now.ToString());
            }
            else
            {
                XtraMessageBox.Show("Bạn phải nhập vào tên đơn vị tính.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_tendvt.Focus();
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
