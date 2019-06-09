using QLBDDTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBDDAL
{
    public class TranDauDAL
    {
        private string connectionstring;
        public string ConnectionString
        {
            get { return connectionstring; }
            set { connectionstring = value; }
        }
        public TranDauDAL()
        {
            connectionstring = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public bool them(TranDauDTO td)
        {
            string query = string.Empty;
            query += "INSERT INTO [trandau] ([MaTranDau], [MaDoiNha], [MaDoiKhach], [ThoiGian], [MaVongDau])";
            query += "VALUES (@MaTranDau,@MaDoiNha,@MaDoiKhach,@ThoiGian,@MaVongDau)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@MaTranDau", td.MaTranDau);
                    cmd.Parameters.AddWithValue("@MaDoiNha", td.MaDoiNha);
                    cmd.Parameters.AddWithValue("@MaDoiKhach", td.MaDoiKhach);
                    cmd.Parameters.AddWithValue("@ThoiGian", td.ThoiGian);
                    cmd.Parameters.AddWithValue("@MaVongDau", td.MaVongDau);
                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {

                        con.Close();
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
