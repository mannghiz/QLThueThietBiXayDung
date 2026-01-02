using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace QLThueThietBiXayDung.DAL
{
    public class PhieuTraDAL : BaseDAL
    {
        public List<PhieuTra> Search(int? employeeId)
        {
            var query = db.PhieuTras.AsNoTracking()
                .Include(p => p.PhieuThue)
                .Include(p => p.NhanVien)
                .Include(p => p.ChiTietPhieuTras.Select(ct => ct.ThietBi))
                .AsQueryable();
            if (employeeId.HasValue)
            {
                query = query.Where(p => p.MaNV == employeeId.Value);
            }
            return query.ToList();
        }

        public PhieuTra GetById(int id)
        {
            return db.PhieuTras
                .AsNoTracking()
                .Include(p => p.PhieuThue)
                .Include(p => p.NhanVien)
                .Include(p => p.ChiTietPhieuTras.Select(ct => ct.ThietBi))
                .FirstOrDefault(p => p.MaPhieuTra == id);
        }

        public List<PhieuTra> GetAll()
        {
            return db.PhieuTras
                .AsNoTracking()
                .Include(p => p.PhieuThue)
                .Include(p => p.NhanVien)
                .Include(p => p.ChiTietPhieuTras.Select(ct => ct.ThietBi))
                .ToList();
        }

        public void CreateOrUpdate(PhieuTra phieuTra)
        {
            using (var tran = db.Database.BeginTransaction())
            {
                try
                {
                    if (phieuTra.MaPhieuTra == 0)
                        db.PhieuTras.Add(phieuTra);
                    else
                    {
                        var oldPhieuTra = db.PhieuTras
                            .FirstOrDefault(p => p.MaPhieuTra == phieuTra.MaPhieuTra);

                       if (oldPhieuTra != null)
                       {
                            db.Entry(oldPhieuTra).CurrentValues.SetValues(phieuTra);
                       } 

                        var oldCT = db.ChiTietPhieuTras
                            .Where(x => x.MaPhieuTra == phieuTra.MaPhieuTra)
                            .ToList();

                        db.ChiTietPhieuTras.RemoveRange(oldCT);

                        foreach (var ct in phieuTra.ChiTietPhieuTras)
                        {
                            var newCTPhieuTra = new ChiTietPhieuTra
                            {
                                MaTB = ct.MaTB,
                                SoLuongTra = ct.SoLuongTra,
                                TinhTrang = ct.TinhTrang,
                                PhatThem = ct.PhatThem,
                                GhiChu = ct.GhiChu
                            };
                            newCTPhieuTra.MaPhieuTra = phieuTra.MaPhieuTra;
                            db.ChiTietPhieuTras.Add(newCTPhieuTra);
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

        public void Delete(int maPhieuTra)
        {
            var phieuTra = db.PhieuTras
                .FirstOrDefault(p => p.MaPhieuTra == maPhieuTra);

            if (phieuTra != null)
            {
                db.PhieuTras.Remove(phieuTra);
                db.SaveChanges();
            }
        }
        public void UpdatePaymentStatus(int id, bool status)
        {
            var item = db.PhieuTras.Find(id);
            if (item != null)
            {
                item.DaThanhToan = status;
                db.SaveChanges();
            }
        }
    }
}
