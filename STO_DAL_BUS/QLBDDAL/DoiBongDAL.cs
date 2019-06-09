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
    public class DoiBongDAL
    {
        private string connectionstring;
        public string ConnectionString
        {
            get { return connectionstring; }
            set { connectionstring = value; }
        }
        public DoiBongDAL()
        {
            connectionstring = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public bool them(DoiBongDTO db)
        {
            string query = string.Empty;
            query += "INSERT INTO [doibong] ([MaDoiBong], [TenDoiBong], [SoLuongCauThu], [SoCauThuNgoai], [TenSanNha])";
            query += "VALUES (@MaDoiBong,@TenDoiBong,@SoLuongCauThu,@SoCauThuNgoai,@TenSanNha)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@MaDoiBong", db.MaDoiBong);
                    cmd.Parameters.AddWithValue("@TenDoiBong", db.TenDoiBong);
                    cmd.Parameters.AddWithValue("@SoLuongCauThu", db.SoLuongCauThu);
                    cmd.Parameters.AddWithValue("@SoCauThuNgoai", db.SoCauThuNgoai);
                    cmd.Parameters.AddWithValue("@TenSanNha", db.TenSanNha);
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
