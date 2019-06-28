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
    public class ChiTietBXHDAL
    {
        private string connectionstring;
        public string ConnectionString
        {
            get { return connectionstring; }
            set { connectionstring = value; }
        }
        public ChiTietBXHDAL()
        {
            connectionstring = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public bool them(ChiTietBXHDTO ctbxh)
        {
            string query = string.Empty;
            query += "INSERT INTO [chitietBXH] ([MaCTBXH], [MaDoiBong], [MaBXH], [Thang], [Hoa], [Thua], [HieuSo], [Diem], [Hang], [TongSBT])";
            query += "VALUES (@MaCTBXH,@MaDoiBong,@MaBXH,@Thang,@Hoa,@Thua,@HieuSo,@Diem,@Hang,@TongSBT)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@MaCTBXH", ctbxh.MaCTBXH);
                    cmd.Parameters.AddWithValue("@MaDoiBong", ctbxh.MaDoiBong);
                    cmd.Parameters.AddWithValue("@MaBXH", ctbxh.MaBXH);
                    cmd.Parameters.AddWithValue("@Thang", ctbxh.Thang);
                    cmd.Parameters.AddWithValue("@Hoa", ctbxh.Hoa);
                    cmd.Parameters.AddWithValue("@Thua", ctbxh.Thua);
                    cmd.Parameters.AddWithValue("@HieuSo", ctbxh.HieuSo);
                    cmd.Parameters.AddWithValue("@Diem", ctbxh.Diem);
                    cmd.Parameters.AddWithValue("@Hang", ctbxh.Hang);
                    cmd.Parameters.AddWithValue("@TongSBT", ctbxh.TongSBT);
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

        public bool lammoi()
        {
            string query = string.Empty;
            query += "DELETE FROM dbo.chitietBXH";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
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
