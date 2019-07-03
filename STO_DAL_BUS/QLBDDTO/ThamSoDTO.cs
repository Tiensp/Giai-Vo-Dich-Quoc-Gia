using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBDDTO
{
    public class ThamSoDTO
    {
        private int tuoictmin;
        private int tuoictmax;
        private int soluongctmin;
        private int soluongctmax;
        private int soctngoaimax;
        private int tgghibanmax;
        public int TuoiCTMin { get => tuoictmin; set => tuoictmin = value; }
        public int TuoiCTMax { get => tuoictmax; set => tuoictmax = value; }
        public int SoLuongCTMin { get => soluongctmin; set => soluongctmin = value; }
        public int SoLuongCTMax { get => soluongctmax; set => soluongctmax = value; }
        public int SoCTNgoaiMax { get => soctngoaimax; set => soctngoaimax = value; }
        public int TGGhiBanMax { get => tgghibanmax; set => tgghibanmax = value; }
    }
}
