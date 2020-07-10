using System;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;
namespace QuanLyNhaHang
{
    class Sqlite
    {
        public string connectionSTR = "";
        public Sqlite()
        {
            connectionSTR = $@"Data Source={Application.StartupPath}\quanlynhahang.db;Version=3;";
            // this.db_name = "democoffee.db";
        }

        public void SaveDataFromFTP(DataTable data_csv, string ipaddress, string nameftp)
        {
            for (int col = data_csv.Columns.Count - 1; col >= 0; col--)
            {

                if (string.IsNullOrEmpty(data_csv.Columns[col].ColumnName) || data_csv.Columns[col].ColumnName.Contains("\r"))
                    data_csv.Columns.RemoveAt(col);
            }

            string sql = "INSERT INTO tbl_data([Địa chỉ ip], [Tên trạm], [Thời gian tải], ";
            foreach (DataColumn column in data_csv.Columns)
            {
                if (!string.IsNullOrEmpty(column.ColumnName))
                {
                    sql += "[" + column.ColumnName + "],";
                }

            }

            sql = sql.Substring(0, sql.Length - 1) + ") ";
            using (var conn = new SQLiteConnection(connectionSTR))
            {
                // Be sure you already created the Person Table!

                conn.Open();
                using (var cmd = new SQLiteCommand(conn))
                {
                    using (var transaction = conn.BeginTransaction())
                    {
                        foreach (DataRow dr in data_csv.Rows)
                        {
                            string temp = sql;
                            string value = $"SELECT * FROM (SELECT '{ipaddress}' as [Địa chỉ ip], '{nameftp}' as [Tên trạm], '{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}' as [Thời gian tải], ";
                            foreach (DataColumn column in data_csv.Columns)
                            {
                                if (!string.IsNullOrEmpty(column.ColumnName))
                                {
                                    value += "'" + dr[column.ColumnName].ToString().Trim() + $"' as [{column.ColumnName}],";
                                }
                            }
                            value = value.Substring(0, value.Length - 1);

                            temp = temp + value + $") WHERE NOT EXISTS(select 0 from tbl_data where [Ngày]='{dr["Ngày"] as string}' and [Thời gian]='{dr["Thời gian"] as string}' and [Địa chỉ ip]='{ipaddress}')";

                            cmd.CommandText = temp;
                            cmd.ExecuteNonQuery();


                        }

                        transaction.Commit();
                    }
                }
                conn.Close();
            }
        }

        public void ImportDataExcel(DataTable data_csv)
        {
            string ipaddress = "127.0.0.1";
            string nameftp = "Default";
            string sql = "INSERT INTO tbl_data([Địa chỉ ip], [Tên trạm], [Thời gian tải], ";
            foreach (DataColumn column in data_csv.Columns)
            {
                if (!string.IsNullOrEmpty(column.ColumnName))
                {
                    sql += "[" + column.ColumnName + "],";
                }

            }


            sql = sql.Substring(0, sql.Length - 1) + ") ";

            using (var conn = new SQLiteConnection(connectionSTR))
            {
                // Be sure you already created the Person Table!

                conn.Open();
                using (var cmd = new SQLiteCommand(conn))
                {
                    using (var transaction = conn.BeginTransaction())
                    {
                        foreach (DataRow dr in data_csv.Rows)
                        {
                            string temp = sql;
                            string value = $"SELECT * FROM (SELECT '{ipaddress}' as [Địa chỉ ip], '{nameftp}' as [Tên trạm], '{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}' as [Thời gian tải], ";
                            foreach (DataColumn column in data_csv.Columns)
                            {
                                if (!string.IsNullOrEmpty(column.ColumnName))
                                {
                                    value += "'" + dr[column.ColumnName].ToString().Trim() + $"' as [{column.ColumnName}],";
                                }
                            }
                            value = value.Substring(0, value.Length - 1);
                            temp = temp + value + $") WHERE NOT EXISTS(select 0 from tbl_data where [Ngày]='{dr["Ngày"] as string}' and [Thời gian]='{dr["Thời gian"] as string}' and [Địa chỉ ip]='{ipaddress}')";
                            cmd.CommandText = temp;

                            cmd.ExecuteNonQuery();


                        }

                        transaction.Commit();
                    }
                }
                conn.Close();
            }
        }

        public bool IsServerConnected()
        {
            using (var l_oConnection = new SQLiteConnection(connectionSTR))
            {
                try
                {
                    l_oConnection.Open();
                    return true;
                }
                catch (SQLiteException ex)
                {
                    return false;
                }
            }
        }

        public string GetDatabaseProvider()
        {
            return "sqlite";
        }

        public DataTable GetAllColumnInTable(string table_name, string database_name = "")
        {
            DataTable table = ExecuteQuery($"PRAGMA table_info({table_name})");
            return table;
        }


        public int CheckTableIsExsit(string table_name, string database_name = "")
        {
            string result = ExecuteScalar($"SELECT count(*) as dem FROM sqlite_master WHERE type='table' AND name='{table_name}';").ToString();
            return int.Parse(result);
        }

        public void SaveLogFTPDownload(string ipaddress, string nameftp, string status, string description)
        {
            using (var conn = new SQLiteConnection(connectionSTR))
            {
                // Be sure you already created the Person Table!

                conn.Open();
                using (var cmd = new SQLiteCommand(conn))
                {
                    using (var transaction = conn.BeginTransaction())
                    {
                        string date = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        string sql = $"INSERT INTO tbl_log(ipaddress, nameftp, status, description, date) VALUES('{ipaddress}', '{nameftp}', '{status}', '{description}', '{date}')";
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                        transaction.Commit();
                    }
                }
                conn.Close();
            }
        }

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(connectionSTR))
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }

        public DataSet ExecuteQuery_Dataset(string query, object[] parameter = null)
        {
            DataSet data = new DataSet();

            using (SQLiteConnection connection = new SQLiteConnection(connectionSTR))
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);

                adapter.Fill(data);

                connection.Close();
            }

            return data;
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;

            using (SQLiteConnection connection = new SQLiteConnection(connectionSTR))
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();

                connection.Close();
            }

            return data;
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;

            using (SQLiteConnection connection = new SQLiteConnection(connectionSTR))
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();

                connection.Close();
            }

            return data;
        }

        public void SaveDataSQLClient(DataTable data_csv, string ipaddress, string nameftp)
        {
            throw new NotImplementedException();
        }
    }
}
