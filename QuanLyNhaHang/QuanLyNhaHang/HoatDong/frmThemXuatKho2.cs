using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace QuanLyNhaHang.HoatDong
{
    public partial class frmThemXuatKho2 : DevExpress.XtraEditors.XtraForm
    {
        public frmThemXuatKho2()
        {
            InitializeComponent();
        }

        #region DanhMuc"
        public void LoadKhachHang()
        {
            var ds = Data.LoadData("SELECT makh, tenkh from tbl_khachhang ORDER BY tenkh");
            cboKhachHang.Properties.DataSource = ds.Tables[0];
            cboKhachHang.Properties.DisplayMember = "tenkh";
            cboKhachHang.Properties.ValueMember = "makh";
            cboKhachHang.EditValue = Data._str_makh;
        }

        public void LoadHangHoa()
        {
            var ds = Data.LoadData("SELECT * from view_hanghoa where sudung='1' order by tenhang");
            cbo_hanghoa.DataSource = ds.Tables[0];
            cbo_hanghoa.DisplayMember = "mahang";
            cbo_hanghoa.ValueMember = "mahang";
        }

        public void LoadKho()
        {
            var ds = Data.LoadData("SELECT * from tbl_kho order by tenkho");
            cboKho.Properties.DataSource = ds.Tables[0];
            cboKho.Properties.DisplayMember = "tenkho";
            cboKho.Properties.ValueMember = "makho";
        }

        #endregion
        public void LoadChiTietPhieuXuat()
        {
            var x = gridView2.FocusedRowHandle;
            var y = gridView2.TopRowIndex;
            var ds = Data.LoadData($@"SELECT * from view_chitiet_phieuxuat where maphieu='{ txtMaPhieu.Text }'");
            dgvPhieuXuatKho.DataSource = ds.Tables[0];
            gridView2.FocusedRowHandle = x;
            gridView2.TopRowIndex = y;
        }

        private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            int i = view.FocusedRowHandle;
            DataSet ds = new DataSet();
            if (view.FocusedColumn.FieldName == "mahang")
            {
                if (string.IsNullOrEmpty(cboKhachHang.Text)) { e.Valid = false; e.ErrorText = "Bạn phải chọn khách hàng để thực hiện."; }
                if (string.IsNullOrEmpty(txtMaPhieu.Text)) { e.Valid = false; e.ErrorText = "Bạn phải nhập vào mã phiếu xuất kho."; }
                ds = Data.LoadData("SELECT * from view_hanghoa where mahang='" + e.Value + "'");
                //view.SetRowCellValue(i, "soducuoiky", Convert.ToDouble(Data.Data._get_data("SELECT soducuoiky from view_tonkho_tucthoi where mathamchieu='" + e.Value + "'")));
                view.SetRowCellValue(i, "tenhang", ds.Tables[0].Rows[0]["tenhang"].ToString());
                view.SetRowCellValue(i, "tendvt", ds.Tables[0].Rows[0]["tendvt"].ToString());
                view.SetRowCellValue(i, "idmahang", ds.Tables[0].Rows[0]["id"].ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    float dongia = 0;
                    if (string.IsNullOrEmpty(Data.GetData($@"SELECT dongia from view_chitiet_phieuxuat where idmahang='{e.Value}' ORDER BY ngayxuat DESC LIMIT 1 ")))
                    {
                        dongia = 0;
                    }
                    else
                    {
                        dongia = float.Parse(Data.GetData($@"SELECT dongia from view_chitiet_phieuxuat where idmahang='{e.Value}' ORDER BY ngayxuat DESC LIMIT 1 "));
                    }
                    view.SetRowCellValue(i, "soluong", 0);
                    view.SetRowCellValue(i, "dongia", dongia);
                    view.SetRowCellValue(i, "thoigian", DateTime.Now);
                    view.SetRowCellValue(i, "nguoitd", Data._strtendangnhap.ToUpper());
                }
                else
                {
                    e.Valid = false;
                    e.ErrorText = "Mã hàng hóa xuất không tồn tại.";
                }
            }
            else if (view.FocusedColumn.FieldName == "soluong")
            {
                if (Data.IsNumber(e.Value.ToString()) == false)
                {
                    e.Valid = false;
                    e.ErrorText = "Dữ liệu bạn nhập vào không đúng.";
                }
                else
                {
                    view.SetRowCellValue(i, "thanhtien", Convert.ToDouble(e.Value) * Convert.ToDouble(view.GetRowCellValue(i, "dongia")));
                }
            }
            else if (view.FocusedColumn.FieldName == "dongia")
            {
                if (Data.IsNumber(e.Value.ToString()) == false)
                {
                    e.Valid = false;
                    e.ErrorText = "Dữ liệu bạn nhập vào không đúng.";
                }
                else
                {
                    view.SetRowCellValue(i, "thanhtien", Convert.ToDouble(e.Value) * Convert.ToDouble(view.GetRowCellValue(i, "soluong")));
                }
            }
        }

        public frmPhieuXuatKho frm1_copy;
        public delegate void PassDataB2A(string text);
        public void funObjectB(frmPhieuXuatKho frm1)
        {
            this.frm1_copy = frm1;
        }

        private void btn_lammoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadChiTietPhieuXuat();
        }

        public void _xoatext()
        {
            txt_diengiai.Text = "";
            cboKhachHang.EditValue = DBNull.Value;
            dateNgayXuat.EditValue = DateTime.Now.Date;
            TaoMaPhieuXuat();
        }

        public void TaoMaPhieuXuat()
        {
            DataSet ds = new DataSet();
            string _str_thang, _str_nam, _str_ngay;
            _str_thang = Convert.ToDateTime(dateNgayXuat.EditValue).ToString("MM");
            _str_nam = Convert.ToDateTime(dateNgayXuat.EditValue).ToString("yy");
            _str_ngay = Convert.ToDateTime(dateNgayXuat.EditValue).ToString("dd");

            ds = Data.LoadData("SELECT * FROM tbl_phieuxuat where strftime('%d', ngayxuat)='" + _str_ngay + "' and strftime('%m', ngayxuat)='" + _str_thang + "' and strftime('%Y', ngayxuat)='" + Convert.ToDateTime(dateNgayXuat.EditValue).ToString("yyyy") + "'");

            if (ds.Tables[0].Rows.Count == 0)
            {
                txtMaPhieu.Text = "PN" + _str_nam + _str_thang + _str_ngay + "01";
            }
            else
            {
                string _kyhieu = "PN" + _str_nam + _str_thang + _str_ngay;
                txtMaPhieu.Text = Data.GetData("SELECT '" + _kyhieu + "'||substr('00'||CAST(substr(max(maphieu),9,2)+1 as varchar),-2) from tbl_phieuxuat where substr(maphieu,1,8)='" + _kyhieu + "'");
            }
        }

        private void btn_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _xoatext();
            if (Data._edit == true)
            {
                Data._edit = false;
                txtMaPhieu.Properties.ReadOnly = false;
                dateNgayXuat.Properties.ReadOnly = false;
                TaoMaPhieuXuat();
            }
        }

        private void txt_maphieu_TextChanged(object sender, EventArgs e)
        {
            LoadChiTietPhieuXuat();
        }

        private void btn_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dgr = XtraMessageBox.Show("Bạn có muốn xóa phiếu xuất kho " + txtMaPhieu.Text + " này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                Data.RunCMD("delete from tbl_chitiet_phieuxuat where maphieu='" + txtMaPhieu.Text + "'");
                Data.RunCMD("delete from tbl_phieuxuat where maphieu='" + txtMaPhieu.Text + "'");
                LoadChiTietPhieuXuat();
                //Gửi dữ liệu về form chính
                PassDataB2A datasend = new PassDataB2A(frm1_copy.funDataA);
                datasend(DateTime.Now.ToString());
            }
        }

        private void btn_luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaPhieu.Text))
            {
                XtraMessageBox.Show("Bạn phải nhập vào mã phiếu để thực hiện.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaPhieu.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cboKhachHang.Text))
            {
                XtraMessageBox.Show("Bạn phải chọn khách hàng để xuất kho.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKhachHang.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cboKho.Text))
            {
                XtraMessageBox.Show("Bạn phải chọn kho để thực hiện.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKho.Focus();
                return;
            }
            var _nguoilap = Data.GetData("select tennv from view_nguoidung where tendangnhap='" + Data._strtendangnhap.ToUpper() + "'");
            if (Data.CheckID($@"select count(*) from tbl_phieuxuat where maphieu='{txtMaPhieu.Text }'") == 0)
            {
                string sql = "insert into tbl_phieuxuat(maphieu, makho, ngayxuat, nguoilap, makh, diengiai, nguoitd, thoigian) values (@maphieu, @makho, @ngayxuat, @nguoilap, @makh, @diengiai, @nguoitd, @thoigian)";

                SQLiteCommand sqlCom = new SQLiteCommand(sql, Data.strconnect);
                sqlCom.Parameters.AddWithValue("@maphieu", txtMaPhieu.Text);
                sqlCom.Parameters.AddWithValue("@ngayxuat", Convert.ToDateTime(dateNgayXuat.EditValue).ToString("yyyy-MM-dd"));
                sqlCom.Parameters.AddWithValue("@makho", cboKho.EditValue);
                sqlCom.Parameters.AddWithValue("@nguoilap", _nguoilap);
                sqlCom.Parameters.AddWithValue("@makh", cboKhachHang.EditValue);
                sqlCom.Parameters.AddWithValue("@diengiai", txt_diengiai.Text);
                sqlCom.Parameters.AddWithValue("@nguoitd", Data._strtendangnhap.ToUpper());
                sqlCom.Parameters.AddWithValue("@thoigian", DateTime.Now);
                Data.open_connect();
                sqlCom.ExecuteNonQuery();
                Data.close_connect();
            }
            else
            {
                string sql = "update tbl_phieuxuat set makh=@makh, ngayxuat=@ngayxuat, makho=@makho, nguoilap=@nguoilap, diengiai=@diengiai, nguoitd2=@nguoitd2, thoigian2=@thoigian2 where maphieu=@maphieu";

                SQLiteCommand sqlCom = new SQLiteCommand(sql, Data.strconnect);
                sqlCom.Parameters.AddWithValue("@maphieu", txtMaPhieu.Text);
                sqlCom.Parameters.AddWithValue("@ngayxuat", Convert.ToDateTime(dateNgayXuat.EditValue).ToString("yyyy-MM-dd"));
                sqlCom.Parameters.AddWithValue("@makho", cboKho.EditValue);
                sqlCom.Parameters.AddWithValue("@nguoilap", _nguoilap);
                sqlCom.Parameters.AddWithValue("@makh", cboKhachHang.EditValue);
                sqlCom.Parameters.AddWithValue("@diengiai", txt_diengiai.Text);
                sqlCom.Parameters.AddWithValue("@nguoitd2", Data._strtendangnhap.ToUpper());
                sqlCom.Parameters.AddWithValue("@thoigian2", DateTime.Now);
                Data.open_connect();
                sqlCom.ExecuteNonQuery();
                Data.close_connect();
            }

            LuuPhieuXuatKho();

            LoadChiTietPhieuXuat();

            PassDataB2A datasend = new PassDataB2A(frm1_copy.funDataA);
            datasend(DateTime.Now.ToString());

            XtraMessageBox.Show("Đã cập nhật thành công phiếu xuất.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void LuuPhieuXuatKho()
        {
            cboKhachHang.Focus();
            if (gridView2.RowCount <= 0)
            {
                XtraMessageBox.Show("Vui lòng nhập vào vật tư nhập kho", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvPhieuXuatKho.Focus();
            }
            else
            {
                for (var i = 0; i <= gridView2.RowCount; i++)
                {
                    var dr = gridView2.GetDataRow(Convert.ToInt32(i));

                    if (ReferenceEquals(dr, null))
                    {
                        break;
                    }
                    switch (dr.RowState)
                    {
                        case DataRowState.Added:
                            if (Data.CheckID($@"select count(*) from tbl_chitiet_phieuxuat where maphieu='{ txtMaPhieu.Text }' and idmahang='{ dr["idmahang"] }'") == 0)
                            {
                                string sql = "insert into tbl_chitiet_phieuxuat(maphieu, idmahang, soluong, dongia, ghichu, nguoitd, thoigian) values (@maphieu, @idmahang, @soluong, @dongia, @ghichu, @nguoitd, @thoigian)";

                                SQLiteCommand sqlCom = new SQLiteCommand(sql, Data.strconnect);
                                sqlCom.Parameters.AddWithValue("@maphieu", txtMaPhieu.Text);
                                sqlCom.Parameters.AddWithValue("@idmahang", dr["idmahang"]);
                                sqlCom.Parameters.AddWithValue("@soluong", Convert.ToDouble(dr["soluong"]));
                                sqlCom.Parameters.AddWithValue("@dongia", Convert.ToDouble(dr["dongia"]));
                                sqlCom.Parameters.AddWithValue("@ghichu", dr["ghichu"]);
                                sqlCom.Parameters.AddWithValue("@nguoitd", Data._strtendangnhap.ToUpper());
                                sqlCom.Parameters.AddWithValue("@thoigian", DateTime.Now);
                                Data.open_connect();
                                sqlCom.ExecuteNonQuery();
                                Data.close_connect();
                            }
                            break;
                        case DataRowState.Modified:
                            string sql1 = "update tbl_chitiet_phieuxuat set soluong=@soluong, dongia=@dongia, ghichu=@ghichu, nguoitd2=@nguoitd2, thoigian2=@thoigian2 where maphieu=@maphieu and idmahang=@idmahang";

                            SQLiteCommand sqlCom1 = new SQLiteCommand(sql1, Data.strconnect);
                            sqlCom1.Parameters.AddWithValue("@maphieu", txtMaPhieu.Text);
                            sqlCom1.Parameters.AddWithValue("@idmahang", dr["idmahang"]);
                            sqlCom1.Parameters.AddWithValue("@soluong", Convert.ToDouble(dr["soluong"]));
                            sqlCom1.Parameters.AddWithValue("@dongia", Convert.ToDouble(dr["dongia"]));
                            sqlCom1.Parameters.AddWithValue("@ghichu", dr["ghichu"]);
                            sqlCom1.Parameters.AddWithValue("@nguoitd2", Data._strtendangnhap.ToUpper());
                            sqlCom1.Parameters.AddWithValue("@thoigian2", DateTime.Now);
                            Data.open_connect();
                            sqlCom1.ExecuteNonQuery();
                            Data.close_connect();
                            break;
                    }
                }
            }
        }

        private void gridView2_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            var i = gridView2.FocusedRowHandle;
            if (ReferenceEquals(e.Column, col_xoa))
            {
                var dgr = XtraMessageBox.Show("Bạn có muốn xóa mã hàng " + gridView2.GetRowCellValue(i, "tenhang") + " này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dgr == DialogResult.Yes)
                {
                    Data.RunCMD($@"delete from tbl_chitiet_phieuxuat where maphieu='{ txtMaPhieu.Text }' and idmahang='{ gridView2.GetRowCellValue(i, "idmahang") }'");
                    LoadChiTietPhieuXuat();
                }
            }
        }

        private void btn_in_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var ds = Data.LoadData("SELECT * from view_chitiet_phieunhap where maphieu='" + txtMaPhieu.Text + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                Data._dtreport = ds.Tables[0];
                Data._report = 2;
                frmReport frm = new frmReport();
                frm.Show();
            }
            else
            {
                XtraMessageBox.Show("Không tồn tại dữ liệu.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_excel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            xtraSaveFileDialog1.Filter = "Excel files |*.xlsx";
            xtraSaveFileDialog1.FileName = "PhieuNhapKho_" + DateTime.Now.ToString("dd-MM-yyyy hh-mm-ss"); ;
            if (xtraSaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string strLenh = "SELECT maphieu as [Mã phiếu], mancc as [Mã NCC], ncc as [Nhà cung cấp], ngaynhap as [Ngày nhập], nguoilap as [Người lập], mahang as [Mã hàng hóa], tenhang as [Tên hàng hóa], tendvt as [ĐVT], soluong as [Số lượng], dongia as [Đơn giá], thanhtien as [Thành tiền], ghichu as [Ghi chú] from view_chitiet_phieunhap where maphieu='" + txtMaPhieu.Text + "'";
                var arr = mdl_ExportExcel.LoadSQL2ListArr(strLenh);
                mdl_ExportExcel.ExportListArr2Excel(arr, xtraSaveFileDialog1.FileName);
            }
        }

        private void frm_them_nhapkho_FormClosing(object sender, FormClosingEventArgs e)
        {
            Data._edit = false;
        }

        private void cbo_ncc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                Data._int_flag = 2;
                if (frm2 == null || frm2.IsDisposed)
                    frm2 = new frmThemKhachHang();
                frm2.Show();

                PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm2.funObjectB_XK);
                sendIDObjectfrm1(this);
            }
        }

        frmThemKhachHang frm2 = new frmThemKhachHang();
        public delegate void PassIDform1(frmThemXuatKho2 frm1_copy);

        public void funDataA_XuatKho(string txtform2)
        {
            label1A.Text = txtform2;
        }

        private void label1A_TextChanged(object sender, EventArgs e)
        {
            LoadKhachHang();
        }

        private void cbo_ncc_Click(object sender, EventArgs e)
        {
            gridLookUpEdit1View.FocusedRowHandle = GridControl.AutoFilterRowHandle;
            gridLookUpEdit1View.FocusedColumn = gridLookUpEdit1View.Columns["tenkh"];
            gridLookUpEdit1View.ShowEditor();
        }

        private void date_ngaynhap_TextChanged(object sender, EventArgs e)
        {
            if (Data._edit == false)
            {
                TaoMaPhieuXuat();
            }
        }

        private void frmThemPhieuXuatKho_Load(object sender, EventArgs e)
        {
            dateNgayXuat.EditValue = DateTime.Now.Date;
            LoadKhachHang();
            LoadHangHoa();
            LoadKho();
            if (Data._edit == false)
            {
                TaoMaPhieuXuat();
            }
            else
            {
                var ds = Data.LoadData("select * from tbl_phieuxuat where maphieu='" + Data._strmaphieu + "'");
                if (ds.Tables[0].Rows.Count <= 0) { return; }
                txtMaPhieu.Text = Data._strmaphieu;
                txt_diengiai.Text = ds.Tables[0].Rows[0]["diengiai"].ToString();
                cboKho.EditValue = ds.Tables[0].Rows[0]["makho"];
                cboKhachHang.EditValue = ds.Tables[0].Rows[0]["makh"];
                dateNgayXuat.EditValue = ds.Tables[0].Rows[0]["ngayxuat"];

                cboKhachHang.Focus();
                txtMaPhieu.Properties.ReadOnly = true;
            }
        }
    }
}
