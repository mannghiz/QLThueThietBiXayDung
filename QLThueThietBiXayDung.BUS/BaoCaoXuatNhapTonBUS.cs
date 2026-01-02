using QLThueThietBiXayDung.DAL;
using QLThueThietBiXayDung.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThueThietBiXayDung.BUS
{
    public class BaoCaoXuatNhapTonBUS
    {
        private readonly BaoCaoNhapXuatTonDAL _baoCaoXuatNhapTonDAL = new BaoCaoNhapXuatTonDAL();

        public List<BaoCaoNhapXuatTonEntity> ThongKeXuatNhapTon()
        {
            return _baoCaoXuatNhapTonDAL.ThongKeXuatNhapTon();
        }
    }
}
