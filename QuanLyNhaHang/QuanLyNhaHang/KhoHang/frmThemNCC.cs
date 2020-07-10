using DevExpress.XtraEditors;
using QuanLyNhaHang.HoatDong;
using System;
using System.Windows.Forms;

namespace QuanLyNhaHang.KhoHang
{
    public partial class frmThemNCC : XtraForm
    {
        public frmThemNCC()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string _strMaNCC = "";
        public void TaoMaNCC()
        {
            var ds = Data.LoadData("select * from tbl_ncc");
            if (ds.Tables[0].Rows.Count == 0)
            {
                _strMaNCC = "NCC001";
            }
            else
            {
                _strMaNCC = Data.GetData("SELECT 'NCC'||substr('000'||CAST(substr(max(mancc),4,3)+1 as varchar),-3) from tbl_ncc");
            }
            txt_mancc.Text = _strMaNCC;
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_mancc.Text))
            {
                XtraMessageBox.Show("Bạn phải nhập vào mã nhà cung cấp.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_mancc.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txt_ncc.Text))
            {
                XtraMessageBox.Show("Bạn phải nhập vào tên nhà cung cấp.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_ncc.Focus();
                return;
            }
            TaoMaNCC();
            Data.RunCMD($@"insert into tbl_ncc (mancc, ncc, diachi, sodt, sofax, email, masothue, ghichu, nguoitd, thoigian) values ('{ _strMaNCC }','{ txt_ncc.Text }','{ txt_diachi.Text }','{ txt_sodt.Text }','{ txt_sofax.Text }','{ txt_email.Text }','{ txt_masothue.Text }','{ txt_ghichu.Text }','{ Data._strtendangnhap.ToUpper() }','{ DateTime.Now.ToString() }')");
            //Ghi lại log
            Data.HistoryLog("Đã thêm mới nhà cung cấp " + txt_ncc.Text + ".", "Danh mục nhà cung cấp");
            XoaText();
            Data._str_mancc = txt_mancc.Text;
            if (Data._int_flag == 1)
            {
                //Gửi dữ liệu load form chính
                PassDataB2A datasend = new PassDataB2A(frm1_copy.funDataA);
                datasend(DateTime.Now.ToString());
            }
            else if (Data._int_flag == 2)
            {
                //Gửi dữ liệu load form chính
                PassDataB2A_NhapKho datasend_nhapkho = new PassDataB2A_NhapKho(frm2_copy.funDataA_NhapKho);
                datasend_nhapkho(DateTime.Now.ToString());
                this.Close();
            }
        }

        public frmNCC frm1_copy;
        public delegate void PassDataB2A(string text);
        public void funObjectB(frmNCC frm1)
        {
            this.frm1_copy = frm1;
        }

        public frmThemPhieuNhapKho frm2_copy;
        public delegate void PassDataB2A_NhapKho(string text);
        public void funObjectB_NhapKho(frmThemPhieuNhapKho frm2_NhapKho)
        {
            this.frm2_copy = frm2_NhapKho;
        }
        public void XoaText()
        {
            TaoMaNCC();
            txt_ncc.Text = "";
            txt_diachi.Text = "";
            txt_email.Text = "";
            txt_sodt.Text = "";
            txt_sofax.Text = "";
            txt_masothue.Text = "";
            txt_ghichu.Text = "";
            txt_ncc.Focus();
        }
        private void btn_nhaplai_Click(object sender, EventArgs e)
        {
            XoaText();
        }

        private void frmThemNCC_KeyDown(object sender, KeyEventArgs e)
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

        private void frmThemNCC_Load(object sender, EventArgs e)
        {
            TaoMaNCC();
        }
    }
}
