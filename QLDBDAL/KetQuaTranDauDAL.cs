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
    public class KetQuaTranDauDAL
    {
        private string connectionstring;
        public string ConnectionString
        {
            get { return connectionstring; }
            set { connectionstring = value; }
        }
        public KetQuaTranDauDAL()
        {
            connectionstring = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public bool them(KetQuaTranDauDTO kqtd)
        {
            string query = string.Empty;
            query += "INSERT INTO [ketquatrandau] ([MaKetQua], [SoBTDoiNha], [SoBTDoiKhach], [MaTranDau])";
            query += "VALUES (@MaKetQua,@SoBTDoiNha,@SoBTDoiKhach,@MaTranDau)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@MaKetQua", kqtd.MaKetQua);
                    cmd.Parameters.AddWithValue("@SoBTDoiNha", kqtd.SoBTDoiNha);
                    cmd.Parameters.AddWithValue("@SoBTDoiKhach", kqtd.SoBTDoiKhach);
                    cmd.Parameters.AddWithValue("@MaTranDau", kqtd.MaTranDau);
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
            query += "DELETE FROM dbo.ketquatrandau";
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
