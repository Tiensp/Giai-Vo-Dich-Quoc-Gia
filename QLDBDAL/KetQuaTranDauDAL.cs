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

        public int count()
        {
            int count = 0;
            string query = string.Empty;
            query += "SELECT COUNT * FROM dbo.ketquatrandau";
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
                        count = cmd.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();
                    }
                    catch (Exception ex)
                    {
                        con.Close();
                    }
                }
            }
            return count;
        }
        public List<KetQuaTranDauDTO> Load()
        {
            List<KetQuaTranDauDTO> list = new List<KetQuaTranDauDTO>();
            string query = string.Empty;
            query += "SELECT * FROM dbo.ketquatrandau";
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
                            KetQuaTranDauDTO kq = new KetQuaTranDauDTO()
                            {
                                MaKetQua = row["MaKetQua"].ToString(),
                                MaTranDau = row["MaTranDau"].ToString(),
                                SoBTDoiKhach = int.Parse(row["SoBTDoiKhach"].ToString()),
                                SoBTDoiNha = int.Parse(row["SoBTDoiNha"].ToString())
                            };

                            list.Add(kq);
                        }
                        catch (Exception ex)
                        {

                        }


                    }
                }

            }

            return list;
        }
    }
}
