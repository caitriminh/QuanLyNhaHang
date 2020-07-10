using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace QuanLyNhaHang.HoatDong
{
    public partial class frmBaoCaoKhoHang : DevExpress.XtraEditors.XtraForm
    {
        public frmBaoCaoKhoHang()
        {
            InitializeComponent();
        }

        private void frmBaoCaoKhoHang_Load(object sender, EventArgs e)
        {
            dateTuNgay.EditValue = DateTime.Now.Date.ToString("01/MM/yyyy");
            dateDenNgay.EditValue = DateTime.Now.Date;
            LoadDanhSachPhieuNhap();
        }

        public void LoadDanhSachPhieuNhap()
        {
            var ds = Data.LoadData($@"SELECT ngaynhap, count(maphieu) as sophieu, sum(thanhtien) as tongtien from view_chitiet_phieunhap where ngaynhap>='{Convert.ToDateTime(dateTuNgay.EditValue).ToString("yyyy-MM-dd")}' and ngaynhap<='{Convert.ToDateTime(dateDenNgay.EditValue).ToString("yyyy-MM-dd")}' GROUP BY ngaynhap");
            dgvDSPhieuNhap.DataSource = ds.Tables[0];
            lblNgayNhap.DataBindings.Clear();
            lblNgayNhap.DataBindings.Add("text", ds.Tables[0], "ngaynhap");
        }

        public void LoadDSCTMatHang()
        {
            var ds = Data.LoadData($@"SELECT mahang, tenhang, tendvt, nhomhang, sum(soluong) as soluong, dongia, sum(thanhtien) as thanhtien from view_chitiet_phieunhap where ngaynhap='{Convert.ToDateTime(lblNgayNhap.Text).ToString("yyyy-MM-dd")}' GROUP BY mahang, tenhang, nhomhang, dongia, tendvt");
            dgvDSCTPhieuNhap.DataSource = ds.Tables[0];
        }

        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadDanhSachPhieuNhap();
        }

        private void btnNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadDanhSachPhieuNhap();
        }

        private void lblNgayNhap_TextChanged(object sender, EventArgs e)
        {
            LoadDSCTMatHang();
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage1")
            {
                LoadDanhSachPhieuNhap();
            }
            else if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage2")
            {
                LoadBaoCaoTheoMatHang();
            }
        }

        public void LoadBaoCaoTheoMatHang()
        {
            var ds = Data.LoadData($@"SELECT mahang, tenhang, tendvt, nhomhang, sum(soluong) as soluong, dongia, sum(thanhtien) as thanhtien from view_chitiet_phieunhap where ngaynhap>='{Convert.ToDateTime(dateTuNgay.EditValue).ToString("yyyy-MM-dd")}' and ngaynhap<='{Convert.ToDateTime(dateDenNgay.EditValue).ToString("yyyy-MM-dd")}' GROUP BY mahang, tenhang, nhomhang, dongia, tendvt");
            dgvBaoCaoMatHang.DataSource = ds.Tables[0];
        }

        private void btnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xtraSaveFileDialog1.Filter = "Excel files |*.xlsx";
            if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage1")
            {
                xtraSaveFileDialog1.FileName = "DanhSachPhieuNhap_" + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss");
                if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string strLenh = $@"SELECT ngaynhap as [Ngày nhập], mahang [Mã hàng], nhomhang as [Nhóm hàng], tenhang as [Tên hàng], tendvt as [ĐVT], sum(soluong) as [Số lượng], dongia as [Đơn giá], sum(thanhtien) as [Thành tiền] from view_chitiet_phieunhap where ngaynhap >= '{Convert.ToDateTime(dateTuNgay.EditValue).ToString("yyyy-MM-dd")}' and ngaynhap<='{Convert.ToDateTime(dateDenNgay.EditValue).ToString("yyyy-MM-dd")}' GROUP BY mahang, tenhang, nhomhang, dongia, tendvt, ngaynhap";
                    var arr = mdl_ExportExcel.LoadSQL2ListArr(strLenh);
                    mdl_ExportExcel.ExportListArr2Excel(arr, xtraSaveFileDialog1.FileName);
                }
            }
            else if (xtraTabControl1.SelectedTabPage.Name == "xtraTabPage2")
            {
                xtraSaveFileDialog1.FileName = "BaoCaoTheoMatHang_" + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss");
                if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    dgvBaoCaoMatHang.ExportToXlsx(xtraSaveFileDialog1.FileName);
                    Process.Start(xtraSaveFileDialog1.FileName);
                }
            }
        }
    }
}
