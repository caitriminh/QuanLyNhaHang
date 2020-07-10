using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Windows.Forms;

namespace QuanLyNhaHang.QuanTri
{
    public partial class frmNguoiDung : XtraForm
    {
        public frmNguoiDung()
        {
            InitializeComponent();
        }

        private void frm_nguoidung_Load(object sender, EventArgs e)
        {
            LoadNguoiDung();
            //LoadPhanQuyen();
        }

        //public void LoadPhanQuyen()
        //{
        //    if (Data.Data._check_id($@"select count(*) from tbl_phanquyen where tendangnhap='{Data.Data._strtendangnhap.ToUpper()}' and mamenu='1' and luu='True'") == 1)
        //    {
        //        btn_Them.Enabled = true;
        //    }
        //    else
        //    {
        //        btn_Them.Enabled = false;
        //    }

        //    if (Data.Data._check_id($@"select count(*) from tbl_phanquyen where tendangnhap='{Data.Data._strtendangnhap.ToUpper()}' and mamenu='1' and xoa='True'") == 1)
        //    {
        //        btn_Xoa.Enabled = true;
        //    }
        //    else
        //    {
        //        btn_Xoa.Enabled = false;
        //    }

        //    if (Data.Data._check_id($@"select count(*) from tbl_phanquyen where tendangnhap='{Data.Data._strtendangnhap.ToUpper()}' and mamenu='1' and sua='True'") == 1)
        //    {
        //        gridView1.OptionsBehavior.ReadOnly = false;
        //        btn_Luu.Enabled = true;
        //        col_reset_password.Visible = true;
        //    }
        //    else
        //    {
        //        gridView1.OptionsBehavior.ReadOnly = true;
        //        btn_Luu.Enabled = false;
        //        col_reset_password.Visible = false;
        //    }

        //    if (Data.Data._check_id($@"select count(*) from tbl_phanquyen where tendangnhap='{Data.Data._strtendangnhap.ToUpper()}' and mamenu='1' and [in]='True'") == 1)
        //    {
        //        btn_Excel.Enabled = true;
        //    }
        //    else
        //    {
        //        btn_Excel.Enabled = false;
        //    }
        //}

        public void LoadNguoiDung()
        {
            DataSet ds = new DataSet();
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            ds = Data.LoadData("select * from view_nguoidung where tendangnhap not in ('ADMIN') order by tendangnhap");
            dgv_NguoiDung.DataSource = ds.Tables[0];
            lbl_tendangnhap.DataBindings.Clear();
            lbl_tendangnhap.DataBindings.Add("text", ds.Tables[0], "tendangnhap");
            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }

        public void funDataA(string txtform2)
        {
            label1A.Text = txtform2;
        }

        private void btn_Excel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xtraSaveFileDialog1.Filter = "Excel file *|.xlsx";
            xtraSaveFileDialog1.FileName = "DanhMuc_NguoiDung_" + DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss");
            if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dgv_NguoiDung.ExportToXlsx(xtraSaveFileDialog1.FileName);
                Process.Start(xtraSaveFileDialog1.FileName);
            }
        }

        private void label1A_TextChanged(object sender, EventArgs e)
        {
            LoadNguoiDung();
        }

        private void btn_Them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm2 == null || frm2.IsDisposed)
                frm2 = new frmThemNguoiDung();
            frm2.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm2.funObjectB);
            sendIDObjectfrm1(this);
        }

        frmThemNguoiDung frm2 = new frmThemNguoiDung();
        public delegate void PassIDform1(frmNguoiDung frm1_copy);

        private void btn_Xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int i = gridView1.FocusedRowHandle;
            DialogResult dgr = XtraMessageBox.Show("Bạn có muốn xóa tên đăng nhập " + gridView1.GetRowCellValue(i, "tendangnhap") + " này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                var row = gridView1.GetFocusedDataRow();
                Data.RunCMD("delete from tbl_nguoidung where tendangnhap='" + gridView1.GetRowCellValue(i, "tendangnhap") + "'");
                //Ghi lại log
                Data.HistoryLog("Đã xóa người dùng có tên " + gridView1.GetRowCellValue(i, "tendangnhap") + ".", "Danh mục người dùng");
                row.Table.Rows.Remove(row);
            }
        }

        private void btn_NapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadNguoiDung();
        }

        private void LuuNguoiDung()
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
                    string sql = $@"update tbl_nguoidung set ghichu=@ghichu, thoigian2=@thoigian2, nguoitd2=@nguoitd2 where tendangnhap=@tendangnhap";

                    SQLiteCommand sqlCom = new SQLiteCommand(sql, Data.strconnect);
                    sqlCom.Parameters.AddWithValue("@tendangnhap", dr["tendangnhap"]);
                    sqlCom.Parameters.AddWithValue("@ghichu", dr["ghichu"]);
                    sqlCom.Parameters.AddWithValue("@nguoitd2", Data._strtendangnhap.ToUpper());
                    sqlCom.Parameters.AddWithValue("@thoigian2", DateTime.Now);
                    Data.open_connect();
                    sqlCom.ExecuteNonQuery();
                    Data.close_connect();
                    //Ghi lại log
                    Data.HistoryLog("Đã cập nhật lại thông tin người dùng có tên " + dr["tendangnhap"].ToString().ToUpper() + ".", "Danh mục người dùng");
                }
            }
        }

        private void btn_Luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lbl_tendangnhap.Focus();
            DialogResult dgr = XtraMessageBox.Show("Bạn có muốn lưu lại những thay đổi không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                LuuNguoiDung();
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            if (ReferenceEquals(e.Column, col_reset_password))
            {
                DialogResult dgr = XtraMessageBox.Show("Bạn có muốn khôi phục lại mật khẩu mặc định của tài khoản " + gridView1.GetRowCellValue(i, "tendangnhap") + " không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dgr == DialogResult.Yes)
                {
                    Data.RunCMD($@"update tbl_nguoidung set matkhau='{ Data.Md5(gridView1.GetRowCellValue(i, "tendangnhap").ToString()) }' where tendangnhap='{ gridView1.GetRowCellValue(i, "tendangnhap") }'");
                    //Ghi lại log
                    Data.HistoryLog("Đã khôi phục lại mật khẩu người dùng có tên " + gridView1.GetRowCellValue(i, "tendangnhap") + ".", "Danh mục người dùng");
                    XtraMessageBox.Show("Đã khôi phục mật khẩu thành công.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
