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
    }
}
