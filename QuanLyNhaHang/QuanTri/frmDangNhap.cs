using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace QuanLyNhaHang.QuanTri
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }
        public string is_login { set; get; }
        public string username { set; get; }
        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //public MainView frm1_copy;
        //public delegate void PassDataB2A(string text);
        //public void funObjectB(MainView frm1)
        //{
        //    this.frm1_copy = frm1;
        //}

        private void frm_dangnhap_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btn_dangnhap_Click(sender, e);
                    break;
                case Keys.Escape:
                    Application.Exit();
                    break;
            }
        }

        private void frm_dangnhap_Load(object sender, EventArgs e)
        {
            txt_tendangnhap.Focus();
        }

        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            int i = Data.CheckID("select count (*) from tbl_nguoidung where tendangnhap='" + txt_tendangnhap.Text.ToUpper() + "' and matkhau='" + Data.Md5(txt_matkhau.Text) + "'");
            if (i == 1)
            {
                Data._strtendangnhap = txt_tendangnhap.Text.ToUpper();
                Data.HistoryLog("Đã đăng nhập vào hệ thống.", "Đăng nhập");

                //Gửi dữ liệu load form chính
                //PassDataB2A datasend = new PassDataB2A(frm1_copy.FunDataA);
                //datasend(DateTime.Now.ToString());
                this.is_login = "OK";
                this.username = txt_tendangnhap.Text.Trim();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                txt_tendangnhap.Text = "";
                txt_matkhau.Text = "";
                txt_tendangnhap.Focus();
                XtraMessageBox.Show("Đăng nhập không thành công.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }
        }


    }
}
