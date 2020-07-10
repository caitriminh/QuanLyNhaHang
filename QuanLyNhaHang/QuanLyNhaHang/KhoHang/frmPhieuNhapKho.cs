using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyNhaHang.KhoHang
{
    public partial class frmPhieuNhapKho : DevExpress.XtraEditors.XtraForm
    {
        public frmPhieuNhapKho()
        {
            InitializeComponent();
        }

        private void frmPhieuNhapKho_Load(object sender, EventArgs e)
        {
            dateTuNgay.EditValue = DateTime.Now.Date;
            dateDenNgay.EditValue = DateTime.Now.Date;
            LoadPhieuNhap();
        }

        int i = 0;
        public void LoadPhieuNhap()
        {
            var ds = new DataSet();
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            if (i == 0)
            {
                ds = Data.LoadData($@"SELECT * from view_phieunhap where strftime('%m-%Y', ngaynhap)='{Convert.ToDateTime(dateTuNgay.EditValue).ToString("MM-yyyy")}' order by maphieu desc");
            }
            else if (i == 1)
            {
                ds = Data.LoadData("SELECT * from view_phieunhap where ngaynhap>='" + Convert.ToDateTime(dateTuNgay.EditValue).ToString("yyyy-MM-dd") + "' and ngaynhap<='" + Convert.ToDateTime(dateDenNgay.EditValue).ToString("yyyy-MM-dd") + "' order by maphieu desc");
            }
            dgvPhieuNhap.DataSource = ds.Tables[0];
            lblMaPhieu.DataBindings.Clear();
            lblMaPhieu.DataBindings.Add("text", ds.Tables[0], "maphieu");
            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Data._int_flag = 2;
            if (frm2 == null || frm2.IsDisposed)
                frm2 = new frmThemPhieuNhapKho();
            frm2.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm2.funObjectB);
            sendIDObjectfrm1(this);
        }

        frmThemPhieuNhapKho frm2 = new frmThemPhieuNhapKho();
        public delegate void PassIDform1(frmPhieuNhapKho frm1_copy);
        public void funDataA(string txtform2)
        {
            label1A.Text = txtform2;
        }

        private void label1A_TextChanged(object sender, EventArgs e)
        {
            LoadPhieuNhap();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Data._int_flag = 2;
            Data._strmaphieu = lblMaPhieu.Text;
            Data._edit = true;
            if (frm2 == null || frm2.IsDisposed)
                frm2 = new frmThemPhieuNhapKho();
            frm2.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm2.funObjectB);
            sendIDObjectfrm1(this);
        }

        private void lblMaPhieu_TextChanged(object sender, EventArgs e)
        {
            LoadChiTietPhieuNhap();
        }

        public void LoadChiTietPhieuNhap()
        {
            var ds = Data.LoadData("SELECT * from view_chitiet_phieunhap where maphieu='" + lblMaPhieu.Text + "' order by tenhang");
            dgvChiTietNhapKho.DataSource = ds.Tables[0];
        }

        private void btnNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadPhieuNhap();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dgr = XtraMessageBox.Show("Bạn có muốn xóa phiếu nhập kho " + lblMaPhieu.Text + " này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                Data.RunCMD("delete from tbl_chitiet_phieunhap where maphieu='" + lblMaPhieu.Text + "'");
                Data.RunCMD("delete from tbl_phieunhap where maphieu='" + lblMaPhieu.Text + "'");
                //Ghi lại log
                Data.HistoryLog("Đã xóa phiếu nhập kho " + lblMaPhieu.Text + ".", "Phiếu nhập kho");
                LoadPhieuNhap();
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            if (ReferenceEquals(e.Column, col_xoa))
            {
                DialogResult dgr = XtraMessageBox.Show("Bạn có muốn mã phiếu nhập kho " + lblMaPhieu.Text + " này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dgr == DialogResult.Yes)
                {
                    Data.RunCMD("delete from tbl_chitiet_phieunhap where maphieu='" + lblMaPhieu.Text + "'");
                    Data.RunCMD("delete from tbl_phieunhap where maphieu='" + lblMaPhieu.Text + "'");

                    //Ghi lại log
                    Data.HistoryLog("Đã xóa phiếu nhập kho " + lblMaPhieu.Text + ".", "Phiếu nhập kho");
                    LoadPhieuNhap();
                }
            }
        }

        private void LuuPhieuNhap()
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
                    Data.RunCMD("update tbl_phieunhap set diengiai='" + dr["diengiai"] + "', thoigian2='" + DateTime.Now.ToString() + "' where maphieu='" + dr["maphieu"] + "'");
                    //Ghi lại log
                    Data.HistoryLog("Đã cập nhật phiếu nhập kho " + dr["maphieu"] + ".", "Phiếu nhập kho");
                }
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lblMaPhieu.Focus();
            DialogResult dgrResult = XtraMessageBox.Show("Bạn có muốn lưu lại những thay đổi phiếu nhập kho không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgrResult == DialogResult.Yes)
            {
                LuuPhieuNhap();
            }
        }

        private void btn_excel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xtraSaveFileDialog1.Filter = "Excel files |*.xlsx";
            xtraSaveFileDialog1.FileName = "PhieuNhapKho_" + DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss"); ;
            if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string strLenh = "SELECT maphieu as [Mã phiếu], mancc as [Mã NCC], ncc as [Nhà cung cấp], ngaynhap as [Ngày nhập], nguoilap as [Người lập], mahang as [Mã hàng hóa], tenhang as [Tên hàng hóa], tendvt as [ĐVT], soluong as [Số lượng], dongia as [Đơn giá], thanhtien as [Thành tiền], ghichu as [Ghi chú] from view_chitiet_phieunhap where maphieu='" + lblMaPhieu.Text + "'";
                var arr = mdl_ExportExcel.LoadSQL2ListArr(strLenh);
                mdl_ExportExcel.ExportListArr2Excel(arr, xtraSaveFileDialog1.FileName);
            }
        }
    }
}
