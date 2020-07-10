using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Windows.Forms;

namespace QuanLyNhaHang.Quy
{
    public partial class frmPhieuChi : DevExpress.XtraEditors.XtraForm
    {
        public frmPhieuChi()
        {
            InitializeComponent();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm2 == null || frm2.IsDisposed)
                frm2 = new frmThemPhieuChi();
            frm2.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm2.funObjectB);
            sendIDObjectfrm1(this);
        }

        frmThemPhieuChi frm2 = new frmThemPhieuChi();
        public delegate void PassIDform1(frmPhieuChi frm1_copy);
        public void funDataA(string txtform2)
        {
            label1A.Text = txtform2;
        }

        private void label1A_TextChanged(object sender, EventArgs e)
        {
            LoadPhieuChi();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Data._strmaphieu = lblMaPhieu.Text;
            Data._edit = true;
            if (frm2 == null || frm2.IsDisposed)
                frm2 = new frmThemPhieuChi();
            frm2.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm2.funObjectB);
            sendIDObjectfrm1(this);
        }

        public void LoadPhieuChi()
        {
            var x = gridView2.FocusedRowHandle;
            var y = gridView2.TopRowIndex;
            var ds = Data.LoadData($@"SELECT * from view_phieuthuchi where ngaylap>='{Convert.ToDateTime(dateTuNgay.EditValue).ToString("yyyy-MM-dd")}' and ngaylap<='{Convert.ToDateTime(dateDenNgay.EditValue).ToString("yyyy-MM-dd")}' and nhomphieu='CHI' order by maphieu");
            dgvPhieuChi.DataSource = ds.Tables[0];
            lblMaPhieu.DataBindings.Clear();
            lblMaPhieu.DataBindings.Add("text", ds.Tables[0], "maphieu");
            gridView2.FocusedRowHandle = x;
            gridView2.TopRowIndex = y;
        }

        private void btnNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadPhieuChi();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dgr = XtraMessageBox.Show("Bạn có muốn xóa phiếu thu " + lblMaPhieu.Text + " này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                Data.RunCMD("delete from tbl_phieuthuchi where maphieu='" + lblMaPhieu.Text + "'");
                //Ghi lại log
                Data.HistoryLog("Đã xóa phiếu thu " + lblMaPhieu.Text + ".", "Danh mục phiếu thu");
                LoadPhieuChi();
            }
        }

        private void LuuPhieuChi()
        {
            for (var index = 0; index <= gridView2.RowCount - 1; index++)
            {
                var dr = gridView2.GetDataRow(Convert.ToInt32(index));
                if (ReferenceEquals(dr, null))
                {
                    break;
                }
                if (dr.RowState == DataRowState.Modified)
                {
                    string sql = $@"update tbl_phieuthuchi set maloaiphieu=@maloaiphieu, sotien=@sotien, ngaylap=@ngaylap, nguoilap=@nguoilap, ghichu=@ghichu, nguoitd2=@nguoitd2, thoigian2=@thoigian2 where maphieu=@maphieu";

                    SQLiteCommand sqlCom = new SQLiteCommand(sql, Data.strconnect);
                    sqlCom.Parameters.AddWithValue("@maphieu", dr["maphieu"]);
                    sqlCom.Parameters.AddWithValue("@maloaiphieu", dr["maloaiphieu"]);
                    sqlCom.Parameters.AddWithValue("@sotien", Convert.ToInt32(dr["sotien"]));
                    sqlCom.Parameters.AddWithValue("@ngaylap", Convert.ToDateTime(dr["ngaylap"]).ToString("yyyy-MM-dd"));
                    sqlCom.Parameters.AddWithValue("@nguoilap", dr["nguoilap"]);
                    sqlCom.Parameters.AddWithValue("@ghichu", dr["ghichu"]);
                    sqlCom.Parameters.AddWithValue("@nguoitd2", Data._strtendangnhap.ToUpper());
                    sqlCom.Parameters.AddWithValue("@thoigian2", DateTime.Now);
                    Data.open_connect();
                    sqlCom.ExecuteNonQuery();
                    Data.close_connect();
                    //Ghi lại log
                    Data.HistoryLog("Đã cập nhật phiếu thu " + dr["maphieu"] + ".", "Danh mục phiếu thu");
                }
            }
            LoadPhieuChi();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lblMaPhieu.Focus();
            DialogResult dgrResult = XtraMessageBox.Show("Bạn có muốn lưu lại những thay đổi trong danh mục phiếu chi không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgrResult == DialogResult.Yes)
            {
                LuuPhieuChi();
            }
        }

        private void btn_excel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xtraSaveFileDialog1.Filter = "Excel files |*.xlsx";
            xtraSaveFileDialog1.FileName = "PhieuChi_" + DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss"); ;
            if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dgvPhieuChi.ExportToXlsx(xtraSaveFileDialog1.FileName);
                Process.Start(xtraSaveFileDialog1.FileName);
            }
        }

        public void LoadLoaiPhieu()
        {
            var ds = Data.LoadData("select * from tbl_loaiphieuthuchi where nhomphieu='CHI' order by loaiphieu");
            cboLoaiPhieu.DataSource = ds.Tables[0];
            cboLoaiPhieu.DisplayMember = "loaiphieu";
            cboLoaiPhieu.ValueMember = "maloai";
        }

        private void gridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            var i = gridView2.FocusedRowHandle;
            if (ReferenceEquals(e.Column, colXoa))
            {
                DialogResult dgr = XtraMessageBox.Show("Bạn có muốn xóa mã phiếu nhập chi " + lblMaPhieu.Text + " này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dgr == DialogResult.Yes)
                {
                    Data.RunCMD("delete from tbl_phieuthuchi where maphieu='" + lblMaPhieu.Text + "'");
                    //Ghi lại log
                    Data.HistoryLog("Đã xóa phiếu chi " + lblMaPhieu.Text + ".", "Danh mục phiếu chi");
                    LoadPhieuChi();
                }
            }
        }

        private void frmPhieuChi_Load(object sender, EventArgs e)
        {
            dateTuNgay.EditValue = DateTime.Now.Date;
            dateDenNgay.EditValue = DateTime.Now.Date;
            LoadLoaiPhieu();
            LoadPhieuChi();
        }
    }
}
