using DevExpress.XtraEditors;
using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace QuanLyNhaHang.NhanSu
{
    public partial class frmThemTamUng : DevExpress.XtraEditors.XtraForm
    {
        public frmThemTamUng()
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
            if (string.IsNullOrEmpty(txtLyDo.Text))
            {
                XtraMessageBox.Show("Bạn phải nhập lý do ứng lương của nhân viên.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLyDo.Focus();
                return;
            }
            if (Convert.ToDouble(txtSoTien.Text) <= 0)
            {
                XtraMessageBox.Show("Bạn phải nhập vào số tiền tạm ứng.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string sql = $@"insert into tbl_tamung(manv, sotien, ngayung, lydo, nguoitd, thoigian) values (@manv, @sotien, @ngayung, @lydo, @nguoitd, @thoigian)";

            SQLiteCommand sqlCom = new SQLiteCommand(sql, Data.strconnect);
            sqlCom.Parameters.AddWithValue("@manv", cboNhanVien.EditValue);
            sqlCom.Parameters.AddWithValue("@sotien", Convert.ToInt32(txtSoTien.Text));
            sqlCom.Parameters.AddWithValue("@ngayung", Convert.ToDateTime(dateNgayUng.EditValue).ToString("yyyy-MM-dd"));
            sqlCom.Parameters.AddWithValue("@lydo", txtLyDo.Text);
            sqlCom.Parameters.AddWithValue("@nguoitd", Data._strtendangnhap.ToUpper());
            sqlCom.Parameters.AddWithValue("@thoigian", DateTime.Now);
            Data.open_connect();
            sqlCom.ExecuteNonQuery();
            Data.close_connect();
            //Ghi lại log
            Data.HistoryLog("Đã thêm ứng lương nhân viên có tên là " + cboNhanVien.Text + ".", "Danh mục ứng lương");
            XoaText();
            //Gửi dữ liệu load form chính
            PassDataB2A datasend = new PassDataB2A(frm1_copy.funDataA);
            datasend(DateTime.Now.ToString());

        }


        public frmTamUng frm1_copy;
        public delegate void PassDataB2A(string text);
        public void funObjectB(frmTamUng frm1)
        {
            this.frm1_copy = frm1;
        }

        public void XoaText()
        {
            cboNhanVien.EditValue = DBNull.Value;
            txtSoTien.Text = "0";
            dateNgayUng.EditValue = DateTime.Now.Date;
            txtLyDo.Text = "";
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


        private void frmThemTamUng_KeyDown(object sender, KeyEventArgs e)
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

        private void frmThemTamUng_Load(object sender, EventArgs e)
        {
            dateNgayUng.EditValue = DateTime.Now.Date;
            LoadNhanVien();
        }
    }
}
