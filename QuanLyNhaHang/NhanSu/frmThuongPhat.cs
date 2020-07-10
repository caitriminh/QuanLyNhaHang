using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Windows.Forms;
namespace QuanLyNhaHang.NhanSu
{
    public partial class frmThuongPhat : XtraForm
    {
        public frmThuongPhat()
        {
            InitializeComponent();
        }

        public void LoadThuongPhat()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var ds = Data.LoadData($@"select * from view_thuongphat where ngaythang>='{Convert.ToDateTime(dateTuNgay.EditValue).ToString("yyyy-MM-dd")}' and ngaythang<='{Convert.ToDateTime(dateDenNgay.EditValue).ToString("yyyy-MM-dd")}' order by ngaythang, manv");
            dgvThuongPhat.DataSource = ds.Tables[0];
            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm == null || frm.IsDisposed)
                frm = new frmThemThuongPhat();
            frm.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm.funObjectB);
            sendIDObjectfrm1(this);
        }

        frmThemThuongPhat frm = new frmThemThuongPhat();
        public delegate void PassIDform1(frmThuongPhat frm1_copy);
        public void funDataA(string txtform2)
        {
            label1A.Text = txtform2;
        }

        private void label1A_TextChanged(object sender, EventArgs e)
        {
            LoadThuongPhat();
        }

        private void btnNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadThuongPhat();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            var dgr = XtraMessageBox.Show($@"Bạn có muốn xóa thưởng phạt nhân viên {gridView1.GetRowCellValue(i, "tennv")} này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                Data.RunCMD($@"delete from tbl_thuongphat where id='{gridView1.GetRowCellValue(i, "id")}'");
                //Ghi lại log
                Data.HistoryLog($@"Đã xóa thưởng phạt nhân viên {gridView1.GetRowCellValue(i, "tennv")}.", "Danh mục thưởng phạt");
                LoadThuongPhat();
            }
        }

        private void LuuThuongPhat()
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
                    string sql = $@"update tbl_thuongphat set sotien=@sotien, lydo=@lydo, ngaythang=@ngaythang, nguoitd2=@nguoitd2, thoigian2=@thoigian2 where id=@id";

                    SQLiteCommand sqlCom = new SQLiteCommand(sql, Data.strconnect);
                    sqlCom.Parameters.AddWithValue("@id", dr["id"]);
                    sqlCom.Parameters.AddWithValue("@sotien", Convert.ToInt32(dr["sotien"]));
                    sqlCom.Parameters.AddWithValue("@ngaythang", Convert.ToDateTime(dr["ngaythang"]).ToString("yyyy-MM-dd"));
                    sqlCom.Parameters.AddWithValue("@lydo", dr["lydo"]);
                    sqlCom.Parameters.AddWithValue("@nguoitd2", Data._strtendangnhap.ToUpper());
                    sqlCom.Parameters.AddWithValue("@thoigian2", DateTime.Now);
                    Data.open_connect();
                    sqlCom.ExecuteNonQuery();
                    Data.close_connect();
                    //Ghi lại log
                    Data.HistoryLog("Đã cập nhật lại thông tin thưởng phạt của nhân viên " + dr["tennv"] + ".", "Danh mục thưởng phạt");
                    LoadThuongPhat();
                }
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            label1A.Focus();
            var dgr = XtraMessageBox.Show($@"Bạn có muốn lưu lại những thay đổi trong danh mục thưởng phạt nhân viên này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                LuuThuongPhat();
            }
        }

        private void frmThuongPhat_Load(object sender, EventArgs e)
        {
            dateTuNgay.EditValue = DateTime.Now.ToString("01/MM/yyyy");
            dateDenNgay.EditValue = DateTime.Now.Date;
            LoadThuongPhat();
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            if (ReferenceEquals(e.Column, colXoa))
            {
                var dgr = XtraMessageBox.Show($@"Bạn có muốn xóa thưởng phạt nhân viên {gridView1.GetRowCellValue(i, "tennv")} này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dgr == DialogResult.Yes)
                {
                    Data.RunCMD($@"delete from tbl_thuongphat where id='{gridView1.GetRowCellValue(i, "id")}'");
                    //Ghi lại log
                    Data.HistoryLog($@"Đã xóa thưởng phạt nhân viên {gridView1.GetRowCellValue(i, "tennv")}.", "Danh mục thưởng phạt");
                    LoadThuongPhat();
                }
            }
        }

        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadThuongPhat();
        }

        private void btnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xtraSaveFileDialog1.Filter = "Excel files |*.xlsx";
            xtraSaveFileDialog1.FileName = "DanhMucThuongPhat_" + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss");
            if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dgvThuongPhat.ExportToXlsx(xtraSaveFileDialog1.FileName);
                Process.Start(xtraSaveFileDialog1.FileName);
            }
        }
    }
}
