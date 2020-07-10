using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace QuanLyNhaHang.HoatDong
{
    public partial class frmHangHoa : XtraForm
    {
        public frmHangHoa()
        {
            InitializeComponent();
        }

        public void LoadHangHoa()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var ds = Data.LoadData("select * from view_hanghoa order by tenhang");
            dgvHangHoa.DataSource = ds.Tables[0];
            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm == null || frm.IsDisposed)
                frm = new frmThemHangHoa();
            frm.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm.funObjectB);
            sendIDObjectfrm1(this);
        }

        frmThemHangHoa frm = new frmThemHangHoa();
        public delegate void PassIDform1(frmHangHoa frm1_copy);
        public void funDataA(string txtform2)
        {
            label1A.Text = txtform2;
        }

        private void label1A_TextChanged(object sender, EventArgs e)
        {
            LoadHangHoa();
        }

        private void btnNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadHangHoa();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            var dgr = XtraMessageBox.Show($@"Bạn có muốn xóa mặt hàng {gridView1.GetRowCellValue(i, "tenhang")} này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                Data.RunCMD($@"delete from tbl_hanghoa where mahang='{gridView1.GetRowCellValue(i, "mahang")}'");
                //Ghi lại log
                Data.HistoryLog($@"Đã xóa tên hàng hóa {gridView1.GetRowCellValue(i, "tenban")}.", "Danh mục hàng hóa");
                LoadHangHoa();
            }
        }

        private void LuuHangHoa()
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
                    var manhomhang = Data.GetData($@"select manhom from tbl_nhomhang where nhomhang='{dr["nhomhang"]}'");
                    var maloaihanghoa = Data.GetData($@"select maloai from tbl_loaihanghoa where loaihanghoa='{dr["loaihanghoa"]}'");
                    Data.RunCMD($@"update tbl_hanghoa set tenhang='{dr["tenhang"]}', giaban='{Convert.ToDouble(dr["giaban"])}', gianhap='{Convert.ToDouble(dr["gianhap"])}', madvt='{dr["madvt"] }', manhomhang='{manhomhang}', maloaihanghoa='{maloaihanghoa}', ghichu='{dr["ghichu"]}', thoigian2='{ DateTime.Now.ToString() }', nguoitd2='{ Data._strtendangnhap.ToUpper() }' where id='{dr["id"] }'");

                    //Ghi lại log
                    Data.HistoryLog("Đã cập nhật lại thông tin danh mục hàng hóa " + dr["tenhang"] + ".", "Danh mục hàng hóa");
                }
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            label1A.Focus();
            var dgr = XtraMessageBox.Show($@"Bạn có muốn lưu lại những thay đổi trong danh mục hàng hóa này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                LuuHangHoa();
                LoadHangHoa();
            }
        }
        //public void LoadNhomHang()
        //{
        //    var ds = Data.LoadData("select * from tbl_nhomhang order by nhomhang");
        //    cboNhomHang.DataSource = ds.Tables[0];
        //    cboNhomHang.ValueMember = "manhom";
        //    cboNhomHang.DisplayMember = "nhomhang";
        //}

        public void LoadDonViTinh()
        {
            var ds = Data.LoadData("select * from tbl_donvitinh order by tendvt");
            cboDVT.DataSource = ds.Tables[0];
            cboDVT.ValueMember = "madvt";
            cboDVT.DisplayMember = "tendvt";
        }

        public void LoadNhomHang()
        {
            var table = new DataSet();
            table = Data.LoadData("select * from tbl_nhomhang");
            var imageCollection = new ImageCollection();
            cboNhomHang2.SmallImages = imageCollection;
            int i = 0;
            foreach (DataRow item in table.Tables[0].Rows)
            {
                string url_item = Application.StartupPath + "\\img\\" + item["hinh"];
                var image_item = Image.FromFile(url_item);
                imageCollection.AddImage(image_item, item["nhomhang"].ToString());
                cboNhomHang2.Items.Add(new ImageComboBoxItem(item["nhomhang"].ToString(), item["nhomhang"].ToString(), i));
                i++;
            }
        }

        private void frmHangHoa_Load(object sender, EventArgs e)
        {
            LoadNhomHang();
            LoadLoaiHangHoa();
            LoadDonViTinh();
            LoadHangHoa();
        }

        public void LoadLoaiHangHoa()
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

        private void btnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xtraSaveFileDialog1.Filter = "Excel file *|.xlsx";
            if (gridView1.SelectedRowsCount <= 0)
            {
                XtraMessageBox.Show("Bạn phải chọn danh mục hàng hóa để thực hiện.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            xtraSaveFileDialog1.FileName = "DanhMuc_HangHoa_" + DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss");
            if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var selectedRows = gridView1.GetSelectedRows();
                var joinHangHoa = string.Join("','", from r in selectedRows select gridView1.GetRowCellValue(Convert.ToInt32(r), "mahang"));

                string strLenh = "SELECT mahang as [Mã hàng], loaihanghoa as [Loại hàng], nhomhang as [Nhóm hàng], tenhang as [Tên hàng], tendvt as [ĐVT], gianhap as [Giá nhập], giaban as [Giá bán], ghichu as [Ghi chú] from view_hanghoa where mahang in ('" + joinHangHoa + "') order by tenhang";
                var arr = mdl_ExportExcel.LoadSQL2ListArr(strLenh);
                mdl_ExportExcel.ExportListArr2Excel(arr, xtraSaveFileDialog1.FileName);
            }
        }
    }
}
