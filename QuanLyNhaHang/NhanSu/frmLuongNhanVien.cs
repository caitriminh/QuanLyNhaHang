using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
namespace QuanLyNhaHang.NhanSu
{
    public partial class frmLuongNhanVien : XtraForm
    {
        public frmLuongNhanVien()
        {
            InitializeComponent();
        }

        public void LoadLuongNhanVien()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var ds = Data.LoadData($@"SELECT a.id, a.manv, k.tennv, ifnull(b.congsang,0) as congsang, ifnull(e.mucluongca1,0) as mucluongca1, ifnull(c.congchieu,0) as congchieu, ifnull(f.mucluongca2,0) as mucluongca2, 
                ifnull(d.congtoi, 0) as congtoi, ifnull(g.mucluongca3, 0) as mucluongca3, ifnull(b.congsang, 0) + ifnull(c.congchieu, 0) + ifnull(d.congtoi, 0) as tongcong,
                ifnull(b.congsang, 0) * ifnull(e.mucluongca1, 0) + ifnull(c.congchieu, 0) * ifnull(f.mucluongca2, 0) + ifnull(d.congtoi, 0) * ifnull(g.mucluongca3, 0) as tongluong,
                ifnull(h.tamung, 0) as tamung, ifnull(i.tienthuong, 0) as tienthuong, ifnull(j.tienphat, 0) as tienphat, a.phucap,
                ifnull(b.congsang, 0) * ifnull(e.mucluongca1, 0) + ifnull(c.congchieu, 0) * ifnull(f.mucluongca2, 0) + ifnull(d.congtoi, 0) * ifnull(g.mucluongca3, 0) + ifnull(i.tienthuong, 0) -
                ifnull(h.tamung, 0) - ifnull(j.tienphat, 0) + a.phucap as thuclanh,

                a.ghichu, a.nguoitd, a.thoigian, a.nguoitd2, a.thoigian2 from tbl_luongnhanvien a
                LEFT JOIN(SELECT manv, sum(tongcong) as congsang from view_tongcong WHERE macalamviec = 1 and namthang = '{Convert.ToDateTime(dateLuongThang.EditValue).ToString("yyyy-MM")}' GROUP BY manv) b on b.manv = a.manv
                LEFT JOIN(SELECT manv, sum(tongcong) as congchieu from view_tongcong WHERE macalamviec = 2 and namthang = '{Convert.ToDateTime(dateLuongThang.EditValue).ToString("yyyy-MM")}' GROUP BY manv) c on c.manv = a.manv
                LEFT JOIN(SELECT manv, sum(tongcong) as congtoi from view_tongcong WHERE macalamviec = 3 and namthang = '{Convert.ToDateTime(dateLuongThang.EditValue).ToString("yyyy-MM")}' GROUP BY manv) d on d.manv = a.manv
                LEFT JOIN(SELECT manv, mucluong as mucluongca1 from tbl_mucluong where macalamviec = 1) e on e.manv = a.manv
                LEFT JOIN(SELECT manv, mucluong as mucluongca2 from tbl_mucluong where macalamviec = 2) f on f.manv = a.manv
                LEFT JOIN(SELECT manv, mucluong as mucluongca3 from tbl_mucluong where macalamviec = 3) g on g.manv = a.manv
                LEFT JOIN(SELECT manv, sum(sotien) as tamung from view_tamung where strftime('%Y-%m', ngayung) = '{Convert.ToDateTime(dateLuongThang.EditValue).ToString("yyyy-MM")}' GROUP BY manv) h on h.manv = a.manv
                LEFT JOIN(SELECT manv, sum(sotien) as tienthuong from tbl_thuongphat where strftime('%Y-%m', ngaythang) = '{Convert.ToDateTime(dateLuongThang.EditValue).ToString("yyyy-MM")}' and sotien > 0 GROUP BY manv) i on i.manv = h.manv
                LEFT JOIN(SELECT manv, sum(sotien) as tienphat from tbl_thuongphat where strftime('%Y-%m', ngaythang) = '{Convert.ToDateTime(dateLuongThang.EditValue).ToString("yyyy-MM")}' and sotien < 0 GROUP BY manv) j on j.manv = h.manv
                INNER JOIN tbl_nhanvien k on k.manv = a.manv
                where strftime('%Y-%m', thangluong) = '{Convert.ToDateTime(dateLuongThang.EditValue).ToString("yyyy-MM")}'");
            dgvBangLuong.DataSource = ds.Tables[0];
            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }



        frmThemMucLuong frm = new frmThemMucLuong();
        public delegate void PassIDform1(frmMucLuong frm1_copy);
        public void funDataA(string txtform2)
        {
            label1A.Text = txtform2;
        }

        private void label1A_TextChanged(object sender, EventArgs e)
        {
            LoadLuongNhanVien();
        }

        private void btnNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadLuongNhanVien();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            var dgr = XtraMessageBox.Show($@"Bạn có muốn xóa mức lương của nhân viên {gridView1.GetRowCellValue(i, "tennv")} này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                Data.RunCMD($@"delete from tbl_mucluong where id='{gridView1.GetRowCellValue(i, "id")}'");
                //Ghi lại log
                Data.HistoryLog($@"Đã xóa mức lương nhân viên {gridView1.GetRowCellValue(i, "tennv")}.", "Danh mục mức lương");
                LoadLuongNhanVien();
            }
        }

        private void LuuMucLuong()
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
                    string sql = $@"update tbl_mucluong set macalamviec=@macalamviec, mucluong=@mucluong, ghichu=@ghichu, ngaynhap=@ngaynhap, nguoitd2=@nguoitd2, thoigian2=@thoigian2 where id=@id";

                    SQLiteCommand sqlCom = new SQLiteCommand(sql, Data.strconnect);
                    sqlCom.Parameters.AddWithValue("@id", dr["id"]);
                    sqlCom.Parameters.AddWithValue("@macalamviec", dr["macalamviec"]);
                    sqlCom.Parameters.AddWithValue("@mucluong", Convert.ToDouble(dr["mucluong"]));
                    sqlCom.Parameters.AddWithValue("@ngaynhap", Convert.ToDateTime(dr["ngaynhap"]).ToString("yyyy-MM-dd"));
                    sqlCom.Parameters.AddWithValue("@ghichu", dr["ghichu"]);
                    sqlCom.Parameters.AddWithValue("@nguoitd2", Data._strtendangnhap.ToUpper());
                    sqlCom.Parameters.AddWithValue("@thoigian2", DateTime.Now);
                    Data.open_connect();
                    sqlCom.ExecuteNonQuery();
                    Data.close_connect();
                    //Ghi lại log
                    Data.HistoryLog("Đã cập nhật lại thông tin ứng lương của nhân viên " + dr["tennv"] + ".", "Danh mục ứng lương");
                    LoadLuongNhanVien();
                }
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            label1A.Focus();
            var dgr = XtraMessageBox.Show($@"Bạn có muốn lưu lại những thay đổi trong danh mục mức lương này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                LuuMucLuong();
            }
        }


        private void frmMucLuong_Load(object sender, EventArgs e)
        {
            dateLuongThang.EditValue = DateTime.Now.Date;
            LoadLuongNhanVien();
        }

        private void btnBangLuong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Data.RunCMD($@"INSERT into tbl_luongnhanvien(manv, thangluong, nguoitd, thoigian) SELECT manv, '{Convert.ToDateTime(dateLuongThang.EditValue).ToString("yyyy-MM-01")}', '{Data._strtendangnhap.ToUpper()}', '{DateTime.Now}' from tbl_nhanvien where manv not in (SELECT manv from tbl_luongnhanvien where strftime('%Y-%m',thangluong)='{Convert.ToDateTime(dateLuongThang.EditValue).ToString("yyyy-MM")}')");
            LoadLuongNhanVien();
        }
    }
}
