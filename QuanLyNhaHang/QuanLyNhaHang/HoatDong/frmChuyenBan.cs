using DevExpress.Utils.Drawing;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyNhaHang.HoatDong
{
    public partial class frmChuyenBan : DevExpress.XtraEditors.XtraForm
    {
        public frmChuyenBan()
        {
            InitializeComponent();
            galleryControl1.Gallery.ItemClick += new GalleryItemClickEventHandler(Gallery_ItemClick2);
        }

        int count_group_gallery = 0;
        public void LoadBan()
        {
            var provider = new Sqlite();
            var table_group = provider.ExecuteQuery("SELECT DISTINCT khuvuc FROM view_ban");
            var table_item = provider.ExecuteQuery($@"SELECT DISTINCT a.maban, tenban, khuvuc, hinh, CASE when b.maban>0 THEN 'True' ELSE 'False' END as sudung from view_ban a LEFT JOIN (SELECT maban from tbl_hoadon where dathanhtoan=0) b on b.maban=a.maban where b.maban IS NULL ORDER BY khuvuc, tenban");
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

        private void btnChuyenBan2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var ds2 = Data.LoadData($@"select * from view_ban where maban='{MaBan}'");
            var dgr = XtraMessageBox.Show($@"Bạn có muốn chuyển bàn {ds.Tables[0].Rows[0]["tenban"]} sang bàn {ds2.Tables[0].Rows[0]["tenban"]} này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr != DialogResult.Yes) { return; }
            Data.RunCMD($@"update tbl_hoadon set maban='{MaBan}' where mahoadon='{Data._strMaHD}'");
            //Data.RunCMD($@"update tbl_ban set sudung='True' where maban='{MaBan}'");
            //Data.RunCMD($@"update tbl_ban set sudung='False' where maban='{Data._strMaBan}'");
            //Gửi dữ liệu load form chính
            PassDataB2A datasend = new PassDataB2A(frm1_copy.funDataA);
            datasend(DateTime.Now.ToString());
            Close();
        }

        public frmMain frm1_copy;
        public delegate void PassDataB2A(string text);
        public void funObjectB(frmMain frm1)
        {
            this.frm1_copy = frm1;
        }

        DataSet ds = new DataSet();
        private void frmChuyenBan_Load(object sender, EventArgs e)
        {
            ds = Data.LoadData($@"select * from view_ban where maban='{Data._strMaBan}'");

            this.Text = "CHUYỂN BÀN : " + ds.Tables[0].Rows[0]["khuvuc"] + " - " + ds.Tables[0].Rows[0]["tenban"];
            LoadBan();
        }

        string MaBan = "";
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

            MaBan = e.Item.Value.ToString();

            var ds = new DataSet();
            ds = Data.LoadData($@"select * from view_hoadon where maban='{e.Item.Value.ToString()}' and dathanhtoan='0'");
            if (ds.Tables[0].Rows.Count <= 0) { return; }


        }

        private void btnNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            galleryControl1.Gallery.Groups.Clear();
            LoadBan();
        }

        private void btnChuyenBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnChuyenBan2_ItemClick(sender, e);
        }
    }
}
