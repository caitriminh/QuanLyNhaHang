using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Windows.Forms;
namespace QuanLyNhaHang.DanhMuc
{
    public partial class frmDonViTinh : XtraForm
    {
        public frmDonViTinh()
        {
            InitializeComponent();
        }

        private void frmDonViTinh_Load(object sender, EventArgs e)
        {
            LoadDonViTinh();
        }

        public void LoadDonViTinh()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var ds = Data.LoadData("select * from tbl_donvitinh order by tendvt");
            dgvDonViTinh.DataSource = ds.Tables[0];
            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm == null || frm.IsDisposed)
                frm = new frmThemDonViTinh();
            frm.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm.funObjectB);
            sendIDObjectfrm1(this);
        }

        frmThemDonViTinh frm = new frmThemDonViTinh();
        public delegate void PassIDform1(frmDonViTinh frm1_copy);
        public void funDataA(string txtform2)
        {
            label1A.Text = txtform2;
        }

        private void label1A_TextChanged(object sender, EventArgs e)
        {
            LoadDonViTinh();
        }

        private void btnNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadDonViTinh();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            var dgr = XtraMessageBox.Show($@"Bạn có muốn xóa đơn vị tính {gridView1.GetRowCellValue(i, "tendvt")} này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                Data.RunCMD($@"delete from tbl_donvitinh where madvt='{gridView1.GetRowCellValue(i, "madvt")}'");
                //Ghi lại log
                Data.HistoryLog($@"Đã xóa đơn vị tính {gridView1.GetRowCellValue(i, "tendvt")}.", "Danh mục đơn vị tính");
                LoadDonViTinh();
            }
        }

        private void LuuDonViTinh()
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
                    Data.RunCMD("update tbl_donvitinh set tendvt='" + dr["tendvt"] + "', thoigian2='" + DateTime.Now.ToString() + "', nguoitd2='" + Data._strtendangnhap.ToUpper() + "' where madvt='" + dr["madvt"] + "'");
                    //Ghi lại log
                    Data.HistoryLog("Đã cập nhật lại thông tin đơn vị tính " + dr["tendvt"] + ".", "Danh mục đơn vị tính");
                }
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            label1A.Focus();
            var dgr = XtraMessageBox.Show($@"Bạn có muốn lưu lại những thay đổi trong danh mục đơn vị tính này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                LuuDonViTinh();
            }
        }
    }
}
