﻿using QLBDBUS;
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

namespace QLBDUI.GiaiDauFD.LapLichTD
{
    public partial class lapLich : Form
    {
        private TranDauBUS tdBUS = new TranDauBUS();
        private DoiBongBUS dbBUS = new DoiBongBUS();
        private VongThiDauBUS vtdBUS = new VongThiDauBUS();
        public List<TranDauDTO> ListTranDauSTO = new List<TranDauDTO>();
        private ThemTranDau formThemTD = new ThemTranDau(null);
        private CapNhatTranDau formCNTD = new CapNhatTranDau(null);
        private DataTable dt = new DataTable();
        private string mavongdau = null;
        public lapLich()
        {
            InitializeComponent();
        }

        private void load_data_td()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.DataSource = dt;
            DataGridViewTextBoxColumn clMaTD = new DataGridViewTextBoxColumn();
            clMaTD.Name = "Ma";
            clMaTD.HeaderText = "Mã Trận Đấu";
            clMaTD.DataPropertyName = "MaTranDau";
            dataGridView1.Columns.Add(clMaTD);

            DataGridViewTextBoxColumn clMaDoiNha = new DataGridViewTextBoxColumn();
            clMaDoiNha.Name = "MaDoiNha";
            clMaDoiNha.HeaderText = "Đội Nhà";
            clMaDoiNha.DataPropertyName = "DoiNha";
            dataGridView1.Columns.Add(clMaDoiNha);

            DataGridViewTextBoxColumn clMaDoiKhach = new DataGridViewTextBoxColumn();
            clMaDoiKhach.Name = "MaDoiKhach";
            clMaDoiKhach.HeaderText = "Đội Khách";
            clMaDoiKhach.DataPropertyName = "DoiKhach";
            dataGridView1.Columns.Add(clMaDoiKhach);

            DataGridViewTextBoxColumn clTG = new DataGridViewTextBoxColumn();
            clTG.Name = "ThoiGian";
            clTG.HeaderText = "Thời gian";
            clTG.DataPropertyName = "ThoiGian";
            dataGridView1.Columns.Add(clTG);

            CurrencyManager myCurrencyManager = (CurrencyManager)this.BindingContext[dataGridView1.DataSource];
            myCurrencyManager.Refresh();
        }

        private void LapLich_Load(object sender, EventArgs e)
        {
            List<VongThiDauDTO> listvtd = vtdBUS.load();
            foreach (VongThiDauDTO vtd in listvtd)
            {
                vtdCbx.Items.Add(vtd.TenVongDau);
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<VongThiDauDTO> listvtd = vtdBUS.load();
            foreach (VongThiDauDTO vtd in listvtd)
            {
                if (vtd.TenVongDau == vtdCbx.Text)
                {
                    mavongdau = vtd.MaVongDau;
                    break;
                }
            }
            dt = vtdBUS.hienthi(mavongdau);
            load_data_td();
        }

        private void ThemButt_Click(object sender, EventArgs e)
        {
            formThemTD = new ThemTranDau(vtdCbx.Text);
            this.Hide();
            formThemTD.FormClosed += new FormClosedEventHandler(formThemTD_FormClosed);
            formThemTD.Show();
        }

        private void formThemTD_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            ComboBox1_SelectedIndexChanged(sender, e);
        }

        private void XoaButt_Click(object sender, EventArgs e)
        {
            ListTranDauSTO = tdBUS.load();
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                for (int i = 0; i < ListTranDauSTO.Count; i++)
                {
                    if (ListTranDauSTO[i].MaTranDau == item.Cells["Ma"].Value.ToString())
                    {
                        tdBUS.xoa(ListTranDauSTO[i]);
                        dt = vtdBUS.hienthi(mavongdau);
                        break;
                    }
                }
            }
            load_data_td();
        }

        private void CapnhatButt_Click(object sender, EventArgs e)
        {
            bool canupdate = false;
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                ListTranDauSTO = tdBUS.load();
                for (int i = 0; i < ListTranDauSTO.Count; i++)
                {
                    if (ListTranDauSTO[i].MaTranDau == item.Cells["Ma"].Value.ToString())
                    {
                        canupdate = true;
                        formCNTD = new CapNhatTranDau(ListTranDauSTO[i]);
                        this.Hide();
                        formCNTD.FormClosed += new FormClosedEventHandler(formCNTD_FormClosed);
                        formCNTD.Show();
                        break;
                    }
                }
            }
            if (!canupdate) MessageBox.Show("Bạn chưa chọn trận đấu muốn cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void formCNTD_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
            ComboBox1_SelectedIndexChanged(sender, e);
        }
    }
}

