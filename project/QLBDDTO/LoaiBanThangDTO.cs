using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBDDTO
{
    public class LoaiBanThangDTO
    {
        private int maloaibt;
        private string tenloaibt;
        public int MaLoaiBT { get => maloaibt; set => maloaibt = value; }
        public string TenLoaiBT { get => tenloaibt; set => tenloaibt = value; }     
    }
}
