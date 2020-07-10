using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Windows.Forms;
namespace QuanLyNhaHang.HoatDong
{
    public partial class frmBan : XtraForm
    {
        public frmBan()
        {
            InitializeComponent();
        }

        public void LoadBan()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var ds = Data.LoadData("select * from view_ban order by khuvuc, tenban");
            dgvKhuVuc.DataSource = ds.Tables[0];
            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm == null || frm.IsDisposed)
                frm = new frmThemBan();
            frm.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm.funObjectB);
            sendIDObjectfrm1(this);
        }

        frmThemBan frm = new frmThemBan();
        public delegate void PassIDform1(frmBan frm1_copy);
        public void funDataA(string txtform2)
        {
            label1A.Text = txtform2;
        }

        private void label1A_TextChanged(object sender, EventArgs e)
        {
            LoadBan();
        }

        private void btnNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadBan();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            var dgr = XtraMessageBox.Show($@"Bạn có muốn xóa bàn {gridView1.GetRowCellValue(i, "tenban")} này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                Data.RunCMD($@"delete from tbl_ban where maban='{gridView1.GetRowCellValue(i, "maban")}'");
                //Ghi lại log
                Data.HistoryLog($@"Đã xóa tên bàn {gridView1.GetRowCellValue(i, "tenban")}.", "Danh mục bàn");
                LoadBan();
            }
        }

        private void LuuBan()
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
                    Data.RunCMD($@"update tbl_ban set tenban='{dr["tenban"]}', makhuvuc='{dr["makhuvuc"] }', thoigian2='{ DateTime.Now.ToString() }', nguoitd2='{ Data._strtendangnhap.ToUpper() }' where maban='{dr["maban"] }'");
                    //Ghi lại log
                    Data.HistoryLog("Đã cập nhật lại thông tin danh mục bàn " + dr["tenban"] + ".", "Danh mục bàn");
                }
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            label1A.Focus();
            var dgr = XtraMessageBox.Show($@"Bạn có muốn lưu lại những thay đổi trong danh mục bàn này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                LuuBan();
            }
        }
        public void LoadKhuVuc()
        {
            var ds = Data.LoadData("select * from tbl_khuvuc order by khuvuc");
            cboKhuVuc.DataSource = ds.Tables[0];
            cboKhuVuc.ValueMember = "makhuvuc";
            cboKhuVuc.DisplayMember = "khuvuc";
        }
        private void frmBan_Load(object sender, EventArgs e)
        {
            LoadKhuVuc();
            LoadBan();
        }
    }
}
