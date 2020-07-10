using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Windows.Forms;
namespace QuanLyNhaHang.NhanSu
{
    public partial class frmChamCong : XtraForm
    {
        public frmChamCong()
        {
            InitializeComponent();
        }

        public void LoadChamCong()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var ds = Data.LoadData($@"select * from view_chamcong where ngaychamcong>='{Convert.ToDateTime(dateTuNgay.EditValue).ToString("yyyy-MM-dd")}' and ngaychamcong<='{Convert.ToDateTime(dateDenNgay.EditValue).ToString("yyyy-MM-dd")}' order by manv");
            dgvChamCong.DataSource = ds.Tables[0];
            lblMaNV.DataBindings.Clear();
            lblMaNV.DataBindings.Add("text", ds.Tables[0], "manv");

            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Data._str_id = lblMaNV.Text;
            if (frm == null || frm.IsDisposed)
                frm = new frmThemChamCong();
            frm.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm.funObjectB);
            sendIDObjectfrm1(this);
        }

        frmThemChamCong frm = new frmThemChamCong();
        public delegate void PassIDform1(frmChamCong frm1_copy);
        public void funDataA(string txtform2)
        {
            label1A.Text = txtform2;
        }

        private void label1A_TextChanged(object sender, EventArgs e)
        {
            LoadChamCong();
        }

        private void btnNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadChamCong();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            var dgr = XtraMessageBox.Show($@"Bạn có muốn xóa chấm công nhân viên {gridView1.GetRowCellValue(i, "tennv")} này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                Data.RunCMD($@"delete from tbl_chamcong where id='{gridView1.GetRowCellValue(i, "id")}'");
                //Ghi lại log
                Data.HistoryLog($@"Đã xóa chấm công nhân viên {gridView1.GetRowCellValue(i, "tennv")}.", "Danh mục chấm công");
                LoadChamCong();
            }
        }

        private void LuuChamCong()
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
                    string sql = $@"update tbl_chamcong set macalamviec=@macalamviec, socong=@socong, ghichu=@ghichu, ngaychamcong=@ngaychamcong, nguoitd2=@nguoitd2, thoigian2=@thoigian2 where id=@id";

                    SQLiteCommand sqlCom = new SQLiteCommand(sql, Data.strconnect);
                    sqlCom.Parameters.AddWithValue("@id", dr["id"]);
                    sqlCom.Parameters.AddWithValue("@macalamviec", dr["macalamviec"]);
                    sqlCom.Parameters.AddWithValue("@socong", Convert.ToDouble(dr["socong"]));
                    sqlCom.Parameters.AddWithValue("@ngaychamcong", Convert.ToDateTime(dr["ngaychamcong"]).ToString("yyyy-MM-dd"));
                    sqlCom.Parameters.AddWithValue("@ghichu", dr["ghichu"]);
                    sqlCom.Parameters.AddWithValue("@nguoitd2", Data._strtendangnhap.ToUpper());
                    sqlCom.Parameters.AddWithValue("@thoigian2", DateTime.Now);
                    Data.open_connect();
                    sqlCom.ExecuteNonQuery();
                    Data.close_connect();
                    //Ghi lại log
                    Data.HistoryLog("Đã cập nhật lại thông tin chấm công của nhân viên " + dr["tennv"] + ".", "Danh mục chấm công");
                    LoadChamCong();
                }
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            label1A.Focus();
            var dgr = XtraMessageBox.Show($@"Bạn có muốn lưu lại những thay đổi trong danh mục chấm công nhân viên này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                LuuChamCong();
            }
        }

        public void LoadCaLamViec()
        {
            var ds = Data.LoadData("select * from tbl_calamviec order by calamviec");
            cboCaLamViec.DataSource = ds.Tables[0];
            cboCaLamViec.DisplayMember = "calamviec";
            cboCaLamViec.ValueMember = "id";
        }

        private void frmChamCong_Load(object sender, EventArgs e)
        {
            dateTuNgay.EditValue = DateTime.Now.Date.ToString("01/MM/yyyy");
            dateDenNgay.EditValue = DateTime.Now.Date;
            LoadCaLamViec();
            LoadChamCong();
        }

        private void gridView1_CellMerge(object sender, DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e)
        {
            if (e.Column == colTenNV)
            {
                string text1 = gridView1.GetRowCellDisplayText(e.RowHandle1, colTenNV);
                string text2 = gridView1.GetRowCellDisplayText(e.RowHandle2, colTenNV);
                e.Merge = (text1 == text2);
                e.Handled = true;
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (ReferenceEquals(e.Column, colXoa))
            {
                var i = gridView1.FocusedRowHandle;
                var dgr = XtraMessageBox.Show($@"Bạn có muốn xóa chi tiết chấm công của nhân viên {gridView1.GetRowCellValue(i, "tennv")} này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dgr == DialogResult.Yes)
                {
                    Data.RunCMD($@"delete from tbl_chamcong where id='{gridView1.GetRowCellValue(i, "id")}'");
                    //Ghi lại log
                    Data.HistoryLog($@"Đã xóa chấm công nhân viên {gridView1.GetRowCellValue(i, "tennv")}.", "Danh mục chấm công");
                    LoadChamCong();
                }
            }
        }

        private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            int i = view.FocusedRowHandle;
            DataSet ds = new DataSet();
            if (view.FocusedColumn.FieldName == "macalamviec")
            {
                if (Data.CheckID($@"select count(*) from tbl_chamcong where manv='{view.GetRowCellValue(i, "manv")}' and ngaychamcong='{Convert.ToDateTime(view.GetRowCellValue(i, "ngaychamcong")).ToString("yyyy-MM-dd")}' and macalamviec='{e.Value}'") > 0)
                {
                    e.Valid = false;
                    e.ErrorText = "Ca làm việc bạn chọn đã tồn tại trong ngày chấm công. Nhấn ESC để nhập lại.";
                }
            }
            else if (view.FocusedColumn.FieldName == "ngaychamcong")
            {
                if (Data.CheckID($@"select count(*) from tbl_chamcong where manv='{view.GetRowCellValue(i, "manv")}' and ngaychamcong='{Convert.ToDateTime(e.Value).ToString("yyyy-MM-dd")}' and macalamviec='{view.GetRowCellValue(i, "macalamviec")}'") > 0)
                {
                    e.Valid = false;
                    e.ErrorText = "Ngày chấm công bạn chọn đã tồn tại. Nhấn ESC để nhập lại.";
                }
            }
        }

        private void btnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xtraSaveFileDialog1.Filter = "Excel files |*.xlsx";
            xtraSaveFileDialog1.FileName = "NhatKyChamCong_" + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss");
            if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dgvChamCong.ExportToXlsx(xtraSaveFileDialog1.FileName);
                Process.Start(xtraSaveFileDialog1.FileName);
            }
        }

        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadChamCong();
        }
    }
}
