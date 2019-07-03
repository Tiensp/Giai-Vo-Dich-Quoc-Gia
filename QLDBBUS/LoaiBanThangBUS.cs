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
    public class LoaiBanThangBUS
    {
        private LoaiBanThangDAL lbtDAL;
        public LoaiBanThangBUS()
        {
            lbtDAL = new LoaiBanThangDAL();
        }
        public bool them(LoaiBanThangDTO lbt)
        {
            bool re = lbtDAL.them(lbt);
            return re;
        }
        public bool lammoi()
        {
            bool re = lbtDAL.lammoi();
            return re;
        }

        public DataSet getData()

        {

            DataSet ds = lbtDAL.getData();

            return ds;

        }

        public void deleteData()

        {

            lbtDAL.deleteData();

            return;

        }


    }
}
