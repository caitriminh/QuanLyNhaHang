using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace QuanLyNhaHang.DanhMuc
{
    public partial class frmThemLoaiChiPhi : XtraForm
    {
        public frmThemLoaiChiPhi()
        {
            InitializeComponent();
        }

        public frmLoaiChiPhi frm1_copy;
        public delegate void PassDataB2A(string text);
        public void funObjectB(frmLoaiChiPhi frm1)
        {
            this.frm1_copy = frm1;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboNhomPhieu.Text))
            {
                XtraMessageBox.Show("Bạn hãy nhập vào nhóm phiếu.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNhomPhieu.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtLoaiPhieu.Text))
            {
                XtraMessageBox.Show("Bạn phải nhập vào tên kho.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLoaiPhieu.Focus();
                return;
            }

            Data.RunCMD($@"insert into tbl_loaiphieuthuchi(loaiphieu, nhomphieu, nguoitd, thoigian) values ('{txtLoaiPhieu.Text}','{ cboNhomPhieu.Text }', '{ Data._strtendangnhap.ToUpper() }', '{ DateTime.Now}')");

            //Ghi lại log
            Data.HistoryLog("Đã thêm loại phiếu thu chi " + txtLoaiPhieu.Text + ".", "Danh mục loại phiếu thu chi");
            //Xóa text
            txtLoaiPhieu.Text = "";
            txtLoaiPhieu.Focus();
            //Gửi dữ liệu load form chính
            PassDataB2A datasend = new PassDataB2A(frm1_copy.funDataA);
            datasend(DateTime.Now.ToString());
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

        private void frmThemLoaiChiPhi_Load(object sender, EventArgs e)
        {
            cboNhomPhieu.SelectedIndex = 0;
        }
    }
}
