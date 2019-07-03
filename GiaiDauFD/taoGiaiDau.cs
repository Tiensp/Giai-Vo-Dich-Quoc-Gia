using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBDBUS;
using QLBDDTO;

namespace QLBDUI.GiaiDauFD
{
    public partial class taoGiaiDau : Form
    {

        CauThuBUS ctBUS = new CauThuBUS();
        BanThangBUS btBUS = new BanThangBUS();
        BXHBUS bxhBUS = new BXHBUS();
        ChiTietBXHBUS ctbxhBUS = new ChiTietBXHBUS();
        DoiBongBUS dbBUS = new DoiBongBUS();
        KetQuaTranDauBUS kqBUS = new KetQuaTranDauBUS();
        LoaiBanThangBUS lbtBUS = new LoaiBanThangBUS();
        LoaiCauThuBUS lctBUS = new LoaiCauThuBUS();
        ThamSoBUS tsBUS = new ThamSoBUS();
        TranDauBUS tdBUS = new TranDauBUS();
        VongThiDauBUS vtdBUS = new VongThiDauBUS();

        public taoGiaiDau()
        {
            InitializeComponent();
        }

        private void OkButt_Click(object sender, EventArgs e)
        {
            if (!resetDBCbox.Checked && !resetLichBanTCbox.Checked)
                MessageBox.Show("Bạn chưa chọn dữ liệu giải đấu cần làm mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {
                if (!resetDBCbox.Checked)
                {
                    bool check = resetLichBT();
                    if (check) MessageBox.Show("Làm mới Lịch thi đấu và dữ liệu bàn thắng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else MessageBox.Show("Lỗi!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    bool check = resetDoiBong();
                    if (check) MessageBox.Show("Làm mới giải đấu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else MessageBox.Show("Lỗi!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void Backbutt_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void ResetDBCbox_CheckedChanged(object sender, EventArgs e)
        {
            if (resetDBCbox.Checked)
            {
                resetLichBanTCbox.Checked = true;
                resetLichBanTCbox.Enabled = false;
            }
            else
            {
                resetLichBanTCbox.Enabled = true;
            }
        }


        private bool resetDoiBong()
        {
            bool check = resetLichBT();
            if (!check) return check;

            check = ctBUS.lammoi();
            check = dbBUS.lammoi();


            return check;
        }


        private bool resetLichBT()
        {
            bool check = btBUS.lammoi();
            List<CauThuDTO> listct = ctBUS.loadcauthu();
            foreach (CauThuDTO ct in listct)
            {
                ctBUS.resettongbt(ct);
            }
            check = ctbxhBUS.lammoi();
            check = kqBUS.lammoi();
            check = tdBUS.lammoi();
            check = vtdBUS.lammoi();
            check = bxhBUS.lammoi();
            return check;
        }

    

    }
}
