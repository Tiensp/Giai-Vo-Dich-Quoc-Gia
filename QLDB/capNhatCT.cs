using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBDDTO;
using QLBDBUS;

namespace QLBDUI.GiaiDauFD.QLDB
{
    public partial class capNhatCT : Form
    {
        private LoaiCauThuBUS lctBus = new LoaiCauThuBUS();
        private List<LoaiCauThuDTO> listLCT = new List<LoaiCauThuDTO>();
        bool savebuttwasClicked = false;

        public capNhatCT(int mact, string tencauthu, string ngaysinh, string loaict, string ghichu)
        {
            InitializeComponent();

            listLCT = lctBus.loadLoaiCT();
            foreach (LoaiCauThuDTO lct in listLCT)
            {
                if(lct.MaLoaiCT == loaict) this.cbxPlayerType.Text = lct.LoaiCauThu;
                break;
            }

            this.playerCode.Text = mact.ToString();
            this.playerName.Text = tencauthu;
            this.playerBirth.Text = ngaysinh;
            this.playerNote.Text = ghichu;

        }

        private void BackButt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Savebutt_Click(object sender, EventArgs e)
        {
            savebuttwasClicked = true;
            this.Close();
        }


        public CauThuDTO send_data()
        {
            if (savebuttwasClicked)
            {
                string loaict = null;
                foreach (LoaiCauThuDTO lct in listLCT)
                {
                    if (lct.LoaiCauThu == cbxPlayerType.Text) loaict = lct.MaLoaiCT;
                }



                CauThuDTO ct = new CauThuDTO()
                {
                    MaCauThu = playerCode.Text,

                    TenCauThu = playerName.Text,

                    NgaySinh = playerBirth.Value,

                    TuoiCauThu = DateTime.Now.Year - playerBirth.Value.Year,

                    MaLoaiCT = loaict,

                    GhiChu = playerNote.Text

                };


                return ct;
            }

            return null;
        }

        private void CapNhatCT_Load(object sender, EventArgs e)
        {
            listLCT = lctBus.loadLoaiCT();
            foreach (LoaiCauThuDTO lct in listLCT)
            {
                this.cbxPlayerType.Items.Add(lct.LoaiCauThu);
            }
        }
    }
}
