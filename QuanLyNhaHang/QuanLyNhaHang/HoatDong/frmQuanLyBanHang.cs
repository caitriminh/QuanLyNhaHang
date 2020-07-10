using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyNhaHang.HoatDong
{
    public partial class frmQuanLyBanHang : DevExpress.XtraEditors.XtraForm
    {
        public frmQuanLyBanHang()
        {
            InitializeComponent();
            galleryControl1.Gallery.ItemClick += new GalleryItemClickEventHandler(Gallery_ItemClick2);
        }

        int count_group_gallery = 0;
        int i = 1;
        public void LoadBan()
        {
            var provider = new Sqlite();
            DataTable table_group = new DataTable();
            DataTable table_item = new DataTable();

            table_group = provider.ExecuteQuery($@"SELECT DISTINCT c.khuvuc from tbl_ban a LEFT JOIN (SELECT DISTINCT maban from tbl_hoadon where ngayban>='{Convert.ToDateTime(dateTuNgay.EditValue).ToString("yyyy-MM-dd")}' and ngayban<='{Convert.ToDateTime(dateDenNgay.EditValue).ToString("yyyy-MM-dd")}' and huyhoadon=0) b on b.maban=a.maban INNER JOIN tbl_khuvuc c on c.makhuvuc=a.makhuvuc");
            table_item = provider.ExecuteQuery($@"SELECT a.maban, a.tenban, c.khuvuc, c.hinh, CASE when b.maban is null then 'False' ELSE 'True' END as sudung from tbl_ban a LEFT JOIN (SELECT DISTINCT maban from tbl_hoadon where ngayban>='{Convert.ToDateTime(dateTuNgay.EditValue).ToString("yyyy-MM-dd")}' and ngayban<='{Convert.ToDateTime(dateDenNgay.EditValue).ToString("yyyy-MM-dd")}' and huyhoadon=0) b on b.maban=a.maban INNER JOIN tbl_khuvuc c on c.makhuvuc=a.makhuvuc");

            count_group_gallery = table_group.Rows.Count;

            galleryControl1.Gallery.ItemImageLayout = ImageLayoutMode.ZoomInside;
            galleryControl1.Gallery.ImageSize = new Size(64, 64);
            galleryControl1.Gallery.ShowItemText = true;
            galleryControl1.Gallery.ShowGroupCaption = true;

            foreach (DataRow group in table_group.Rows)
            {
                var galleryItem = new GalleryItemGroup();
                galleryItem.Caption = group["khuvuc"] as string;

                foreach (DataRow item in table_item.Rows)
                {
                    if (group["khuvuc"].ToString().Equals(item["khuvuc"].ToString()))
                    {
                        var gc_item = new GalleryItem();
                        gc_item.AppearanceCaption.Normal.Font = new Font("Tahoma", 12, FontStyle.Regular);
                        gc_item.AppearanceCaption.Hovered.Font = new Font("Tahoma", 12, FontStyle.Regular);
                        gc_item.AppearanceCaption.Pressed.Font = new Font("Tahoma", 12, FontStyle.Regular);

                        string url = Data.BASE_URL_ICON + item["hinh"];
                        if (item["sudung"].ToString() == "True")
                        {
                            gc_item.ImageOptions.Image = Image.FromFile(url);
                        }
                        else
                        {
                            gc_item.ImageOptions.Image = Data.MakeGrayscale((Bitmap)Image.FromFile(url));
                        }
                        gc_item.Caption = item["tenban"].ToString();
                        gc_item.Value = item["maban"].ToString();

                        galleryItem.Items.Add(gc_item);
                    }
                }
                galleryControl1.Gallery.Groups.Add(galleryItem);
            }
        }

        private void Gallery_ItemClick2(object sender, GalleryItemClickEventArgs e)
        {
            for (int i = 0; i < count_group_gallery; i++)
            {
                foreach (GalleryItem item in galleryControl1.Gallery.Groups[i].Items)
                {
                    item.Checked = false;
                }
            }
            var gc_item = new GalleryItem();
            gc_item.Checked = true;
            gc_item.Caption = e.Item.Caption;
            gc_item.ImageOptions.Image = e.Item.ImageOptions.Image;
            gc_item.Value = e.Item.Value;
            e.Item.Assign(gc_item);
            strMaBan = e.Item.Value.ToString();
            LoadHoaDon();
        }

        string strMaBan = "";
        public void LoadHoaDon()
        {
            var x = gridView2.FocusedRowHandle;
            var y = gridView2.TopRowIndex;
            var ds = new DataSet();
            ds = Data.LoadData($@"select * from view_hoadon where maban='{strMaBan}' and huyhoadon='0' and ngayban>='{Convert.ToDateTime(dateTuNgay.EditValue).ToString("yyyy-MM-dd")}' and ngayban<='{Convert.ToDateTime(dateDenNgay.EditValue).ToString("yyyy-MM-dd")}' order by ngayban desc");
            dgvHoaDon.DataSource = ds.Tables[0];
            if (ds.Tables[0].Rows.Count == 0) { lblMaHD.Text = ""; }
            lblMaHD.DataBindings.Clear();
            lblMaHD.DataBindings.Add("text", ds.Tables[0], "mahoadon");
            gridView2.FocusedRowHandle = x;
            gridView2.TopRowIndex = y;
        }

        //GalleryItem item = null;
        private void btnNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            galleryControl1.Gallery.Groups.Clear();
            LoadBan();
        }

        public void LoadHangHoaImageCbo()
        {
            var table = new DataSet();
            table = Data.LoadData("select * from view_hanghoa");
            var imageCollection = new ImageCollection();
            cboTenHang.SmallImages = imageCollection;
            int i = 0;
            foreach (DataRow item in table.Tables[0].Rows)
            {
                string url_item = Application.StartupPath + "\\img\\" + item["hinh"];
                var image_item = Image.FromFile(url_item);
                imageCollection.AddImage(image_item, item["tenhang"].ToString());
                cboTenHang.Items.Add(new ImageComboBoxItem(item["tenhang"].ToString(), item["tenhang"].ToString(), i));
                i++;
            }
        }

        private void frmQuanLyBanHang_Load(object sender, EventArgs e)
        {
            dateTuNgay.EditValue = DateTime.Now.Date;
            dateDenNgay.EditValue = DateTime.Now.Date;

            LoadBan();
            LoadHangHoaImageCbo();
        }

        public void LoadChiTietHoaDon()
        {
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            var ds = new DataSet();
            ds = Data.LoadData($@"select * from view_chitiet_hoadon where mahoadon='{lblMaHD.Text}'");
            dgvChiTietHoaDon.DataSource = ds.Tables[0];
            lblMaHang.DataBindings.Clear();
            lblMaHang.DataBindings.Add("text", ds.Tables[0], "idmahang");

            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }

        bool hideTreeview;
        bool flag = true;
        int wPanel3;
        private void lblMaHD_TextChanged(object sender, EventArgs e)
        {
            LoadChiTietHoaDon();
        }

        private void splitContainerControl4_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            if (e.Button.Properties.Caption == "Hide")
            {
                if (flag) { wPanel3 = splitContainerControl2.Panel2.Width; }
                SplitPanelVisibility pv = hideTreeview == false ? SplitPanelVisibility.Both : SplitPanelVisibility.Panel1;
                splitContainerControl2.PanelVisibility = pv;
                hideTreeview = !hideTreeview;
                splitContainerControl1.SplitterPosition = (flag) ? splitContainerControl1.SplitterPosition + wPanel3 : splitContainerControl1.SplitterPosition - wPanel3;
                flag = !flag;
            }
            else if (e.Button.Properties.Caption == "Hủy bàn")
            {
                var tenban = Data.GetData($@"select tenban from view_hoadon where mahoadon='{lblMaHD.Text}'");
                var dgr = XtraMessageBox.Show($@"Bạn có muốn hủy bàn {tenban} này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dgr == DialogResult.Yes)
                {
                    Data.RunCMD($@"update tbl_hoadon set huyhoadon=1 where mahoadon='{lblMaHD.Text}'");
                    LoadHoaDon();
                }
            }
            else if (e.Button.Properties.Caption == "Excel")
            {
                xtraSaveFileDialog1.Filter = "Excel files |*.xlsx";
                xtraSaveFileDialog1.FileName = "DanhMucBanHang_Ban_" + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss");
                if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string strLenh = $@"SELECT mahoadon as [Mã hóa đơn], ngayban as [Ngày bán], tenban as [Tên bàn], strftime('%H:%M', giobd) as [Bắt đầu], strftime('%H:%M', giokt) as [Kết thúc], mahang as [Mã hàng], nhomhang as [Nhóm hàng], tenhang as [Tên hàng], tendvt as [ĐVT], soluong as [Số lượng], dongia as [Đơn giá], thanhtien as [Thành tiền], tienchieckhau as [Chiếc khấu], phidichvu as [Phí dịch vụ], tongthanhtien as [Tổng thành tiền] from view_chitiet_hoadon where ngayban>='{Convert.ToDateTime(dateTuNgay.EditValue).ToString("yyyy-MM-dd")}' and ngayban<='{Convert.ToDateTime(dateDenNgay.EditValue).ToString("yyyy-MM-dd")}' and maban='{strMaBan}'";
                    var arr = mdl_ExportExcel.LoadSQL2ListArr(strLenh);
                    mdl_ExportExcel.ExportListArr2Excel(arr, xtraSaveFileDialog1.FileName);
                }
            }
        }

        private void splitContainerControl3_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            int intSL = 0;
            intSL = Convert.ToInt32(Data.GetData($@"select soluong from tbl_chitiet_hoadon where mahoadon='{lblMaHD.Text}' and idmahang='{lblMaHang.Text}'"));
            if (e.Button.Properties.Caption == "Thêm")
            {
                Data.RunCMD($@"update tbl_chitiet_hoadon set soluong='{intSL + 1}' where mahoadon='{lblMaHD.Text}' and idmahang='{lblMaHang.Text}'");
            }
            else if (e.Button.Properties.Caption == "Bớt")
            {
                if (intSL - 1 <= 0) { return; }
                Data.RunCMD($@"update tbl_chitiet_hoadon set soluong='{intSL - 1}' where mahoadon='{lblMaHD.Text}' and idmahang='{lblMaHang.Text}'");
            }
            else if (e.Button.Properties.Caption == "Xóa")
            {
                var dgr = XtraMessageBox.Show($@"Bạn có muốn xóa tên hàng {gridView1.GetRowCellValue(i, "tenhang")} này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dgr != DialogResult.Yes) { return; }
                Data.RunCMD($@"delete from tbl_chitiet_hoadon where mahoadon='{lblMaHD.Text}' and idmahang='{lblMaHang.Text}'");
            }
            else if (e.Button.Properties.Caption == "Lưu")
            {
                lblMaHD.Focus();
                for (var index = 0; index <= gridView1.RowCount - 1; index++)
                {
                    var dr = gridView1.GetDataRow(Convert.ToInt32(index));
                    if (ReferenceEquals(dr, null))
                    {
                        break;
                    }
                    if (dr.RowState == DataRowState.Modified)
                    {
                        Data.RunCMD($@"update tbl_chitiet_hoadon set soluong='{dr["soluong"]}' where mahoadon='{lblMaHD.Text}' and idmahang='{dr["idmahang"]}'");
                        //Ghi lại log
                        Data.HistoryLog("Đã cập nhật chi tiết hóa đơn của mặt hàng " + dr["tenhang"] + " thuộc hóa đơn " + lblMaHD.Text + ".", "Quản lý bán hàng");
                    }
                }
            }
            LoadChiTietHoaDon();
        }
    }
}
