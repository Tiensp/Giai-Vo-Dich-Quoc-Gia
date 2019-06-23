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

namespace QLBDUI.GiaiDauFD.QLDB
{
    public partial class themMoiDB : Form
    {
        private DoiBongBUS dbBUS;
        private CauThuBUS ctBUS;
        private List<CauThuDTO> ListCauThuSTO = new List<CauThuDTO>();
        ThemCT formthemCT = new ThemCT();
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
            if (kt == false)
            {
                MessageBox.Show("loi");
            }
            else
            {
                MessageBox.Show("ok");
            }

            //add cầu thủ
            for (int i = 0; i < ListCauThuSTO.Count; i++)
            {
                CauThuDTO ctDTO = ListCauThuSTO[i];
                    bool kt1 = ctBUS.them(ctDTO);
                    if (kt1 == false)
                    {
                        MessageBox.Show("loi them ct");
                    }
                    else
                    {
                         MessageBox.Show("ok");
                    }
            }
        }

        private void themMoiDB_Load(object sender, EventArgs e)
        {
            dbBUS = new DoiBongBUS();
            ctBUS = new CauThuBUS();
            load_data_ct();
        }
        private void load_data_ct()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = ListCauThuSTO;

            DataGridViewTextBoxColumn clMa = new DataGridViewTextBoxColumn();
            clMa.Name = "Ma";
            clMa.HeaderText = "Mã Cầu Thủ";
            clMa.DataPropertyName = "MaCauThu";
            dataGridView1.Columns.Add(clMa);

            DataGridViewTextBoxColumn clTen = new DataGridViewTextBoxColumn();
            clTen.Name = "Ten";
            clTen.HeaderText = "Tên Câu Thủ";
            clTen.DataPropertyName = "TenCauThu";
            dataGridView1.Columns.Add(clTen);

            DataGridViewTextBoxColumn clNgaySinh = new DataGridViewTextBoxColumn();
            clNgaySinh.Name = "NgaySinh";
            clNgaySinh.HeaderText = "Ngày sinh";
            clNgaySinh.DataPropertyName = "NgaySinh";
            dataGridView1.Columns.Add(clNgaySinh);

            DataGridViewTextBoxColumn clLoaiCauThu = new DataGridViewTextBoxColumn();
            clLoaiCauThu.Name = "LoaiCauThu";
            clLoaiCauThu.HeaderText = "Loại Câu Thủ";
            clLoaiCauThu.DataPropertyName = "MaLoaiCT";
            dataGridView1.Columns.Add(clLoaiCauThu);

            DataGridViewTextBoxColumn clGhiChu = new DataGridViewTextBoxColumn();
            clGhiChu.Name = "GhiChu";
            clGhiChu.HeaderText = "Ghi chú";
            clGhiChu.DataPropertyName = "GhiChu";
            dataGridView1.Columns.Add(clGhiChu);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dataGridView1.DataSource];
            myCurrencyManager.Refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            formthemCT.FormClosed += new FormClosedEventHandler(formthemCT_FormClosed);
            formthemCT.Show();
        }

        private void formthemCT_FormClosed(object sender, FormClosedEventArgs e)
        {
            ListCauThuSTO.Add(formthemCT.send_data(int.Parse(textBox3.Text)));
            this.Show();
            load_data_ct();
        }
    }
}
