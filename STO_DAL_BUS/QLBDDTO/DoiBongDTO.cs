using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBDDTO
{
    public class DoiBongDTO
    {
        private int madoibong;
        private string tendoibong;
        private int soluongcauthu;
        private int soluongcauthungoai;
        private string tensannha;
        public int MaDoiBong { get => madoibong; set => madoibong = value; }
        public string TenDoiBong { get => tendoibong; set => tendoibong = value; }
        public int SoLuongCauThu { get => soluongcauthu; set => soluongcauthu = value; }
        public int SoCauThuNgoai { get => soluongcauthungoai; set => soluongcauthungoai = value; }
        public string TenSanNha { get => tensannha; set => tensannha = value; }
    }
}
