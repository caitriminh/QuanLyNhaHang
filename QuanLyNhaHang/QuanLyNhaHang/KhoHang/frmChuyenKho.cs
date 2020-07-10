using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyNhaHang.KhoHang
{
    public partial class frmChuyenKho : DevExpress.XtraEditors.XtraForm
    {
        public frmChuyenKho()
        {
            InitializeComponent();
        }

        int i = 0;
        public void LoadChuyenKho()
        {
            var ds = new DataSet();
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;

            ds = Data.LoadData($@"SELECT * from view_phieuxuat where ngayxuat>='{ Convert.ToDateTime(dateTuNgay.EditValue).ToString("yyyy-MM-dd") }' and ngayxuat<='{ Convert.ToDateTime(dateDenNgay.EditValue).ToString("yyyy-MM-dd") }' and chuyenkho=1 order by maphieu desc");
            dgvChuyenKho.DataSource = ds.Tables[0];
            lblMaPhieu.DataBindings.Clear();
            lblMaPhieu.DataBindings.Add("text", ds.Tables[0], "maphieu");
            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm2 == null || frm2.IsDisposed)
                frm2 = new frmThemChuyenKho();
            frm2.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm2.funObjectB);
            sendIDObjectfrm1(this);
        }

        frmThemChuyenKho frm2 = new frmThemChuyenKho();
        public delegate void PassIDform1(frmChuyenKho frm1_copy);
        public void funDataA(string txtform2)
        {
            label1A.Text = txtform2;
        }

        private void label1A_TextChanged(object sender, EventArgs e)
        {
            LoadChuyenKho();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Data._strmaphieu = lblMaPhieu.Text;
            Data._edit = true;
            if (frm2 == null || frm2.IsDisposed)
                frm2 = new frmThemChuyenKho();
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
            var ds = Data.LoadData($@"SELECT * from view_chitiet_phieuxuat where maphieu='{ lblMaPhieu.Text }' order by tenhang");
            dgvChiTietChuyenKho.DataSource = ds.Tables[0];
        }

        private void btnNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadChuyenKho();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dgr = XtraMessageBox.Show("Bạn có muốn xóa phiếu chuyển kho " + lblMaPhieu.Text + " này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                Data.RunCMD($@"delete from tbl_chitiet_phieuxuat where maphieu='{ lblMaPhieu.Text }'");
                Data.RunCMD($@"delete from tbl_phieuxuat where maphieu='{ lblMaPhieu.Text }'");
                //Ghi lại log
                Data.HistoryLog("Đã xóa phiếu chuyển kho " + lblMaPhieu.Text + ".", "Phiếu chuyển kho");
                LoadChuyenKho();
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            if (ReferenceEquals(e.Column, col_xoa))
            {
                DialogResult dgr = XtraMessageBox.Show("Bạn có muốn xóa phiếu chuyển kho " + lblMaPhieu.Text + " này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dgr == DialogResult.Yes)
                {
                    Data.RunCMD($@"delete from tbl_chitiet_phieuxuat where maphieu='{ lblMaPhieu.Text }'");
                    Data.RunCMD($@"delete from tbl_phieuxuat where maphieu='{ lblMaPhieu.Text }'");

                    //Ghi lại log
                    Data.HistoryLog("Đã xóa phiếu chuyển kho " + lblMaPhieu.Text + ".", "Phiếu chuyển kho");
                    LoadChuyenKho();
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
                    Data.RunCMD($@"update tbl_phieuxuat set diengiai='{ dr["diengiai"] }', thoigian2='{DateTime.Now.ToString() }' where maphieu='{ dr["maphieu"] }'");
                    //Ghi lại log
                    Data.HistoryLog("Đã cập nhật phiếu chuyển kho " + dr["maphieu"] + ".", "Phiếu chuyển kho");
                }
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lblMaPhieu.Focus();
            DialogResult dgrResult = XtraMessageBox.Show("Bạn có muốn lưu lại những thay đổi phiếu chuyển kho này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgrResult == DialogResult.Yes)
            {
                LuuPhieuNhap();
            }
        }

        private void btn_excel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xtraSaveFileDialog1.Filter = "Excel files |*.xlsx";
            xtraSaveFileDialog1.FileName = "PhieuChuyenKho_" + DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss"); ;
            if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string strLenh = "SELECT maphieu as [Mã phiếu], mancc as [Mã NCC], ncc as [Nhà cung cấp], ngaynhap as [Ngày nhập], nguoilap as [Người lập], mahang as [Mã hàng hóa], tenhang as [Tên hàng hóa], tendvt as [ĐVT], soluong as [Số lượng], dongia as [Đơn giá], thanhtien as [Thành tiền], ghichu as [Ghi chú] from view_chitiet_phieuxuat where maphieu='" + lblMaPhieu.Text + "'";
                var arr = mdl_ExportExcel.LoadSQL2ListArr(strLenh);
                mdl_ExportExcel.ExportListArr2Excel(arr, xtraSaveFileDialog1.FileName);
            }
        }

        private void frmChuyenKho_Load(object sender, EventArgs e)
        {
            dateTuNgay.EditValue = DateTime.Now.Date.ToString("01/MM/yyyy");
            dateDenNgay.EditValue = DateTime.Now.Date;
            LoadChuyenKho();
        }
    }
}
