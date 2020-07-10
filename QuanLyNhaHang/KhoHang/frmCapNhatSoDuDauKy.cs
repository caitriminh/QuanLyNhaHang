using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using VB = Microsoft.VisualBasic.Strings;
namespace QuanLyNhaHang.KhoHang
{
    public partial class frmCapNhatSoDuDauKy : XtraForm
    {
        public frmCapNhatSoDuDauKy()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frm_capnhat_sodu_dauky_Load(object sender, EventArgs e)
        {

        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            DateTime date_thangtruoc = Convert.ToDateTime(date_thangnam.EditValue);
            int _thang, _nam;
            _thang = Convert.ToDateTime(date_thangtruoc.AddMonths(-1).ToString()).Month;
            string thang = VB.Right("00" + _thang.ToString(), 2);
            _nam = Convert.ToDateTime(date_thangtruoc.AddMonths(-1).ToString()).Year;
            string namthang = _nam + "-" + thang;
            var dgr = XtraMessageBox.Show("Bạn đang thực hiện chuyển số dư hàng hóa từ tháng " + date_thangtruoc.AddMonths(-1).ToString("MM/yyyy") + " sang tháng " + Convert.ToDateTime(date_thangnam.EditValue).ToString("MM/yyyy") + "", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                string _thangnam = Convert.ToDateTime(date_thangnam.EditValue).ToString("yyyy-MM-01");
                //Xóa dữ liệu năm chuyển đến
                Data.RunCMD($@"delete from tbl_tonkho where ngaythang='{Convert.ToDateTime(date_thangnam.EditValue).ToString("yyyy-MM-01")}'");
                Data.RunCMD($@"INSERT INTO tbl_tonkho (
                                                    ngaythang,
                                                    idmahang,
                                                    makho,
                                                    sodudauky,
                                                    tiendauky,
                                                    nguoitd,
                                                    thoigian
                                                ) SELECT
                                                    '{_thangnam}',
                                                    tbl_tonkho.idmahang,
                                                    tbl_tonkho.makho,
                                                    tbl_tonkho.sodudauky + ifnull(a.sodu, 0) + ifnull(b.slnhap, 0) - ifnull(c.slxuat, 0) AS soducuoiky,
                                                    ifnull(
                                                        tbl_tonkho.tiendauky + ifnull(a.tiendau, 0) + ifnull(b.tiennhap, 0) - round(
                                                            (
                                                                tbl_tonkho.tiendauky + ifnull(a.tiendau, 0) + ifnull(b.tiennhap, 0)
                                                            ) / (
                                                                tbl_tonkho.sodudauky + ifnull(a.sodu, 0) + ifnull(b.slnhap, 0)
                                                            ) * ifnull(c.slxuat, 0),
                                                            1
                                                        ),
                                                        0
                                                    ) AS tiencuoiky,
                                                    '{Data._strtendangnhap.ToUpper()}',
                                                    '{DateTime.Now}'
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
                                                        strftime('%Y-%m', ngaynhap) = '{namthang}'
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
                                                        strftime('%Y-%m', ngaynhap) = '{namthang}'
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
                                                        strftime('%Y-%m', ngayxuat) = '{namthang}'
                                                    GROUP BY
                                                        idmahang,
                                                        makho
                                                ) c ON c.idmahang = tbl_tonkho.idmahang
                                                AND c.makho = tbl_tonkho.makho
                                                WHERE
                                                    strftime(
                                                        '%Y-%m',
                                                        tbl_tonkho.ngaythang
                                                    ) = '{namthang}'");
                //Gửi dữ liệu load form chính


                XtraMessageBox.Show("Đã chuyển số dư thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }

        }

        private void frmCapNhatSoDuDauKy_Load(object sender, EventArgs e)
        {
            date_thangnam.EditValue = DateTime.Now.Date.ToString("MM/yyyy");
        }
    }
}
