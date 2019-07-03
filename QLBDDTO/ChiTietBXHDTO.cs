using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;



namespace QLBDDTO

{

    public class ChiTietBXHDTO

    {

        private string mactbxh;

        private string madoibong;

        private string mabxh;

        private int thang;

        private int hoa;

        private int thua;

        private int hieuso;

        private int diem;

        private int hang;

        private int tongsbt;



        public string MaCTBXH { get => mactbxh; set => mactbxh = value; }

        public string MaDoiBong { get => madoibong; set => madoibong = value; }

        public string MaBXH { get => mabxh; set => mabxh = value; }

        public int Thang { get => thang; set => thang = value; }

        public int Hoa { get => hoa; set => hoa = value; }

        public int Thua { get => thua; set => thua = value; }

        public int HieuSo { get => hieuso; set => hieuso = value; }

        public int Diem { get => diem; set => diem = value; }

        public int Hang { get => hang; set => hang = value; }

        public int TongSBT { get => tongsbt; set => tongsbt = value; }

    }

}