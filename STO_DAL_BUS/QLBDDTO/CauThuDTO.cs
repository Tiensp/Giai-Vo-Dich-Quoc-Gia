using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBDDTO
{
    public class CauThuDTO
    {
        private string macauthu;
        private string tencauthu;
        private DateTime ngaysinh;
        private string ghichu;
        private int tongsobt;
        private int tuoi;
        private string maloaict;
        private string madoibong;
        public string MaCauThu { get => macauthu; set => macauthu = value; }
        public string TenCauThu { get => tencauthu; set => tencauthu = value; }
        public DateTime NgaySinh { get => ngaysinh; set => ngaysinh = value; }
        public string GhiChu { get => ghichu; set => ghichu = value; }
        public int TongSoBT { get => tongsobt; set => tongsobt = value; }
        public int TuoiCauThu { get => tuoi; set => tuoi = value; }
        public string MaLoaiCT { get => maloaict; set => maloaict = value; }
        public string MaDoiBong { get => madoibong ; set => madoibong = value; }
    }
}
