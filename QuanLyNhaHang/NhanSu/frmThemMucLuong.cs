using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SQLite;

namespace QuanLyNhaHang.NhanSu
{
    public partial class frmThemMucLuong : DevExpress.XtraEditors.XtraForm
    {
        public frmThemMucLuong()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboNhanVien.Text))
            {
                XtraMessageBox.Show("Bạn phải nhập vào tên nhân viên.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNhanVien.Focus();
                return;
            }
            if (Convert.ToDouble(txtMucLuong.Text) <= 0)
            {
                XtraMessageBox.Show("Bạn phải nhập vào mức lương.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMucLuong.Text = "0";
                return;
            }
            string sql = $@"insert into tbl_mucluong(manv, macalamviec, mucluong, ngaynhap, ghichu, nguoitd, thoigian) values (@manv, @macalamviec, @mucluong, @ngaynhap, @ghichu, @nguoitd, @thoigian)";

            SQLiteCommand sqlCom = new SQLiteCommand(sql, Data.strconnect);
            sqlCom.Parameters.AddWithValue("@manv", cboNhanVien.EditValue);
            sqlCom.Parameters.AddWithValue("@macalamviec", cboCaLamViec.EditValue);
            sqlCom.Parameters.AddWithValue("@mucluong", Convert.ToDouble(txtMucLuong.Text));
            sqlCom.Parameters.AddWithValue("@ngaynhap", Convert.ToDateTime(dateNgayNhap.EditValue).ToString("yyyy-MM-dd"));
            sqlCom.Parameters.AddWithValue("@ghichu", txtGhiChu.Text);
            sqlCom.Parameters.AddWithValue("@nguoitd", Data._strtendangnhap.ToUpper());
            sqlCom.Parameters.AddWithValue("@thoigian", DateTime.Now);
            Data.open_connect();
            sqlCom.ExecuteNonQuery();
            Data.close_connect();
            //Ghi lại log
            Data.HistoryLog("Đã thêm mức lương nhân viên có tên là " + cboNhanVien.Text + ".", "Danh mục mức lương");
            XoaText();
            //Gửi dữ liệu load form chính
            PassDataB2A datasend = new PassDataB2A(frm1_copy.funDataA);
            datasend(DateTime.Now.ToString());

        }


        public frmMucLuong frm1_copy;
        public delegate void PassDataB2A(string text);
        public void funObjectB(frmMucLuong frm1)
        {
            this.frm1_copy = frm1;
        }

        public void XoaText()
        {
            cboCaLamViec.EditValue = DBNull.Value;
            txtMucLuong.Text = "1";
            dateNgayNhap.EditValue = DateTime.Now.Date;
            txtGhiChu.Text = "";
            cboNhanVien.Focus();
        }
        private void btn_nhaplai_Click(object sender, EventArgs e)
        {
            XoaText();
        }

        public void LoadNhanVien()
        {
            var ds = Data.LoadData("select * from tbl_nhanvien order by manv");
            cboNhanVien.Properties.DataSource = ds.Tables[0];
            cboNhanVien.Properties.DisplayMember = "tennv";
            cboNhanVien.Properties.ValueMember = "manv";
        }

        public void LoadCaLamViec()
        {
            var ds = Data.LoadData("select * from tbl_calamviec order by calamviec");
            cboCaLamViec.Properties.DataSource = ds.Tables[0];
            cboCaLamViec.Properties.DisplayMember = "calamviec";
            cboCaLamViec.Properties.ValueMember = "id";
        }

        private void frmThemMucLuong_Load(object sender, EventArgs e)
        {
            dateNgayNhap.EditValue = DateTime.Now.Date;
            LoadCaLamViec();
            LoadNhanVien();
        }

        private void frmThemMucLuong_KeyDown(object sender, KeyEventArgs e)
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