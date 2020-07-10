using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace QuanLyNhaHang.DanhMuc
{
    public partial class frmThemKho : XtraForm
    {
        public frmThemKho()
        {
            InitializeComponent();
        }

        public frmKho frm1_copy;
        public delegate void PassDataB2A(string text);
        public void funObjectB(frmKho frm1)
        {
            this.frm1_copy = frm1;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenKho.Text.Length > 0)
            {
                string _strMaKho = "";
                if (Data.CheckID("select count(*) from tbl_kho") == 0)
                {
                    _strMaKho = "K01";
                }
                else
                {
                    _strMaKho = Data.GetData("SELECT 'K'||substr('00'||CAST(substr(max(makho),2,2)+1 as varchar),-2) from tbl_kho");
                }

                Data.RunCMD($@"insert into tbl_kho(makho, tenkho, nguoitd, thoigian) values ('{_strMaKho}','{ txtTenKho.Text }', '{ Data._strtendangnhap.ToUpper() }', '{ DateTime.Now}')");

                //Ghi lại log
                Data.HistoryLog("Đã thêm tên kho " + txtTenKho.Text + ".", "Danh mục kho");
                //Xóa text
                txtTenKho.Text = "";
                //Gửi dữ liệu load form chính
                PassDataB2A datasend = new PassDataB2A(frm1_copy.funDataA);
                datasend(DateTime.Now.ToString());
            }
            else
            {
                XtraMessageBox.Show("Bạn phải nhập vào tên kho.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenKho.Focus();
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

        private void frmThemKho_Load(object sender, EventArgs e)
        {

        }
    }
}
