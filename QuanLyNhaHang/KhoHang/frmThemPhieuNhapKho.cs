using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace QuanLyNhaHang.KhoHang
{
    public partial class frmThemPhieuNhapKho : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmThemPhieuNhapKho()
        {
            InitializeComponent();
        }
        #region DanhMuc
        public void LoadNhaCungCap()
        {
            var ds = Data.LoadData("SELECT mancc, ncc from tbl_ncc ORDER BY ncc");
            cboNCC.Properties.DataSource = ds.Tables[0];
            cboNCC.Properties.DisplayMember = "ncc";
            cboNCC.Properties.ValueMember = "mancc";
            cboNCC.EditValue = Data._str_mancc;
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

        public void LoadChiTietPhieuNhap()
        {
            var x = gridView2.FocusedRowHandle;
            var y = gridView2.TopRowIndex;
            var ds = Data.LoadData($@"SELECT * from view_chitiet_phieunhap where maphieu='{ txt_maphieu.Text }'");
            dgv_phieunhapkho.DataSource = ds.Tables[0];
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
                if (string.IsNullOrEmpty(cboNCC.Text)) { e.Valid = false; e.ErrorText = "Bạn phải chọn nhà cung cấp để thực hiện."; }
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

        public frmPhieuNhapKho frm1_copy;
        public delegate void PassDataB2A(string text);
        public void funObjectB(frmPhieuNhapKho frm1)
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
            cboNCC.EditValue = DBNull.Value;
            date_ngaynhap.EditValue = DateTime.Now.Date;
            _create_id();
        }

        public void _create_id()
        {
            DataSet ds = new DataSet();
            string _str_thang, _str_nam, _str_ngay;
            _str_thang = Convert.ToDateTime(date_ngaynhap.EditValue).ToString("MM");
            _str_nam = Convert.ToDateTime(date_ngaynhap.EditValue).ToString("yy");
            _str_ngay = Convert.ToDateTime(date_ngaynhap.EditValue).ToString("dd");

            ds = Data.LoadData("SELECT * FROM tbl_phieunhap where strftime('%d', ngaynhap)='" + _str_ngay + "' and strftime('%m', ngaynhap)='" + _str_thang + "' and strftime('%Y', ngaynhap)='" + Convert.ToDateTime(date_ngaynhap.EditValue).ToString("yyyy") + "'");

            if (ds.Tables[0].Rows.Count == 0)
            {
                txt_maphieu.Text = "PN" + _str_nam + _str_thang + _str_ngay + "01";
            }
            else
            {
                string _kyhieu = "PN" + _str_nam + _str_thang + _str_ngay;
                txt_maphieu.Text = Data.GetData("SELECT '" + _kyhieu + "'||substr('00'||CAST(substr(max(maphieu),9,2)+1 as varchar),-2) from tbl_phieunhap where substr(maphieu,1,8)='" + _kyhieu + "'");
            }
        }

        private void btn_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _xoatext();
            if (Data._edit == true)
            {
                Data._edit = false;
                txt_maphieu.Properties.ReadOnly = false;
                date_ngaynhap.Properties.ReadOnly = false;
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
                txt_maphieu.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cboNCC.Text))
            {
                XtraMessageBox.Show("Bạn phải chọn nhà cung cấp để nhập kho.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNCC.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cboKho.Text))
            {
                XtraMessageBox.Show("Bạn phải chọn kho để thực hiện.", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKho.Focus();
                return;
            }
            var _nguoilap = Data.GetData("select tennv from view_nguoidung where tendangnhap='" + Data._strtendangnhap.ToUpper() + "'");
            if (Data.CheckID("select count(*) from tbl_phieunhap where maphieu='" + txt_maphieu.Text + "'") == 0)
            {
                string sql = "insert into tbl_phieunhap(maphieu, ngaynhap, makho, nguoilap, mancc, diengiai, nguoitd, thoigian) values (@maphieu, @ngaynhap, @makho, @nguoilap, @mancc, @diengiai, @nguoitd, @thoigian)";

                SQLiteCommand sqlCom = new SQLiteCommand(sql, Data.strconnect);
                sqlCom.Parameters.AddWithValue("@maphieu", txt_maphieu.Text);
                sqlCom.Parameters.AddWithValue("@ngaynhap", Convert.ToDateTime(date_ngaynhap.EditValue).ToString("yyyy-MM-dd"));
                sqlCom.Parameters.AddWithValue("@makho", cboKho.EditValue);
                sqlCom.Parameters.AddWithValue("@nguoilap", _nguoilap);
                sqlCom.Parameters.AddWithValue("@mancc", cboNCC.EditValue);
                sqlCom.Parameters.AddWithValue("@diengiai", txt_diengiai.Text);
                sqlCom.Parameters.AddWithValue("@nguoitd", Data._strtendangnhap.ToUpper());
                sqlCom.Parameters.AddWithValue("@thoigian", DateTime.Now);
                Data.open_connect();
                sqlCom.ExecuteNonQuery();
                Data.close_connect();
            }
            else
            {
                string sql = "update tbl_phieunhap set mancc=@mancc, ngaynhap=@ngaynhap, makho=@makho, nguoilap=@nguoilap, diengiai=@diengiai, nguoitd2=@nguoitd2, thoigian2=@thoigian2 where maphieu=@maphieu";

                SQLiteCommand sqlCom = new SQLiteCommand(sql, Data.strconnect);
                sqlCom.Parameters.AddWithValue("@maphieu", txt_maphieu.Text);
                sqlCom.Parameters.AddWithValue("@ngaynhap", Convert.ToDateTime(date_ngaynhap.EditValue).ToString("yyyy-MM-dd"));
                sqlCom.Parameters.AddWithValue("@makho", cboKho.EditValue);
                sqlCom.Parameters.AddWithValue("@nguoilap", _nguoilap);
                sqlCom.Parameters.AddWithValue("@mancc", cboNCC.EditValue);
                sqlCom.Parameters.AddWithValue("@diengiai", txt_diengiai.Text);
                sqlCom.Parameters.AddWithValue("@nguoitd2", Data._strtendangnhap.ToUpper());
                sqlCom.Parameters.AddWithValue("@thoigian2", DateTime.Now);
                Data.open_connect();
                sqlCom.ExecuteNonQuery();
                Data.close_connect();
            }

            LuuPhieuNhapKho();

            LoadChiTietPhieuNhap();

            PassDataB2A datasend = new PassDataB2A(frm1_copy.funDataA);
            datasend(DateTime.Now.ToString());

            XtraMessageBox.Show("Đã cập nhật thành công phiếu nhập.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void LuuPhieuNhapKho()
        {
            cboNCC.Focus();
            if (gridView2.RowCount <= 0)
            {
                XtraMessageBox.Show("Vui lòng nhập vào vật tư nhập kho", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgv_phieunhapkho.Focus();
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
                            if (Data.CheckID("select count(*) from tbl_chitiet_phieunhap where maphieu='" + txt_maphieu.Text + "' and idmahang='" + dr["idmahang"] + "'") == 0)
                            {
                                Data.RunCMD("insert into tbl_chitiet_phieunhap(maphieu, idmahang, soluong, dongia, ghichu, nguoitd, thoigian) values ('" + txt_maphieu.Text + "','" + dr["idmahang"] + "','" + dr["soluong"] + "','" + dr["dongia"] + "','" + dr["ghichu"] + "','" + Data._strtendangnhap.ToUpper() + "','" + DateTime.Now.ToString() + "')");
                            }
                            break;
                        case DataRowState.Modified:
                            Data.RunCMD("update tbl_chitiet_phieunhap set soluong='" + dr["soluong"] + "', dongia='" + dr["dongia"] + "', ghichu='" + dr["ghichu"] + "', nguoitd2='" + Data._strtendangnhap.ToUpper() + "', thoigian2='" + DateTime.Now.ToString() + "' where maphieu='" + txt_maphieu.Text + "' and idmahang='" + dr["idmahang"] + "'");
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
                var dgr = XtraMessageBox.Show("Bạn có muốn xóa mã hàng " + gridView2.GetRowCellValue(i, "mahanghoa") + " này không?", "Xác Nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dgr == DialogResult.Yes)
                {
                    Data.RunCMD("delete from tbl_chitiet_phieunhap where maphieu='" + txt_maphieu.Text + "' and idmahang='" + gridView2.GetRowCellValue(i, "idmahang") + "'");
                    LoadChiTietPhieuNhap();
                }
            }
        }

        private void btn_in_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var ds = Data.LoadData("SELECT * from view_chitiet_phieunhap where maphieu='" + txt_maphieu.Text + "'");
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


        private void frm_them_nhapkho_Load(object sender, EventArgs e)
        {
            date_ngaynhap.EditValue = DateTime.Now.Date;
            LoadNhaCungCap();
            LoadHangHoa();
            LoadKho();
            if (Data._edit == false)
            {
                _create_id();
            }
            else
            {
                var ds = Data.LoadData("select * from tbl_phieunhap where maphieu='" + Data._strmaphieu + "'");
                if (ds.Tables[0].Rows.Count <= 0) { return; }
                txt_maphieu.Text = Data._strmaphieu;
                txt_diengiai.Text = ds.Tables[0].Rows[0]["diengiai"].ToString();
                cboKho.EditValue = ds.Tables[0].Rows[0]["makho"];
                cboNCC.EditValue = ds.Tables[0].Rows[0]["mancc"];
                date_ngaynhap.EditValue = ds.Tables[0].Rows[0]["ngaynhap"];

                cboNCC.Focus();
                txt_maphieu.Properties.ReadOnly = true;
                date_ngaynhap.Properties.ReadOnly = true;
            }
        }

        private void cbo_ncc_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                Data._int_flag = 2;
                if (frm2 == null || frm2.IsDisposed)
                    frm2 = new frmThemNCC();
                frm2.Show();

                PassIDform1 sendIDObjectfrm1 = new PassIDform1(frm2.funObjectB_NhapKho);
                sendIDObjectfrm1(this);
            }
        }

        frmThemNCC frm2 = new frmThemNCC();
        public delegate void PassIDform1(frmThemPhieuNhapKho frm1_copy);

        public void funDataA_NhapKho(string txtform2)
        {
            label1A.Text = txtform2;
        }

        private void label1A_TextChanged(object sender, EventArgs e)
        {
            LoadNhaCungCap();
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

    }
}
