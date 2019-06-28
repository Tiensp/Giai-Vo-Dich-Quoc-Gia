using QLBDDTO;
using QLBDDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBDBUS
{
    public class CauThuBUS
    {
        private CauThuDAL ctDAL;
        public CauThuBUS()
        {
            ctDAL = new CauThuDAL();
        }
        public bool them(CauThuDTO ct)
        {
            bool re = ctDAL.them(ct);
            return re;
        }

        public void capnhat(CauThuDTO ct)
        {
            ctDAL.capnhat(ct);
        }

        public void xoa(CauThuDTO ct)
        {
            ctDAL.xoa(ct);
        }

        public void resettongbt(CauThuDTO ct)
        {
            ctDAL.resettongbt(ct);
        }

        public bool lammoi()
        {
            bool re = ctDAL.lammoi();
            return re;
        }

        public List<CauThuDTO> loadcauthu()
        {
            List<CauThuDTO> ct = ctDAL.Loadcauthu();
            return ct;
        }

    }
}
