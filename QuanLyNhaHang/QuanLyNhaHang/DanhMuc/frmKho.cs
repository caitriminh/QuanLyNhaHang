using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Windows.Forms;
namespace QuanLyNhaHang.DanhMuc
{
    public partial class frmKho : XtraForm
    {
        public frmKho()
        {
            InitializeComponent();
        }

        public void LoadKho()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var ds = Data.LoadData("select * from tbl_kho order by tenkho");
            dgvKho.DataSource = ds.Tables[0];
            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm == null || frm.IsDisposed)
                frm = new frmThemKho();
            frm.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm.funObjectB);
            sendIDObjectfrm1(this);
        }

        frmThemKho frm = new frmThemKho();
        public delegate void PassIDform1(frmKho frm1_copy);
        public void funDataA(string txtform2)
        {
            label1A.Text = txtform2;
        }

        private void label1A_TextChanged(object sender, EventArgs e)
        {
            LoadKho();
        }

        private void btnNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadKho();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            var dgr = XtraMessageBox.Show($@"Bạn có muốn xóa tên kho {gridView1.GetRowCellValue(i, "tenkho")} này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                Data.RunCMD($@"delete from tbl_kho where makho='{gridView1.GetRowCellValue(i, "makho")}'");
                //Ghi lại log
                Data.HistoryLog($@"Đã xóa tên kho {gridView1.GetRowCellValue(i, "tenkho")}.", "Danh mục kho");
                LoadKho();
            }
        }

        private void LuuKho()
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
                    Data.RunCMD("update tbl_kho set tenkho='" + dr["tenkho"] + "', thoigian2='" + DateTime.Now.ToString() + "', nguoitd2='" + Data._strtendangnhap.ToUpper() + "' where makho='" + dr["makho"] + "'");
                    //Ghi lại log
                    Data.HistoryLog("Đã cập nhật lại thông tin tên kho " + dr["tenkho"] + ".", "Danh mục kho");
                }
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            label1A.Focus();
            var dgr = XtraMessageBox.Show($@"Bạn có muốn lưu lại những thay đổi trong danh mục kho này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                LuuKho();
            }
        }

        private void frmKho_Load(object sender, EventArgs e)
        {
            LoadKho();
        }
    }
}
