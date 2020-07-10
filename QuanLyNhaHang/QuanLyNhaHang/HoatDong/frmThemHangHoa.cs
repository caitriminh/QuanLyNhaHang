using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyNhaHang.HoatDong
{
    public partial class frmThemHangHoa : XtraForm
    {
        public frmThemHangHoa()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        string _strMaHang = "";
        public void TaoMaMatHang()
        {
            if (Data.CheckID("select count(*) from tbl_hanghoa") == 0)
            {
                _strMaHang = "MH0001";
            }
            else
            {
                _strMaHang = Data.GetData("SELECT 'MH'||substr('0000'||CAST(substr(max(mahang),3,4)+1 as varchar),-4) from tbl_hanghoa");
            }
            txtMaHang.Text = _strMaHang;
        }
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaHang.Text))
            {
                XtraMessageBox.Show("Bạn phải nhập vào mã khách hàng.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaHang.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtTenHang.Text))
            {
                XtraMessageBox.Show("Bạn phải nhập vào tên mặt hàng.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenHang.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cboNhomHang.Text))
            {
                XtraMessageBox.Show("Bạn phải nhập vào nhóm mặt hàng.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNhomHang.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cboLoaiHangHoa.Text))
            {
                XtraMessageBox.Show("Bạn phải nhập vào loại hàng hóa.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLoaiHangHoa.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cboDVT.Text))
            {
                XtraMessageBox.Show("Bạn phải nhập đơn vị tính của mặt hàng.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboDVT.Focus();
                return;
            }
            if (Data.CheckID($@"select count(*) from tbl_hanghoa where mahang='{txtMaHang.Text}'") > 0) { XtraMessageBox.Show("Mã hàng " + txtMaHang.Text + " này đã tồn tại.", "Cảnh Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); return; }

            string sql = "insert into tbl_hanghoa(mahang, tenhang, maloaihanghoa, manhomhang, madvt, gianhap, giaban, ghichu, nguoitd, thoigian) values (@mahang, @tenhang, @maloaihanghoa, @manhomhang, @madvt, @gianhap, @giaban, @ghichu, @nguoitd, @thoigian)";

            SQLiteCommand sqlCom = new SQLiteCommand(sql, Data.strconnect);
            sqlCom.Parameters.AddWithValue("@mahang", txtMaHang.Text);
            sqlCom.Parameters.AddWithValue("@tenhang", txtTenHang.Text);
            sqlCom.Parameters.AddWithValue("@maloaihanghoa", cboLoaiHangHoa.EditValue);
            sqlCom.Parameters.AddWithValue("@manhomhang", cboNhomHang.EditValue);
            sqlCom.Parameters.AddWithValue("@madvt", cboDVT.EditValue);
            sqlCom.Parameters.AddWithValue("@gianhap", Convert.ToDouble(txtDonGiaNhap.Text));
            sqlCom.Parameters.AddWithValue("@giaban", Convert.ToDouble(txtDonGiaBan.Text));
            sqlCom.Parameters.AddWithValue("@ghichu", txtGhiChu.Text);
            sqlCom.Parameters.AddWithValue("@nguoitd", Data._strtendangnhap.ToUpper());
            sqlCom.Parameters.AddWithValue("@thoigian", DateTime.Now);
            Data.open_connect();
            sqlCom.ExecuteNonQuery();
            Data.close_connect();

            XoaText();

            //Gửi dữ liệu load form chính
            PassDataB2A datasend = new PassDataB2A(frm1_copy.funDataA);
            datasend(DateTime.Now.ToString());
        }

        public void XoaText()
        {
            txtMaHang.Text = Data.GetData("SELECT 'MH'||substr('0000'||CAST(substr(max(mahang),3,4)+1 as varchar),-4) from tbl_hanghoa");
            txtTenHang.Text = "";
            txtDonGiaNhap.Text = "0";
            txtDonGiaBan.Text = "0";
            txtGhiChu.Text = "";
            txtTenHang.Focus();
        }
        private void btn_nhaplai_Click(object sender, EventArgs e)
        {
            XoaText();
        }

        public frmHangHoa frm1_copy;
        public delegate void PassDataB2A(string text);
        public void funObjectB(frmHangHoa frm1)
        {
            this.frm1_copy = frm1;
        }

        private void frmThemHangHoa_Load(object sender, EventArgs e)
        {
            TaoMaMatHang();
            LoadLoaiHangHoa();
            LoadNhomHang();
            LoadDonViTinh();
        }

        //public void LoadNhomHang()
        //{
        //    var ds = Data.LoadData("select * from tbl_nhomhang order by nhomhang");
        //    cboNhomHang.Properties.DataSource = ds.Tables[0];
        //    cboNhomHang.Properties.ValueMember = "manhom";
        //    cboNhomHang.Properties.DisplayMember = "nhomhang";
        //}

        public void LoadNhomHang()
        {
            var imageCollection = new ImageCollection();
            cboNhomHang.Properties.SmallImages = imageCollection;
            int i = 0;
            var ds = Data.LoadData("select * from tbl_nhomhang order by nhomhang");
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                string url_item = Application.StartupPath + "\\img\\" + item["hinh"];
                var image_item = Image.FromFile(url_item);
                imageCollection.AddImage(image_item, item["nhomhang"].ToString());
                cboNhomHang.Properties.Items.Add(new ImageComboBoxItem(item["nhomhang"].ToString(), item["manhom"].ToString(), i));
                i++;
            }
            cboNhomHang.SelectedIndex = 0;
        }

        public void LoadLoaiHangHoa()
        {
            var imageCollection = new ImageCollection();
            cboLoaiHangHoa.Properties.SmallImages = imageCollection;
            int i = 0;
            var ds = Data.LoadData("select * from tbl_loaihanghoa order by loaihanghoa");
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                string url_item = Application.StartupPath + @"\img\loaihang\" + item["hinh"];
                var image_item = Image.FromFile(url_item);
                imageCollection.AddImage(image_item, item["loaihanghoa"].ToString());
                cboLoaiHangHoa.Properties.Items.Add(new ImageComboBoxItem(item["loaihanghoa"].ToString(), item["maloai"].ToString(), i));
                i++;
            }
            cboLoaiHangHoa.SelectedIndex = 0;
        }
        public void LoadDonViTinh()
        {
            var ds = Data.LoadData("select * from tbl_donvitinh order by tendvt");
            cboDVT.Properties.DataSource = ds.Tables[0];
            cboDVT.Properties.ValueMember = "madvt";
            cboDVT.Properties.DisplayMember = "tendvt";
        }

        private void frmThemHangHoa_KeyDown(object sender, KeyEventArgs e)
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
    }
}
