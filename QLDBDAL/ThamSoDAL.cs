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
    public class ThamSoDAL
    {
        private string connectionstring;
        public string ConnectionString
        {
            get { return connectionstring; }
            set { connectionstring = value; }
        }
        public ThamSoDAL()
        {
            connectionstring = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public bool them(ThamSoDTO ts)
        {
            string query = string.Empty;
            query += "INSERT INTO [ThamSo] ([TuoiCTMin], [TuoiCTMax], [SoLuongCTMin], [SoLuongCTMax], [SoCTNgoaiMax], [TGGhiBanMax])";
            query += "VALUES (@TuoiCTMin,@TuoiCTMax,@SoLuongCTMin,@SoLuongCTMax,@SoCTNgoaiMax,@TGGhiBanMax)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@TuoiCTMin", ts.TuoiCTMin);
                    cmd.Parameters.AddWithValue("@TuoiCTMax", ts.TuoiCTMax);
                    cmd.Parameters.AddWithValue("@SoLuongCTMin", ts.SoLuongCTMin);
                    cmd.Parameters.AddWithValue("@SoLuongCTMax", ts.SoLuongCTMax);
                    cmd.Parameters.AddWithValue("@SoCTNgoaiMax", ts.SoCTNgoaiMax);
                    cmd.Parameters.AddWithValue("@TGGhiBanMax", ts.TGGhiBanMax);
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
            query += "DELETE FROM dbo.ThamSo";
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
