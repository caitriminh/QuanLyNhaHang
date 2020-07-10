using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    sealed class Data
    {
        public static string _strtendangnhap = "ADMIN", _strmaphieu, _str_mancc, _str_id, _str_makh, _str_tungay, _str_dennngay, _strMaBan, _strMaHD, _str_NhanVien;
        public static bool _bol_start, _edit;
        public static int _report, _int_flag;
        public static DataSet _dsreport, _ds_phutung;
        public static DataTable _dtreport;
        public static string BASE_URL_ICON = Application.StartupPath + @"\img\khuvuc\";
        public static SQLiteConnection strconnect = new SQLiteConnection();
        internal static object mdl_ExportExcel;

        public static void open_connect()
        {
            try
            {
                strconnect.ConnectionString = "Data Source=quanlynhahang.db;Version=3;";
                strconnect.Open();
            }
            catch (Exception)
            {

            }
        }

        public static void close_connect()
        {
            strconnect.Close();
        }

        public static DataSet LoadData(string strcmd)
        {
            DataSet ds = new DataSet();
            open_connect();
            SQLiteDataAdapter cmd = new SQLiteDataAdapter(strcmd, strconnect);
            cmd.Fill(ds);
            close_connect();
            return ds;
        }

        public static int CheckID(string strcmd)
        {
            int _intcheck = 0;
            open_connect();
            SQLiteCommand cmd = new SQLiteCommand(strcmd, strconnect);
            _intcheck = Convert.ToInt32(cmd.ExecuteScalar());
            close_connect();
            return _intcheck;
        }

        public static string GetData(string strcmd)
        {

            open_connect();
            SQLiteCommand cmd = new SQLiteCommand(strcmd, strconnect);
            var result = cmd.ExecuteScalar();
            if (result != null)
            {
                return result.ToString();
            }
            close_connect();
            return null;
        }
        public static void RunCMD(string strcmd)
        {
            open_connect();
            SQLiteCommand cmd = new SQLiteCommand(strcmd, strconnect);
            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();
            close_connect();
        }

        public static void HistoryLog(string _str_thaotac, string _str_form)
        {
            string _str_hedieuhanh = Environment.OSVersion.ToString();
            string _str_tenmay = Dns.GetHostName();
            open_connect();
            SQLiteCommand cmd = new SQLiteCommand("insert into tbl_nhatky_hoatdong(tendangnhap, ngaycapnhat, thaotac, form, tenmay, hedieuhanh, thoigian) values ('" + _strtendangnhap.ToUpper() + "','" + DateTime.Now.ToString("yyyy-MM-dd") + "','" + _str_thaotac + "','" + _str_form + "','" + _str_tenmay + "','" + _str_hedieuhanh + "','" + DateTime.Now.ToString() + "')", strconnect);
            cmd.CommandTimeout = 0;
            cmd.ExecuteNonQuery();
            close_connect();
        }
        #region "Tạo mã MD5"
        public static string Md5(string data)
        {
            return BitConverter.ToString(EncryptData(data)).Replace("-", "").ToLower();
        }

        public static byte[] EncryptData(string data)
        {
            var md5Hasher = new MD5CryptoServiceProvider();
            UTF8Encoding encoder = new UTF8Encoding();
            var hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(data));
            return hashedBytes;
        }
        #endregion

        public static bool IsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }

        public static Bitmap MakeGrayscale(Bitmap original)
        {
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);
            Graphics g = Graphics.FromImage(newBitmap);


            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][]
               {
           new float[] {.3f, .3f, .3f, 0, 0},
           new float[] {.59f, .59f, .59f, 0, 0},
           new float[] {.11f, .11f, .11f, 0, 0},
           new float[] {0, 0, 0, 1, 0},
           new float[] {0, 0, 0, 0, 1}
               });

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colorMatrix);

            g.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height),
               0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);

            g.Dispose();
            return newBitmap;
        }
    }
}
