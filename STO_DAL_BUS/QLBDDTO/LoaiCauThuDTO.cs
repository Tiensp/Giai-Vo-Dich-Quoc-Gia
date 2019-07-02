using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBDDTO
{
    public class LoaiCauThuDTO
    {
        private string maloaict;
        private string loaicauthu;
        public string MaLoaiCT { get => maloaict; set => maloaict = value; }
        public string LoaiCauThu { get => loaicauthu ; set => loaicauthu = value; }
    }
}
