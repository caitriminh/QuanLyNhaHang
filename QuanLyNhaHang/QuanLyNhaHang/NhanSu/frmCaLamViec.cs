using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
namespace QuanLyNhaHang.NhanSu
{
    public partial class frmCaLamViec : XtraForm
    {
        public frmCaLamViec()
        {
            InitializeComponent();
        }

        public void LoadCaLamViec()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var ds = Data.LoadData("select * from tbl_calamviec order by calamviec");
            dgvCaLamViec.DataSource = ds.Tables[0];
            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm == null || frm.IsDisposed)
                frm = new frmThemCaLamViec();
            frm.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm.funObjectB);
            sendIDObjectfrm1(this);
        }

        frmThemCaLamViec frm = new frmThemCaLamViec();
        public delegate void PassIDform1(frmCaLamViec frm1_copy);
        public void funDataA(string txtform2)
        {
            label1A.Text = txtform2;
        }

        private void label1A_TextChanged(object sender, EventArgs e)
        {
            LoadCaLamViec();
        }

        private void btnNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadCaLamViec();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            var dgr = XtraMessageBox.Show($@"Bạn có muốn xóa tên ca làm việc {gridView1.GetRowCellValue(i, "calamviec")} này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                Data.RunCMD($@"delete from tbl_calamviec where id='{gridView1.GetRowCellValue(i, "id")}'");
                //Ghi lại log
                Data.HistoryLog($@"Đã xóa tên ca làm việc {gridView1.GetRowCellValue(i, "calamviec")}.", "Danh mục ca làm việc");
                LoadCaLamViec();
            }
        }

        private void LuuCaLamViec()
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
                    string sql = $@"update tbl_calamviec set calamviec=@calamviec, thoigian2=@thoigian2, nguoitd2=@nguoitd2 where id=@id";

                    SQLiteCommand sqlCom = new SQLiteCommand(sql, Data.strconnect);
                    sqlCom.Parameters.AddWithValue("@id", dr["id"]);
                    sqlCom.Parameters.AddWithValue("@calamviec", dr["calamviec"]);
                    sqlCom.Parameters.AddWithValue("@nguoitd2", Data._strtendangnhap.ToUpper());
                    sqlCom.Parameters.AddWithValue("@thoigian2", DateTime.Now);
                    Data.open_connect();
                    sqlCom.ExecuteNonQuery();
                    Data.close_connect();
                    //Ghi lại log
                    Data.HistoryLog("Đã cập nhật lại thông tin ca làm việc " + dr["calamviec"] + ".", "Danh mục ca làm việc");
                    LoadCaLamViec();
                }
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            label1A.Focus();
            var dgr = XtraMessageBox.Show($@"Bạn có muốn lưu lại những thay đổi trong danh mục ca làm việc này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                LuuCaLamViec();
            }
        }

        private void frmCaLamViec_Load(object sender, EventArgs e)
        {
            LoadCaLamViec();
        }
    }
}
