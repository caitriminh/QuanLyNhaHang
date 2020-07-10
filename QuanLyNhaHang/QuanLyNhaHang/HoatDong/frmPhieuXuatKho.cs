using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace QuanLyNhaHang.HoatDong
{
    public partial class frmPhieuXuatKho : DevExpress.XtraEditors.XtraForm
    {
        public frmPhieuXuatKho()
        {
            InitializeComponent();
        }

        int i = 0;
        public void LoadPhieuXuat()
        {
            var ds = new DataSet();
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;

            ds = Data.LoadData("SELECT * from view_phieuxuat where ngayxuat>='" + Convert.ToDateTime(dateTuNgay.EditValue).ToString("yyyy-MM-dd") + "' and ngayxuat<='" + Convert.ToDateTime(dateDenNgay.EditValue).ToString("yyyy-MM-dd") + "' and chuyenkho=0 order by maphieu desc");
            dgvPhieuXuat.DataSource = ds.Tables[0];
            lblMaPhieu.DataBindings.Clear();
            lblMaPhieu.DataBindings.Add("text", ds.Tables[0], "maphieu");
            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Data._int_flag = 2;
            if (frm2 == null || frm2.IsDisposed)
                frm2 = new frmThemXuatKho2();
            frm2.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm2.funObjectB);
            sendIDObjectfrm1(this);
        }

        frmThemXuatKho2 frm2 = new frmThemXuatKho2();
        public delegate void PassIDform1(frmPhieuXuatKho frm1_copy);
        public void funDataA(string txtform2)
        {
            label1A.Text = txtform2;
        }

        private void label1A_TextChanged(object sender, EventArgs e)
        {
            LoadPhieuXuat();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Data._int_flag = 2;
            Data._strmaphieu = lblMaPhieu.Text;
            Data._edit = true;
            if (frm2 == null || frm2.IsDisposed)
                frm2 = new frmThemXuatKho2();
            frm2.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm2.funObjectB);
            sendIDObjectfrm1(this);
        }

        private void lblMaPhieu_TextChanged(object sender, EventArgs e)
        {
            LoadChiTietPhieuXuat();
        }

        public void LoadChiTietPhieuXuat()
        {
            var ds = Data.LoadData("SELECT * from view_chitiet_phieuxuat where maphieu='" + lblMaPhieu.Text + "' order by tenhang");
            dgvChiTietXuatKho.DataSource = ds.Tables[0];
        }

        private void btnNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadPhieuXuat();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dgr = XtraMessageBox.Show("Bạn có muốn xóa phiếu xuất kho " + lblMaPhieu.Text + " này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                Data.RunCMD("delete from tbl_chitiet_phieuxuat where maphieu='" + lblMaPhieu.Text + "'");
                Data.RunCMD("delete from tbl_phieuxuat where maphieu='" + lblMaPhieu.Text + "'");
                //Ghi lại log
                Data.HistoryLog("Đã xóa phiếu xuất kho " + lblMaPhieu.Text + ".", "Phiếu xuất kho");
                LoadPhieuXuat();
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (ReferenceEquals(e.Column, col_xoa))
            {
                var dgr = XtraMessageBox.Show("Bạn có muốn xóa phiếu xuất kho " + lblMaPhieu.Text + " này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dgr == DialogResult.Yes)
                {
                    Data.RunCMD("delete from tbl_chitiet_phieuxuat where maphieu='" + lblMaPhieu.Text + "'");
                    Data.RunCMD("delete from tbl_phieuxuat where maphieu='" + lblMaPhieu.Text + "'");
                    //Ghi lại log
                    Data.HistoryLog("Đã xóa phiếu xuất kho " + lblMaPhieu.Text + ".", "Phiếu xuất kho");
                    LoadPhieuXuat();
                }
            }
        }

        private void LuuPhieuXuat()
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
                    string sql = "update tbl_phieuxuat set ngayxuat=@ngayxuat, diengiai=@diengiai, thoigian2=@thoigian2, nguoitd2=@nguoitd2 where maphieu=@maphieu";

                    SQLiteCommand sqlCom = new SQLiteCommand(sql, Data.strconnect);
                    sqlCom.Parameters.AddWithValue("@maphieu", dr["maphieu"]);
                    sqlCom.Parameters.AddWithValue("@ngayxuat", Convert.ToDateTime(dr["ngayxuat"]).ToString("yyyy-MM-dd"));
                    sqlCom.Parameters.AddWithValue("@diengiai", dr["diengiai"]);
                    sqlCom.Parameters.AddWithValue("@nguoitd2", Data._strtendangnhap.ToUpper());
                    sqlCom.Parameters.AddWithValue("@thoigian2", DateTime.Now);
                    Data.open_connect();
                    sqlCom.ExecuteNonQuery();
                    Data.close_connect();
                    //Ghi lại log
                    Data.HistoryLog("Đã cập nhật phiếu xuất kho " + dr["maphieu"] + ".", "Phiếu xuất kho");
                }
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lblMaPhieu.Focus();
            DialogResult dgrResult = XtraMessageBox.Show("Bạn có muốn lưu lại những thay đổi phiếu xuất kho không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgrResult == DialogResult.Yes)
            {
                LuuPhieuXuat();
            }
        }

        private void btn_excel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xtraSaveFileDialog1.Filter = "Excel files |*.xlsx";
            xtraSaveFileDialog1.FileName = "PhieuXuatKho_" + DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss"); ;
            if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string strLenh = "SELECT maphieu as [Mã phiếu], mancc as [Mã NCC], ncc as [Nhà cung cấp], ngaynhap as [Ngày nhập], nguoilap as [Người lập], mahang as [Mã hàng hóa], tenhang as [Tên hàng hóa], tendvt as [ĐVT], soluong as [Số lượng], dongia as [Đơn giá], thanhtien as [Thành tiền], ghichu as [Ghi chú] from view_chitiet_phieunhap where maphieu='" + lblMaPhieu.Text + "'";
                var arr = mdl_ExportExcel.LoadSQL2ListArr(strLenh);
                mdl_ExportExcel.ExportListArr2Excel(arr, xtraSaveFileDialog1.FileName);
            }
        }

        private void frmPhieuXuatKho_Load(object sender, EventArgs e)
        {
            dateTuNgay.EditValue = DateTime.Now.Date.ToString("01/MM/yyyy");
            dateDenNgay.EditValue = DateTime.Now.Date;
            LoadPhieuXuat();
        }
    }
}
