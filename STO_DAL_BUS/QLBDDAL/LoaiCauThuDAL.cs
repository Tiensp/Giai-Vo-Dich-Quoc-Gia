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
    public class LoaiCauThuDAL
    {
        private string connectionstring;
        public string ConnectionString
        {
            get { return connectionstring; }
            set { connectionstring = value; }
        }
        public LoaiCauThuDAL()
        {
            connectionstring = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public bool them(LoaiCauThuDTO lct)
        {
            string query = string.Empty;
            query += "INSERT INTO [loaicauthu] ([MaLoaiCT], [LoaiCauThu])";
            query += "VALUES (@MaLoaiCT,@LoaiCauThu)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@MaLoaiCT", lct.MaLoaiCT);
                    cmd.Parameters.AddWithValue("@LoaiCauThu", lct.LoaiCauThu);
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
