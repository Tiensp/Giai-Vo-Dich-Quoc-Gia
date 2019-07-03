using QLBDDTO;

using QLBDDAL;

using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using System.Data.SqlClient;



namespace QLBDBUS

{

    public class ThamSoBUS

    {

        private ThamSoDAL tsDAL;

        public ThamSoBUS()

        {

            tsDAL = new ThamSoDAL();

        }

        public void deleteData()

        {

            tsDAL.deleteData();

            return;

        }

        public bool addData(ThamSoDTO ts)

        {

            bool re = tsDAL.addData(ts);

            return re;

        }

        public ThamSoDTO getData(string id)

        {

            ThamSoDTO tsDTO = tsDAL.getData(id);

            return tsDTO;

        }

        public List<string> getTTXH(string id)

        {

            List<string> list = tsDAL.getTTXH(id);

            return list;

        }

    }

}