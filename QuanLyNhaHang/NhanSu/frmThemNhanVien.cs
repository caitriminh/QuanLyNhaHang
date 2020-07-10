using DevExpress.XtraEditors;
using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace QuanLyNhaHang.NhanSu
{
    public partial class frmThemNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public frmThemNhanVien()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                XtraMessageBox.Show("Bạn phải nhập vào tên đăng nhập.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtHoTen.Text))
            {
                XtraMessageBox.Show("Bạn phải nhập vào tên nhân viên.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cboGioiTinh.Text))
            {
                XtraMessageBox.Show("Bạn vui lòng chọn giới tính nhân viên", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboGioiTinh.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtNoiSinh.Text))
            {
                XtraMessageBox.Show("Bạn vui lòng nhập vào nơi sinh nhân viên", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoiSinh.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cboChucVu.Text))
            {
                XtraMessageBox.Show("Bạn vui lòng nhập vào chức vụ nhân viên", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboChucVu.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cboCaLamViec.Text))
            {
                XtraMessageBox.Show("Bạn vui lòng nhập vào ca làm việc nhân viên", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCaLamViec.Focus();
                return;
            }
            if (Data.CheckID("select count(*) from tbl_nhanvien where manv='" + txtMaNV.Text + "'") == 0)
            {
                string sql = $@"insert into tbl_nhanvien(manv, tennv, gioitinh, noisinh, ngaysinh, diachi, macalamviec, machucvu, ghichu, nguoitd, thoigian) values(@manv, @tennv, @gioitinh, @noisinh, @ngaysinh, @diachi, @macalamviec, @machucvu, @ghichu, @nguoitd, @thoigian)";

                SQLiteCommand sqlCom = new SQLiteCommand(sql, Data.strconnect);
                sqlCom.Parameters.AddWithValue("@manv", txtMaNV.Text);
                sqlCom.Parameters.AddWithValue("@tennv", txtHoTen.Text);
                sqlCom.Parameters.AddWithValue("@gioitinh", cboGioiTinh.Text);
                sqlCom.Parameters.AddWithValue("@noisinh", txtNoiSinh.Text);
                sqlCom.Parameters.AddWithValue("@ngaysinh", Convert.ToDateTime(dateNgaySinh.EditValue).ToString("yyyy-MM-dd"));
                sqlCom.Parameters.AddWithValue("@diachi", txtDiaChi.Text);
                sqlCom.Parameters.AddWithValue("@macalamviec", cboCaLamViec.EditValue);
                sqlCom.Parameters.AddWithValue("@machucvu", cboChucVu.EditValue);
                sqlCom.Parameters.AddWithValue("@ghichu", txtGhiChu.Text);
                sqlCom.Parameters.AddWithValue("@nguoitd", Data._strtendangnhap.ToUpper());
                sqlCom.Parameters.AddWithValue("@thoigian", DateTime.Now);
                Data.open_connect();
                sqlCom.ExecuteNonQuery();
                Data.close_connect();
                //Ghi lại log
                Data.HistoryLog("Đã thêm nhân viên có tên là " + txtHoTen.Text + ".", "Danh mục nhân viên");
                XoaText();
                //Gửi dữ liệu load form chính
                PassDataB2A datasend = new PassDataB2A(frm1_copy.funDataA);
                datasend(DateTime.Now.ToString());
            }
            else
            {
                XtraMessageBox.Show($@"Tên nhân viên {txtHoTen.Text} đã tồn tại.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaNV.Text = "";
                txtMaNV.Focus();
            }
        }


        public frmNhanVien frm1_copy;
        public delegate void PassDataB2A(string text);
        public void funObjectB(frmNhanVien frm1)
        {
            this.frm1_copy = frm1;
        }

        public void XoaText()
        {
            txtMaNV.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtNoiSinh.Text = "";
            cboCaLamViec.EditValue = DBNull.Value;
            cboChucVu.EditValue = DBNull.Value;
            txtGhiChu.Text = "";
            TaoMaNhanVien();
            txtHoTen.Focus();
        }
        private void btn_nhaplai_Click(object sender, EventArgs e)
        {
            XoaText();
        }

        private void frmThemNhanVien_Load(object sender, EventArgs e)
        {
            dateNgaySinh.EditValue = DateTime.Now.Date;
            TaoMaNhanVien();
            LoadCaLamViec();
            LoadChucVu();
        }

        public void TaoMaNhanVien()
        {
            var ds = Data.LoadData("select * from tbl_nhanvien");
            if (ds.Tables[0].Rows.Count <= 0)
            {
                txtMaNV.Text = "NV001";
            }
            else
            {
                txtMaNV.Text = Data.GetData("SELECT 'NV'||substr('000'||CAST(substr(max(manv),3,3)+1 as varchar),-3) from tbl_nhanvien");
            }
        }

        private void txtHoTen_Leave(object sender, EventArgs e)
        {
            txtHoTen.Text = txtHoTen.Text.ToUpper();
        }

        private void frmThemNhanVien_KeyDown(object sender, KeyEventArgs e)
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

        public void LoadCaLamViec()
        {
            var ds = Data.LoadData("select * from tbl_calamviec order by calamviec");
            cboCaLamViec.Properties.DataSource = ds.Tables[0];
            cboCaLamViec.Properties.DisplayMember = "calamviec";
            cboCaLamViec.Properties.ValueMember = "id";
        }

        public void LoadChucVu()
        {
            var ds = Data.LoadData("select * from tbl_chucvu order by chucvu");
            cboChucVu.Properties.DataSource = ds.Tables[0];
            cboChucVu.Properties.DisplayMember = "chucvu";
            cboChucVu.Properties.ValueMember = "id";
        }

        private void txtNoiSinh_Leave(object sender, EventArgs e)
        {
            txtNoiSinh.Text = txtNoiSinh.Text.ToUpper();
        }
    }
}
