using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBDDTO
{
    public class BanThangDTO
    {
        private string mabanthang;
        private string maketqua;
        private string macauthu;
        private string maloaibt;
        private int thoidiem;
        public string MaBanThang { get => mabanthang; set => mabanthang = value; }
        public string MaKetQua { get => maketqua; set => maketqua = value; }
        public string MaCauThu { get => macauthu; set => macauthu = value; }
        public string MaLoaiBT { get => maloaibt; set => maloaibt = value; }
        public int ThoiDiem { get => thoidiem; set => thoidiem = value; }
    }
}
