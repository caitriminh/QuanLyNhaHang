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
    public partial class frmLoaiHangHoa : XtraForm
    {
        public frmLoaiHangHoa()
        {
            InitializeComponent();
        }

        public void LoadLoaiHangHoa()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var ds = Data.LoadData("select * from tbl_loaihanghoa order by loaihanghoa");
            dgvLoaiHangHoa.DataSource = ds.Tables[0];
            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm == null || frm.IsDisposed)
                frm = new frmThemLoaiHangHoa();
            frm.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm.funObjectB);
            sendIDObjectfrm1(this);
        }

        frmThemLoaiHangHoa frm = new frmThemLoaiHangHoa();
        public delegate void PassIDform1(frmLoaiHangHoa frm1_copy);
        public void funDataA(string txtform2)
        {
            label1A.Text = txtform2;
        }

        private void label1A_TextChanged(object sender, EventArgs e)
        {
            LoadLoaiHang2();
            LoadLoaiHangHoa();
        }

        private void btnNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadLoaiHang2();
            LoadLoaiHangHoa();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            var dgr = XtraMessageBox.Show($@"Bạn có muốn xóa loại hàng hóa {gridView1.GetRowCellValue(i, "loaihanghoa")} này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                Data.RunCMD($@"delete from tbl_loaihanghoa where maloai='{gridView1.GetRowCellValue(i, "maloai")}'");
                LoadLoaiHang2();
                LoadLoaiHangHoa();
                try
                {
                    File.Delete(Application.StartupPath + @"\img\loaihang\" + gridView1.GetRowCellValue(i, "maloai") + ".png");
                }
                catch (Exception)
                {

                    // throw;
                }
                //Ghi lại log
                Data.HistoryLog($@"Đã xóa loại hàng hóa {gridView1.GetRowCellValue(i, "loaihanghoa")}.", "Danh mục loại hàng hóa");

            }
        }

        private void LuuLoaiHangHoa()
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
                    Data.RunCMD("update tbl_loaihanghoa set loaihanghoa='" + dr["loaihanghoa"] + "', thoigian2='" + DateTime.Now.ToString() + "', nguoitd2='" + Data._strtendangnhap.ToUpper() + "' where maloai='" + dr["maloai"] + "'");
                    //Ghi lại log
                    Data.HistoryLog("Đã cập nhật lại thông tin loại hàng hóa " + dr["loaihanghoa"] + ".", "Danh mục loại hàng hóa");
                }
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            label1A.Focus();
            var dgr = XtraMessageBox.Show($@"Bạn có muốn lưu lại những thay đổi trong danh mục loại hàng hóa này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                LuuLoaiHangHoa();
            }
        }

        private void frmLoaiHangHoa_Load(object sender, EventArgs e)
        {
            LoadLoaiHangHoa();
            LoadLoaiHang2();
        }

        public void LoadLoaiHang2()
        {
            var table = new DataSet();
            table = Data.LoadData("select * from tbl_loaihanghoa");
            var imageCollection = new ImageCollection();
            cboLoaiHangHoa.SmallImages = imageCollection;
            int i = 0;
            foreach (DataRow item in table.Tables[0].Rows)
            {
                string url_item = Application.StartupPath + @"\img\loaihang\" + item["hinh"];
                var image_item = Image.FromFile(url_item);
                imageCollection.AddImage(image_item, item["loaihanghoa"].ToString());
                cboLoaiHangHoa.Items.Add(new ImageComboBoxItem(item["loaihanghoa"].ToString(), item["loaihanghoa"].ToString(), i));
                i++;
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            Data._edit = true;
            Data._str_id = gridView1.GetRowCellValue(i, "maloai").ToString();
            if (frm == null || frm.IsDisposed)
                frm = new frmThemLoaiHangHoa();
            frm.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm.funObjectB);
            sendIDObjectfrm1(this);
        }
    }
}
