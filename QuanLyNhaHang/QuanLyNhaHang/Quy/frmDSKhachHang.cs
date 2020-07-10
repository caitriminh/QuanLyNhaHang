using System;

namespace QuanLyNhaHang.Quy
{
    public partial class frmDSKhachHang : DevExpress.XtraEditors.XtraForm
    {
        public frmDSKhachHang()
        {
            InitializeComponent();
        }

        public void LoadKhachHang()
        {
            var ds = Data.LoadData("select * from tbl_khachhang where makh<>'KH0000' order by makh");
            dgvKhachHang.DataSource = ds.Tables[0];
            lblMaKH.DataBindings.Clear();
            lblMaKH.DataBindings.Add("text", ds.Tables[0], "makh");
        }

        private void btnHuyBo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnChon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Data._str_NhanVien = Data.GetData($@"select tenkh from tbl_khachhang where makh='{lblMaKH.Text}'");
            //Gửi dữ liệu load form chính
            if (Data._int_flag == 1)
            {
                PassDataB2A datasend = new PassDataB2A(frm1_copy.funDataA);
                datasend(DateTime.Now.ToString());
            }
            else if (Data._int_flag == 2)
            {
                PassDataB2A_phieuchi datasend = new PassDataB2A_phieuchi(frm1_copy_phieuchi.funDataA);
                datasend(DateTime.Now.ToString());
            }

            Close();
        }

        public frmThemPhieuThu frm1_copy;
        public delegate void PassDataB2A(string text);
        public void funObjectB(frmThemPhieuThu frm1)
        {
            this.frm1_copy = frm1;
        }

        public frmThemPhieuChi frm1_copy_phieuchi;
        public delegate void PassDataB2A_phieuchi(string text);
        public void funObjectB_phieuchi(frmThemPhieuChi frm1_phieuchi)
        {
            this.frm1_copy_phieuchi = frm1_phieuchi;
        }

        private void frmDSKhachHang_Load(object sender, EventArgs e)
        {
            LoadKhachHang();
        }

        private void frmDSKhachHang_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            Data._int_flag = 0;
        }
    }
}
