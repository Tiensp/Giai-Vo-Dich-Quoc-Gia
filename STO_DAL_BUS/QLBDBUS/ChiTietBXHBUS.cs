using QLBDDTO;
using QLBDDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBDBUS
{
    public class ChiTietBXHBUS
    {
        private ChiTietBXHDAL ctbxhDAL;
        public ChiTietBXHBUS()
        {
            ctbxhDAL = new ChiTietBXHDAL();
        }
        public bool them(ChiTietBXHDTO ctbxh)
        {
            bool re = ctbxhDAL.them(ctbxh);
            return re;
        }
    }
}
