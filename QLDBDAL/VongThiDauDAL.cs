﻿using QLBDDTO;
using System;
using System.Collections.Generic;
using System.Configuration;
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

    }
}
