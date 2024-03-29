﻿using QLBDDTO;
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
    public class LoaiBanThangDAL
    {
        private string connectionstring;
        public string ConnectionString
        {
            get { return connectionstring; }
            set { connectionstring = value; }
        }
        public LoaiBanThangDAL()
        {
            connectionstring = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public bool them(LoaiBanThangDTO lbt)
        {
            string query = string.Empty;
            query += "INSERT INTO [loaibanthang] ([MaLoaiBT], [TenLoaiBT])";
            query += "VALUES (@MaLoaiBT,@TenLoaiBT)";
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@MaLoaiBT", lbt.MaLoaiBT);
                    cmd.Parameters.AddWithValue("@TenLoaiBT", lbt.TenLoaiBT);          
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
        public DataSet getData() //hàm lấy dữ liệu từ dtb trả về DataSet
        {
            DataSet ds = new DataSet();
            string query = string.Empty;
            query += "SELECT * FROM loaibanthang";
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(ds, "LBT");
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
        public void deleteData() //hàm xóa toàn bộ dữ liệu 
        {
            string query = string.Empty; //tạo câu lệnh xóa dữ liệu khác bản ghi mặc định trong DTB
            query += "DELETE FROM [loaibanthang]";
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
                    }
                    catch
                    {
                        con.Close();
                    }

                }
            }
        }
    }
}
