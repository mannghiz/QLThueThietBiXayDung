using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThueThietBiXayDung.DAL.Entity
{
    public class BaoCaoNhapXuatTonEntity
    {
        public int MaTB { get; set; }
        public string TenThietBi { get; set; }
        public int TongNhap { get; set; }
        public int ChoThue { get; set; }
        public int DaTra { get; set; }
        public int ChuaTra { get; set; }
        public int TonKho { get; set; }
    }
}
