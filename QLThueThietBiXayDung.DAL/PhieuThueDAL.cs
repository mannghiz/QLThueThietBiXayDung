using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace QLThueThietBiXayDung.DAL
{
    public class PhieuThueDAL : BaseDAL
    {
        public List<PhieuThue> Search(int? customerId, int? employeeId)
        {
            var query = db.PhieuThues.AsNoTracking()
                .Include(p => p.KhachHang)
                .Include(p => p.NhanVien)
                .Include(p => p.ChiTietPhieuThues.Select(ct => ct.ThietBi))
                .AsQueryable();
            if (customerId.HasValue)
            {
                query = query.Where(p => p.MaKH == customerId.Value);
            }
            if (employeeId.HasValue)
            {
                query = query.Where(p => p.MaNV == employeeId.Value);
            }
            return query.ToList();
        }

        public PhieuThue GetById(int id)
        {
            return db.PhieuThues
                .AsNoTracking()
                .Include(p => p.KhachHang)
                .Include(p => p.NhanVien)
                .Include(p => p.ChiTietPhieuThues.Select(ct => ct.ThietBi))
                .FirstOrDefault(p => p.MaPhieuThue == id);
        }

        public List<PhieuThue> GetAll()
        {
            return db.PhieuThues.AsNoTracking()
                .Include(p => p.KhachHang)
                .Include(p => p.NhanVien)
                .Include(p => p.ChiTietPhieuThues.Select(ct => ct.ThietBi))
                .ToList();
        }

        public void CreateOrUpdate(PhieuThue phieuThue)
        {
            using (var tran = db.Database.BeginTransaction())
            {
                try
                {
                    if (phieuThue.MaPhieuThue == 0)
                        db.PhieuThues.Add(phieuThue);
                    else
                    {
                        var oldPhieuThue = db.PhieuThues
                            .FirstOrDefault(x => x.MaPhieuThue == phieuThue.MaPhieuThue);

                        if (oldPhieuThue != null)
                        {
                            db.Entry(oldPhieuThue).CurrentValues.SetValues(phieuThue);
                        } 

                        var oldCT = db.ChiTietPhieuThues
                            .Where(x => x.MaPhieuThue == phieuThue.MaPhieuThue)
                            .ToList();

                        db.ChiTietPhieuThues.RemoveRange(oldCT);


                        foreach (var ct in phieuThue.ChiTietPhieuThues)
                        {
                            var newCT = new ChiTietPhieuThue()
                            {
                                MaTB = ct.MaTB,
                                SoLuongThue = ct.SoLuongThue,
                                GiaThueNgay = ct.GiaThueNgay,
                                ThanhTienDuKien = ct.ThanhTienDuKien,
                                GhiChu = ct.GhiChu
                            };
                            newCT.MaPhieuThue = phieuThue.MaPhieuThue;
                            db.ChiTietPhieuThues.Add(newCT);
                        }
                    }


                    db.SaveChanges();
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        public void Delete(int id)
        {
            var pt = db.PhieuThues
                .Include(x => x.ChiTietPhieuThues)
                .FirstOrDefault(x => x.MaPhieuThue == id);

            if (pt != null)
            {
                db.ChiTietPhieuThues.RemoveRange(pt.ChiTietPhieuThues);
                db.PhieuThues.Remove(pt);
                db.SaveChanges();
            }
        }
    }
}
