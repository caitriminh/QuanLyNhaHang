using DevExpress.XtraEditors;
using System;
using System.IO;
using System.Windows.Forms;

namespace QuanLyNhaHang.DanhMuc
{
    public partial class frmThemLoaiHangHoa : XtraForm
    {
        public frmThemLoaiHangHoa()
        {
            InitializeComponent();
        }

        public frmLoaiHangHoa frm1_copy;
        public delegate void PassDataB2A(string text);
        public void funObjectB(frmLoaiHangHoa frm1)
        {
            this.frm1_copy = frm1;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            var duongdanfile = "";
            var tenfile = "";
            if (txtLoaiHangHoa.Text.Length > 0)
            {
                if (Data._edit == false)
                {
                    Data.RunCMD($@"insert into tbl_loaihanghoa(loaihanghoa, nguoitd, thoigian) values ('{ txtLoaiHangHoa.Text }', '{ Data._strtendangnhap.ToUpper() }', '{ DateTime.Now}')");

                    if (lblDuongDan.Text == "Bạn vui lòng chọn hình ...")
                    {
                        duongdanfile = Application.StartupPath + @"\img\loaihang\0.png";
                    }
                    else
                    {
                        duongdanfile = openFileDialog1.FileName;
                    }
                    tenfile = Data.GetData("select max(maloai) from tbl_loaihanghoa") + ".png";
                    File.Copy(duongdanfile, Application.StartupPath + @"\img\loaihang\" + tenfile, true);
                    Data.RunCMD($@"update tbl_loaihanghoa set hinh='{tenfile}' where maloai='{Data.GetData("select max(maloai) from tbl_loaihanghoa")}'");
                    //Ghi lại log
                    Data.HistoryLog("Đã thêm loại hàng hóa " + txtLoaiHangHoa.Text + ".", "Danh mục loại hàng hóa");
                    txtLoaiHangHoa.Text = "";

                }
                else
                {
                    Data.RunCMD($@"update tbl_loaihanghoa set loaihanghoa='{txtLoaiHangHoa.Text}' where maloai='{Data._str_id}'");
                    //Ghi lại log
                    Data.HistoryLog("Đã cập nhật loại hàng hóa " + txtLoaiHangHoa.Text + ".", "Danh mục loại hàng hóa");

                }
                //Gửi dữ liệu load form chính
                PassDataB2A datasend = new PassDataB2A(frm1_copy.funDataA);
                datasend(DateTime.Now.ToString());
            }
            else
            {
                XtraMessageBox.Show("Bạn phải nhập vào tên loại hàng hóa.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLoaiHangHoa.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmThemLoaiHangHoa_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btnLuu_Click(sender, e);
                    break;
                case Keys.Escape:
                    Application.Exit();
                    break;
            }
        }

        private void frmThemLoaiHangHoa_Load(object sender, EventArgs e)
        {
            if (Data._edit == true)
            {
                btnChonHinh.Enabled = false;
                var ds = Data.LoadData($@"select * from tbl_loaihanghoa where maloai='{Data._str_id}'");
                if (ds.Tables[0].Rows.Count <= 0) { return; }
                txtLoaiHangHoa.Text = ds.Tables[0].Rows[0]["loaihanghoa"].ToString();
            }
        }

        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Chọn hình đại diện |*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lblDuongDan.Text = openFileDialog1.FileName;
            }
        }
    }
}
