using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBDDTO
{
    public class ChiTietBXHDTO
    {
        private int mactbxh;
        private int madoibong;
        private int mabxh;
        private int thang;
        private int hoa;
        private int thua;
        private int hieuso;
        private int diem;
        private int hang;
        private int tongsbt;

        public int MaCTBXH { get => mactbxh; set => mactbxh = value; }
        public int MaDoiBong { get => madoibong; set => madoibong = value; }
        public int MaBXH { get => mabxh; set => mabxh = value; }
        public int Thang { get => thang; set => thang = value; }
        public int Hoa { get => hoa; set => hoa = value; }
        public int Thua { get => thua; set => thua = value; }
        public int HieuSo { get => hieuso; set => hieuso = value; }
        public int Diem { get => diem; set => diem = value; }
        public int Hang { get => hang; set => hang = value; }
        public int TongSBT { get => tongsbt; set => tongsbt = value; }
    }
}
