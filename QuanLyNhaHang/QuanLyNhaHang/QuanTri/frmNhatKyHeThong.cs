using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyNhaHang.QuanTri
{
    public partial class frmNhatKyHeThong : DevExpress.XtraEditors.XtraForm
    {
        public frmNhatKyHeThong()
        {
            InitializeComponent();
        }

        private void frm_nhatky_hethong_Load(object sender, EventArgs e)
        {
            dateTuNgay.EditValue = DateTime.Now.Date;
            dateDenNgay.EditValue = DateTime.Now.Date;
            LoadNhatKyHeThong();
            //LoadPhanQuyen();
        }

        //public void LoadPhanQuyen()
        //{
        //    if (Data.Data._check_id($@"select count(*) from tbl_phanquyen where tendangnhap='{Data.Data._strtendangnhap.ToUpper()}' and mamenu='2' and xoa='True'") == 1)
        //    {
        //        btn_xoa.Enabled = true;
        //        col_xoa.Visible = true;
        //    }
        //    else
        //    {
        //        btn_xoa.Enabled = false;
        //        col_xoa.Visible = false;
        //    }


        //    if (Data.Data._check_id($@"select count(*) from tbl_phanquyen where tendangnhap='{Data.Data._strtendangnhap.ToUpper()}' and mamenu='2' and [in]='True'") == 1)
        //    {
        //        btn_excel.Enabled = true;
        //    }
        //    else
        //    {
        //        btn_excel.Enabled = false;
        //    }
        //}
        public void LoadNhatKyHeThong()
        {
            DataSet ds = new DataSet();
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            ds = Data.LoadData("select * from tbl_nhatky_hoatdong where ngaycapnhat>='" + Convert.ToDateTime(dateTuNgay.EditValue).ToString("yyyy-MM-dd") + "' and ngaycapnhat<='" + Convert.ToDateTime(dateDenNgay.EditValue).ToString("yyyy-MM-dd") + "' order by id desc");
            dgvNhatKyHeThong.DataSource = ds.Tables[0];
            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }

        private void btn_tim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadNhatKyHeThong();
        }

        private void btn_lammoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadNhatKyHeThong();
        }

        private void btn_excel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xtraSaveFileDialog1.Filter = "Excel file *|.xlsx";
            if (gridView1.SelectedRowsCount <= 0)
            {
                XtraMessageBox.Show("Bạn phải chọn chi tiết nội dụng để thực hiện.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            xtraSaveFileDialog1.FileName = "NhatKy_HeThong_" + DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss"); ;
            if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var joinSTT = "";
                var selectedRows = gridView1.GetSelectedRows();
                joinSTT = string.Join("','", from r in selectedRows select gridView1.GetRowCellValue(Convert.ToInt32(r), "id"));

                string strLenh = "select tendangnhap, ngaycapnhat, thaotac, form, tenmay, hedieuhanh, thoigian from tbl_nhatky_hoatdong where id in ('" + joinSTT + "') order by id";
                var arr = mdl_ExportExcel.LoadSQL2ListArr(strLenh);
                mdl_ExportExcel.ExportListArr2Excel(arr, xtraSaveFileDialog1.FileName);
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (ReferenceEquals(e.Column, col_xoa))
            {
                int i = gridView1.FocusedRowHandle;
                DialogResult dgr = XtraMessageBox.Show("Bạn có muốn xóa thông tin nhật ký hệ thống này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dgr == DialogResult.Yes)
                {
                    var row = gridView1.GetFocusedDataRow();
                    Data.RunCMD("delete from tbl_nhatky_hoatdong where id='" + gridView1.GetRowCellValue(i, "id") + "'");
                    row.Table.Rows.Remove(row);

                }
            }
        }

        private void btn_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.SelectedRowsCount <= 0)
            {
                XtraMessageBox.Show("Bạn phải chọn chi tiết nội dụng để thực hiện.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var dgr = XtraMessageBox.Show("Bạn có muốn xóa các chi tiết đã chọn không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                var joinSTT = "";
                var selectedRows = gridView1.GetSelectedRows();
                joinSTT = string.Join("','", from r in selectedRows select gridView1.GetRowCellValue(Convert.ToInt32(r), "id"));

                Data.RunCMD("delete from tbl_nhatky_hoatdong where id in ('" + joinSTT + "')");
                LoadNhatKyHeThong();

            }
        }

        private void btnXoaTatCa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dgr = XtraMessageBox.Show("Bạn có muốn xóa tất cả nhật ký hệ thống không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                var i = Data.CheckID("select count(*) from tbl_nhatky_hoatdong");
                Data.RunCMD("delete from tbl_nhatky_hoatdong");
                LoadNhatKyHeThong();
                XtraMessageBox.Show($@"Đã xóa tất cả {i} dòng.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
