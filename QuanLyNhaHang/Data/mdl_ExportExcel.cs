using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    sealed class mdl_ExportExcel
    {

        private const int MAX_ROW_1_ARRAY = 30000;

        //ListArr gồm nhiều List(Of KeyValuePair(Of Integer, Object(,)))
        //Mỗi List(Of KeyValuePair(Of Integer, Object(,))) tương ứng thông tin của 1 sheet
        //KeyvaluePair object chứa dữ liệu mảng và số dòng thực tế có dữ liệu của Array
        //OverideAddSheet = true : Chèn thêm sheet vào file cũ, không xóa file cũ
        //OverideAddSheet = false ( mặc định ) : Xóa file cũ , tạo file mới
        public static Microsoft.Office.Interop.Excel.Application ExportListArr2Excel(List<List<KeyValuePair<int, object[,]>>> listArr, string filepath, bool OverideAddSheet = false)
        {
            if (File.Exists(filepath))
            {
                if (XtraMessageBox.Show("Bạn có muốn chép đè lên file đã tồn tại không?", "Export to Excel", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (OverideAddSheet) //Chép đè bằng thao tác Add Sheet vào file cũ
                    {
                        if (FileIsOpenning(filepath))
                        {
                            XtraMessageBox.Show("Không thể chép đè khi file đang mở. Vui lòng đóng file Excel trước khi thực hiện thao tác này");
                            return null;
                        }
                    }
                    else //Chép đè bằng thao tác Xóa file cũ, tạo file mới
                    {
                        try
                        {
                            System.IO.File.Delete(filepath);
                        }
                        catch (Exception)
                        {
                            XtraMessageBox.Show("Không thể chép đè khi file đang mở. Vui lòng đóng file Excel trước khi thực hiện thao tác này");
                            return null;
                        }
                    }
                }
                else
                {
                    return null;
                }
            }

            try
            {
                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                app.Visible = true;
                app.DisplayAlerts = false;
                Microsoft.Office.Interop.Excel.Workbook wb = default(Microsoft.Office.Interop.Excel.Workbook);
                Microsoft.Office.Interop.Excel.Worksheet ws = default(Microsoft.Office.Interop.Excel.Worksheet);
                if (File.Exists(filepath))
                {
                    //Nếu file đã có, mở file và chèn thêm Sheet
                    wb = app.Workbooks.Open(Filename: filepath, UpdateLinks: false, IgnoreReadOnlyRecommended: true);
                    ws = wb.Worksheets.Add(After: wb.Worksheets[wb.Worksheets.Count]);
                }
                else
                {
                    //Chưa có file thì tạo file excel mới
                    wb = app.Workbooks.Add();
                    ws = wb.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;
                }
                app.ScreenUpdating = false;
                var calculation = app.Calculation;
                app.Calculation = Microsoft.Office.Interop.Excel.XlCalculation.xlCalculationManual;
                //Duyệt qua từng Result Set , Mỗi Result Set ghi vào 1 sheet
                List<KeyValuePair<int, object[,]>> resultSet;
                for (var r = 0; r <= listArr.Count - 1; r++)
                {
                    resultSet = listArr[r];
                    int cRow = 2;
                    //Duyệt qua từng Object Array Data để ghi vào sheet
                    foreach (var item in resultSet)
                    {
                        //item.Key : số dòng có dữ liệu thật của Array
                        ws.Range["A" + System.Convert.ToString(cRow)].Resize[item.Key,
                            item.Value.GetLength(1)].Value = item.Value;
                        cRow += System.Convert.ToInt32(item.Key);
                    }
                    ws.Range["A2"].Resize[cRow,
                        resultSet[0].Value.GetLength(1)].EntireColumn.AutoFit();
                    if (r < listArr.Count - 1)
                    {
                        ws = wb.Worksheets.Add(After: wb.Worksheets[wb.Worksheets.Count]);
                    }
                }

                app.ScreenUpdating = true;
                app.Calculation = calculation;
                wb.SaveAs(filepath);
                //app.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlMaximized;
                app.DisplayAlerts = true;
                return app;
            }
            catch (System.Exception ex)
            {
                XtraMessageBox.Show("Xuất Excel thất bại.\n" + ex.Message);
                return null;
            }

        }

        //Hỗ trợ đọc nhiều lệnh SQL, mỗi lệnh sẽ ghi ra 1 Sheet
        //Mỗi Result Set lại chia nhỏ ra thành nhiều Array, mỗi Array tối đa 30 000 dòng
        //List(Of KeyValuePair(Of Integer, Object(,))) tương ứng thông tin của 1 sheet
        //KeyvaluePair object chứa dữ liệu mảng và số dòng thực tế có dữ liệu của Array

        public static List<List<KeyValuePair<int, object[,]>>> LoadSQL2ListArr(string query,
           CommandType cmdType = CommandType.Text, params SQLiteParameter[] paramList)
        {
            var result = new List<List<KeyValuePair<int, object[,]>>>();
            using (var con = new SQLiteConnection("Data Source=" + Application.StartupPath + @"\quanlynhahang.db;Version=3;"))
            {
                try
                {
                    con.Open();
                    var cmd = con.CreateCommand();
                    cmd.CommandText = query;
                    cmd.CommandType = cmdType;
                    cmd.Parameters.AddRange(paramList);
                    var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    int FieldCount = 0;
                    var rowCount = MAX_ROW_1_ARRAY;
                    object[,] arr = null;
                    int row = 0;
                    List<KeyValuePair<int, object[,]>> resultSet;
                    do //Loop Result SETs
                    {
                        FieldCount = System.Convert.ToInt32(reader.FieldCount);
                        arr = new object[rowCount, FieldCount];
                        resultSet = new List<KeyValuePair<int, object[,]>>();
                        result.Add(resultSet);
                        for (var c = 0; c <= FieldCount - 1; c++) //Gắn tiêu đề cột
                        {
                            arr[0, (int)c] = reader.GetName(c);
                        }
                        row = 1;
                        while (reader.Read()) //Loop Rows of 1 Result Set
                        {
                            for (var c = 0; c <= FieldCount - 1; c++)
                            {
                                arr[row, (int)c] = reader[c];
                            }
                            row++;
                            if (row == rowCount)
                            {
                                resultSet.Add(new KeyValuePair<int, object[,]>(rowCount, arr));
                                arr = new object[rowCount, FieldCount];
                                row = 0;
                            }
                        }
                        if (row > 0)
                        {
                            resultSet.Add(new KeyValuePair<int, object[,]>(row, arr));
                        }
                    } while (reader.NextResult());
                    reader.Close();

                }
                catch (System.Exception ex)
                {
                    XtraMessageBox.Show("Đọc dữ liệu thất bại.\n" + ex.Message);
                }
            }
            return result;
        }


        public static bool FileIsOpenning(string fileName)
        {
            bool returnValue = false;
            returnValue = false;
            if (!File.Exists(fileName))
            {
                return returnValue;
            }
            try
            {
                using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }

            }
            catch (Exception)
            {
                returnValue = true;
            }
            return returnValue;
        }

    }
}
