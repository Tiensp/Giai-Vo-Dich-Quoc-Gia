using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBDDTO
{
    public class BanThangDTO
    {
        private int mabanthang;
        private int maketqua;
        private int macauthu;
        private int maloaibt;
        private int thoidiem;
        public int MaBanThang { get => mabanthang; set => mabanthang = value; }
        public int MaKetQua { get => maketqua; set => maketqua = value; }
        public int MaCauThu { get => macauthu; set => macauthu = value; }
        public int MaLoaiBT { get => maloaibt; set => maloaibt = value; }
        public int ThoiDiem { get => thoidiem; set => thoidiem = value; }
    }
}
