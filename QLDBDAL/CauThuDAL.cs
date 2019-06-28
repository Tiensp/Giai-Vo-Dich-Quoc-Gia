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
            query += "VALUES (@MaCauThu,@TenCauThu,@NgaySinh,@GhiChu,@TongSoBT,@TuoiCauThu,@MaLoaiCT,@MaDoiBong)";
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
                    cmd.Parameters.AddWithValue("@MaDoiBong", ct.MaDoiBong);
                    cmd.Parameters.AddWithValue("@MaLoaiCT", ct.MaLoaiCT);

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

        public void capnhat(CauThuDTO ct)
        {
            string query = string.Empty;

            query += "UPDATE dbo.cauthu SET TenCauThu=@TenCauThu, NgaySinh=@NgaySinh, GhiChu=@GhiChu, ";
            query += "TongSoBT=@TongSoBT, TuoiCauThu=@TuoiCauThu, MaLoaiCT=@MaLoaiCT, MaDoiBong=@MaDoiBong ";
            query += "WHERE MaCauThu=@MaCauThu";
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
                    cmd.Parameters.AddWithValue("@MaDoiBong", ct.MaDoiBong);
                    cmd.Parameters.AddWithValue("@MaLoaiCT", ct.MaLoaiCT);

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

        public void xoa(CauThuDTO ct)
        {
            string query = string.Empty;

            query += "DELETE FROM dbo.cauthu ";
            query += "WHERE MaCauThu=@MaCauThu";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@MaCauThu", ct.MaCauThu);

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


        public void resettongbt(CauThuDTO ct)
        {
            string query = string.Empty;

            query += "UPDATE dbo.cauthu SET TongSoBT=@TongSoBT ";
            query += "WHERE MaCauThu=@MaCauThu";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@MaCauThu", ct.MaCauThu);
                    cmd.Parameters.AddWithValue("@TongSoBT", 0);

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

        public bool lammoi()
        {
            string query = string.Empty;
            query += "DELETE FROM dbo.cauthu";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    //try
                    //{
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        con.Dispose();
                    //}
                   // catch (Exception ex)
                    //{
                        con.Close();
                        return false;
                    //}
                }
            }

            return true;
        }


        public List<CauThuDTO> Loadcauthu()
        {
            List<CauThuDTO> listct = new List<CauThuDTO>();
            string query = string.Empty;
            query += "SELECT * FROM dbo.cauthu";
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
                            CauThuDTO ct = new CauThuDTO()
                            {
                                MaCauThu = int.Parse(row["MaCauThu"].ToString()),

                                TenCauThu = row["TenCauThu"].ToString(),

                                NgaySinh = DateTime.Parse(row["NgaySinh"].ToString()),

                                TuoiCauThu = int.Parse(row["TuoiCauThu"].ToString()),

                                MaLoaiCT = int.Parse(row["MaLoaiCT"].ToString()),

                                GhiChu = row["GhiChu"].ToString(),

                                MaDoiBong = int.Parse(row["MaDoiBong"].ToString()),

                                TongSoBT = int.Parse(row["TongSoBT"].ToString())
                            };

                            listct.Add(ct);
                        } catch(Exception ex)
                        {

                        }


                    }
                }

            }

            return listct;
        }

    }
}
