using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace QuanLyNhaHang.KhoHang
{
    public partial class frmThemChuyenKho : XtraForm
    {
        public frmThemChuyenKho()
        {
            InitializeComponent();
        }
        #region DanhMuc

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
            cboTuKho.Properties.DataSource = ds.Tables[0];
            cboTuKho.Properties.DisplayMember = "tenkho";
            cboTuKho.Properties.ValueMember = "makho";
        }

        public void LoadKhoDen()
        {
            var ds = Data.LoadData($@"SELECT * from tbl_kho where makho not in ('{cboTuKho.EditValue}') order by tenkho");
            cboDenKho.Properties.DataSource = ds.Tables[0];
            cboDenKho.Properties.DisplayMember = "tenkho";
            cboDenKho.Properties.ValueMember = "makho";
        }
        #endregion

        public void LoadChiTietPhieuNhap()
        {
            var x = gridView2.FocusedRowHandle;
            var y = gridView2.TopRowIndex;
            var ds = Data.LoadData($@"SELECT * from view_chitiet_phieunhap where maphieu='{ txt_maphieu.Text }'");
            dgvPhieuChuyenKho.DataSource = ds.Tables[0];
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
                if (string.IsNullOrEmpty(cboTuKho.Text)) { e.Valid = false; e.ErrorText = "Bạn phải chọn kho cần chuyển để thực hiện."; }
                if (string.IsNullOrEmpty(cboDenKho.Text)) { e.Valid = false; e.ErrorText = "Bạn phải chọn kho cần chuyển đến thực hiện."; }
                if (string.IsNullOrEmpty(txt_maphieu.Text)) { e.Valid = false; e.ErrorText = "Bạn phải nhập vào mã phiếu nhập kho."; }
                ds = Data.LoadData("SELECT * from view_hanghoa where mahang='" + e.Value + "'");
                //view.SetRowCellValue(i, "soducuoiky", Convert.ToDouble(Data.Data._get_data("SELECT soducuoiky from view_tonkho_tucthoi where mathamchieu='" + e.Value + "'")));
                view.SetRowCellValue(i, "tenhang", ds.Tables[0].Rows[0]["tenhang"].ToString());
                view.SetRowCellValue(i, "tendvt", ds.Tables[0].Rows[0]["tendvt"].ToString());
                view.SetRowCellValue(i, "idmahang", ds.Tables[0].Rows[0]["id"].ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    float dongia = 0;
                    if (string.IsNullOrEmpty(Data.GetData($@"SELECT dongia from view_chitiet_phieunhap where idmahang='{e.Value}' ORDER BY ngaynhap DESC LIMIT 1 ")))
                    {
                        dongia = 0;
                    }
                    else
                    {
                        dongia = float.Parse(Data.GetData($@"SELECT dongia from view_chitiet_phieunhap where idmahang='{e.Value}' ORDER BY ngaynhap DESC LIMIT 1 "));
                    }
                    view.SetRowCellValue(i, "soluong", 0);
                    view.SetRowCellValue(i, "dongia", dongia);
                    view.SetRowCellValue(i, "thoigian", DateTime.Now);
                    view.SetRowCellValue(i, "nguoitd", Data._strtendangnhap.ToUpper());
                }
                else
                {
                    e.Valid = false;
                    e.ErrorText = "Mã hàng hóa nhập không tồn tại.";
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

        public frmChuyenKho frm1_copy;
        public delegate void PassDataB2A(string text);
        public void funObjectB(frmChuyenKho frm1)
        {
            this.frm1_copy = frm1;
        }

        private void btn_lammoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadChiTietPhieuNhap();
        }

        public void _xoatext()
        {
            txt_diengiai.Text = "";
            cboTuKho.EditValue = DBNull.Value;
            cboDenKho.EditValue = DBNull.Value;
            dateNgayChuyen.EditValue = DateTime.Now.Date;
            _create_id();
        }

        public void _create_id()
        {
            DataSet ds = new DataSet();
            string _str_thang, _str_nam, _str_ngay;
            _str_thang = Convert.ToDateTime(dateNgayChuyen.EditValue).ToString("MM");
            _str_nam = Convert.ToDateTime(dateNgayChuyen.EditValue).ToString("yy");
            _str_ngay = Convert.ToDateTime(dateNgayChuyen.EditValue).ToString("dd");

            ds = Data.LoadData("SELECT * FROM tbl_phieuxuat where strftime('%d', ngayxuat)='" + _str_ngay + "' and strftime('%m', ngayxuat)='" + _str_thang + "' and strftime('%Y', ngayxuat)='" + Convert.ToDateTime(dateNgayChuyen.EditValue).ToString("yyyy") + "' and chuyenkho=1");

            if (ds.Tables[0].Rows.Count == 0)
            {
                txt_maphieu.Text = "CK" + _str_nam + _str_thang + _str_ngay + "01";
            }
            else
            {
                string _kyhieu = "CK" + _str_nam + _str_thang + _str_ngay;
                txt_maphieu.Text = Data.GetData("SELECT '" + _kyhieu + "'||substr('00'||CAST(substr(max(maphieu),9,2)+1 as varchar),-2) from tbl_phieuxuat where substr(maphieu,1,8)='" + _kyhieu + "' and chuyenkho=1");
            }
        }

        private void btn_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _xoatext();
            if (Data._edit == true)
            {
                Data._edit = false;
                txt_maphieu.Properties.ReadOnly = false;
                dateNgayChuyen.Properties.ReadOnly = false;
                _create_id();
            }
        }

        private void txt_maphieu_TextChanged(object sender, EventArgs e)
        {
            LoadChiTietPhieuNhap();
        }

        private void btn_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var dgr = XtraMessageBox.Show("Bạn có muốn xóa phiếu nhập kho " + txt_maphieu.Text + " này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dgr == DialogResult.Yes)
            {
                Data.RunCMD("delete from tbl_chitiet_phieunhap where maphieu='" + txt_maphieu.Text + "'");
                Data.RunCMD("delete from tbl_phieunhap where maphieu='" + txt_maphieu.Text + "'");
                LoadChiTietPhieuNhap();
                //Gửi dữ liệu về form chính
                PassDataB2A datasend = new PassDataB2A(frm1_copy.funDataA);
                datasend(DateTime.Now.ToString());
            }
        }

        private void btn_luu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_maphieu.Text))
            {
                XtraMessageBox.Show("Bạn phải nhập vào mã phiếu để thực hiện.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Data.CheckID("select count(*) from tbl_phieuxuat where maphieu='" + txt_maphieu.Text + "'") == 0)
            {
                //Tạo phiếu xuất
                string sql = "insert into tbl_phieuxuat(maphieu, ngayxuat, makho, makhoden, nguoilap, diengiai, chuyenkho, nguoitd, thoigian) values (@maphieu, @ngayxuat, @makho, @makhoden, @nguoilap, @diengiai, @chuyenkho, @nguoitd, @thoigian)";

                SQLiteCommand sqlCom = new SQLiteCommand(sql, Data.strconnect);
                sqlCom.Parameters.AddWithValue("@maphieu", txt_maphieu.Text);
                sqlCom.Parameters.AddWithValue("@ngayxuat", Convert.ToDateTime(dateNgayChuyen.EditValue).ToString("yyyy-MM-dd"));
                sqlCom.Parameters.AddWithValue("@makho", cboTuKho.EditValue);
                sqlCom.Parameters.AddWithValue("@makhoden", cboDenKho.EditValue);
                sqlCom.Parameters.AddWithValue("@nguoilap", cboNhanVien.Text);

                sqlCom.Parameters.AddWithValue("@diengiai", txt_diengiai.Text);
                sqlCom.Parameters.AddWithValue("@chuyenkho", 1);
                sqlCom.Parameters.AddWithValue("@nguoitd", Data._strtendangnhap.ToUpper());
                sqlCom.Parameters.AddWithValue("@thoigian", DateTime.Now);
                Data.open_connect();
                sqlCom.ExecuteNonQuery();
                Data.close_connect();

                //Tạo phiếu nhập
                string sql1 = "insert into tbl_phieunhap(maphieu, ngaynhap, makho, nguoilap, diengiai, nguoitd, thoigian) values (@maphieu, @ngaynhap, @makho, @nguoilap, @diengiai, @nguoitd, @thoigian)";

                SQLiteCommand sqlCom1 = new SQLiteCommand(sql1, Data.strconnect);
                sqlCom1.Parameters.AddWithValue("@maphieu", txt_maphieu.Text);
                sqlCom1.Parameters.AddWithValue("@ngaynhap", Convert.ToDateTime(dateNgayChuyen.EditValue).ToString("yyyy-MM-dd"));
                sqlCom1.Parameters.AddWithValue("@makho", cboTuKho.EditValue);
                sqlCom1.Parameters.AddWithValue("@nguoilap", cboNhanVien.Text);

                sqlCom1.Parameters.AddWithValue("@diengiai", txt_diengiai.Text);
                sqlCom1.Parameters.AddWithValue("@nguoitd", Data._strtendangnhap.ToUpper());
                sqlCom1.Parameters.AddWithValue("@thoigian", DateTime.Now);
                Data.open_connect();
                sqlCom1.ExecuteNonQuery();
                Data.close_connect();
            }
            else
            {
                string sql = "update tbl_phieuxuat set ngayxuat=@ngayxuat, nguoilap=@nguoilap, diengiai=@diengiai, nguoitd2=@nguoitd2, thoigian2=@thoigian2 where maphieu=@maphieu";

                SQLiteCommand sqlCom = new SQLiteCommand(sql, Data.strconnect);
                sqlCom.Parameters.AddWithValue("@maphieu", txt_maphieu.Text);
                sqlCom.Parameters.AddWithValue("@ngayxuat", Convert.ToDateTime(dateNgayChuyen.EditValue).ToString("yyyy-MM-dd"));
                sqlCom.Parameters.AddWithValue("@nguoilap", cboNhanVien.Text);

                sqlCom.Parameters.AddWithValue("@diengiai", txt_diengiai.Text);
                sqlCom.Parameters.AddWithValue("@nguoitd2", Data._strtendangnhap.ToUpper());
                sqlCom.Parameters.AddWithValue("@thoigian2", DateTime.Now);
                Data.open_connect();
                sqlCom.ExecuteNonQuery();
                Data.close_connect();
            }

            LuuPhieuChuyenKho();

            LoadChiTietPhieuNhap();

            PassDataB2A datasend = new PassDataB2A(frm1_copy.funDataA);
            datasend(DateTime.Now.ToString());

            XtraMessageBox.Show("Đã cập nhật thành công phiếu nhập.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void LuuPhieuChuyenKho()
        {
            cboTuKho.Focus();
            if (gridView2.RowCount <= 0)
            {
                XtraMessageBox.Show("Vui lòng nhập vào các mặt hàng cần chuyển kho.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvPhieuChuyenKho.Focus();
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
                            if (Data.CheckID($@"select count(*) from tbl_chitiet_phieuxuat where maphieu='{ txt_maphieu.Text }' and idmahang='{ dr["idmahang"] }'") == 0)
                            {
                                //Chi tiết phiếu xuất
                                Data.RunCMD($@"insert into tbl_chitiet_phieuxuat(maphieu, idmahang, soluong, dongia, ghichu, nguoitd, thoigian) values ('{ txt_maphieu.Text }','{ dr["idmahang"] }','{ dr["soluong"] }','{ dr["dongia"] }','{ dr["ghichu"] }','{ Data._strtendangnhap.ToUpper() }','{ DateTime.Now.ToString() }')");
                                //Chi tiết phiếu nhập
                                Data.RunCMD($@"insert into tbl_chitiet_phieunhap(maphieu, idmahang, soluong, dongia, ghichu, nguoitd, thoigian) values ('{ txt_maphieu.Text }','{ dr["idmahang"] }','{ dr["soluong"] }','{ dr["dongia"] }','{ dr["ghichu"] }','{ Data._strtendangnhap.ToUpper() }','{ DateTime.Now.ToString() }')");
                            }
                            break;
                        case DataRowState.Modified:
                            //Chi tiết phiếu xuất
                            Data.RunCMD($@"update tbl_chitiet_phieuxuat set soluong='{ dr["soluong"] }', dongia='{ dr["dongia"] }', ghichu='{ dr["ghichu"] }', nguoitd2='{ Data._strtendangnhap.ToUpper() }', thoigian2='{ DateTime.Now.ToString() }' where maphieu='{ txt_maphieu.Text }' and idmahang='{ dr["idmahang"] }'");
                            //Chi tiết phiếu nhập
                            Data.RunCMD($@"update tbl_chitiet_phieunhap set soluong='{ dr["soluong"] }', dongia='{ dr["dongia"] }', ghichu='{ dr["ghichu"] }', nguoitd2='{ Data._strtendangnhap.ToUpper() }', thoigian2='{ DateTime.Now.ToString() } ' where maphieu='{ txt_maphieu.Text } ' and idmahang='{ dr["idmahang"] } '");
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
                    Data.RunCMD($@"delete from tbl_chitiet_phieunhap where maphieu='{ txt_maphieu.Text }' and idmahang='{ gridView2.GetRowCellValue(i, "idmahang") }'");
                    LoadChiTietPhieuNhap();
                }
            }
        }

        private void btn_in_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var ds = Data.LoadData($@"SELECT * from view_chitiet_phieunhap where maphieu='{ txt_maphieu.Text }'");
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
                string strLenh = "SELECT maphieu as [Mã phiếu], mancc as [Mã NCC], ncc as [Nhà cung cấp], ngaynhap as [Ngày nhập], nguoilap as [Người lập], mahang as [Mã hàng hóa], tenhang as [Tên hàng hóa], tendvt as [ĐVT], soluong as [Số lượng], dongia as [Đơn giá], thanhtien as [Thành tiền], ghichu as [Ghi chú] from view_chitiet_phieunhap where maphieu='" + txt_maphieu.Text + "'";
                var arr = mdl_ExportExcel.LoadSQL2ListArr(strLenh);
                mdl_ExportExcel.ExportListArr2Excel(arr, xtraSaveFileDialog1.FileName);
            }
        }

        private void frm_them_nhapkho_FormClosing(object sender, FormClosingEventArgs e)
        {
            Data._edit = false;
        }

        public void LoadNhanVien()
        {
            var ds = Data.LoadData("select * from tbl_nhanvien");
            cboNhanVien.Properties.DataSource = ds.Tables[0];
            cboNhanVien.Properties.DisplayMember = "tennv";
            cboNhanVien.Properties.ValueMember = "tennv";
        }

        private void frm_them_nhapkho_Load(object sender, EventArgs e)
        {
            dateNgayChuyen.EditValue = DateTime.Now.Date;
            LoadHangHoa();
            LoadKho();
            LoadNhanVien();
            if (Data._edit == false)
            {
                _create_id();
            }
            else
            {
                var ds = Data.LoadData("select * from tbl_phieuxuat where maphieu='" + Data._strmaphieu + "'");
                if (ds.Tables[0].Rows.Count <= 0) { return; }
                txt_maphieu.Text = Data._strmaphieu;
                txt_diengiai.Text = ds.Tables[0].Rows[0]["diengiai"].ToString();
                cboTuKho.EditValue = ds.Tables[0].Rows[0]["makho"];
                cboDenKho.EditValue = ds.Tables[0].Rows[0]["makhoden"];
                dateNgayChuyen.EditValue = ds.Tables[0].Rows[0]["ngayxuat"];
                cboNhanVien.EditValue = ds.Tables[0].Rows[0]["nguoilap"];
                txt_maphieu.Properties.ReadOnly = true;
                dateNgayChuyen.Properties.ReadOnly = true;
            }
        }



        private void label1A_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbo_ncc_Click(object sender, EventArgs e)
        {
            gridLookUpEdit1View.FocusedRowHandle = GridControl.AutoFilterRowHandle;
            gridLookUpEdit1View.FocusedColumn = gridLookUpEdit1View.Columns["ncc"];
            gridLookUpEdit1View.ShowEditor();
        }

        private void date_ngaynhap_TextChanged(object sender, EventArgs e)
        {
            if (Data._edit == false)
            {
                _create_id();
            }
        }

        private void cboTuKho_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboTuKho.Text)) { return; }
            LoadKhoDen();
        }
    }
}
