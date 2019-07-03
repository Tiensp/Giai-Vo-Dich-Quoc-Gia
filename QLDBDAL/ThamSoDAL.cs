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

    public class ThamSoDAL

    {

        private string connectionstring;

        public string ConnectionString

        {

            get { return connectionstring; }

            set { connectionstring = value; }

        }

        public ThamSoDAL()

        {

            connectionstring = ConfigurationManager.AppSettings["ConnectionString"];

        }



        public void deleteData() //hàm xóa dữ liệu khác dữ liệu tham số mặc định

        {

            string query = string.Empty; //tạo câu lệnh xóa dữ liệu khác bản ghi mặc định trong DTB

            query += "DELETE FROM [ThamSo] Where MaThamSo <> '0'";

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

        public bool addData(ThamSoDTO ts) //hàm thêm dữ liệu vào dtb

        {

            deleteData();

            string query1 = string.Empty; // tạo câu lệnh thêm dữ liệu

            query1 += "INSERT INTO [ThamSo] ([MaThamSo], [TuoiCTMin], [TuoiCTMax], [SoLuongCTMin], [SoLuongCTMax], [SoCTNgoaiMax], [TGGhiBanMax], [DiemThang], [DiemHoa], [DiemThua], [Diem], [HieuSo], [BTSK], [KQDK])";

            query1 += "VALUES (@MaThamSo,@TuoiCTMin,@TuoiCTMax,@SoLuongCTMin,@SoLuongCTMax,@SoCTNgoaiMax,@TGGhiBanMax,@DiemThang,@DiemHoa,@DiemThua,@Diem,@HieuSo,@BTSK,@KQDK)";

            using (SqlConnection con = new SqlConnection(ConnectionString))

            {

                using (SqlCommand cmd1 = new SqlCommand())

                {

                    cmd1.Connection = con;

                    cmd1.CommandType = System.Data.CommandType.Text;

                    cmd1.CommandText = query1;

                    cmd1.Parameters.AddWithValue("@MaThamSo", ts.MaThamSo);

                    cmd1.Parameters.AddWithValue("@TuoiCTMin", ts.TuoiCTMin);

                    cmd1.Parameters.AddWithValue("@TuoiCTMax", ts.TuoiCTMax);

                    cmd1.Parameters.AddWithValue("@SoLuongCTMin", ts.SoLuongCTMin);

                    cmd1.Parameters.AddWithValue("@SoLuongCTMax", ts.SoLuongCTMax);

                    cmd1.Parameters.AddWithValue("@SoCTNgoaiMax", ts.SoCTNgoaiMax);

                    cmd1.Parameters.AddWithValue("@TGGhiBanMax", ts.TGGhiBanMax);

                    cmd1.Parameters.AddWithValue("@DiemThang", ts.DiemThang);

                    cmd1.Parameters.AddWithValue("@DiemHoa", ts.DiemHoa);

                    cmd1.Parameters.AddWithValue("@DiemThua", ts.DiemThua);

                    cmd1.Parameters.AddWithValue(@"Diem", ts.Diem);

                    cmd1.Parameters.AddWithValue(@"HieuSo", ts.HieuSo);

                    cmd1.Parameters.AddWithValue(@"BTSK", ts.BTSK);

                    cmd1.Parameters.AddWithValue(@"KQDK", ts.KQDK);

                    try

                    {

                        con.Open();

                        cmd1.ExecuteNonQuery();

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



        public ThamSoDTO getData(string id) //hàm lấy dữ liệu từ dtb

        {

            ThamSoDTO tsDTO = new ThamSoDTO();

            string query = string.Empty;

            query += "SELECT * FROM ThamSo WHERE MaThamSo = @ID";

            using (SqlConnection conn = new SqlConnection(ConnectionString))

            {

                using (SqlCommand cmd = new SqlCommand())

                {

                    cmd.Connection = conn;

                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.CommandText = query;

                    cmd.Parameters.AddWithValue("@ID", id);

                    try

                    {

                        conn.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())

                        {

                            while (dr.Read())

                            {

                                tsDTO.MaThamSo = (string)dr["MaThamSo"];

                                tsDTO.TuoiCTMin = (int)dr["TuoiCTMin"];

                                tsDTO.TuoiCTMax = (int)dr["TuoiCTMax"];

                                tsDTO.SoLuongCTMin = (int)dr["SoLuongCTMin"];

                                tsDTO.SoLuongCTMax = (int)dr["SoLuongCTMax"];

                                tsDTO.SoCTNgoaiMax = (int)dr["SoCTNgoaiMax"];

                                tsDTO.TGGhiBanMax = (int)dr["TGGhiBanMax"];

                                tsDTO.DiemThang = (int)dr["DiemThang"];

                                tsDTO.DiemHoa = (int)dr["DiemHoa"];

                                tsDTO.DiemThua = (int)dr["DiemThua"];

                                tsDTO.Diem = (int)dr["Diem"];

                                tsDTO.HieuSo = (int)dr["HieuSo"];

                                tsDTO.BTSK = (int)dr["BTSK"];

                                tsDTO.KQDK = (int)dr["KQDK"];

                            }



                        }

                        conn.Close();

                        conn.Dispose();

                    }

                    catch (Exception ex)

                    {

                        conn.Close();

                    }



                }



            }

            if (tsDTO.MaThamSo == null)

                return null;

            return tsDTO;

        }



        public List<string> getTTXH(string id) //hàm lấy TTXH

        {

            List<string> list = new List<string>();

            string query = string.Empty; //tạo câu lệnh truy vấn dữ liệu TTXH trong DTB

            query += "SELECT [Diem], [HieuSo], [BTSK], [KQDK] FROM [ThamSo] Where MaThamSo = @ID";

            using (SqlConnection con = new SqlConnection(ConnectionString))

            {

                using (SqlCommand cmd = new SqlCommand())

                {

                    cmd.Connection = con;

                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.CommandText = query;

                    cmd.Parameters.AddWithValue("@ID", id);

                    try

                    {

                        con.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())

                        {

                            while (dr.Read())

                            {

                                int iDiem = (int)dr["Diem"];

                                int iHieuSo = (int)dr["HieuSo"];

                                int iBTSK = (int)dr["BTSK"];

                                int iKQDK = (int)dr["KQDK"];

                                int iCheck = 0;

                                while (list.Count < 4)

                                {

                                    if (iDiem == iCheck)

                                        list.Insert(iDiem, "Điểm");

                                    if (iHieuSo == iCheck)

                                        list.Insert(iHieuSo, "Hiệu số");

                                    if (iBTSK == iCheck)

                                        list.Insert(iBTSK, "Bàn thắng sân khách");

                                    if (iKQDK == iCheck)

                                        list.Insert(iKQDK, "Kết quả đối kháng");

                                    iCheck++;

                                }

                            }

                        }

                        con.Close();

                    }

                    catch (Exception ex)

                    {

                        con.Close();

                    }



                }

            }

            return list;

        }

    }

}