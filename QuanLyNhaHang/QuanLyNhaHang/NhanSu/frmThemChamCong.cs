using DevExpress.XtraEditors;
using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace QuanLyNhaHang.NhanSu
{
    public partial class frmThemChamCong : DevExpress.XtraEditors.XtraForm
    {
        public frmThemChamCong()
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
            if (Convert.ToDouble(txtSoCong.Text) <= 0)
            {
                XtraMessageBox.Show("Bạn phải nhập vào số công.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoCong.Text = "0";
                return;
            }
            if (Data.CheckID($@"select count(*) from tbl_chamcong where manv='{cboNhanVien.EditValue}' and ngaychamcong='{Convert.ToDateTime(dateNgayThang.EditValue).ToString("yyyy-MM-dd")}' and macalamviec='{cboCaLamViec.EditValue}'") > 0)
            {
                XtraMessageBox.Show($@"Ca làm việc của nhân viên {cboNhanVien.Text} này đã tồn tại.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
            string sql = $@"insert into tbl_chamcong(manv, macalamviec, socong, ngaychamcong, ghichu, nguoitd, thoigian) values (@manv, @macalamviec, @socong, @ngaychamcong, @ghichu, @nguoitd, @thoigian)";

            SQLiteCommand sqlCom = new SQLiteCommand(sql, Data.strconnect);
            sqlCom.Parameters.AddWithValue("@manv", cboNhanVien.EditValue);
            sqlCom.Parameters.AddWithValue("@macalamviec", cboCaLamViec.EditValue);
            sqlCom.Parameters.AddWithValue("@socong", Convert.ToInt32(txtSoCong.Text));
            sqlCom.Parameters.AddWithValue("@ngaychamcong", Convert.ToDateTime(dateNgayThang.EditValue).ToString("yyyy-MM-dd"));
            sqlCom.Parameters.AddWithValue("@ghichu", txtGhiChu.Text);
            sqlCom.Parameters.AddWithValue("@nguoitd", Data._strtendangnhap.ToUpper());
            sqlCom.Parameters.AddWithValue("@thoigian", DateTime.Now);
            Data.open_connect();
            sqlCom.ExecuteNonQuery();
            Data.close_connect();
            //Ghi lại log
            Data.HistoryLog("Đã thêm chấm công nhân viên có tên là " + cboNhanVien.Text + ".", "Danh mục chấm công");
            XoaText();
            //Gửi dữ liệu load form chính
            PassDataB2A datasend = new PassDataB2A(frm1_copy.funDataA);
            datasend(DateTime.Now.ToString());

        }


        public frmChamCong frm1_copy;
        public delegate void PassDataB2A(string text);
        public void funObjectB(frmChamCong frm1)
        {
            this.frm1_copy = frm1;
        }

        public void XoaText()
        {
            //cboNhanVien.EditValue = DBNull.Value;
            //cboCaLamViec.EditValue = DBNull.Value;
            txtSoCong.Text = "1";
            dateNgayThang.EditValue = DateTime.Now.Date;
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
            cboNhanVien.EditValue = Data._str_id;
        }

        public void LoadCaLamViec()
        {
            var ds = Data.LoadData("select * from tbl_calamviec order by calamviec");
            cboCaLamViec.Properties.DataSource = ds.Tables[0];
            cboCaLamViec.Properties.DisplayMember = "calamviec";
            cboCaLamViec.Properties.ValueMember = "id";
        }

        private void frmThemChamCong_Load(object sender, EventArgs e)
        {
            dateNgayThang.EditValue = DateTime.Now.Date;
            LoadCaLamViec();
            LoadNhanVien();
        }

        private void frmThemChamCong_KeyDown(object sender, KeyEventArgs e)
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
