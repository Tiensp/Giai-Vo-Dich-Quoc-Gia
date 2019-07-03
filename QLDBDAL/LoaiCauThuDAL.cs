using QLBDDTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBDDAL
{
    public class LoaiCauThuDAL
    {
        private string connectionstring;
        public string ConnectionString
        {
            get { return connectionstring; }
            set { connectionstring = value; }
        }
        public LoaiCauThuDAL()
        {
            connectionstring = ConfigurationManager.AppSettings["ConnectionString"];
        }
        public bool them(LoaiCauThuDTO lct)
        {
            string query = string.Empty;
            query += "INSERT INTO [loaicauthu] ([MaLoaiCT], [LoaiCauThu])";
            query += "VALUES (@MaLoaiCT,@LoaiCauThu)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@MaLoaiCT", lct.MaLoaiCT);
                    cmd.Parameters.AddWithValue("@LoaiCauThu", lct.LoaiCauThu);
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
            query += "DELETE FROM dbo.loaicauthu";
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
        public List<LoaiCauThuDTO> loadLoaiCT()
        {
            List<LoaiCauThuDTO> listLoaict = new List<LoaiCauThuDTO>();
            string query = string.Empty;
            query += "SELECT MaLoaiCT, LoaiCauThu FROM dbo.loaicauthu";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        LoaiCauThuDTO lct = new LoaiCauThuDTO()
                        {
                            LoaiCauThu = row["LoaiCauThu"].ToString(),
                            MaLoaiCT = row["MaLoaiCT"].ToString()
                        };

                        listLoaict.Add(lct);
                    }
                }

            }
            
            return listLoaict;
        }
        public DataSet getData() //hàm lấy dữ liệu từ dtb trả về DataSet

        {

            DataSet ds = new DataSet();

            string query = string.Empty;

            query += "SELECT * FROM loaicauthu";

            using (SqlConnection conn = new SqlConnection(ConnectionString))

            {

                try

                {

                    conn.Open();

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);

                    da.Fill(ds, "LCT");

                    conn.Close();

                    conn.Dispose();

                }

                catch (Exception ex)

                {

                    throw ex;

                }



            }

            return ds;

        }


    }
}
