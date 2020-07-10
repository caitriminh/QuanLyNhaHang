using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace QuanLyNhaHang.DanhMuc
{
    public partial class frmNhomHang : XtraForm
    {
        public frmNhomHang()
        {
            InitializeComponent();
        }

        public void LoadNhomHang()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var ds = Data.LoadData("select * from tbl_nhomhang order by nhomhang");
            dgvNhomHang.DataSource = ds.Tables[0];
            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm == null || frm.IsDisposed)
                frm = new frmThemNhomHang();
            frm.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm.funObjectB);
            sendIDObjectfrm1(this);
        }

        frmThemNhomHang frm = new frmThemNhomHang();
        public delegate void PassIDform1(frmNhomHang frm1_copy);
        public void funDataA(string txtform2)
        {
            label1A.Text = txtform2;
        }

        private void label1A_TextChanged(object sender, EventArgs e)
        {
            CreateImageCollectionFromCategory();
            LoadNhomHang();
        }

        private void btnNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CreateImageCollectionFromCategory();
            LoadNhomHang();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            var dgr = XtraMessageBox.Show($@"Bạn có muốn xóa nhóm hàng {gridView1.GetRowCellValue(i, "nhomhang")} này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                Data.RunCMD($@"delete from tbl_nhomhang where manhom='{gridView1.GetRowCellValue(i, "manhom")}'");
                try
                {
                    File.Delete(Application.StartupPath + @"\img\" + gridView1.GetRowCellValue(i, "manhom") + ".png");
                }
                catch (Exception)
                {

                    //throw;
                }
                //Ghi lại log
                Data.HistoryLog($@"Đã xóa nhóm hàng {gridView1.GetRowCellValue(i, "nhomhang")}.", "Danh mục nhóm hàng");
                LoadNhomHang();
            }
        }

        private void LuuNhomHang()
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
                    Data.RunCMD("update tbl_nhomhang set nhomhang='" + dr["nhomhang"] + "', thoigian2='" + DateTime.Now.ToString() + "', nguoitd2='" + Data._strtendangnhap.ToUpper() + "' where manhom='" + dr["manhom"] + "'");
                    //Ghi lại log
                    Data.HistoryLog("Đã cập nhật lại thông tin nhóm hàng " + dr["nhomhang"] + ".", "Danh mục nhóm hàng");
                }
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            label1A.Focus();
            var dgr = XtraMessageBox.Show($@"Bạn có muốn lưu lại những thay đổi trong danh mục khu vực này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                LuuNhomHang();
            }
        }

        private void frmNhomHang_Load(object sender, EventArgs e)
        {
            CreateImageCollectionFromCategory();
            LoadNhomHang();
        }

        public void CreateImageCollectionFromCategory()
        {
            var table = new DataSet();
            table = Data.LoadData("select * from tbl_nhomhang");
            var imageCollection = new ImageCollection();
            cboNhomHang.SmallImages = imageCollection;
            int i = 0;
            foreach (DataRow item in table.Tables[0].Rows)
            {
                string url_item = Application.StartupPath + "\\img\\" + item["hinh"];
                var image_item = Image.FromFile(url_item);
                imageCollection.AddImage(image_item, item["nhomhang"].ToString());
                cboNhomHang.Items.Add(new ImageComboBoxItem(item["nhomhang"].ToString(), item["nhomhang"].ToString(), i));
                i++;
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            Data._edit = true;
            Data._str_id = gridView1.GetRowCellValue(i, "manhom").ToString();
            if (frm == null || frm.IsDisposed)
                frm = new frmThemNhomHang();
            frm.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm.funObjectB);
            sendIDObjectfrm1(this);
        }
    }
}
