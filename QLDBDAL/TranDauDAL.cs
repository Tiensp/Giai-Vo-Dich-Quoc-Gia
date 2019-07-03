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
    public class TranDauDAL
    {
        private string connectionstring;
        public string ConnectionString
        {
            get { return connectionstring; }
            set { connectionstring = value; }
        }
        public TranDauDAL()
        {
            connectionstring = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public bool them(TranDauDTO td)
        {
            string query = string.Empty;
            query += "INSERT INTO [trandau] ([MaTranDau], [MaDoiNha], [MaDoiKhach], [ThoiGian], [MaVongDau])";
            query += "VALUES (@MaTranDau,@MaDoiNha,@MaDoiKhach,@ThoiGian,@MaVongDau)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@MaTranDau", td.MaTranDau);
                    cmd.Parameters.AddWithValue("@MaDoiNha", td.MaDoiNha);
                    cmd.Parameters.AddWithValue("@MaDoiKhach", td.MaDoiKhach);
                    cmd.Parameters.AddWithValue("@ThoiGian", td.ThoiGian);
                    cmd.Parameters.AddWithValue("@MaVongDau", td.MaVongDau);
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
            query += "DELETE FROM dbo.trandau";
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


        public List<TranDauDTO> Load()
        {
            List<TranDauDTO> list = new List<TranDauDTO>();
            string query = string.Empty;
            query += "SELECT * FROM dbo.trandau";
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
                            TranDauDTO td = new TranDauDTO()
                            {
                                MaDoiKhach = row["MaDoiKhach"].ToString(),
                                MaDoiNha = row["MaDoiNha"].ToString(),
                                MaTranDau = row["MaTranDau"].ToString(),
                                MaVongDau = row["MaVongDau"].ToString(),
                                ThoiGian = Convert.ToDateTime(row["ThoiGian"].ToString())
                            };

                            list.Add(td);
                        }
                        catch (Exception ex)
                        {

                        }


                    }
                }

            }

            return list;
        }

        public void xoa(TranDauDTO td)
        {
            string query = string.Empty;

            query += "DELETE FROM dbo.trandau ";
            query += "WHERE MaTranDau=@MaTranDau";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@MaTranDau", td.MaTranDau);

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
                    }
                }
            }
        }

        public void capnhat(TranDauDTO td)
        {
            string query = string.Empty;

            query += "UPDATE dbo.trandau SET MaDoiNha=@MaDoiNha, MaDoiKhach=@MaDoiKhach, ThoiGian=@ThoiGian, MaVongDau=@MaVongDau ";
            query += "WHERE MaTranDau=@MaTranDau";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@MaTranDau", td.MaTranDau);
                    cmd.Parameters.AddWithValue("@MaDoiNha", td.MaDoiNha);
                    cmd.Parameters.AddWithValue("@MaDoiKhach", td.MaDoiKhach);
                    cmd.Parameters.AddWithValue("@ThoiGian", td.ThoiGian);
                    cmd.Parameters.AddWithValue("@MaVongDau", td.MaVongDau);
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
                    }
                }
            }
        }



    }
}
