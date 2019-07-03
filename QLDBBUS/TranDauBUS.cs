﻿using QLBDDTO;
using QLBDDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBDBUS
{
    public class TranDauBUS
    {
        private TranDauDAL tdDAL;
        public TranDauBUS()
        {
            tdDAL = new TranDauDAL();
        }
        public bool them(TranDauDTO td)
        {
            bool re = tdDAL.them(td);
            return re;
        }
        public bool lammoi()
        {
            bool re = tdDAL.lammoi();
            return re;
        }

        public List<TranDauDTO> load()
        {
            return tdDAL.Load();
        }
        public void xoa(TranDauDTO td)
        {
            tdDAL.xoa(td);
        }

        public void capnhat(TranDauDTO td)
        {
            tdDAL.capnhat(td);
        }

    }
}