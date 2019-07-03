using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBDDTO
{
    public class KetQuaTranDauDTO
    {
        private int maketqua;
        private int sobtdoinha;
        private int sobtdoikhach;
        private int matrandau;
        public int MaKetQua { get => maketqua; set => maketqua = value; }
        public int SoBTDoiNha { get => sobtdoinha; set => sobtdoinha = value; }
        public int SoBTDoiKhach { get => sobtdoikhach; set => sobtdoikhach = value; }
        public int MaTranDau { get => matrandau; set => matrandau = value; }

    }
}
