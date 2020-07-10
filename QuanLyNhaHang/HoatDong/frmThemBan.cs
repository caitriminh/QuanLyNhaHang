using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace QuanLyNhaHang.HoatDong
{
    public partial class frmThemBan : XtraForm
    {
        public frmThemBan()
        {
            InitializeComponent();
        }

        public frmBan frm1_copy;
        public delegate void PassDataB2A(string text);
        public void funObjectB(frmBan frm1)
        {
            this.frm1_copy = frm1;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenBan.Text.Length > 0)
            {
                Data.RunCMD($@"insert into tbl_ban(makhuvuc, tenban, nguoitd, thoigian) values ('{cboKhuVuc.EditValue}','{ txtTenBan.Text }', '{ Data._strtendangnhap.ToUpper() }', '{ DateTime.Now}')");

                //Ghi lại log
                Data.HistoryLog("Đã thêm bàn " + txtTenBan.Text + ".", "Danh mục bàn");
                //Xóa text
                txtTenBan.Text = "";
                //Gửi dữ liệu load form chính
                PassDataB2A datasend = new PassDataB2A(frm1_copy.funDataA);
                datasend(DateTime.Now.ToString());
            }
            else
            {
                XtraMessageBox.Show("Bạn phải nhập vào tên khu vực.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenBan.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmThemBan_Load(object sender, EventArgs e)
        {
            LoadKhuVuc();
        }

        public void LoadKhuVuc()
        {
            var ds = Data.LoadData("select * from tbl_khuvuc order by khuvuc");
            cboKhuVuc.Properties.DataSource = ds.Tables[0];
            cboKhuVuc.Properties.ValueMember = "makhuvuc";
            cboKhuVuc.Properties.DisplayMember = "khuvuc";
        }
        private void frmThemBan_KeyDown(object sender, KeyEventArgs e)
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
