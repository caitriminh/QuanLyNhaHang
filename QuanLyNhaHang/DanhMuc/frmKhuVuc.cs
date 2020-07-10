using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Windows.Forms;
namespace QuanLyNhaHang.DanhMuc
{
    public partial class frmKhuVuc : XtraForm
    {
        public frmKhuVuc()
        {
            InitializeComponent();
        }

        public void LoadKhuVuc()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var ds = Data.LoadData("select * from tbl_khuvuc order by khuvuc");
            dgvKhuVuc.DataSource = ds.Tables[0];
            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm == null || frm.IsDisposed)
                frm = new frmThemKhuVuc();
            frm.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm.funObjectB);
            sendIDObjectfrm1(this);
        }

        frmThemKhuVuc frm = new frmThemKhuVuc();
        public delegate void PassIDform1(frmKhuVuc frm1_copy);
        public void funDataA(string txtform2)
        {
            label1A.Text = txtform2;
        }

        private void label1A_TextChanged(object sender, EventArgs e)
        {
            LoadKhuVuc();
        }

        private void btnNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadKhuVuc();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            var dgr = XtraMessageBox.Show($@"Bạn có muốn xóa khu vực {gridView1.GetRowCellValue(i, "khuvuc")} này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                Data.RunCMD($@"delete from tbl_khuvuc where makhuvuc='{gridView1.GetRowCellValue(i, "makhuvuc")}'");
                //Ghi lại log
                Data.HistoryLog($@"Đã xóa khu vực {gridView1.GetRowCellValue(i, "khuvuc")}.", "Danh mục khu vực");
                LoadKhuVuc();
            }
        }

        private void LuuKhuVuc()
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
                    Data.RunCMD("update tbl_khuvuc set khuvuc='" + dr["khuvuc"] + "', thoigian2='" + DateTime.Now.ToString() + "', nguoitd2='" + Data._strtendangnhap.ToUpper() + "' where makhuvuc='" + dr["makhuvuc"] + "'");
                    //Ghi lại log
                    Data.HistoryLog("Đã cập nhật lại thông tin khu vực " + dr["khuvuc"] + ".", "Danh mục khu vực");
                }
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            label1A.Focus();
            var dgr = XtraMessageBox.Show($@"Bạn có muốn lưu lại những thay đổi trong danh mục khu vực này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                LuuKhuVuc();
            }
        }

        private void frmKhuVuc_Load(object sender, EventArgs e)
        {
            LoadKhuVuc();
        }
    }
}
