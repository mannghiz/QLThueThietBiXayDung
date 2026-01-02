using QLThueThietBiXayDung.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThueThietBiXayDung.DAL
{
    public class ThongKeDoanhThuDAL : BaseDAL
    {
        public List<DoanhThuTheoKhachHangEntity> ThongKeDoanhThuTheoKhachHang()
        {
            string sql = @"SELECT 
                    kh.MaKH,
                    kh.HoTen,
                    SUM(ISNULL(ctthue.ThanhTienDuKien, 0) + ISNULL(cttra.PhatThem, 0)) AS DoanhThu
                FROM 
                    dbo.KhachHang kh
                LEFT JOIN 
                    dbo.PhieuThue pt ON kh.MaKH = pt.MaKH
                LEFT JOIN 
                    dbo.ChiTietPhieuThue ctthue ON pt.MaPhieuThue = ctthue.MaPhieuThue
                LEFT JOIN 
                    dbo.PhieuTra ptr ON pt.MaPhieuThue = ptr.MaPhieuThue
                LEFT JOIN 
                    dbo.ChiTietPhieuTra cttra ON ptr.MaPhieuTra = cttra.MaPhieuTra AND ctthue.MaTB = cttra.MaTB
                GROUP BY 
                    kh.MaKH, kh.HoTen
                ORDER BY 
                    kh.MaKH;";
            return db.Database.SqlQuery<DoanhThuTheoKhachHangEntity>(sql).ToList();
        }

        public List<DoanhThuTheoThietBiEntity> ThongKeDoanhThuTheoThietBi()
        {
            string sql = @"SELECT 
            t.MaTB,
            t.TenThietBi,
            SUM(ISNULL(ctthue.ThanhTienDuKien, 0) + ISNULL(cttra.PhatThem, 0)) AS DoanhThu
        FROM 
            dbo.ThietBi t
        LEFT JOIN 
            dbo.ChiTietPhieuThue ctthue ON t.MaTB = ctthue.MaTB
        LEFT JOIN 
            dbo.PhieuThue pt ON ctthue.MaPhieuThue = pt.MaPhieuThue
        LEFT JOIN 
            dbo.PhieuTra ptr ON pt.MaPhieuThue = ptr.MaPhieuThue
        LEFT JOIN 
            dbo.ChiTietPhieuTra cttra ON ptr.MaPhieuTra = cttra.MaPhieuTra AND t.MaTB = cttra.MaTB
        GROUP BY 
            t.MaTB, t.TenThietBi
        ORDER BY 
            t.MaTB;";
            return db.Database.SqlQuery<DoanhThuTheoThietBiEntity>(sql).ToList();
        }
    }
}
