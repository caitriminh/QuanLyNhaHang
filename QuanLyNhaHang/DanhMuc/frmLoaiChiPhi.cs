using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Windows.Forms;
namespace QuanLyNhaHang.DanhMuc
{
    public partial class frmLoaiChiPhi : XtraForm
    {
        public frmLoaiChiPhi()
        {
            InitializeComponent();
        }

        public void LoadLoaiChiPhi()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var ds = Data.LoadData("select * from tbl_loaiphieuthuchi order by loaiphieu");
            dgvLoaiChiPhi.DataSource = ds.Tables[0];
            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm == null || frm.IsDisposed)
                frm = new frmThemLoaiChiPhi();
            frm.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm.funObjectB);
            sendIDObjectfrm1(this);
        }

        frmThemLoaiChiPhi frm = new frmThemLoaiChiPhi();
        public delegate void PassIDform1(frmLoaiChiPhi frm1_copy);
        public void funDataA(string txtform2)
        {
            label1A.Text = txtform2;
        }

        private void label1A_TextChanged(object sender, EventArgs e)
        {
            LoadLoaiChiPhi();
        }

        private void btnNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadLoaiChiPhi();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            var dgr = XtraMessageBox.Show($@"Bạn có muốn xóa loại phiếu thu chi {gridView1.GetRowCellValue(i, "loaiphieu")} này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                Data.RunCMD($@"delete from tbl_loaiphieuthuchi where maloai='{gridView1.GetRowCellValue(i, "maloai")}'");
                //Ghi lại log
                Data.HistoryLog($@"Đã xóa loại phiếu thu chi {gridView1.GetRowCellValue(i, "loaiphieu")}.", "Danh mục loại phiếu thu chi");
                LoadLoaiChiPhi();
            }
        }

        private void LuuLoaiPhieuThuChi()
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
                    Data.RunCMD($@"update tbl_loaiphieuthuchi set nhomphieu='{ dr["nhomphieu"] }', loaiphieu='{dr["loaiphieu"]}', thoigian2='{ DateTime.Now.ToString() }', nguoitd2='{ Data._strtendangnhap.ToUpper() }' where maloai='{ dr["maloai"] }'");
                    //Ghi lại log
                    Data.HistoryLog("Đã cập nhật lại thông tin loại phiếu thu chi " + dr["loaiphieu"] + ".", "Danh mục loại phiếu thu chi");
                }
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            label1A.Focus();
            var dgr = XtraMessageBox.Show($@"Bạn có muốn lưu lại những thay đổi trong danh mục loại phiếu thu chi này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                LuuLoaiPhieuThuChi();
            }
        }
        private void frmLoaiChiPhi_Load(object sender, EventArgs e)
        {
            LoadLoaiChiPhi();
        }
    }
}
