using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Windows.Forms;
namespace QuanLyNhaHang.NhanSu
{
    public partial class frmTamUng : XtraForm
    {
        public frmTamUng()
        {
            InitializeComponent();
        }

        public void LoadTamUng()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var ds = Data.LoadData($@"select * from view_tamung where ngayung>='{Convert.ToDateTime(dateTuNgay.EditValue).ToString("yyyy-MM-dd")}' and ngayung<='{Convert.ToDateTime(dateDenNgay.EditValue).ToString("yyyy-MM-dd")}' order by ngayung, manv");
            dgvTamUng.DataSource = ds.Tables[0];
            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm == null || frm.IsDisposed)
                frm = new frmThemTamUng();
            frm.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm.funObjectB);
            sendIDObjectfrm1(this);
        }

        frmThemTamUng frm = new frmThemTamUng();
        public delegate void PassIDform1(frmTamUng frm1_copy);
        public void funDataA(string txtform2)
        {
            label1A.Text = txtform2;
        }

        private void label1A_TextChanged(object sender, EventArgs e)
        {
            LoadTamUng();
        }

        private void btnNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadTamUng();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            var dgr = XtraMessageBox.Show($@"Bạn có muốn xóa tạm ứng lương của nhân viên {gridView1.GetRowCellValue(i, "tennv")} này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                Data.RunCMD($@"delete from tbl_tamung where id='{gridView1.GetRowCellValue(i, "id")}'");
                //Ghi lại log
                Data.HistoryLog($@"Đã xóa tạm ứng lương nhân viên {gridView1.GetRowCellValue(i, "tennv")}.", "Danh mục tạm ứng");
                LoadTamUng();
            }
        }

        private void LuuTamUng()
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
                    string sql = $@"update tbl_tamung set sotien=@sotien, lydo=@lydo, ngayung=@ngayung, nguoitd2=@nguoitd2, thoigian2=@thoigian2 where id=@id";

                    SQLiteCommand sqlCom = new SQLiteCommand(sql, Data.strconnect);
                    sqlCom.Parameters.AddWithValue("@id", dr["id"]);
                    sqlCom.Parameters.AddWithValue("@sotien", Convert.ToInt32(dr["sotien"]));
                    sqlCom.Parameters.AddWithValue("@ngayung", Convert.ToDateTime(dr["ngayung"]).ToString("yyyy-MM-dd"));
                    sqlCom.Parameters.AddWithValue("@lydo", dr["lydo"]);
                    sqlCom.Parameters.AddWithValue("@nguoitd2", Data._strtendangnhap.ToUpper());
                    sqlCom.Parameters.AddWithValue("@thoigian2", DateTime.Now);
                    Data.open_connect();
                    sqlCom.ExecuteNonQuery();
                    Data.close_connect();
                    //Ghi lại log
                    Data.HistoryLog("Đã cập nhật lại thông tin ứng lương của nhân viên " + dr["tennv"] + ".", "Danh mục ứng lương");
                    LoadTamUng();
                }
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            label1A.Focus();
            var dgr = XtraMessageBox.Show($@"Bạn có muốn lưu lại những thay đổi trong danh mục tạm ứng lương này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                LuuTamUng();
            }
        }

        private void frmTamUng_Load(object sender, EventArgs e)
        {
            dateTuNgay.EditValue = DateTime.Now.ToString("01/MM/yyyy");
            dateDenNgay.EditValue = DateTime.Now.Date;
            LoadTamUng();
        }

        private void btnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xtraSaveFileDialog1.Filter = "Excel files |*.xlsx";
            xtraSaveFileDialog1.FileName = "DanhMucTamUng_" + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss");
            if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dgvTamUng.ExportToXlsx(xtraSaveFileDialog1.FileName);
                Process.Start(xtraSaveFileDialog1.FileName);
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            if (ReferenceEquals(e.Column, colXoa))
            {
                var dgr = XtraMessageBox.Show($@"Bạn có muốn xóa tạm ứng lương của nhân viên {gridView1.GetRowCellValue(i, "tennv")} này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dgr == DialogResult.Yes)
                {
                    Data.RunCMD($@"delete from tbl_tamung where id='{gridView1.GetRowCellValue(i, "id")}'");
                    //Ghi lại log
                    Data.HistoryLog($@"Đã xóa tạm ứng lương nhân viên {gridView1.GetRowCellValue(i, "tennv")}.", "Danh mục tạm ứng");
                    LoadTamUng();
                }
            }
        }
    }
}
