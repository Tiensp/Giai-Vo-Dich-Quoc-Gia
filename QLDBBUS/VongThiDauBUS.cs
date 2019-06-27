using QLBDDTO;
using QLBDDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBDBUS
{
    public class VongThiDauBUS
    {
        private VongThiDauDAL vtdDAL;
        public VongThiDauBUS()
        {
            vtdDAL = new VongThiDauDAL();
        }
        public bool them(VongThiDauDTO vtd)
        {
            bool re = vtdDAL.them(vtd);
            return re;
        }
    }
}
