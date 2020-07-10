using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace QuanLyNhaHang.DanhMuc
{
    public partial class frmNhomKhachHang : XtraForm
    {
        public frmNhomKhachHang()
        {
            InitializeComponent();
        }

        public void LoadNhomKH()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var ds = Data.LoadData("select * from tbl_nhomkhachhang order by nhomkh");
            dgvNhomKH.DataSource = ds.Tables[0];
            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm == null || frm.IsDisposed)
                frm = new frmThemNhomKhachHang2();
            frm.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm.funObjectB);
            sendIDObjectfrm1(this);
        }

        frmThemNhomKhachHang2 frm = new frmThemNhomKhachHang2();
        public delegate void PassIDform1(frmNhomKhachHang frm1_copy);
        public void funDataA(string txtform2)
        {
            label1A.Text = txtform2;
        }

        private void label1A_TextChanged(object sender, EventArgs e)
        {
            LoadNhomKH2();
            LoadNhomKH();
        }

        private void btnNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadNhomKH2();
            LoadNhomKH();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            var dgr = XtraMessageBox.Show($@"Bạn có muốn xóa nhóm khách hàng {gridView1.GetRowCellValue(i, "nhomkh")} này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                Data.RunCMD($@"delete from tbl_nhomkhachhang where manhomkh='{gridView1.GetRowCellValue(i, "manhomkh")}'");
                //Ghi lại log
                Data.HistoryLog($@"Đã xóa nhóm khách hàng {gridView1.GetRowCellValue(i, "nhomkh")}.", "Danh mục nhóm khách hàng");
                LoadNhomKH();
            }
        }

        private void LuuNhomKH()
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
                    Data.RunCMD("update tbl_nhomkhachhang set nhomkh='" + dr["nhomkh"] + "', thoigian2='" + DateTime.Now.ToString() + "', nguoitd2='" + Data._strtendangnhap.ToUpper() + "' where manhomkh='" + dr["manhomkh"] + "'");
                    //Ghi lại log
                    Data.HistoryLog("Đã cập nhật lại thông tin nhóm khách hàng " + dr["nhomkh"] + ".", "Danh mục nhóm khách hàng");
                }
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            label1A.Focus();
            var dgr = XtraMessageBox.Show($@"Bạn có muốn lưu lại những thay đổi trong danh mục nhóm khách hàng này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                LuuNhomKH();
            }
        }

        private void frmNhomKhachHang_Load(object sender, EventArgs e)
        {
            LoadNhomKH2();
            LoadNhomKH();
        }

        public void LoadNhomKH2()
        {
            var table = new DataSet();
            table = Data.LoadData("select * from tbl_nhomkhachhang");
            var imageCollection = new ImageCollection();
            cboNhomKH.SmallImages = imageCollection;
            int i = 0;
            foreach (DataRow item in table.Tables[0].Rows)
            {
                string url_item = Application.StartupPath + @"\img\nhomkh\" + item["hinh"];
                var image_item = Image.FromFile(url_item);
                imageCollection.AddImage(image_item, item["nhomkh"].ToString());
                cboNhomKH.Items.Add(new ImageComboBoxItem(item["nhomkh"].ToString(), item["nhomkh"].ToString(), i));
                i++;
            }
        }
    }
}
