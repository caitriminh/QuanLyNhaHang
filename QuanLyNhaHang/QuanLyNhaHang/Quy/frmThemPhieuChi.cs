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

namespace QuanLyNhaHang.Quy
{
    public partial class frmThemPhieuChi : DevExpress.XtraEditors.XtraForm
    {
        public frmThemPhieuChi()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboLoaiPhieu.Text))
            {
                XtraMessageBox.Show("Bạn phải chọn lý do lập phiếu chi.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboLoaiPhieu.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtNguoiNop.Text))
            {
                XtraMessageBox.Show("Bạn phải nhập người nhận tiền.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNguoiNop.Focus();
                return;
            }
            if (Convert.ToDouble(txtSoTien.Text) <= 0)
            {
                XtraMessageBox.Show("Bạn phải nhập vào số tiền của phiếu chi.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string sql = "";
            if (Data._edit == false)
            {
                TaoMaPhieu();
                sql = $@"insert into tbl_phieuthuchi(maphieu, maloaiphieu, sotien, ngaylap, nguoilap, ghichu, nguoitd, thoigian) values (@maphieu, @maloaiphieu, @sotien, @ngaylap, @nguoilap, @ghichu, @nguoitd, @thoigian)";

                SQLiteCommand sqlCom = new SQLiteCommand(sql, Data.strconnect);
                sqlCom.Parameters.AddWithValue("@maphieu", txtMaPhieu.Text);
                sqlCom.Parameters.AddWithValue("@maloaiphieu", cboLoaiPhieu.EditValue);
                sqlCom.Parameters.AddWithValue("@sotien", Convert.ToInt32(txtSoTien.Text));
                sqlCom.Parameters.AddWithValue("@ngaylap", Convert.ToDateTime(dateNgayLap.EditValue).ToString("yyyy-MM-dd"));
                sqlCom.Parameters.AddWithValue("@nguoilap", txtNguoiNop.Text);
                sqlCom.Parameters.AddWithValue("@ghichu", txtGhiChu.Text);
                sqlCom.Parameters.AddWithValue("@nguoitd", Data._strtendangnhap.ToUpper());
                sqlCom.Parameters.AddWithValue("@thoigian", DateTime.Now);
                Data.open_connect();
                sqlCom.ExecuteNonQuery();
                Data.close_connect();
                //Ghi lại log
                Data.HistoryLog("Đã thêm phiếu chi " + txtMaPhieu.Text + ".", "Danh mục phiếu chi");
                XoaText();
                //Gửi dữ liệu load form chính
                PassDataB2A datasend = new PassDataB2A(frm1_copy.funDataA);
                datasend(DateTime.Now.ToString());
            }
            else
            {
                sql = $@"update tbl_phieuthuchi set maloaiphieu=@maloaiphieu, sotien=@sotien, ngaylap=@ngaylap, nguoilap=@nguoilap, ghichu=@ghichu, nguoitd2=@nguoitd2, thoigian2=@thoigian2 where maphieu=@maphieu";

                SQLiteCommand sqlCom = new SQLiteCommand(sql, Data.strconnect);
                sqlCom.Parameters.AddWithValue("@maphieu", txtMaPhieu.Text);
                sqlCom.Parameters.AddWithValue("@maloaiphieu", cboLoaiPhieu.EditValue);
                sqlCom.Parameters.AddWithValue("@sotien", Convert.ToInt32(txtSoTien.Text));
                sqlCom.Parameters.AddWithValue("@ngaylap", Convert.ToDateTime(dateNgayLap.EditValue).ToString("yyyy-MM-dd"));
                sqlCom.Parameters.AddWithValue("@nguoilap", txtNguoiNop.Text);
                sqlCom.Parameters.AddWithValue("@ghichu", txtGhiChu.Text);
                sqlCom.Parameters.AddWithValue("@nguoitd2", Data._strtendangnhap.ToUpper());
                sqlCom.Parameters.AddWithValue("@thoigian2", DateTime.Now);
                Data.open_connect();
                sqlCom.ExecuteNonQuery();
                Data.close_connect();
                //Ghi lại log
                Data.HistoryLog("Đã cập nhật phiếu chi " + txtMaPhieu.Text + ".", "Danh mục phiếu chi");
                //Gửi dữ liệu load form chính
                PassDataB2A datasend = new PassDataB2A(frm1_copy.funDataA);
                datasend(DateTime.Now.ToString());
                Close();
            }
        }


        public frmPhieuChi frm1_copy;
        public delegate void PassDataB2A(string text);
        public void funObjectB(frmPhieuChi frm1)
        {
            this.frm1_copy = frm1;
        }

        public void XoaText()
        {
            txtMaPhieu.Text = "";
            cboLoaiPhieu.EditValue = DBNull.Value;
            txtSoTien.Text = "0";
            dateNgayLap.EditValue = DateTime.Now.Date;
            txtGhiChu.Text = "";
            txtNguoiNop.Text = "";
            txtMaPhieu.Focus();
        }
        private void btn_nhaplai_Click(object sender, EventArgs e)
        {
            XoaText();
        }

        public void LoadLoaiPhieu()
        {
            var ds = Data.LoadData("select maloai as maloaiphieu, loaiphieu from tbl_loaiphieuthuchi where nhomphieu='CHI' order by loaiphieu");
            cboLoaiPhieu.Properties.DataSource = ds.Tables[0];
            cboLoaiPhieu.Properties.DisplayMember = "loaiphieu";
            cboLoaiPhieu.Properties.ValueMember = "maloaiphieu";
        }

        public void TaoMaPhieu()
        {
            DataSet ds = new DataSet();
            string _str_thang, _str_nam, _str_ngay;
            _str_thang = Convert.ToDateTime(dateNgayLap.EditValue).ToString("MM");
            _str_nam = Convert.ToDateTime(dateNgayLap.EditValue).ToString("yy");
            _str_ngay = Convert.ToDateTime(dateNgayLap.EditValue).ToString("dd");

            ds = Data.LoadData("SELECT * FROM view_phieuthuchi where strftime('%d', ngaylap)='" + _str_ngay + "' and strftime('%m', ngaylap)='" + _str_thang + "' and strftime('%Y', ngaylap)='" + Convert.ToDateTime(dateNgayLap.EditValue).ToString("yyyy") + "' and nhomphieu='CHI'");

            if (ds.Tables[0].Rows.Count == 0)
            {
                txtMaPhieu.Text = "PC" + _str_nam + _str_thang + _str_ngay + "01";
            }
            else
            {
                string _kyhieu = "PC" + _str_nam + _str_thang + _str_ngay;
                txtMaPhieu.Text = Data.GetData("SELECT '" + _kyhieu + "'||substr('00'||CAST(substr(max(maphieu),9,2)+1 as varchar),-2) from view_phieuthuchi where substr(maphieu,1,8)='" + _kyhieu + "' and nhomphieu='CHI'");
            }
        }

        private void dateNgayLap_TextChanged(object sender, EventArgs e)
        {
            if (Data._edit == true) { return; }
            TaoMaPhieu();
        }

        private void btnNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Data._int_flag = 2;
            if (frm2 == null || frm2.IsDisposed)
                frm2 = new frmNguoiNop();
            frm2.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm2.funObjectB_phieuchi);
            sendIDObjectfrm1(this);
        }

        frmNguoiNop frm2 = new frmNguoiNop();
        frmDSNCC frm1 = new frmDSNCC();
        frmDSKhachHang frm3 = new frmDSKhachHang();
        public delegate void PassIDform1(frmThemPhieuChi frm1_copy);
        public void funDataA(string txtform2)
        {
            label1A.Text = txtform2;
        }

        private void label1A_TextChanged(object sender, EventArgs e)
        {
            txtNguoiNop.Text = Data._str_NhanVien;
        }

        private void btnNCC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Data._int_flag = 2;
            if (frm1 == null || frm1.IsDisposed)
                frm1 = new frmDSNCC();
            frm1.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm1.funObjectB_phieuchi);
            sendIDObjectfrm1(this);
        }

        private void btnKhachHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Data._int_flag = 2;
            if (frm3 == null || frm3.IsDisposed)
                frm3 = new frmDSKhachHang();
            frm3.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm3.funObjectB_phieuchi);
            sendIDObjectfrm1(this);
        }

        private void dropDownButton1_Click(object sender, EventArgs e)
        {
            Data._int_flag = 2;
            if (frm2 == null || frm2.IsDisposed)
                frm2 = new frmNguoiNop();
            frm2.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm2.funObjectB_phieuchi);
            sendIDObjectfrm1(this);
        }

        private void frmThemPhieuChi_Load(object sender, EventArgs e)
        {
            dateNgayLap.EditValue = DateTime.Now.Date;
            LoadLoaiPhieu();
            if (Data._edit == true)
            {
                var ds = Data.LoadData($@"select * from tbl_phieuthuchi where maphieu='{Data._strmaphieu}'");
                if (ds.Tables[0].Rows.Count == 0) { return; }
                cboLoaiPhieu.DataBindings.Clear();
                txtMaPhieu.DataBindings.Clear();
                txtGhiChu.DataBindings.Clear();
                txtNguoiNop.DataBindings.Clear();
                txtSoTien.DataBindings.Clear();
                dateNgayLap.DataBindings.Clear();

                cboLoaiPhieu.DataBindings.Add("editvalue", ds.Tables[0], "maloaiphieu");
                txtMaPhieu.DataBindings.Add("text", ds.Tables[0], "maphieu");
                txtGhiChu.DataBindings.Add("text", ds.Tables[0], "ghichu");
                txtNguoiNop.DataBindings.Add("text", ds.Tables[0], "nguoilap");
                txtSoTien.DataBindings.Add("text", ds.Tables[0], "sotien");
                dateNgayLap.DataBindings.Add("editvalue", ds.Tables[0], "ngaylap");

                txtMaPhieu.Properties.ReadOnly = true;
            }
            else
            {
                TaoMaPhieu();
            }
        }

        private void frmThemPhieuChi_KeyDown(object sender, KeyEventArgs e)
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