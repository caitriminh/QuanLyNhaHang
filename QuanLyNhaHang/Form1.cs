using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraEditors;
using QuanLyNhaHang.DanhMuc;
using QuanLyNhaHang.HoatDong;
using QuanLyNhaHang.KhoHang;
using QuanLyNhaHang.NhanSu;
using QuanLyNhaHang.QuanTri;
using QuanLyNhaHang.Quy;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
            InitSkins();
            InitSkinGallery();
        }

        public void InitSkins()
        {
            SkinManager.EnableFormSkins();
            BonusSkins.Register();
            defaultLookAndFeel1.LookAndFeel.SetSkinStyle(Properties.Settings.Default.skin);
        }

        private void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(ribbonGalleryBarItem1, true);
        }

        public void OpenForm(Type typeform)
        {
            foreach (var frm in MdiChildren.Where(frm => frm.GetType() == typeform))
            {
                frm.Activate();
                return;
            }

            BeginInvoke(new Action(() =>
            {
                var form = (Form)(Activator.CreateInstance(typeform));
                form.MdiParent = this;
                form.Show();
            }));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OpenForm(typeof(frmMain));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            var strSkin = defaultLookAndFeel1.LookAndFeel.SkinName;
            Properties.Settings.Default.skin = strSkin;
            Properties.Settings.Default.Save();
        }

        private void btnDonViTinh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmDonViTinh));
        }

        private void btnKhuVuc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmKhuVuc));
        }

        private void btnBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmBan));
        }

        private void btnNhomHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmNhomHang));
        }

        private void btnKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmKho));
        }

        private void btnLoaiPhieuThuChi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmLoaiChiPhi));
        }

        private void btnKhachHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmKhachHang));
        }

        private void btnQuanLyBanHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmQuanLyBanHang));
        }

        private void btnHangHoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmHangHoa));
        }

        private void btnNCC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmNCC));
        }

        private void btnPhieuNhapKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmPhieuNhapKho));
        }

        private void btnSuDungDichVu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmMain));
        }

        private void btnLoaiHangHoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmLoaiHangHoa));
        }

        private void btnNhomKH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmNhomKhachHang));
        }

        private void btnThongKeDoanhThu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmThongKeDoanhThu));
        }

        private void btnThongKeDoAnUong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmThongKeDoAnUong));
        }

        private void btnTonKhoBanDau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmSoDu));
        }

        private void btnTonKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmTonKho));
        }

        private void btnPhieuXuatKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmPhieuXuatKho));
        }

        private void btnBaoCaoKhoHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmBaoCaoKhoHang));
        }

        private void btnChuyenKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmChuyenKho));
        }

        private void btnNhatKyHeThong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmNhatKyHeThong));
        }

        private void btnNguoiDung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmNguoiDung));
        }

        private void btnChucVu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmChucVu));
        }

        private void btnCaLamViec_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmCaLamViec));
        }

        private void btnNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmNhanVien));
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dgr = XtraMessageBox.Show("Bạn có muốn đóng chương trình không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnDoiMatKhau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmDoiMatKhau();
            frm.ShowDialog();
        }

        private void btnKhoaHeThong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmDangNhap();
            frm.ShowDialog();
        }

        private void btnTamUng_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmTamUng));
        }

        private void btnDanhMucPhieuThuChi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmLoaiChiPhi));
        }

        private void btnThuongPhat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmThuongPhat));
        }

        private void btnChamCong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmChamCong));
        }

        private void btnMucLuong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmMucLuong));
        }

        private void btnLuongNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmLuongNhanVien));
        }

        private void btnPhieuThu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmPhieuThu));
        }

        private void btnPhieuChi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(typeof(frmPhieuChi));
        }

        private void btnChuyenSoDu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var frm = new frmCapNhatSoDuDauKy();
            frm.ShowDialog();
        }
    }
}
