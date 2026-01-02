using QLThueThietBiXayDung.DAL;
using QLThueThietBiXayDung.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThueThietBiXayDung.BUS
{
    public class ThongKeDoanhThuBUS
    {
        private readonly ThongKeDoanhThuDAL _thongKeDoanhThuDAL = new ThongKeDoanhThuDAL();

        public List<DoanhThuTheoKhachHangEntity> ThongKeDoanhThuTheoKhachHang()
        {
            return _thongKeDoanhThuDAL.ThongKeDoanhThuTheoKhachHang();
        }

        public List<DoanhThuTheoThietBiEntity> ThongKeDoanhThuTheoThietBi()
        {
            return _thongKeDoanhThuDAL.ThongKeDoanhThuTheoThietBi();
        }
    }
}
