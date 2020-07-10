using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyNhaHang.HoatDong
{
    public partial class frmThemKhachHang : XtraForm
    {
        public frmThemKhachHang()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                XtraMessageBox.Show("Bạn phải nhập vào mã khách hàng.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaKH.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtKhachHang.Text))
            {
                XtraMessageBox.Show("Bạn phải nhập vào tên khách hàng.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKhachHang.Focus();
                return;
            }
            TaoMaKhachHang();
            Data.RunCMD($@"insert into tbl_khachhang (makh, manhomkh, tenkh, sofax, diachi, sodt, ghichu, nguoitd, thoigian) values ('{txtMaKH.Text}','{cboNhomKH.EditValue}','{ txtKhachHang.Text.ToUpper() }', '{ txtSoFax.Text }', '{ txtDiaChi.Text }', '{ txtSoDT.Text }', '{ txtGhiChu.Text }', '{ Data._strtendangnhap.ToUpper() }','{ DateTime.Now.ToString() }')");
            Data._str_makh = txtMaKH.Text;
            XoaText();

            //Gửi dữ liệu load form chính
            if (Data._int_flag == 1)
            {
                PassDataB2A datasend = new PassDataB2A(frm1_copy.funDataA);
                datasend(DateTime.Now.ToString());
            }
            else if (Data._int_flag == 2)
            {
                PassDataB2A_XK datasend = new PassDataB2A_XK(frm1_copy_XK.funDataA_XuatKho);
                datasend(DateTime.Now.ToString());
            }
        }

        public void XoaText()
        {
            TaoMaKhachHang();
            txtKhachHang.Text = "";
            txtDiaChi.Text = "";
            txtSoFax.Text = "";
            txtSoDT.Text = "";
            txtGhiChu.Text = "";
            txtKhachHang.Focus();
        }

        public void TaoMaKhachHang()
        {
            var ds = Data.LoadData("select * from tbl_khachhang");
            if (ds.Tables[0].Rows.Count == 0)
            {
                txtMaKH.Text = "KH0001";
            }
            else
            {
                txtMaKH.Text = Data.GetData("SELECT 'KH'||substr('0000'||CAST(substr(max(makh),3,4)+1 as varchar),-4) from tbl_khachhang");
            }
        }
        private void btn_nhaplai_Click(object sender, EventArgs e)
        {
            XoaText();
        }

        public frmKhachHang frm1_copy;
        public delegate void PassDataB2A(string text);
        public void funObjectB(frmKhachHang frm1)
        {
            this.frm1_copy = frm1;
        }

        public frmThemXuatKho2 frm1_copy_XK;
        public delegate void PassDataB2A_XK(string text);
        public void funObjectB_XK(frmThemXuatKho2 frm1_XK)
        {
            this.frm1_copy_XK = frm1_XK;
        }

        private void frmThemKhachHang_Load(object sender, EventArgs e)
        {
            TaoMaKhachHang();
            LoadNhomKH();
        }

        public void LoadNhomKH()
        {
            var imageCollection = new ImageCollection();
            cboNhomKH.Properties.SmallImages = imageCollection;
            int i = 0;
            var ds = Data.LoadData("select * from tbl_nhomkhachhang order by nhomkh");
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                string url_item = Application.StartupPath + @"\img\nhomkh\" + item["hinh"];
                var image_item = Image.FromFile(url_item);
                imageCollection.AddImage(image_item, item["nhomkh"].ToString());
                cboNhomKH.Properties.Items.Add(new ImageComboBoxItem(item["nhomkh"].ToString(), item["manhomkh"].ToString(), i));
                i++;
            }
            cboNhomKH.SelectedIndex = 0;
        }

        private void frmThemKhachHang_KeyDown(object sender, KeyEventArgs e)
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

        private void txtKhachHang_Leave(object sender, EventArgs e)
        {
            txtKhachHang.Text = txtKhachHang.Text.ToUpper();
        }

        private void frmThemKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            Data._int_flag = 1;
        }
    }
}
