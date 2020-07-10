using System;

namespace QuanLyNhaHang
{
    public partial class frmReport : DevExpress.XtraEditors.XtraForm
    {
        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            if (Data._report == 1)
            {
                //this.Text = "Danh Mục Hàng Hóa";
                //rpt_hanghoa rpt = new rpt_hanghoa();
                //documentViewer1.PrintingSystem = rpt.PrintingSystem;
                //rpt.DataSource = Data.Data._dtreport;
                //rpt.BindData();
                //rpt.CreateDocument();
            }
        }
    }
}
