using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBDDTO
{
    public class BXHDTO
    {
        private int mabxh;
        private DateTime ngaygio;
        public int MaBXH { get => mabxh; set => mabxh = value; }
        public DateTime NgayGio { get => ngaygio; set => ngaygio = value; }
    }
}
