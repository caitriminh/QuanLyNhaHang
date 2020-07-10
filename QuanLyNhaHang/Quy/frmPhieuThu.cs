﻿using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Windows.Forms;

namespace QuanLyNhaHang.Quy
{
    public partial class frmPhieuThu : DevExpress.XtraEditors.XtraForm
    {
        public frmPhieuThu()
        {
            InitializeComponent();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm2 == null || frm2.IsDisposed)
                frm2 = new frmThemPhieuThu();
            frm2.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm2.funObjectB);
            sendIDObjectfrm1(this);
        }

        frmThemPhieuThu frm2 = new frmThemPhieuThu();
        public delegate void PassIDform1(frmPhieuThu frm1_copy);
        public void funDataA(string txtform2)
        {
            label1A.Text = txtform2;
        }

        private void label1A_TextChanged(object sender, EventArgs e)
        {
            LoadPhieuThu();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Data._strmaphieu = lblMaPhieu.Text;
            Data._edit = true;
            if (frm2 == null || frm2.IsDisposed)
                frm2 = new frmThemPhieuThu();
            frm2.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm2.funObjectB);
            sendIDObjectfrm1(this);
        }

        public void LoadPhieuThu()
        {
            var x = gridView2.FocusedRowHandle;
            var y = gridView2.TopRowIndex;
            var ds = Data.LoadData($@"SELECT * from view_phieuthuchi where ngaylap>='{Convert.ToDateTime(dateTuNgay.EditValue).ToString("yyyy-MM-dd")}' and ngaylap<='{Convert.ToDateTime(dateDenNgay.EditValue).ToString("yyyy-MM-dd")}' and nhomphieu='THU' order by maphieu");
            dgvPhieuThu.DataSource = ds.Tables[0];
            lblMaPhieu.DataBindings.Clear();
            lblMaPhieu.DataBindings.Add("text", ds.Tables[0], "maphieu");
            gridView2.FocusedRowHandle = x;
            gridView2.TopRowIndex = y;
        }

        private void btnNapLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadPhieuThu();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dgr = XtraMessageBox.Show("Bạn có muốn xóa phiếu thu " + lblMaPhieu.Text + " này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                Data.RunCMD("delete from tbl_phieuthuchi where maphieu='" + lblMaPhieu.Text + "'");
                //Ghi lại log
                Data.HistoryLog("Đã xóa phiếu thu " + lblMaPhieu.Text + ".", "Danh mục phiếu thu");
                LoadPhieuThu();
            }
        }

        private void LuuPhieuThu()
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
                    string sql = $@"update tbl_phieuthuchi set maloaiphieu=@maloaiphieu, sotien=@sotien, ngaylap=@ngaylap, nguoilap=@nguoilap, ghichu=@ghichu, nguoitd2=@nguoitd2, thoigian2=@thoigian2 where maphieu=@maphieu";

                    SQLiteCommand sqlCom = new SQLiteCommand(sql, Data.strconnect);
                    sqlCom.Parameters.AddWithValue("@maphieu", dr["maphieu"]);
                    sqlCom.Parameters.AddWithValue("@maloaiphieu", dr["maloaiphieu"]);
                    sqlCom.Parameters.AddWithValue("@sotien", Convert.ToInt32(dr["sotien"]));
                    sqlCom.Parameters.AddWithValue("@ngaylap", Convert.ToDateTime(dr["ngaylap"]).ToString("yyyy-MM-dd"));
                    sqlCom.Parameters.AddWithValue("@nguoilap", dr["nguoilap"]);
                    sqlCom.Parameters.AddWithValue("@ghichu", dr["ghichu"]);
                    sqlCom.Parameters.AddWithValue("@nguoitd2", Data._strtendangnhap.ToUpper());
                    sqlCom.Parameters.AddWithValue("@thoigian2", DateTime.Now);
                    Data.open_connect();
                    sqlCom.ExecuteNonQuery();
                    Data.close_connect();
                    //Ghi lại log
                    Data.HistoryLog("Đã cập nhật phiếu thu " + dr["maphieu"] + ".", "Danh mục phiếu thu");
                }
            }
            LoadPhieuThu();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            lblMaPhieu.Focus();
            DialogResult dgrResult = XtraMessageBox.Show("Bạn có muốn lưu lại những thay đổi trong danh mục phiếu thu không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgrResult == DialogResult.Yes)
            {
                LuuPhieuThu();
            }
        }

        private void btn_excel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xtraSaveFileDialog1.Filter = "Excel files |*.xlsx";
            xtraSaveFileDialog1.FileName = "PhieuThu_" + DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss"); ;
            if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dgvPhieuThu.ExportToXlsx(xtraSaveFileDialog1.FileName);
                Process.Start(xtraSaveFileDialog1.FileName);
            }
        }

        public void LoadLoaiPhieu()
        {
            var ds = Data.LoadData("select * from tbl_loaiphieuthuchi where nhomphieu='THU' order by loaiphieu");
            cboLoaiPhieu.DataSource = ds.Tables[0];
            cboLoaiPhieu.DisplayMember = "loaiphieu";
            cboLoaiPhieu.ValueMember = "maloai";
        }

        private void frmPhieuThu_Load(object sender, EventArgs e)
        {
            dateTuNgay.EditValue = DateTime.Now.Date;
            dateDenNgay.EditValue = DateTime.Now.Date;
            LoadLoaiPhieu();
            LoadPhieuThu();
        }

        private void gridView2_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            var i = gridView2.FocusedRowHandle;
            if (ReferenceEquals(e.Column, colXoa))
            {
                DialogResult dgr = XtraMessageBox.Show("Bạn có muốn mã phiếu nhập thu " + lblMaPhieu.Text + " này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dgr == DialogResult.Yes)
                {
                    Data.RunCMD("delete from tbl_phieuthuchi where maphieu='" + lblMaPhieu.Text + "'");
                    //Ghi lại log
                    Data.HistoryLog("Đã xóa phiếu thu " + lblMaPhieu.Text + ".", "Danh mục phiếu thu");
                    LoadPhieuThu();
                }
            }
        }
    }
}