using System;

namespace QuanLyNhaHang.HoatDong
{
    public partial class frmThongKeDoAnUong : DevExpress.XtraEditors.XtraForm
    {
        public frmThongKeDoAnUong()
        {
            InitializeComponent();
        }

        private void frmThongKeDoAnUong_Load(object sender, EventArgs e)
        {
            dateTuNgay.EditValue = DateTime.Now.Date.ToString("01/MM/yyyy");
            dateDenNgay.EditValue = DateTime.Now.Date;
            LoadThongKe();
        }

        public void LoadThongKe()
        {
            var ds = Data.LoadData($@"SELECT ngayban, tenban, a.idmahang, a.nhomhang, a.mahang, tenhang, tendvt, sum(soluong) as slban, sum(tongthanhtien) as doanhthu, sum(soluong)*ifnull(b.dongiavon,0) as giavon, sum(tongthanhtien)-sum(soluong)*ifnull(b.dongiavon,0) as loinhuan from view_chitiet_hoadon a
                        LEFT JOIN
                        (
                        SELECT a.idmahang, round(ifnull((sum(thanhtien) + ifnull(b.tiendauky,0)) / (sum(soluong) + ifnull(b.sodudauky,0)),0), 1) as dongiavon from view_chitiet_phieunhap a
                               LEFT JOIN(
                        SELECT a1.idmahang, sodudauky + ifnull(b1.sodu, 0) as sodudauky, tiendauky + ifnull(b1.tiendau, 0) as tiendauky from tbl_tonkho a1
                              LEFT JOIN(SELECT idmahang, sodu, tiendau from view_sodudauky where strftime('%Y-%m', ngaynhap) = '{Convert.ToDateTime(dateTuNgay.EditValue).ToString("yyyy-MM")}' and makho = 'K01') b1 on b1.idmahang = a1.idmahang
                        where strftime('%Y-%m', ngaythang) = '{Convert.ToDateTime(dateTuNgay.EditValue).ToString("yyyy-MM")}' and makho = 'K01'
                        ) b on b.idmahang = a.idmahang

                        where ngaynhap >= '{Convert.ToDateTime(dateTuNgay.EditValue).ToString("yyyy-MM-dd")}' and ngaynhap<='{Convert.ToDateTime(dateDenNgay.EditValue).ToString("yyyy-MM-dd")}' and makho = 'K01' GROUP BY a.idmahang
                        ) b on b.idmahang = a.idmahang
                        where ngayban >= '{Convert.ToDateTime(dateTuNgay.EditValue).ToString("yyyy-MM-dd")}' and ngayban<='{Convert.ToDateTime(dateDenNgay.EditValue).ToString("yyyy-MM-dd")}'
                        GROUP BY ngayban, a.idmahang, mahang, tenban, tenhang, tendvt, nhomhang");
            dgvThongKeDoAnUong.DataSource = ds.Tables[0];
        }

        private void btnNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadThongKe();
        }

        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadThongKe();
        }
    }
}
