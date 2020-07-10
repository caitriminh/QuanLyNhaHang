using DevExpress.XtraEditors;
using System;
using System.IO;
using System.Windows.Forms;

namespace QuanLyNhaHang.DanhMuc
{
    public partial class frmThemNhomKhachHang2 : XtraForm
    {
        public frmThemNhomKhachHang2()
        {
            InitializeComponent();
        }

        public frmNhomKhachHang frm1_copy;
        public delegate void PassDataB2A(string text);
        public void funObjectB(frmNhomKhachHang frm1)
        {
            this.frm1_copy = frm1;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            var duongdanfile = "";
            var tenfile = "";
            if (txtNhomKH.Text.Length > 0)
            {
                if (Data._edit == false)
                {
                    Data.RunCMD($@"insert into tbl_nhomkhachhang(nhomkh, nguoitd, thoigian) values ('{ txtNhomKH.Text }', '{ Data._strtendangnhap.ToUpper() }', '{ DateTime.Now}')");

                    if (lblDuongDan.Text == "Bạn vui lòng chọn hình ...")
                    {
                        duongdanfile = Application.StartupPath + @"\img\nhomkh\0.png";
                    }
                    else
                    {
                        duongdanfile = openFileDialog1.FileName;
                    }
                    tenfile = Data.GetData("select max(manhomkh) from tbl_nhomkhachhang") + ".png";
                    File.Copy(duongdanfile, Application.StartupPath + @"\img\nhomkh\" + tenfile, true);
                    Data.RunCMD($@"update tbl_nhomkhachhang set hinh='{tenfile}' where manhomkh='{Data.GetData("select max(manhomkh) from tbl_nhomkhachhang")}'");
                    //Ghi lại log
                    Data.HistoryLog("Đã thêm nhóm khách hàng " + txtNhomKH.Text + ".", "Danh mục nhóm khách hàng");
                    txtNhomKH.Text = "";

                }
                else
                {
                    Data.RunCMD($@"update tbl_nhomkhachhang set nhomkh='{txtNhomKH.Text}' where manhomkh='{Data._str_id}'");
                    //Ghi lại log
                    Data.HistoryLog("Đã cập nhật nhóm khách hàng " + txtNhomKH.Text + ".", "Danh mục nhóm khách hàng");

                }
                //Gửi dữ liệu load form chính
                PassDataB2A datasend = new PassDataB2A(frm1_copy.funDataA);
                datasend(DateTime.Now.ToString());
            }
            else
            {
                XtraMessageBox.Show("Bạn phải nhập vào tên nhóm khách hàng.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNhomKH.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Chọn hình đại diện |*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                lblDuongDan.Text = openFileDialog1.FileName;
            }
        }

        private void frmThemNhomKhachHang_Load(object sender, EventArgs e)
        {
            if (Data._edit == true)
            {
                btnChonHinh.Enabled = false;
                var ds = Data.LoadData($@"select * from tbl_nhomkhachhang where manhomkh='{Data._str_id}'");
                if (ds.Tables[0].Rows.Count <= 0) { return; }
                txtNhomKH.Text = ds.Tables[0].Rows[0]["nhomkh"].ToString();
            }
        }

        private void frmThemNhomKhachHang_KeyDown(object sender, KeyEventArgs e)
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
    }
}
