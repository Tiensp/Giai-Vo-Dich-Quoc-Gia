using QLBDBUS;
using QLBDDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nmcnpm
{
    public partial class themMoiDB : Form
    {
        private DoiBongBUS dbBUS;
        public themMoiDB()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            ///
            DoiBongDTO dbDTO = new DoiBongDTO();
            dbDTO.MaDoiBong = int.Parse(textBox3.Text);
            dbDTO.TenDoiBong = textBox1.Text;
            dbDTO.SoLuongCauThu = int.Parse(textBox4.Text);
            dbDTO.TenSanNha = textBox2.Text;
            //add data
            bool kt = dbBUS.them(dbDTO);
            if(kt==false)
            {
                MessageBox.Show("loi");
            }
            else
            {
                MessageBox.Show("ok");
            }
        }

        private void themMoiDB_Load(object sender, EventArgs e)
        {
            dbBUS = new DoiBongBUS();
        }
    }
}
