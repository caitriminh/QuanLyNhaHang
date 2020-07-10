using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace QuanLyNhaHang.QuanTri
{
    public partial class frmThemSoDu : XtraForm
    {
        public frmThemSoDu()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboTenHang.Text))
            {
                XtraMessageBox.Show("Bạn phải chọn tên hàng hóa để cập nhật.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTenHang.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtSoLuong.Text))
            {
                XtraMessageBox.Show("Bạn phải nhập vào số dư đầu kỳ.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }

            if (Convert.ToDouble(txtSoLuong.Text) <= 0) { XtraMessageBox.Show("Số đầu kỳ phải lớn hơn 0.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (Convert.ToDouble(lblThanhTien.Text) <= 0) { XtraMessageBox.Show("Số tiền đầu kỳ phải lớn hơn 0.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            //Data.Data._run_cmd($@"INSERT INTO tbl_sodudauky(ngaythang, mahanghoa, slton, tiendau, nguoitd, thoigian) values ('{Convert.ToDateTime(date_ngaythang.EditValue).ToString("yyyy-MM-01")}','{cbo_tenhanghoa.EditValue}','{Convert.ToDouble(txt_soluong.Text)}','{Convert.ToDouble(lblThanhTien.Text)}','{Data.Data._strtendangnhap.ToUpper()}','{DateTime.Now}')");
            string sql = "insert into tbl_sodudauky(ngaynhap, idmahang, makho, sodu, tiendau, ghichu, nguoitd, thoigian) values (@ngaynhap, @mahang, @Makho, @sodu, @tiendau,  @ghichu, @nguoitd, @thoigian)";

            SQLiteCommand sqlCom = new SQLiteCommand(sql, Data.strconnect);
            sqlCom.Parameters.AddWithValue("@ngaynhap", Convert.ToDateTime(date_ngaythang.EditValue).ToString("yyyy-MM-01"));
            sqlCom.Parameters.AddWithValue("@mahang", cboTenHang.EditValue);
            sqlCom.Parameters.AddWithValue("@makho", cboKhoHang.EditValue);
            sqlCom.Parameters.AddWithValue("@sodu", Convert.ToDouble(txtSoLuong.Text));
            sqlCom.Parameters.AddWithValue("@tiendau", Convert.ToDouble(lblThanhTien.Text));
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
            cboTenHang.EditValue = DBNull.Value;
            txtSoLuong.Text = "0";
            txtDonGia.Text = "0";
            lblThanhTien.Text = "0";
            cboTenHang.Focus();
        }

        public frmSoDu frm1_copy;
        public delegate void PassDataB2A(string text);
        public void funObjectB(frmSoDu frm1)
        {
            this.frm1_copy = frm1;
        }

        public void LoadTenHangHoa()
        {
            DataSet ds = new DataSet();
            ds = Data.LoadData("select id, mahang, nhomhang, tenhang, tendvt from view_hanghoa order by tenhang");
            cboTenHang.Properties.DataSource = ds.Tables[0];
            cboTenHang.Properties.DisplayMember = "tenhang";
            cboTenHang.Properties.ValueMember = "id";
        }


        private void cbo_tenhanghoa_Click(object sender, EventArgs e)
        {
            gridLookUpEdit1View.FocusedRowHandle = GridControl.AutoFilterRowHandle;
            gridLookUpEdit1View.FocusedColumn = gridLookUpEdit1View.Columns["tenhang"];
            gridLookUpEdit1View.ShowEditor();
        }

        private void txt_soluong_TextChanged(object sender, EventArgs e)
        {
            double thanhtien = Convert.ToDouble(txtDonGia.Text) * Convert.ToDouble(txtSoLuong.Text);
            lblThanhTien.Text = thanhtien.ToString("#,##0.0");
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            double thanhtien = Convert.ToDouble(txtDonGia.Text) * Convert.ToDouble(txtSoLuong.Text);
            lblThanhTien.Text = thanhtien.ToString("#,##0.0");
        }

        private void frmThemSoDu_Load(object sender, EventArgs e)
        {
            date_ngaythang.EditValue = DateTime.Now.Date.ToString("01/MM/yyyy");
            LoadTenHangHoa();
            LoadKhoHang();
        }

        public void LoadKhoHang()
        {
            var ds = Data.LoadData("select makho, tenkho from tbl_kho order by tenkho");
            cboKhoHang.Properties.DataSource = ds.Tables[0];
            cboKhoHang.Properties.DisplayMember = "tenkho";
            cboKhoHang.Properties.ValueMember = "makho";

        }
        private void frmThemSoDu_KeyDown(object sender, KeyEventArgs e)
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
