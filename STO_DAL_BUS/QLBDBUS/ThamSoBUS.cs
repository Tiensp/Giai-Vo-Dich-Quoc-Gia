using QLBDDTO;
using QLBDDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBDBUS
{
    public class ThamSoBUS
    {
        private ThamSoDAL tsDAL;
        public ThamSoBUS()
        {
            tsDAL = new ThamSoDAL();
        }
        public bool them(ThamSoDTO ts)
        {
            bool re = tsDAL.them(ts);
            return re;
        }
    }
}
