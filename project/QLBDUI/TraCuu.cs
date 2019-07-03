using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLBDUI
{
    public partial class TraCuu : Form
    {
        public TraCuu()
        {
            InitializeComponent();
        }
        private void findButt_Click(object sender, EventArgs e)
        {
            SqlConnection kn = new SqlConnection(@"Data Source=DESKTOP-AFTIQ66\SQLEXPRESS;Initial Catalog=QLBD;Integrated Security=True");

            if (numericUpDown1.Value <= numericUpDown2.Value && numericUpDown2.Value != 0)
            {
                kn.Open();
                //string maCauThu = "select * from cauthu ct, doibong db, loaicauthu lct where ct.MaDoiBong = db.MaDoiBong and lct.MaLoaiCT = ct.MaLoaiCT and MaCauThu like '%" + textBox1.Text + "%' and TenCauThu like '%" + textBox2.Text + "%' and LoaiCauThu like '%" + comboBox2.Text + "%' and TongSoBT = '" + numericUpDown3.Value + "' and TenDoiBong like '%" + comboBox1.Text + "%' and TuoiCauThu >= '" + numericUpDown1.Value + "' AND TuoiCauThu <= '" + numericUpDown2.Value + "'";
                string maCauThu = "select MaCauThu, TenCauThu, NgaySinh, db.TenDoiBong, lct.LoaiCauThu, TuoiCauThu, TongSoBT from cauthu ct, doibong db, loaicauthu lct where ct.MaDoiBong = db.MaDoiBong and lct.MaLoaiCT = ct.MaLoaiCT and MaCauThu like '%" + textBox1.Text + "%' and TenCauThu like '%" + textBox2.Text + "%' and LoaiCauThu like '%" + comboBox2.Text + "%' and TongSoBT = '" + numericUpDown3.Value + "' and TenDoiBong like '%" + comboBox1.Text + "%' and TuoiCauThu >= '" + numericUpDown1.Value + "' AND TuoiCauThu <= '" + numericUpDown2.Value + "'";
                SqlCommand commandCauThu = new SqlCommand(maCauThu, kn);
                SqlDataAdapter adaptermaCauThu = new SqlDataAdapter(commandCauThu);
                DataTable table = new DataTable();
                adaptermaCauThu.Fill(table);
                dataGridView1.DataSource = table;              
                kn.Close();
            }

            if (numericUpDown2.Value == 0 && numericUpDown1.Value == 0)
            {
                kn.Open();              
                string maCauThu = "select MaCauThu, TenCauThu, NgaySinh, db.TenDoiBong, lct.LoaiCauThu, TuoiCauThu, TongSoBT  from cauthu ct, doibong db, loaicauthu lct WHERE ct.MaDoiBong = db.MaDoiBong and lct.MaLoaiCT = ct.MaLoaiCT and ct.TenCauThu like '%" + textBox2.Text + "%' and MaCauThu like '%" + textBox1.Text + "%' and db.TenDoiBong like '%" + comboBox1.Text + "%' and lct.LoaiCauThu like '%" + comboBox2.Text + "%' and TongSoBT like '%" + numericUpDown3.Value + "%'";
                SqlCommand commandCauThu = new SqlCommand(maCauThu, kn);
                SqlDataAdapter adaptermaCauThu = new SqlDataAdapter(commandCauThu);
                DataTable table = new DataTable();
                adaptermaCauThu.Fill(table);
                dataGridView1.DataSource = table;
                kn.Close();
            }       
        }
    }
}

