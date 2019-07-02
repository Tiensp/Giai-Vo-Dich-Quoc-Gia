using QLBDDTO;
using QLBDDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

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
        public DataSet getData()
        {
            DataSet ds = lctDAL.getData();
            return ds;
        }
    }
}
