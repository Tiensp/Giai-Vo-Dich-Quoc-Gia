using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBDDTO
{
    public class TranDauDTO
    {
        private int matrandau;
        private int madoinha;
        private int madoikhach;
        private int mavongdau;
        private DateTime thoigian;

        public int MaTranDau { get => matrandau; set => matrandau = value; }
        public int MaDoiNha { get => madoinha; set => madoinha = value; }
        public int MaDoiKhach { get => madoikhach; set => madoikhach = value; }
        public int MaVongDau { get => mavongdau; set => mavongdau = value; }
        public DateTime ThoiGian { get => thoigian ; set => thoigian = value; }

    }
}
