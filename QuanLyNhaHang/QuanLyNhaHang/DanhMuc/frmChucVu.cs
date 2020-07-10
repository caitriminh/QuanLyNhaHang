using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
namespace QuanLyNhaHang.DanhMuc
{
    public partial class frmChucVu : XtraForm
    {
        public frmChucVu()
        {
            InitializeComponent();
        }

        public void LoadChucVu()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var ds = Data.LoadData("select * from tbl_chucvu order by chucvu");
            dgvChucVu.DataSource = ds.Tables[0];
            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm == null || frm.IsDisposed)
                frm = new frmThemChucVu();
            frm.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm.funObjectB);
            sendIDObjectfrm1(this);
        }

        frmThemChucVu frm = new frmThemChucVu();
        public delegate void PassIDform1(frmChucVu frm1_copy);
        public void funDataA(string txtform2)
        {
            label1A.Text = txtform2;
        }

        private void label1A_TextChanged(object sender, EventArgs e)
        {
            LoadChucVu();
        }

        private void btnNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadChucVu();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            var dgr = XtraMessageBox.Show($@"Bạn có muốn xóa tên chức vụ {gridView1.GetRowCellValue(i, "chucvu")} này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                Data.RunCMD($@"delete from tbl_chucvu where id='{gridView1.GetRowCellValue(i, "id")}'");
                //Ghi lại log
                Data.HistoryLog($@"Đã xóa tên chức vụ {gridView1.GetRowCellValue(i, "chucvu")}.", "Danh mục chức vụ");
                LoadChucVu();
            }
        }

        private void LuuChucVu()
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
                    string sql = $@"update tbl_chucvu set chucvu=@chucvu, thoigian2=@thoigian2, nguoitd2=@nguoitd2 where id=@id";

                    SQLiteCommand sqlCom = new SQLiteCommand(sql, Data.strconnect);
                    sqlCom.Parameters.AddWithValue("@chucvu", dr["chucvu"]);
                    sqlCom.Parameters.AddWithValue("@nguoitd2", Data._strtendangnhap.ToUpper());
                    sqlCom.Parameters.AddWithValue("@thoigian2", DateTime.Now);
                    Data.open_connect();
                    sqlCom.ExecuteNonQuery();
                    Data.close_connect();
                    //Ghi lại log
                    Data.HistoryLog("Đã cập nhật lại thông tin tên chức vụ " + dr["chucvu"] + ".", "Danh mục chức vụ");
                    LoadChucVu();
                }
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            label1A.Focus();
            var dgr = XtraMessageBox.Show($@"Bạn có muốn lưu lại những thay đổi trong danh mục chức vụ này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                LuuChucVu();
            }
        }

        private void frmChucVu_Load(object sender, EventArgs e)
        {
            LoadChucVu();
        }
    }
}
