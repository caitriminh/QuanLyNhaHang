using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace QuanLyNhaHang.NhanSu
{
    public partial class frmNhanVien : XtraForm
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private void frm_nguoidung_Load(object sender, EventArgs e)
        {

            //LoadPhanQuyen();
        }

        //public void LoadPhanQuyen()
        //{
        //    if (Data.Data._check_id($@"select count(*) from tbl_phanquyen where tendangnhap='{Data.Data._strtendangnhap.ToUpper()}' and mamenu='1' and luu='True'") == 1)
        //    {
        //        btn_Them.Enabled = true;
        //    }
        //    else
        //    {
        //        btn_Them.Enabled = false;
        //    }

        //    if (Data.Data._check_id($@"select count(*) from tbl_phanquyen where tendangnhap='{Data.Data._strtendangnhap.ToUpper()}' and mamenu='1' and xoa='True'") == 1)
        //    {
        //        btn_Xoa.Enabled = true;
        //    }
        //    else
        //    {
        //        btn_Xoa.Enabled = false;
        //    }

        //    if (Data.Data._check_id($@"select count(*) from tbl_phanquyen where tendangnhap='{Data.Data._strtendangnhap.ToUpper()}' and mamenu='1' and sua='True'") == 1)
        //    {
        //        gridView1.OptionsBehavior.ReadOnly = false;
        //        btn_Luu.Enabled = true;
        //        col_reset_password.Visible = true;
        //    }
        //    else
        //    {
        //        gridView1.OptionsBehavior.ReadOnly = true;
        //        btn_Luu.Enabled = false;
        //        col_reset_password.Visible = false;
        //    }

        //    if (Data.Data._check_id($@"select count(*) from tbl_phanquyen where tendangnhap='{Data.Data._strtendangnhap.ToUpper()}' and mamenu='1' and [in]='True'") == 1)
        //    {
        //        btn_Excel.Enabled = true;
        //    }
        //    else
        //    {
        //        btn_Excel.Enabled = false;
        //    }
        //}

        public void LoadNhanVien()
        {
            DataSet ds = new DataSet();
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            ds = Data.LoadData("select * from tbl_nhanvien order by manv");
            dgvNhanVien.DataSource = ds.Tables[0];
            lblMaNV.DataBindings.Clear();
            lblMaNV.DataBindings.Add("text", ds.Tables[0], "manv");
            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }

        public void funDataA(string txtform2)
        {
            label1A.Text = txtform2;
        }

        private void btn_Excel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xtraSaveFileDialog1.Filter = "Excel file *|.xlsx";
            xtraSaveFileDialog1.FileName = "DanhMuc_NguoiDung_" + DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss");
            if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string strLenh = "select tendangnhap, hoten, ghichu from tbl_nguoidung order by tendangnhap";
                var arr = mdl_ExportExcel.LoadSQL2ListArr(strLenh);
                mdl_ExportExcel.ExportListArr2Excel(arr, xtraSaveFileDialog1.FileName);
            }
        }

        private void label1A_TextChanged(object sender, EventArgs e)
        {
            LoadNhanVien();
        }

        private void btn_Them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm2 == null || frm2.IsDisposed)
                frm2 = new frmThemNhanVien();
            frm2.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm2.funObjectB);
            sendIDObjectfrm1(this);
        }

        frmThemNhanVien frm2 = new frmThemNhanVien();
        public delegate void PassIDform1(frmNhanVien frm1_copy);

        private void btn_Xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int i = gridView1.FocusedRowHandle;
            DialogResult dgr = XtraMessageBox.Show("Bạn có muốn xóa tên đăng nhập " + gridView1.GetRowCellValue(i, "tendangnhap") + " này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                var row = gridView1.GetFocusedDataRow();
                Data.RunCMD("delete from tbl_nguoidung where tendangnhap='" + gridView1.GetRowCellValue(i, "tendangnhap") + "'");
                //Ghi lại log
                Data.HistoryLog("Đã xóa người dùng có tên " + gridView1.GetRowCellValue(i, "tendangnhap") + ".", "Danh mục người dùng");
                row.Table.Rows.Remove(row);
            }
        }

        private void btn_NapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadNhanVien();
        }

        private void LuuNhanVien()
        {
            for (var index = 0; index <= gridView1.RowCount - 1; index++)
            {
                var dr = gridView1.GetDataRow(Convert.ToInt32(index));
                if (ReferenceEquals(dr, null))
                {
                    break;
                }
                if (dr.RowState == DataRowState.Modified)
                {
                    string sql = $@"update tbl_nhanvien set tennv=@tennv, gioitinh=@gioitinh, noisinh=@noisinh, ngaysinh=@ngaysinh, diachi=@diachi, macalamviec=@macalamviec, machucvu=@machucvu, ghichu=@ghichu, nguoitd2=@nguoitd2, thoigian2=@thoigian2 where manv=@manv";

                    SQLiteCommand sqlCom = new SQLiteCommand(sql, Data.strconnect);
                    sqlCom.Parameters.AddWithValue("@manv", dr["manv"]);
                    sqlCom.Parameters.AddWithValue("@tennv", dr["tennv"].ToString().ToUpper());
                    sqlCom.Parameters.AddWithValue("@gioitinh", dr["gioitinh"]);
                    sqlCom.Parameters.AddWithValue("@noisinh", dr["noisinh"].ToString().ToUpper());
                    sqlCom.Parameters.AddWithValue("@ngaysinh", Convert.ToDateTime(dr["ngaysinh"]).ToString("yyyy-MM-dd"));
                    sqlCom.Parameters.AddWithValue("@diachi", dr["diachi"]);
                    sqlCom.Parameters.AddWithValue("@macalamviec", dr["macalamviec"]);
                    sqlCom.Parameters.AddWithValue("@machucvu", dr["machucvu"]);
                    sqlCom.Parameters.AddWithValue("@ghichu", dr["ghichu"]);
                    sqlCom.Parameters.AddWithValue("@nguoitd2", Data._strtendangnhap.ToUpper());
                    sqlCom.Parameters.AddWithValue("@thoigian2", DateTime.Now);
                    Data.open_connect();
                    sqlCom.ExecuteNonQuery();
                    Data.close_connect();
                    //Ghi lại log
                    Data.HistoryLog("Đã cập nhật lại thông tin nhân viên có tên " + dr["tennv"].ToString().ToUpper() + ".", "Danh mục nhân viên");
                    LoadNhanVien();
                }
            }
        }

        private void btn_Luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lblMaNV.Focus();
            DialogResult dgr = XtraMessageBox.Show("Bạn có muốn lưu lại những thay đổi danh mục nhân viên không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                LuuNhanVien();
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            if (ReferenceEquals(e.Column, colXoa))
            {
                DialogResult dgr = XtraMessageBox.Show("Bạn có muốn xóa nhân viên có tên " + gridView1.GetRowCellValue(i, "tennv") + " không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dgr == DialogResult.Yes)
                {
                    Data.RunCMD($@"delete tbl_nhanvien where manv='{lblMaNV.Text}'");
                    //Ghi lại log
                    Data.HistoryLog("Đã xóa nhân viên có tên " + gridView1.GetRowCellValue(i, "tennv") + ".", "Danh mục nhân viên");
                    LoadNhanVien();
                }
            }
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadCaLamViec();
            LoadChucVu();
            LoadNhanVien();
        }

        public void LoadCaLamViec()
        {
            var ds = Data.LoadData("select * from tbl_calamviec order by calamviec");
            cboCaLamViec.DataSource = ds.Tables[0];
            cboCaLamViec.DisplayMember = "calamviec";
            cboCaLamViec.ValueMember = "id";
        }

        public void LoadChucVu()
        {
            var ds = Data.LoadData("select * from tbl_chucvu order by chucvu");
            cboChucVu.DataSource = ds.Tables[0];
            cboChucVu.DisplayMember = "chucvu";
            cboChucVu.ValueMember = "id";
        }
    }
}
