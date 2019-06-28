using QLBDDTO;
using QLBDDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBDBUS
{
    public class DoiBongBUS
    {
        private DoiBongDAL dbDAL;
        public DoiBongBUS()
        {
            dbDAL = new DoiBongDAL();
        }
        public bool them(DoiBongDTO db)
        {
            bool re = dbDAL.them(db);
            return re;
        }

        public bool capnhat(DoiBongDTO db)
        {
            bool re = dbDAL.capnhat(db); ;
            return re;
        }

        public List<DoiBongDTO> load()
        {
            List<DoiBongDTO> db = dbDAL.Load();
            return db;
        }

        public bool lammoi()
        {
            bool re = dbDAL.lammoi();
            return re;
        }
    }
}
