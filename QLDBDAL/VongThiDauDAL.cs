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
    public class VongThiDauDAL
    {
        private string connectionstring;
        public string ConnectionString
        {
            get { return connectionstring; }
            set { connectionstring = value; }
        }
        public VongThiDauDAL()
        {
            connectionstring = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public bool them(VongThiDauDTO vtd)
        {
            string query = string.Empty;
            query += "INSERT INTO [vongthidau] ([MaVongDau], [TenVongDau])";
            query += "VALUES (@MaVongDau,@TenVongDau)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@MaVongDau", vtd.MaVongDau);
                    cmd.Parameters.AddWithValue("@TenVongDau", vtd.TenVongDau);
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
            query += "DELETE FROM dbo.vongthidau";
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


        public List<VongThiDauDTO> Load()
        {
            List<VongThiDauDTO> list = new List<VongThiDauDTO>();
            string query = string.Empty;
            query += "SELECT * FROM dbo.vongthidau";
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
                        try
                        {
                            VongThiDauDTO vtd = new VongThiDauDTO()
                            {
                                MaVongDau = row["MaVongDau"].ToString(),
                                TenVongDau = row["TenVongDau"].ToString()
                            };

                            list.Add(vtd);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }

            }

            return list;
        }

        public DataTable hienthi(string mavongdau)
        {
            List<VongThiDauDTO> list = new List<VongThiDauDTO>();
            string query = string.Empty;
            query += "SELECT A.MaTranDau, B.TenDoiBong as DoiNha, C.TenDoiBong as DoiKhach, A.ThoiGian ";
            query += "FROM dbo.trandau A, dbo.doibong B, dbo.doibong C ";
            query += "WHERE A.MaDoiNha = B.MaDoiBong and A.MaDoiKhach = C.MaDoiBong and A.MaVongDau = @MaVongDau";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@MaVongDau", mavongdau);
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }

        }
    }
}
