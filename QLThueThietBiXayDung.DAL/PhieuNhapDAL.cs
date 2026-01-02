using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace QLThueThietBiXayDung.DAL
{
    public class PhieuNhapDAL : BaseDAL
    {
        public List<PhieuNhap> Search(DateTime? fromDate, DateTime? toDate, int? employeeId)
        {
            var query = db.PhieuNhaps.AsNoTracking()
                .Include(p => p.NhanVien)
                .Include(p => p.ChiTietPhieuNhaps.Select(ct => ct.ThietBi))
                .AsQueryable();
            if (fromDate.HasValue)
            {
                query = query.Where(p => DbFunctions.TruncateTime(p.NgayNhap) >= DbFunctions.TruncateTime(fromDate.Value));
            }
            if (toDate.HasValue)
            {
                query = query.Where(p => DbFunctions.TruncateTime(p.NgayNhap) <= DbFunctions.TruncateTime(toDate.Value));
            }
            if (employeeId.HasValue)
            {
                query = query.Where(p => p.MaNV == employeeId.Value);
            }
            return query.ToList();
        }

        public PhieuNhap GetById(int id)
        {
            return db.PhieuNhaps.AsNoTracking()
                .Include(p => p.NhanVien)
                .Include(p => p.ChiTietPhieuNhaps.Select(ct => ct.ThietBi))
                .FirstOrDefault(p => p.MaPhieuNhap == id);
        }

        public List<PhieuNhap> GetAll()
        {
            return db.PhieuNhaps.AsNoTracking()
                .Include(p => p.NhanVien)
                .Include(p => p.ChiTietPhieuNhaps.Select(ct => ct.ThietBi))
                .ToList();
        }

        public void CreateOrUpdate(PhieuNhap phieuNhap)
        {
            using (var tran = db.Database.BeginTransaction())
            {
                try
                {
                    if (phieuNhap.MaPhieuNhap == 0)
                    {
                        db.PhieuNhaps.Add(phieuNhap);
                    }
                    else
                    {
                        var oldPhieu = db.PhieuNhaps
                            .FirstOrDefault(x => x.MaPhieuNhap == phieuNhap.MaPhieuNhap);

                        if (oldPhieu != null)
                        {
                            db.Entry(oldPhieu).CurrentValues.SetValues(phieuNhap);
                        }    
                        
                        oldPhieu.TongGiaNhap = phieuNhap.ChiTietPhieuNhaps.Sum(x => x.ThanhTien) ?? 0;

                        db.Entry(oldPhieu).State = EntityState.Modified;

                        var oldDetails = db.ChiTietPhieuNhaps
                            .Where(x => x.MaPhieuNhap == phieuNhap.MaPhieuNhap)
                            .ToList();

                        db.ChiTietPhieuNhaps.RemoveRange(oldDetails);

                        foreach (var ct in phieuNhap.ChiTietPhieuNhaps)
                        {
                            var newCT = new ChiTietPhieuNhap
                            {
                                MaTB = ct.MaTB,
                                SoLuongNhap = ct.SoLuongNhap,
                                GiaNhap = ct.GiaNhap,
                                ThanhTien = ct.ThanhTien,
                                GhiChu = ct.GhiChu
                            };
                            newCT.MaPhieuNhap = phieuNhap.MaPhieuNhap;
                            db.ChiTietPhieuNhaps.Add(newCT);
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
            var pn = db.PhieuNhaps
                .Include(x => x.ChiTietPhieuNhaps)
                .FirstOrDefault(x => x.MaPhieuNhap == id);

            if (pn != null)
            {
                db.ChiTietPhieuNhaps.RemoveRange(pn.ChiTietPhieuNhaps);
                db.PhieuNhaps.Remove(pn);
                db.SaveChanges();
            }
        }
    }
}
