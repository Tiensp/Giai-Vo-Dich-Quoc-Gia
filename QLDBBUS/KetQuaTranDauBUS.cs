using QLBDDTO;
using QLBDDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBDBUS
{
    public class KetQuaTranDauBUS
    {
        private KetQuaTranDauDAL kqtdDAL;
        public KetQuaTranDauBUS()
        {
            kqtdDAL = new KetQuaTranDauDAL();
        }
        public bool them(KetQuaTranDauDTO kqtd)
        {
            bool re = kqtdDAL.them(kqtd);
            return re;
        }
        public bool lammoi()
        {
            bool re = kqtdDAL.lammoi();
            return re;
        }


        public List<KetQuaTranDauDTO> load()
        {
            return kqtdDAL.Load();
        }

    }
}
