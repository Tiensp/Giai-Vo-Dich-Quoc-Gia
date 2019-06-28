using QLBDDTO;
using QLBDDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBDBUS
{
    public class LoaiCauThuBUS
    {
        private LoaiCauThuDAL lctDAL;
        public LoaiCauThuBUS()
        {
            lctDAL = new LoaiCauThuDAL();
        }
        public bool them(LoaiCauThuDTO lct)
        {
            bool re = lctDAL.them(lct);
            return re;
        }

        public List<LoaiCauThuDTO> loadLoaiCT()
        {
            List<LoaiCauThuDTO> LoaiCT = lctDAL.loadLoaiCT();
            return LoaiCT;
        }
        public bool lammoi()
        {
            bool re = lctDAL.lammoi();
            return re;
        }


    }
}
