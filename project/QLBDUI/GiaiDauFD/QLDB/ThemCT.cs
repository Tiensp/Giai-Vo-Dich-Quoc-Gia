﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBDDTO;

namespace QLBDUI.GiaiDauFD.QLDB
{
    public partial class ThemCT : Form
    {
        public ThemCT()
        {
            InitializeComponent();
        }

        private void ThemCT_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
            //data
        }
        public CauThuDTO send_data()
        {
            CauThuDTO ct = new CauThuDTO()
            {
                MaCauThu = int.Parse(textBox1.Text),
                TenCauThu = textBox2.Text,
                NgaySinh = dateTimePicker1.Value,
                TuoiCauThu = 1,
                MaLoaiCT = 2,
                GhiChu = textBox3.Text
            };
            return ct;
        }
    }
}