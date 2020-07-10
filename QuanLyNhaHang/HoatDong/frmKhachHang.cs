using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
namespace QuanLyNhaHang.HoatDong
{
    public partial class frmKhachHang : XtraForm
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }

        public void LoadKhachHang()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var ds = Data.LoadData("select * from view_khachhang where makh<>'KH0000' order by tenkh");
            dgvKhachHang.DataSource = ds.Tables[0];
            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Data._int_flag = 1;
            if (frm == null || frm.IsDisposed)
                frm = new frmThemKhachHang();
            frm.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm.funObjectB);
            sendIDObjectfrm1(this);
        }

        frmThemKhachHang frm = new frmThemKhachHang();
        public delegate void PassIDform1(frmKhachHang frm1_copy);
        public void funDataA(string txtform2)
        {
            label1A.Text = txtform2;
        }

        private void label1A_TextChanged(object sender, EventArgs e)
        {
            LoadKhachHang();
        }

        private void btnNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadKhachHang();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            var dgr = XtraMessageBox.Show($@"Bạn có muốn xóa tên khách hàng {gridView1.GetRowCellValue(i, "tenkh")} này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                Data.RunCMD($@"delete from tbl_khachhang where makh='{gridView1.GetRowCellValue(i, "makh")}'");
                //Ghi lại log
                Data.HistoryLog($@"Đã xóa tên khách hàng {gridView1.GetRowCellValue(i, "tenkh")}.", "Danh mục khách hàng");
                LoadKhachHang();
            }
        }

        private void LuuKhachHang()
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
                    Data.RunCMD($@"update tbl_khachhang set tenkh='{dr["tenkh"]}', diachi='{dr["diachi"]}', sodt='{dr["sodt"]}', sofax='{dr["sofax"]}', ghichu='{dr["ghichu"]}', thoigian2='{ DateTime.Now.ToString() }', nguoitd2='{ Data._strtendangnhap.ToUpper() }' where makh='{dr["makh"] }'");
                    //Ghi lại log
                    Data.HistoryLog("Đã cập nhật lại thông tin danh mục khách hàng " + dr["tenkh"] + ".", "Danh mục khách hàng");
                }
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            label1A.Focus();
            var dgr = XtraMessageBox.Show($@"Bạn có muốn lưu lại những thay đổi trong danh mục khách hàng này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                LuuKhachHang();
            }
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            LoadNhomKH();
            LoadKhachHang();
        }

        public void LoadNhomKH()
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
