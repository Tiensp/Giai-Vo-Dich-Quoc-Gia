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
    public class BanThangDAL
    {
        private string connectionstring;
        public string ConnectionString
        {
            get { return connectionstring; }
            set { connectionstring = value; }
        }
        public BanThangDAL()
        {
            connectionstring = ConfigurationManager.AppSettings["ConnectionString"];
        }
        public bool them(BanThangDTO bt)
        {
            string query = string.Empty;
            query += "INSERT INTO [banthang] ([MaBanThang], [MaKetQua], [MaCauThu], [MaLoaiBT], [ThoiDiem])";
            query += "VALUES (@MaBanThang,@MaKetQua,@MaCauThu,@MaLoaiBT,@ThoiDiem)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@MaBanThang", bt.MaBanThang);
                    cmd.Parameters.AddWithValue("@MaKetQua", bt.MaKetQua);
                    cmd.Parameters.AddWithValue("@MaCauThu", bt.MaCauThu);
                    cmd.Parameters.AddWithValue("@MaLoaiBT", bt.MaLoaiBT);
                    cmd.Parameters.AddWithValue("@ThoiDiem", bt.ThoiDiem);
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
            query += "DELETE FROM dbo.banthang";
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
