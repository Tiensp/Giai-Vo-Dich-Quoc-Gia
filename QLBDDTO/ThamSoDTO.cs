using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;



namespace QLBDDTO

{

    public class ThamSoDTO

    {

        private string mathamso;

        private int tuoictmin;

        private int tuoictmax;

        private int soluongctmin;

        private int soluongctmax;

        private int soctngoaimax;

        private int tgghibanmax;

        private int diemthang;

        private int diemhoa;

        private int diemthua;

        private int diem;

        private int hieuso;

        private int btsk;

        private int kqdk;

        public string MaThamSo { get => mathamso; set => mathamso = value; }

        public int TuoiCTMin { get => tuoictmin; set => tuoictmin = value; }

        public int TuoiCTMax { get => tuoictmax; set => tuoictmax = value; }

        public int SoLuongCTMin { get => soluongctmin; set => soluongctmin = value; }

        public int SoLuongCTMax { get => soluongctmax; set => soluongctmax = value; }

        public int SoCTNgoaiMax { get => soctngoaimax; set => soctngoaimax = value; }

        public int TGGhiBanMax { get => tgghibanmax; set => tgghibanmax = value; }

        public int DiemThang { get => diemthang; set => diemthang = value; }

        public int DiemHoa { get => diemhoa; set => diemhoa = value; }

        public int DiemThua { get => diemthua; set => diemthua = value; }

        public int Diem { get => diem; set => diem = value; }

        public int HieuSo { get => hieuso; set => hieuso = value; }

        public int BTSK { get => btsk; set => btsk = value; }

        public int KQDK { get => kqdk; set => kqdk = value; }

    }

}