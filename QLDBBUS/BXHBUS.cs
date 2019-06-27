using QLBDDTO;
using QLBDDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBDBUS
{
    public class BXHBUS
    {
        private BXHDAL bxhDAL;
        public BXHBUS()
        {
            bxhDAL = new BXHDAL();
        }
        public bool them(BXHDTO bxh)
        {
            bool re = bxhDAL.them(bxh);
            return re;
        }
    }
}
