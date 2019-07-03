using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;



namespace QLBDDTO

{

    public class TranDauDTO

    {

        private string matrandau;

        private string madoinha;

        private string madoikhach;

        private string mavongdau;

        private DateTime thoigian;



        public string MaTranDau { get => matrandau; set => matrandau = value; }

        public string MaDoiNha { get => madoinha; set => madoinha = value; }

        public string MaDoiKhach { get => madoikhach; set => madoikhach = value; }

        public string MaVongDau { get => mavongdau; set => mavongdau = value; }

        public DateTime ThoiGian { get => thoigian; set => thoigian = value; }



    }

}