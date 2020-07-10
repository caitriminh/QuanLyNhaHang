using DevExpress.XtraEditors;
using QuanLyNhaHang.KhoHang;
using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
namespace QuanLyNhaHang.HoatDong
{
    public partial class frmNCC : XtraForm
    {
        public frmNCC()
        {
            InitializeComponent();
        }

        public void LoadNCC()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var ds = Data.LoadData("select * from tbl_ncc WHERE mancc<>'NCC000' order by ncc");
            dgvNCC.DataSource = ds.Tables[0];
            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Data._int_flag = 1;
            if (frm == null || frm.IsDisposed)
                frm = new frmThemNCC();
            frm.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm.funObjectB);
            sendIDObjectfrm1(this);
        }

        frmThemNCC frm = new frmThemNCC();
        public delegate void PassIDform1(frmNCC frm1_copy);
        public void funDataA(string txtform2)
        {
            label1A.Text = txtform2;
        }

        private void label1A_TextChanged(object sender, EventArgs e)
        {
            LoadNCC();
        }

        private void btnNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadNCC();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            var dgr = XtraMessageBox.Show($@"Bạn có muốn xóa tên nhà cung cấp {gridView1.GetRowCellValue(i, "ncc")} này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                Data.RunCMD($@"delete from tbl_ncc where mancc='{gridView1.GetRowCellValue(i, "mancc")}'");
                //Ghi lại log
                Data.HistoryLog($@"Đã xóa tên nhà cung cấp {gridView1.GetRowCellValue(i, "ncc")}.", "Danh mục nhà cung cấp");
                LoadNCC();
            }
        }

        private void LuuNCC()
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
                    Data.RunCMD($@"update tbl_ncc set ncc='{dr["ncc"]}', diachi='{dr["diachi"]}', sodt='{dr["sodt"]}', sofax='{dr["sofax"]}', ghichu='{dr["ghichu"]}', thoigian2='{ DateTime.Now.ToString() }', nguoitd2='{ Data._strtendangnhap.ToUpper() }' where mancc='{dr["mancc"] }'");
                    //Ghi lại log
                    Data.HistoryLog("Đã cập nhật lại thông tin danh mục nhà cung cấp " + dr["ncc"] + ".", "Danh mục nhà cung cấp");
                }
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            label1A.Focus();
            var dgr = XtraMessageBox.Show($@"Bạn có muốn lưu lại những thay đổi trong danh mục nhà cung cấp này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                LuuNCC();
            }
        }

        private void frmNCC_Load(object sender, EventArgs e)
        {
            LoadNCC();
        }

        private void btnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xtraSaveFileDialog1.Filter = "Excel files |*.xlsx";
            xtraSaveFileDialog1.FileName = "DanhMucNhaCC_" + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss");
            if (xtraSaveFileDialog1.ShowDialog() == DialogResult.Yes)
            {
                dgvNCC.ExportToXlsx(xtraSaveFileDialog1.FileName);
                Process.Start(xtraSaveFileDialog1.FileName);
            }
        }
    }
}
