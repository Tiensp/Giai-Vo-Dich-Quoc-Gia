using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBDDTO
{
    public class VongThiDauDTO
    {
        private int mavongdau;
        private string tenvongdau;
        public int MaVongDau { get => mavongdau; set => mavongdau = value; }
        public string TenVongDau { get => tenvongdau; set => tenvongdau = value; }
    }
}
