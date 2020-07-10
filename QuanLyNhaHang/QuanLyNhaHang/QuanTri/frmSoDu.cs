using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
namespace QuanLyNhaHang.QuanTri
{
    public partial class frmSoDu : DevExpress.XtraEditors.XtraForm
    {
        public frmSoDu()
        {
            InitializeComponent();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm == null || frm.IsDisposed)
                frm = new frmThemSoDu();
            frm.Show();

            PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm.funObjectB);
            sendIDObjectfrm1(this);
        }

        frmThemSoDu frm = new frmThemSoDu();
        public delegate void PassIDform1(frmSoDu frm1_copy);
        public void funDataA(string txtform2)
        {
            label1A.Text = txtform2;
        }

        private void label1A_TextChanged(object sender, EventArgs e)
        {
            LoadSoDuDauKy();
        }

        private void frmSoDu_Load(object sender, EventArgs e)
        {
            dateTuNgay.EditValue = DateTime.Now.Date;
            dateDenNgay.EditValue = DateTime.Now.Date;
            LoadKhoHang();
            LoadSoDuDauKy();
        }

        public void LoadKhoHang()
        {
            var ds = new DataSet();
            ds = Data.LoadData("select makho, tenkho from tbl_kho order by tenkho");
            cboKho.DataSource = ds.Tables[0];
            cboKho.DisplayMember = "tenkho";
            cboKho.ValueMember = "makho";
        }

        int i = 1;
        public void LoadSoDuDauKy()
        {
            var ds = new DataSet();
            var x = gridView1.FocusedRowHandle;
            var y = gridView1.TopRowIndex;
            if (i == 1)
            {
                ds = Data.LoadData($@"select * from view_sodudauky where strftime('%m', ngaynhap)='{DateTime.Now.ToString("MM")}' and strftime('%Y', ngaynhap)='{DateTime.Now.ToString("yyyy")}'");
            }
            else if (i == 2)
            {
                ds = Data.LoadData($@"select * from view_sodudauky where ngaynhap>='{Convert.ToDateTime(dateTuNgay.EditValue).ToString("yyyy-MM-dd")}' and ngaynhap<='{Convert.ToDateTime(dateDenNgay.EditValue).ToString("yyyy-MM-dd")}'");
            }
            dgvTonKhoBanDau.DataSource = ds.Tables[0];
            gridView1.FocusedRowHandle = x;
            gridView1.TopRowIndex = y;
        }

        private void btnTim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            i = 2;
            LoadSoDuDauKy();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            var dgr = XtraMessageBox.Show($@"Bạn có muốn xóa số dư của mã hàng {gridView1.GetRowCellValue(i, "tenhang")} này không.", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                Data.RunCMD($@"delete from tbl_sodudauky where id='{gridView1.GetRowCellValue(i, "id")}'");
                LoadSoDuDauKy();
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            label1A.Focus();
            var dgr = XtraMessageBox.Show("Bạn có muốn cập nhật số dư của các mặt hàng không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                LuuSoDu();
            }
        }

        private void LuuSoDu()
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
                    string sql = "update tbl_sodudauky set ngaynhap=@ngaynhap, makho=@makho, sodu=@sodu, tiendau=@tiendau, ghichu=@ghichu, nguoitd2=@nguoitd2, thoigian2=@thoigian2 where id=@id";
                    SQLiteCommand sqlCom = new SQLiteCommand(sql, Data.strconnect);
                    sqlCom.Parameters.AddWithValue("@id", dr["id"]);
                    sqlCom.Parameters.AddWithValue("@ngaynhap", Convert.ToDateTime(dr["ngaynhap"]).ToString("yyyy-MM-01"));
                    sqlCom.Parameters.AddWithValue("@makho", dr["makho"]);
                    sqlCom.Parameters.AddWithValue("@sodu", Convert.ToDouble(dr["sodu"]));
                    sqlCom.Parameters.AddWithValue("@tiendau", Convert.ToDouble(dr["tiendau"]));
                    sqlCom.Parameters.AddWithValue("@ghichu", dr["ghichu"]);
                    sqlCom.Parameters.AddWithValue("@nguoitd2", Data._strtendangnhap.ToUpper());
                    sqlCom.Parameters.AddWithValue("@thoigian2", DateTime.Now);
                    Data.open_connect();
                    sqlCom.ExecuteNonQuery();
                    Data.close_connect();
                    //Ghi lại log
                    Data.HistoryLog("Đã cập nhật lại số dư của mặt hàng " + dr["tenhang"] + ".", "Danh mục số dư đầu kỳ");
                }
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            var i = gridView1.FocusedRowHandle;
            if (ReferenceEquals(e.Column, colXoa))
            {
                var dgr = XtraMessageBox.Show($@"Bạn có muốn xóa số dư của mã hàng {gridView1.GetRowCellValue(i, "tenhang")} này không.", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dgr == DialogResult.Yes)
                {
                    Data.RunCMD($@"delete from tbl_sodudauky where id='{gridView1.GetRowCellValue(i, "id")}'");
                    LoadSoDuDauKy();
                }
            }
        }
    }
}
