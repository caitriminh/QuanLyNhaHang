using DevExpress.XtraEditors;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace QuanLyNhaHang.KhoHang
{
    public partial class frmTonKho : DevExpress.XtraEditors.XtraForm
    {
        public frmTonKho()
        {
            InitializeComponent();
        }

        private void frmTonKho_Load(object sender, EventArgs e)
        {
            dateNgayThang.EditValue = DateTime.Now.Date;
            CapNhatSoLieuTonKho();
            LoadTonKho();
            ////////////////////////////
            splitterControl1.Visible = false;
            xtraTabControl1.Visible = false;
            dgvTonKho.Dock = DockStyle.Fill;
        }

        public void CapNhatSoLieuTonKho()
        {
            Data.RunCMD($@"INSERT INTO tbl_tonkho(ngaythang, idmahang, makho, nguoitd, thoigian) SELECT '{Convert.ToDateTime(dateNgayThang.EditValue).ToString("yyyy-MM-01")}', idmahang, makho,'{Data._strtendangnhap.ToUpper()}','{DateTime.Now}' from view_chitiet_phieunhap a where strftime('%Y-%m', ngaynhap)='{Convert.ToDateTime(dateNgayThang.EditValue).ToString("yyyy-MM")}' and not EXISTS (SELECT makho, idmahang from tbl_tonkho b where strftime('%Y-%m', b.ngaythang)='{Convert.ToDateTime(dateNgayThang.EditValue).ToString("yyyy-MM")}' and b.makho=a.makho and b.idmahang=a.idmahang)");
        }

        public void LoadTonKho()
        {
            var ds = Data.LoadData($@"SELECT
                                    tbl_tonkho.id,
                                    tbl_tonkho.ngaythang,
                                    tbl_hanghoa.tenhang,
                                    tbl_tonkho.makho,
                                    tbl_kho.tenkho,
                                    tbl_donvitinh.tendvt,
                                    tbl_hanghoa.manhomhang,
                                    tbl_nhomhang.nhomhang,
                                    tbl_tonkho.sodudauky + ifnull(a.sodu, 0) AS sodudauky,
                                    tbl_tonkho.tiendauky + ifnull(a.tiendau, 0) AS tiendauky,
                                    ifnull(c.slxuat, 0) AS slxuat,
                                    round(
                                        (
                                            tbl_tonkho.tiendauky + ifnull(a.tiendau, 0) + ifnull(b.tiennhap, 0)
                                        ) / (
                                            tbl_tonkho.sodudauky + ifnull(a.sodu, 0) + ifnull(b.slnhap, 0)
                                        ) * ifnull(c.slxuat, 0),
                                        1
                                    ) AS tienxuat,
                                    ifnull(b.slnhap, 0) AS slnhap,
                                    ifnull(b.tiennhap, 0) AS tiennhap,
                                    tbl_tonkho.tiendauky + ifnull(a.tiendau, 0) + ifnull(b.tiennhap, 0) - round(
                                        (
                                            tbl_tonkho.tiendauky + ifnull(a.tiendau, 0) + ifnull(b.tiennhap, 0)
                                        ) / (
                                            tbl_tonkho.sodudauky + ifnull(a.sodu, 0) + ifnull(b.slnhap, 0)
                                        ) * ifnull(c.slxuat, 0),
                                        1
                                    ) AS tiencuoiky,
                                    tbl_tonkho.sodudauky + ifnull(a.sodu, 0)+ifnull(b.slnhap,0)-ifnull(c.slxuat,0) as soducuoiky,
                                    tbl_tonkho.nguoitd,
                                    tbl_tonkho.thoigian,
                                    tbl_tonkho.nguoitd2,
                                    tbl_tonkho.thoigian2,
                                    tbl_tonkho.idmahang,
                                    tbl_hanghoa.mahang
                                FROM
                                    tbl_tonkho
                                INNER JOIN tbl_kho ON tbl_kho.makho = tbl_tonkho.makho
                                INNER JOIN tbl_hanghoa ON tbl_hanghoa.id = tbl_tonkho.idmahang
                                INNER JOIN tbl_nhomhang ON tbl_nhomhang.manhom = tbl_hanghoa.manhomhang
                                INNER JOIN tbl_donvitinh ON tbl_donvitinh.madvt = tbl_hanghoa.madvt
                                LEFT JOIN (
                                    SELECT
                                        idmahang,
                                        makho,
                                        sodu,
                                        tiendau
                                    FROM
                                        tbl_sodudauky
                                    WHERE
                                        strftime('%Y-%m', ngaynhap) = '{Convert.ToDateTime(dateNgayThang.EditValue).ToString("yyyy-MM")}'
                                ) a ON a.idmahang = tbl_tonkho.idmahang
                                AND a.makho = tbl_tonkho.makho
                                LEFT JOIN (
                                    SELECT
                                        idmahang,
                                        makho,
                                        sum(soluong) AS slnhap,
                                        sum(thanhtien) AS tiennhap
                                    FROM
                                        view_chitiet_phieunhap
                                    WHERE
                                        strftime('%Y-%m', ngaynhap) = '{Convert.ToDateTime(dateNgayThang.EditValue).ToString("yyyy-MM")}'
                                    GROUP BY
                                        idmahang,
                                        makho
                                ) b ON b.idmahang = tbl_tonkho.idmahang
                                AND b.makho = tbl_tonkho.makho
                                LEFT JOIN (
                                    SELECT
                                        idmahang,
                                        makho,
                                        sum(soluong) AS slxuat,
                                        sum(thanhtien) AS tienxuat
                                    FROM
                                        view_chitiet_phieuxuat
                                    WHERE
                                        strftime('%Y-%m', ngayxuat) = '{Convert.ToDateTime(dateNgayThang.EditValue).ToString("yyyy-MM")}'
                                    GROUP BY
                                        idmahang,
                                        makho
                                ) c ON c.idmahang = tbl_tonkho.idmahang
                                AND c.makho = tbl_tonkho.makho
                                WHERE
                                    strftime(
                                        '%Y-%m',
                                        tbl_tonkho.ngaythang
                                    ) = '{Convert.ToDateTime(dateNgayThang.EditValue).ToString("yyyy-MM")}'");
            dgvTonKho.DataSource = ds.Tables[0];
            lblMaKho.DataBindings.Clear();
            lblMaHang.DataBindings.Clear();

            lblMaKho.DataBindings.Add("text", ds.Tables[0], "makho");
            lblMaHang.DataBindings.Add("text", ds.Tables[0], "mahang");

        }

        private void btnNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadTonKho();
        }

        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadTonKho();
        }

        private void btn_excel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xtraSaveFileDialog1.Filter = "Excel files |*.xlsx";
            xtraSaveFileDialog1.FileName = "DanhMucTonKho_" + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss");
            if (xtraSaveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                dgvTonKho.ExportToXlsx(xtraSaveFileDialog1.FileName);
                Process.Start(xtraSaveFileDialog1.FileName);
            }
        }

        public void LoadCTPhieuNhap()
        {
            var ds = Data.LoadData($@"select * from view_chitiet_phieunhap where makho='{lblMaKho.Text}' and mahang='{lblMaHang.Text}' and strftime('%Y-%m', ngaynhap)='{Convert.ToDateTime(dateNgayThang.EditValue).ToString("yyyy-MM")}'");
            dgvChiTietNhapKho.DataSource = ds.Tables[0];
        }

        public void LoadCTPhieuXuat()
        {
            var ds = Data.LoadData($@"select * from view_chitiet_phieuxuat where makho='{lblMaKho.Text}' and mahang='{lblMaHang.Text}' and strftime('%Y-%m', ngayxuat)='{Convert.ToDateTime(dateNgayThang.EditValue).ToString("yyyy-MM")}'");
            dgvChiTietXuatKho.DataSource = ds.Tables[0];
        }

        private void lblMaHang_TextChanged(object sender, EventArgs e)
        {
            LoadCTPhieuNhap();
            LoadCTPhieuXuat();
        }

        private void lblMaKho_TextChanged(object sender, EventArgs e)
        {
            LoadCTPhieuNhap();
            LoadCTPhieuXuat();
        }

        private void chkChiTiet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (chkChiTiet.Checked)
            {
                splitterControl1.Visible = true;
                xtraTabControl1.Visible = true;
                dgvTonKho.Dock = DockStyle.Top;
            }
            else
            {
                splitterControl1.Visible = false;
                xtraTabControl1.Visible = false;
                dgvTonKho.Dock = DockStyle.Fill;
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dgr = XtraMessageBox.Show($@"Bạn có muốn xóa danh mục tồn kho của tháng { Convert.ToDateTime(dateNgayThang.EditValue).ToString("01/MM/yyyy")} này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes) { Data.RunCMD($@"delete from tbl_tonkho where ngaythang='{Convert.ToDateTime(dateNgayThang.EditValue).ToString("yyyy-MM-01")}'"); }
            LoadTonKho();
        }
    }
}
