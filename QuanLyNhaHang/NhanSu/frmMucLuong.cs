using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
namespace QuanLyNhaHang.NhanSu
{
    public partial class frmMucLuong : XtraForm
    {
        public frmMucLuong()
        {
            InitializeComponent();
        }

        public void LoadMucLuong()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var ds = Data.LoadData("select * from view_mucluong order by ngaynhap, manv");
            dgvMucLuong.DataSource = ds.Tables[0];
            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm == null || frm.IsDisposed)
                frm = new frmThemMucLuong();
            frm.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm.funObjectB);
            sendIDObjectfrm1(this);
        }

        frmThemMucLuong frm = new frmThemMucLuong();
        public delegate void PassIDform1(frmMucLuong frm1_copy);
        public void funDataA(string txtform2)
        {
            label1A.Text = txtform2;
        }

        private void label1A_TextChanged(object sender, EventArgs e)
        {
            LoadMucLuong();
        }

        private void btnNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadMucLuong();
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
                LoadMucLuong();
            }
        }

        private void LuuMucLuong()
        {
            label1A.Focus();
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
                    LoadMucLuong();
                }
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var dgr = XtraMessageBox.Show($@"Bạn có muốn lưu lại những thay đổi trong danh mục mức lương này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                LuuMucLuong();
            }
        }

        public void LoadCaLamViec()
        {
            var ds = Data.LoadData("select * from tbl_calamviec order by calamviec");
            cboCaLamViec.DataSource = ds.Tables[0];
            cboCaLamViec.DisplayMember = "calamviec";
            cboCaLamViec.ValueMember = "id";
        }

        private void frmMucLuong_Load(object sender, EventArgs e)
        {
            LoadCaLamViec();
            LoadMucLuong();
        }
    }
}
