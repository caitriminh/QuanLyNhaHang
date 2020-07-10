using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyNhaHang.HoatDong
{
    public partial class frmThongKeDoanhThu : DevExpress.XtraEditors.XtraForm
    {
        public frmThongKeDoanhThu()
        {
            InitializeComponent();
        }

        int i = 0;
        public void LoadHoaDon()
        {
            var ds = new DataSet();
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            if (i == 0)
            {
                ds = Data.LoadData($@"SELECT * from view_hoadon where ngayban>='{Convert.ToDateTime(dateTuNgay.EditValue).ToString("yyyy-MM-01")}' and ngayban<='{Convert.ToDateTime(dateDenNgay.EditValue).ToString("yyyy-MM-dd")}' order by mahoadon");
            }
            else if (i == 1)
            {
                ds = Data.LoadData($@"SELECT * from view_hoadon where ngayban>='{Convert.ToDateTime(dateTuNgay.EditValue).ToString("yyyy-MM-dd")}' and ngayban<='{Convert.ToDateTime(dateDenNgay.EditValue).ToString("yyyy-MM-dd")}' order by mahoadon");
            }
            dgvHoaDon.DataSource = ds.Tables[0];
            lblMaHoaDon.DataBindings.Clear();
            lblMaHoaDon.DataBindings.Add("text", ds.Tables[0], "mahoadon");
            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }


        private void lblMaPhieu_TextChanged(object sender, EventArgs e)
        {

        }

        public void LoadChiTietHoaDon()
        {
            var ds = Data.LoadData("SELECT * from view_chitiet_hoadon where mahoadon='" + lblMaHoaDon.Text + "' order by tenhang");
            dgvChiTietHoaDon.DataSource = ds.Tables[0];
        }

        private void btnNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadHoaDon();
        }


        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            if (ReferenceEquals(e.Column, col_xoa))
            {
                DialogResult dgr = XtraMessageBox.Show("Bạn có muốn mã hóa đơn " + lblMaHoaDon.Text + " này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dgr == DialogResult.Yes)
                {
                    Data.RunCMD("delete from tbl_chitiet_hoadon where mahoadon='" + lblMaHoaDon.Text + "'");
                    Data.RunCMD("delete from tbl_hoadon where mahoadon='" + lblMaHoaDon.Text + "'");

                    //Ghi lại log
                    Data.HistoryLog("Đã xóa hóa đơn bán hàng " + lblMaHoaDon.Text + ".", "Hóa đơn bán hàng");
                    LoadHoaDon();
                }
            }
        }



        private void btn_excel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount <= 0)
            {
                XtraMessageBox.Show("Bạn phải chọn danh mục hóa đơn để thực hiện.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            xtraSaveFileDialog1.Filter = "Excel files |*.xlsx";
            xtraSaveFileDialog1.FileName = "ThongKeDoanhThu_" + DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss"); ;
            if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var selectedRows = gridView1.GetSelectedRows();
                var joinMaHoaDon = string.Join("','", from r in selectedRows select gridView1.GetRowCellValue(Convert.ToInt32(r), "mahoadon"));

                string strLenh = "SELECT mahoadon as [Mã hóa đơn], ngayban as [Ngày], tenban as [Bàn], thanhtien as [Tiền hàng], phidichvu as [Phí dịch vụ], giamgia as [Giảm giá], tongtien as [Tổng tiền], nguoilap as [Thu ngân], giobd1 as [Bắt đầu], giokt1 as [Kết thúc], tenkh as [Khách hàng] from view_hoadon where mahoadon in ('" + joinMaHoaDon + "') order by mahoadon desc";
                var arr = mdl_ExportExcel.LoadSQL2ListArr(strLenh);
                mdl_ExportExcel.ExportListArr2Excel(arr, xtraSaveFileDialog1.FileName);
            }
        }

        private void frmThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            dateTuNgay.EditValue = DateTime.Now.Date;
            dateDenNgay.EditValue = DateTime.Now.Date;
            LoadHoaDon();
        }

        private void lblMaHoaDon_TextChanged(object sender, EventArgs e)
        {
            LoadChiTietHoaDon();
        }

        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            i = 1;
            LoadHoaDon();
        }
    }
}
