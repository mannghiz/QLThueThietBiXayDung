using QLThueThietBiXayDung.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThueThietBiXayDung.DAL
{
    public class BaoCaoNhapXuatTonDAL : BaseDAL
    {
        public BaoCaoNhapXuatTonDAL()
        {
            
        }

        public List<BaoCaoNhapXuatTonEntity> ThongKeXuatNhapTon()
        {
            string sql = @"SELECT 
                t.MaTB,
                t.TenThietBi,
                ISNULL(nhap.TongNhap, 0) AS TongNhap,
                ISNULL(thue.TongThue, 0) AS ChoThue,
                ISNULL(tra.TongTra, 0) AS DaTra,
                ISNULL(thue.TongThue, 0) - ISNULL(tra.TongTra, 0) AS ChuaTra,
                t.SoLuongTonKho AS TonKho
            FROM 
                dbo.ThietBi t
            LEFT JOIN 
                (SELECT MaTB, SUM(SoLuongNhap) AS TongNhap 
                 FROM dbo.ChiTietPhieuNhap 
                 GROUP BY MaTB) nhap
                ON t.MaTB = nhap.MaTB
            LEFT JOIN 
                (SELECT MaTB, SUM(SoLuongThue) AS TongThue 
                 FROM dbo.ChiTietPhieuThue 
                 GROUP BY MaTB) thue
                ON t.MaTB = thue.MaTB
            LEFT JOIN 
                (SELECT MaTB, SUM(SoLuongTra) AS TongTra 
                 FROM dbo.ChiTietPhieuTra 
                 GROUP BY MaTB) tra
                ON t.MaTB = tra.MaTB
            ORDER BY 
                t.MaTB;";

            return db.Database.SqlQuery<BaoCaoNhapXuatTonEntity>(sql).ToList();
        }
    }
}
