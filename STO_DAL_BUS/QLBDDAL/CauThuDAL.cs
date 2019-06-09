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
    public class CauThuDAL
    {
        private string connectionstring;
        public string ConnectionString
        {
            get { return connectionstring; }
            set { connectionstring = value; }
        }
        public CauThuDAL()
        {
            connectionstring = ConfigurationManager.AppSettings["ConnectionString"];
        }
        public bool them(CauThuDTO ct)
        {
            string query = string.Empty;
            query += "INSERT INTO [cauthu] ([MaCauThu], [TenCauThu], [NgaySinh], [GhiChu], [TongSoBT],[TuoiCauThu],[MaLoaiCT],[MaDoiBong])";
            query += "VALUES (@MaCauThu,@TenCauThu,@NgaySinh,@GhiChu,@TongSoBT,@TuoiCauThu,MaLoaiCT,MaDoiBong)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@MaCauThu", ct.MaCauThu);
                    cmd.Parameters.AddWithValue("@TenCauThu", ct.TenCauThu);
                    cmd.Parameters.AddWithValue("@NgaySinh", ct.NgaySinh);
                    cmd.Parameters.AddWithValue("@GhiChu", ct.GhiChu);
                    cmd.Parameters.AddWithValue("@TongSoBT", ct.TongSoBT);
                    cmd.Parameters.AddWithValue("@TuoiCauThu", ct.TuoiCauThu);
                    cmd.Parameters.AddWithValue("@MaLoaiCT", ct.MaLoaiCT);
                    cmd.Parameters.AddWithValue("@MaDoiBong", ct.MaDoiBong);
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
