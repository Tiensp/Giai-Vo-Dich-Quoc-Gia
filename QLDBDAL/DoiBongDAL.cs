using QLBDDTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

        public bool capnhat(DoiBongDTO db)
        {
            string query = string.Empty;

            query += "UPDATE dbo.doibong SET TenDoiBong=@TenDoiBong, SoLuongCauThu=@SoLuongCauThu, SoCauThuNgoai=@SoCauThuNgoai, TenSanNha=@TenSanNha ";
            query += "WHERE MaDoiBong=@MaDoiBong";
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

        public List<DoiBongDTO> Load()
        {
            List<DoiBongDTO> listdb = new List<DoiBongDTO>();
            string query = string.Empty;
            query += "SELECT * FROM dbo.doibong";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandType = System.Data.CommandType.Text;
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        DoiBongDTO db = new DoiBongDTO();
                        db.MaDoiBong = row["MaDoiBong"].ToString();
                        db.TenDoiBong = row["TenDoiBong"].ToString();
                        db.SoLuongCauThu = int.Parse(row["SoLuongCauThu"].ToString());
                        db.SoCauThuNgoai = int.Parse(row["SoCauThuNgoai"].ToString());
                        db.TenDoiBong = row["TenSanNha"].ToString();

                        listdb.Add(db);

                    }
                }

            }

            return listdb;
        }



        public bool lammoi()
        {
            string query = string.Empty;
            query += "DELETE FROM dbo.doibong";
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
