using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.ViewInfo;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QuanLyNhaHang.HoatDong
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
            galleryControl1.Gallery.ItemClick += new GalleryItemClickEventHandler(Gallery_ItemClick2);
            galleryControl1.Gallery.ItemDoubleClick += new GalleryItemClickEventHandler(Gallery_ItemClick);

        }

        bool hideTreeview;
        bool flag = true;
        int wPanel3;
        int count_group_gallery = 0;
        private void btnAnDanhMuc_Click(object sender, EventArgs e)
        {
            if (flag) { wPanel3 = splitContainerControl2.Panel2.Width; }
            SplitPanelVisibility pv = hideTreeview == false ? SplitPanelVisibility.Both : SplitPanelVisibility.Panel1;
            splitContainerControl2.PanelVisibility = pv;
            hideTreeview = !hideTreeview;
            splitContainerControl1.SplitterPosition = (flag) ? splitContainerControl1.SplitterPosition + wPanel3 : splitContainerControl1.SplitterPosition - wPanel3;
            flag = !flag;
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            hideTreeview = splitContainerControl2.PanelVisibility == SplitPanelVisibility.Both;
            dateNgayThang.EditValue = DateTime.Now.Date;
            txt_giobd.EditValue = DateTime.Now.ToString("HH:mm");
            txt_giokt.EditValue = DateTime.Now.ToString("HH:mm");
            LoadBan();
            LoadHangHoaImageCbo();
            LoadHangHoa();
            LoadKhachHang();
        }

        public void LoadHangHoa()
        {
            var ds = Data.LoadData("select * from view_hanghoa order by tenhang");
            dgvHangHoa.DataSource = ds.Tables[0];
        }

        public void LoadKhachHang()
        {
            var ds = Data.LoadData("select * from tbl_khachhang order by tenkh");
            cboKhachHang.Properties.DataSource = ds.Tables[0];
            cboKhachHang.Properties.DisplayMember = "tenkh";
            cboKhachHang.Properties.ValueMember = "makh";
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

        public void LoadBan()
        {
            var provider = new Sqlite();
            var table_group = provider.ExecuteQuery("SELECT DISTINCT khuvuc FROM view_ban2");
            var table_item = provider.ExecuteQuery("SELECT * from view_ban2");
            count_group_gallery = table_group.Rows.Count;

            galleryControl1.Gallery.ItemImageLayout = ImageLayoutMode.ZoomInside;
            galleryControl1.Gallery.ImageSize = new Size(64, 64);
            galleryControl1.Gallery.ShowItemText = true;
            galleryControl1.Gallery.ShowGroupCaption = true;

            foreach (DataRow group in table_group.Rows)
            {
                var galleryItem = new GalleryItemGroup();
                galleryItem.Caption = group["khuvuc"] as string;
                //  galleryItem.CaptionAlignment = GalleryItemGroupCaptionAlignment.Center;

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


        private void Gallery_ItemClick(object sender, GalleryItemClickEventArgs e)
        {
            var gc_item = new GalleryItem();
            string id = e.Item.Value.ToString();
            string url = Data.BASE_URL_ICON + Data.GetData($@"select hinh from view_ban where maban='{id}'");
            string is_status = Convert.ToString(Data.GetData($"select sudung from tbl_ban where maban='{id}'").ToString());
            string status = (is_status == "True") ? "False" : "True";
            Data.RunCMD($"update tbl_ban set sudung = '{status}' where maban='{id}'");
            gc_item.ImageOptions.Image = (is_status == "True") ? Data.MakeGrayscale((Bitmap)Image.FromFile(url)) : Image.FromFile(url);

            gc_item.Caption = e.Item.Caption;
            gc_item.Value = e.Item.Value;
            e.Item.Assign(gc_item);
            lblMaHD.Text = Data.GetData($@"select mahoadon from tbl_hoadon where maban='{id}'");
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

            //string id = e.Item.Value.ToString();
            //Data._strMaBan = id;
            var ds = new DataSet();
            ds = Data.LoadData($@"select * from view_hoadon where maban='{e.Item.Value.ToString()}' and dathanhtoan='0'");
            if (ds.Tables[0].Rows.Count <= 0)
            {
                lblMaHD.Text = "";
                return;
            }
            lblMaHD.Text = ds.Tables[0].Rows[0]["mahoadon"].ToString();

            txt_giobd.EditValue = Convert.ToDateTime(ds.Tables[0].Rows[0]["giobd"]).ToString("HH:mm");
            cboKhachHang.EditValue = ds.Tables[0].Rows[0]["makh"].ToString();
            groupBox1.Text = ds.Tables[0].Rows[0]["khuvuc"].ToString().ToUpper() + " - " + ds.Tables[0].Rows[0]["tenban"].ToString();

        }

        private void btnNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            galleryControl1.Gallery.Groups.Clear();
            LoadBan();
        }

        GalleryItem item = null;
        private void popupMenu1_Popup(object sender, EventArgs e)
        {
            var ds = new DataSet();
            ds = Data.LoadData($@"select * from view_hoadon where maban='{ item.Value.ToString()}' and dathanhtoan='0'");
            if (ds.Tables[0].Rows.Count <= 0)
            {
                lblMaHD.Text = "";
                return;
            }
            lblMaHD.Text = ds.Tables[0].Rows[0]["mahoadon"].ToString();

            if (Data.CheckID($@"select count(*) from tbl_ban where maban ='{ item.Value.ToString()}'") > 0)
            {
                btnChuyenBan.Enabled = false;
                btnGopBan.Enabled = false;
            }
            if (item == null)
            {
                return;
            }

            for (int i = 0; i < count_group_gallery; i++)
            {
                foreach (GalleryItem item in galleryControl1.Gallery.Groups[i].Items)
                {
                    item.Checked = false;
                }
            }

            var gc_item = new GalleryItem();
            gc_item.Checked = true;

            gc_item.Caption = item.Caption;
            gc_item.ImageOptions.Image = item.ImageOptions.Image;
            gc_item.Value = item.Value;
            item.Assign(gc_item);
        }

        private void popupMenu1_CloseUp(object sender, EventArgs e)
        {
            item = null;
        }

        public void TaoHoaDon()
        {
            DataSet ds = new DataSet();
            string _str_thang, _str_nam, _str_ngay;
            _str_thang = Convert.ToDateTime(dateNgayThang.EditValue).ToString("MM");
            _str_nam = Convert.ToDateTime(dateNgayThang.EditValue).ToString("yy");
            _str_ngay = Convert.ToDateTime(dateNgayThang.EditValue).ToString("dd");

            ds = Data.LoadData("SELECT * FROM tbl_hoadon where strftime('%d', ngayban)='" + _str_ngay + "' and strftime('%m', ngayban)='" + _str_thang + "' and strftime('%Y', ngayban)='" + Convert.ToDateTime(dateNgayThang.EditValue).ToString("yyyy") + "'");

            if (ds.Tables[0].Rows.Count == 0)
            {
                lblMaHD.Text = "HD" + _str_nam + _str_thang + _str_ngay + "01";
            }
            else
            {
                string _kyhieu = "HD" + _str_nam + _str_thang + _str_ngay;
                lblMaHD.Text = Data.GetData("SELECT '" + _kyhieu + "'||substr('00'||CAST(substr(max(mahoadon),9,2)+1 as varchar),-2) from tbl_hoadon where substr(mahoadon,1,8)='" + _kyhieu + "'");
            }
        }

        private void btnThanhToan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var tenban = Data.GetData($@"select tenban from tbl_ban where maban={item.Value}");
            var dgr = XtraMessageBox.Show($@"Bạn có muốn thanh toán hóa đơn {lblMaHD.Text} cho bàn {tenban} này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr != DialogResult.Yes) { return; }
            double phidichvu = Convert.ToDouble(txtPhiDichVu.Text);
            var giokt = Convert.ToDateTime(dateNgayThang.EditValue).ToString("yyyy-MM-dd") + " " + txt_giokt.Text;
            Data.RunCMD($@"update tbl_hoadon set dathanhtoan='1', phidichvu='{phidichvu}', giokt='{giokt}' where mahoadon='{lblMaHD.Text}'");
            Data.RunCMD($@"update tbl_ban set sudung='False' where maban='{item.Value}'");
            //LoadBan();
            var gc_item = new GalleryItem();
            string url = Data.BASE_URL_ICON + Data.GetData($@"select hinh from view_ban2 where maban='{item.Value}'");
            gc_item.ImageOptions.Image = Data.MakeGrayscale((Bitmap)Image.FromFile(url));
            gc_item.Caption = item.Caption;
            gc_item.Value = item.Value;
            gc_item.Checked = true;
            item.Assign(gc_item);

            lblMaHD.Text = "";
        }


        private void btnMoBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var gc_item = new GalleryItem();
            string id = item.Value.ToString();

            TaoHoaDon();
            cboKhachHang.EditValue = "KH0000";
            var maban = item.Value;
            var giobd = Convert.ToDateTime(dateNgayThang.EditValue).ToString("yyyy-MM-dd") + " " + txt_giobd.Text;
            Data.RunCMD($@"insert into tbl_hoadon(mahoadon, maban, ngayban, nguoilap, giobd, sokhach, makh, nguoitd, thoigian) values ('{lblMaHD.Text}','{maban}','{Convert.ToDateTime(dateNgayThang.EditValue).ToString("yyyy-MM-dd")}','TRẦN THỊ NGỌC DIỄM','{giobd}','{Convert.ToInt16(txtSoKhach.Text)}','{cboKhachHang.EditValue}','{Data._strtendangnhap.ToUpper()}','{DateTime.Now}')");


            string is_status = Convert.ToString(Data.GetData($"select sudung from view_ban2 where maban='{id}'").ToString());
            string status = (is_status == "True") ? "False" : "True";
            //Data.RunCMD($"update tbl_ban set sudung = '{status}' where maban='{id}'");

            // gc_item.ImageOptions.Image = (is_status == "True") ? imageList1.Images[0] : imageList1.Images[1];
            string url = Data.BASE_URL_ICON + Data.GetData($@"select hinh from view_ban2 where maban='{id}'");
            gc_item.ImageOptions.Image = (is_status == "True") ? Image.FromFile(url) : Data.MakeGrayscale((Bitmap)Image.FromFile(url));

            gc_item.Caption = item.Caption;
            gc_item.Value = item.Value;
            item.Assign(gc_item);


            XtraMessageBox.Show("Đã mở bàn " + item.Caption + " thành công.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void galleryControl1_Gallery_ItemDoubleClick(object sender, GalleryItemClickEventArgs e)
        {

        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblMaHD.Text)) { return; }
            txt_giobd.EditValue = DateTime.Now.ToString("HH:mm");
            btnKetThuc.Enabled = true;
            btnBatDau.Enabled = false;
        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            btnKetThuc.Enabled = false;
            btnBatDau.Enabled = true;
            var giokt = Convert.ToDateTime(dateNgayThang.EditValue).ToString("yyyy-MM-dd") + " " + txt_giokt.Text;
            Data.RunCMD($@"update tbl_hoadon set giokt='{giokt}' where mahoadon='{lblMaHD.Text}'");
        }

        private void dgvHangHoa_DoubleClick(object sender, EventArgs e)
        {
            int i = gridView1.FocusedRowHandle;
            if (Data.CheckID($@"select count(*) from tbl_chitiet_hoadon where mahoadon='{lblMaHD.Text}' and idmahang='{gridView1.GetRowCellValue(i, "id")}'") > 0)
            {
                double soluong = Convert.ToDouble(Data.GetData($@"select soluong from tbl_chitiet_hoadon where idmahang='{gridView1.GetRowCellValue(i, "id")}' and mahoadon='{lblMaHD.Text}'")) + 1;
                Data.RunCMD($@"update tbl_chitiet_hoadon set soluong='{soluong}' where idmahang='{gridView1.GetRowCellValue(i, "id")}' and mahoadon='{lblMaHD.Text}'");
            }
            else
            {
                string sql = "INSERT INTO tbl_chitiet_hoadon(mahoadon, idmahang, soluong, dongia, chieckhau, nguoitd, thoigian) VALUES(@mahoadon, @idmahang, @soluong, @dongia, @chieckhau, @nguoitd, @thoigian)";

                SQLiteCommand sqlCom = new SQLiteCommand(sql, Data.strconnect);
                sqlCom.Parameters.AddWithValue("@mahoadon", lblMaHD.Text);
                sqlCom.Parameters.AddWithValue("@idmahang", gridView1.GetRowCellValue(i, "id"));
                sqlCom.Parameters.AddWithValue("@soluong", 1);
                sqlCom.Parameters.AddWithValue("@dongia", Data.GetData($@"select giaban from tbl_hanghoa where id='{gridView1.GetRowCellValue(i, "id")}'"));
                sqlCom.Parameters.AddWithValue("@chieckhau", 0);
                sqlCom.Parameters.AddWithValue("@nguoitd", Data._strtendangnhap.ToUpper());
                sqlCom.Parameters.AddWithValue("@thoigian", DateTime.Now);
                Data.open_connect();
                sqlCom.ExecuteNonQuery();
                Data.close_connect();
            }
            LoadChiTietHoaDon(lblMaHD.Text);
            LoadTinhTienHoaDon();
        }

        public void LoadChiTietHoaDon(string madh)
        {
            var x = gridView2.FocusedRowHandle;
            var y = gridView2.TopRowIndex;
            var ds = new DataSet();
            ds = Data.LoadData($@"select * from view_chitiet_hoadon where mahoadon='{madh}' and dathanhtoan='0'");
            dgvChiTietHoaDon.DataSource = ds.Tables[0];
            if (ds.Tables[0].Rows.Count > 0)
            {
                btnBatDau.Enabled = false;
                txt_giobd.Enabled = false;
                btnKetThuc.Enabled = true;
                //txt
                btnGopBan.Enabled = true;
                btnChuyenBan.Enabled = true;
                LoadTinhTienHoaDon();
            }
            else
            {
                btnBatDau.Enabled = true;
                txt_giobd.EditValue = DateTime.Now.ToString("HH:mm");
                btnKetThuc.Enabled = false;
                txt_giokt.Enabled = false;
                txtPhiDichVu.Text = "0";
                txtTienThue.Text = "0";
                lblTienAnUong.Text = "0";
                lblTongTien.Text = "";
            }

            gridView2.FocusedRowHandle = x;
            gridView2.TopRowIndex = y;

        }

        private void lblMaHD_TextChanged(object sender, EventArgs e)
        {
            LoadChiTietHoaDon(lblMaHD.Text);

        }

        public void LoadTinhTienHoaDon()
        {
            if (string.IsNullOrEmpty(lblMaHD.Text)) { return; }
            if (Data.CheckID($@"SELECT count(*) from view_chitiet_hoadon where mahoadon='{lblMaHD.Text}'") == 0) { return; }
            double tienanuong = Convert.ToDouble(Data.GetData($@"SELECT sum(tongthanhtien) from view_chitiet_hoadon where mahoadon='{lblMaHD.Text}'"));
            lblTienAnUong.Text = tienanuong.ToString("#,##");
            double thue = Convert.ToDouble(txtTienThue.Text);
            double thanhtienthue = thue * Convert.ToDouble(Data.GetData($@"SELECT sum(tongthanhtien) from view_chitiet_hoadon where mahoadon='{lblMaHD.Text}'")) / 100;
            double phidichvu = 0;
            if (Convert.ToDouble(txtPhiDichVu.Text) > 0)
            {
                phidichvu = Convert.ToDouble(txtPhiDichVu.Text);
                lblPhiDichVu.Text = Convert.ToDouble(txtPhiDichVu.Text).ToString("#,##");
            }
            else
            {
                phidichvu = Convert.ToDouble(Data.GetData($@"SELECT sum(phidichvu) from tbl_hoadon where mahoadon='{lblMaHD.Text}'"));
                lblPhiDichVu.Text = phidichvu.ToString("#,##");
            }

            lblTienThue.Text = thanhtienthue.ToString("#,##");
            double tongtien = tienanuong + thanhtienthue + phidichvu;
            lblTongTien.Text = tongtien.ToString("#,##");
        }

        private void splitContainerControl3_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            var i = gridView2.FocusedRowHandle;
            double soluong = 0;
            if (e.Button.Properties.Caption == "Thêm")
            {
                soluong = Convert.ToDouble(Data.GetData($@"select soluong from tbl_chitiet_hoadon where mahang='{gridView2.GetRowCellValue(i, "mahang")}' and mahoadon='{lblMaHD.Text}'")) + 1;
                Data.RunCMD($@"update tbl_chitiet_hoadon set soluong='{soluong}' where mahang='{gridView2.GetRowCellValue(i, "mahang")}' and mahoadon='{lblMaHD.Text}'");
            }
            else if (e.Button.Properties.Caption == "Bớt")
            {
                soluong = Convert.ToDouble(Data.GetData($@"select soluong from tbl_chitiet_hoadon where mahang='{gridView2.GetRowCellValue(i, "mahang")}' and mahoadon='{lblMaHD.Text}'")) - 1;
                if (soluong < 1) { return; }
                Data.RunCMD($@"update tbl_chitiet_hoadon set soluong='{soluong}' where mahang='{gridView2.GetRowCellValue(i, "mahang")}' and mahoadon='{lblMaHD.Text}'");
            }
            else if (e.Button.Properties.Caption == "Xóa")
            {
                Data.RunCMD($@"delete from tbl_chitiet_hoadon where mahang='{gridView2.GetRowCellValue(i, "mahang")}' and mahoadon='{lblMaHD.Text}'");
            }
            else if (e.Button.Properties.Caption == "Chiếc khấu (%)")
            {
                double chieckhau = 0;
                chieckhau = Convert.ToDouble(Data.GetData($@"select chieckhau from tbl_chitiet_hoadon where mahoadon='{lblMaHD.Text}' group by chieckhau")) + 5;
                Data.RunCMD($@"update tbl_chitiet_hoadon set chieckhau='{chieckhau}' where mahoadon='{lblMaHD.Text}'");
            }
            else if (e.Button.Properties.Caption == "Lưu")
            {
                for (var index = 0; index <= gridView2.RowCount - 1; index++)
                {
                    var dr = gridView2.GetDataRow(Convert.ToInt32(index));
                    if (ReferenceEquals(dr, null))
                    {
                        break;
                    }
                    if (dr.RowState == DataRowState.Modified)
                    {
                        Data.RunCMD($@"update tbl_chitiet_hoadon set soluong='{ dr["soluong"] }', dongia='{dr["dongia"]}', chieckhau='{dr["chieckhau"]}', thoigian2='{ DateTime.Now.ToString() }', nguoitd2='{ Data._strtendangnhap.ToUpper() }' where mahoadon='{ dr["mahoadon"] }' and mahang='{dr["mahang"]}'");
                        //Ghi lại log
                        Data.HistoryLog($@"Đã cập nhật lại thông tin chi tiết mặt hàng { dr["tenhang"] } của hóa đơn {dr["mahoadon"]}", "Chi tiết hóa đơn");
                    }
                }
                XtraMessageBox.Show($@"Đã cập nhật chi tiết hóa đơn {lblMaHD.Text}.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadChiTietHoaDon(lblMaHD.Text);
            LoadTinhTienHoaDon();
        }

        private void txtPhiDichVu_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhiDichVu.Text)) { return; }
            lblPhiDichVu.Text = txtPhiDichVu.Text;
            LoadTinhTienHoaDon();
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnChuyenBan1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Data._strMaBan = item.Value.ToString();
            Data._strMaHD = lblMaHD.Text;
            if (frm == null || frm.IsDisposed)
                frm = new frmChuyenBan();
            frm.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm.funObjectB);
            sendIDObjectfrm1(this);
        }

        frmChuyenBan frm = new frmChuyenBan();
        frmGopBan frm1 = new frmGopBan();
        public delegate void PassIDform1(frmMain frm1_copy);
        public void funDataA(string txtform2)
        {
            label1A.Text = txtform2;
        }

        private void label1A_TextChanged(object sender, EventArgs e)
        {
            galleryControl1.Gallery.Groups.Clear();
            LoadBan();
        }

        private void popupMenu1_BeforePopup(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Point point = galleryControl1.PointToClient(Control.MousePosition);
            RibbonHitInfo hitInfo = galleryControl1.CalcHitInfo(point);
            if (hitInfo.InGalleryItem || hitInfo.HitTest == RibbonHitTest.GalleryImage)
                item = hitInfo.GalleryItem;
            if (item == null)
            {
                e.Cancel = true;
            }
            else
            {
                string status_item = item.Value.ToString();
                status_item = Data.GetData($"SELECT DISTINCT CASE when b.maban>0 THEN 'True' ELSE 'False' END as sudung from view_ban a LEFT JOIN (SELECT maban from tbl_hoadon where dathanhtoan=0) b on b.maban=a.maban where a.maban='{status_item}'");
                bool trangthai = status_item.Equals("False") ? false : true;
                AnHienMenu(trangthai);
            }

        }


        private void btnDoiHinhBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (item == null) { return; }
            openFileDialog1.Filter = "Chọn hình đại diện |*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var makhuvuc = Data.GetData($@"select makhuvuc from view_ban where maban='{ item.Value.ToString()}'");
                string filename_icon = Path.GetFileName(openFileDialog1.FileName);
                string path_file_icon = Data.BASE_URL_ICON + filename_icon;

                if (!File.Exists(path_file_icon))
                {
                    File.Copy(openFileDialog1.FileName, path_file_icon, true);

                }

                Data.RunCMD($@"update tbl_khuvuc set hinh='{filename_icon}' where makhuvuc='{makhuvuc}'");
                galleryControl1.Gallery.Groups.Clear();
                LoadBan();


            }
            XtraMessageBox.Show("Bạn đã cập nhật hình đại diện của bàn thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void AnHienMenu(bool trangthai)
        {
            btnGopBan1.Enabled = trangthai;
            btnChuyenBan1.Enabled = trangthai;
            btnTachHoaDon.Enabled = trangthai;
            btnThanhToan.Enabled = trangthai;

            btnMoBan.Enabled = !trangthai;
        }

        private void btnGopBan1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Data._strMaBan = item.Value.ToString();
            Data._strMaHD = lblMaHD.Text;
            if (frm1 == null || frm1.IsDisposed)
                frm1 = new frmGopBan();
            frm1.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm1.funObjectB);
            sendIDObjectfrm1(this);
        }
    }
}
