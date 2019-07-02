using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBDDTO
{
    public class KetQuaTranDauDTO
    {
        private string maketqua;
        private int sobtdoinha;
        private int sobtdoikhach;
        private string matrandau;
        public string MaKetQua { get => maketqua; set => maketqua = value; }
        public int SoBTDoiNha { get => sobtdoinha; set => sobtdoinha = value; }
        public int SoBTDoiKhach { get => sobtdoikhach; set => sobtdoikhach = value; }
        public string MaTranDau { get => matrandau; set => matrandau = value; }

    }
}
