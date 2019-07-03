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

namespace QLBDUI.GiaiDauFD.LapLichTD
{
    public partial class CapNhatTranDau : Form
    {
        private DoiBongBUS dbBUS = new DoiBongBUS();
        private VongThiDauBUS vtdBUS = new VongThiDauBUS();
        private List<DoiBongDTO> listDB = new List<DoiBongDTO>();
        private List<VongThiDauDTO> listVTD = new List<VongThiDauDTO>();
        private TranDauBUS tdBUS = new TranDauBUS();
        private List<TranDauDTO> listTD = new List<TranDauDTO>();
        private string maDN = null;
        private string maDK = null;


        public CapNhatTranDau(TranDauDTO td)
        {
            InitializeComponent();
            if(td != null)
            {
                listDB = dbBUS.load();
                foreach (DoiBongDTO db in listDB)
                {
                    if (db.MaDoiBong == td.MaDoiNha)
                    {
                        maDNcbx.Text = db.TenDoiBong;
                        maDN = db.MaDoiBong; 
                        sanCbx.Text = db.TenSanNha;
                        break;
                    }
                }

                foreach (DoiBongDTO db in listDB)
                {
                    if (db.MaDoiBong == td.MaDoiKhach)
                    {
                        maDKcbx.Text = db.TenDoiBong;
                        maDK = db.MaDoiBong;
                        break;
                    }
                }

                listVTD = vtdBUS.load();
                foreach (VongThiDauDTO vtd in listVTD)
                {
                    if (vtd.MaVongDau == td.MaVongDau)
                    {
                        vtdCbx.Text = vtd.TenVongDau;
                        break;
                    }
                }
                maTDtxt.Text = td.MaTranDau;
                ngayThiDau.Value = new DateTime(td.ThoiGian.Year, td.ThoiGian.Month, td.ThoiGian.Day);
                gioTxt.Value = td.ThoiGian.Hour;
                phutTxt.Value = td.ThoiGian.Minute;
            }                
        }

        private void CapNhatTranDau_Load(object sender, EventArgs e)
        {
            listVTD = vtdBUS.load();
            foreach (VongThiDauDTO vtd in listVTD)
            {
                vtdCbx.Items.Add(vtd.TenVongDau);
            }

            listDB = dbBUS.load();
            foreach (DoiBongDTO db in listDB)
            {
                maDNcbx.Items.Add(db.TenDoiBong);
            }

            foreach (DoiBongDTO db in listDB)
            {
                maDKcbx.Items.Add(db.TenDoiBong);
            }
        }

        private void MaDNcbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            listDB = dbBUS.load();
            foreach (DoiBongDTO db in listDB)
            {
                if (db.TenDoiBong == maDNcbx.Text)
                {
                    sanCbx.Text = db.TenSanNha;
                    maDN = db.MaDoiBong;
                    break;
                }
            }
        }

        private void MaDKcbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            listDB = dbBUS.load();
            foreach (DoiBongDTO db in listDB)
            {
                if (db.TenDoiBong == maDKcbx.Text)
                {
                    maDK = db.MaDoiBong;
                    break;
                }
            }
        }

        private void TroveButt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LuuButt_Click(object sender, EventArgs e)
        {
            List<VongThiDauDTO> listvtd = vtdBUS.load();
            string mavongdau = null;
            foreach (VongThiDauDTO vtd in listvtd)//load mã loại cầu thủ đã được chọn
            {
                if (vtd.TenVongDau == vtdCbx.Text)
                {
                    mavongdau = vtd.MaVongDau;
                    break;
                }
            }

            var thoiGian = new DateTime(ngayThiDau.Value.Year, ngayThiDau.Value.Month, ngayThiDau.Value.Day, Decimal.ToInt32(gioTxt.Value), Decimal.ToInt32(phutTxt.Value), 0);

            TranDauDTO td = new TranDauDTO()
            {
                MaTranDau = maTDtxt.Text,
                MaDoiKhach = maDK,
                MaDoiNha = maDN,
                MaVongDau = mavongdau,
                ThoiGian = thoiGian
            };
            bool kt = true;
            listTD = tdBUS.load();
            if (maDNcbx.Text == null)
            {
                MessageBox.Show("Bạn chưa chọn đội nhà!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                kt = false;
            }
            else if (maDKcbx.Text == null)
            {
                MessageBox.Show("Bạn chưa chọn đội Khách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                kt = false;
            }
            else if (td.MaDoiKhach == td.MaDoiNha)
            {
                MessageBox.Show("Đội nhà và đội khách trùng tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                kt = false;
            }
            else if (vtdCbx.Text == null)
            {
                MessageBox.Show("Bạn chưa chọn vòng đấu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                kt = false;
            }
            else
                foreach (TranDauDTO TD in listTD)
                {
                    if (TD.MaVongDau == td.MaVongDau)
                        if(TD.MaTranDau != td.MaTranDau)
                        {
                            if ((td.MaDoiNha == TD.MaDoiNha) && (td.MaDoiKhach == TD.MaDoiKhach))
                            {
                                MessageBox.Show("Hai đội đã có trận đấu trong vòng đấu này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                kt = false;
                                break;
                            }
                            else if ((td.MaDoiNha == TD.MaDoiKhach) && (td.MaDoiKhach == TD.MaDoiNha))
                            {
                                MessageBox.Show("Hai đội đã có trận đấu trong vòng đấu này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                kt = false;
                                break;
                            }
                        }                     
                        else if (TD.MaVongDau != td.MaVongDau)
                            if ((td.MaDoiNha == TD.MaDoiNha) && (td.MaDoiKhach == TD.MaDoiKhach))
                            {
                                if (int.Parse(td.MaVongDau) > int.Parse(TD.MaVongDau))
                                {
                                    if (DateTime.Compare(td.ThoiGian, TD.ThoiGian) < 0)
                                    {
                                        MessageBox.Show("Trận lượt về giữa hai đội phải diễn ra sau trân lượt đi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        kt = false;
                                        break;
                                    }
                                }
                                else if (DateTime.Compare(td.ThoiGian, TD.ThoiGian) >= 0)
                                {
                                    MessageBox.Show("Trận lượt đi giữa hai đội phải diễn ra trước trân lượt đi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    kt = false;
                                    break;
                                }
                            }
                            else if ((td.MaDoiNha == TD.MaDoiKhach) && (td.MaDoiKhach == TD.MaDoiNha))
                            {
                                if (int.Parse(td.MaVongDau) > int.Parse(TD.MaVongDau))
                                {
                                    if (DateTime.Compare(td.ThoiGian, TD.ThoiGian) < 0)
                                    {
                                        MessageBox.Show("Trận lượt về giữa hai đội phải diễn ra sau trân lượt đi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        kt = false;
                                        break;
                                    }
                                }
                                else if (DateTime.Compare(td.ThoiGian, TD.ThoiGian) >= 0)
                                {
                                    MessageBox.Show("Trận lượt đi giữa hai đội phải diễn ra trước trân lượt đi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    kt = false;
                                    break;
                                }
                            }
                }
            if (kt)
            {
                tdBUS.capnhat(td);
                this.Close();
            }
        }
    }
}
