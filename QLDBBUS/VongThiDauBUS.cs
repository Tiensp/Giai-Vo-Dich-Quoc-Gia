using QLBDDTO;
using QLBDDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
        public bool lammoi()
        {
            bool re = vtdDAL.lammoi();
            return re;
        }
        public List<VongThiDauDTO> load()
        {
            return vtdDAL.Load();
        }
        public DataTable hienthi(string mavongdau)
        {
            return vtdDAL.hienthi(mavongdau);
        }
    }
}
