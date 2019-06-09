using QLBDDTO;
using QLBDDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBDBUS
{
        public class BanThangBUS
        {
            private BanThangDAL btDAL;
            public BanThangBUS()    
            {
                btDAL = new BanThangDAL();
            }
            public bool them(BanThangDTO bt)
            {
                bool re = btDAL.them(bt);
                return re;
            }
        
    }
}
