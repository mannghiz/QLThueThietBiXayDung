using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace QLThueThietBiXayDung.DAL
{
    public class NhanVienDAL : BaseDAL
    {
        public NhanVien GetById(int id)
        {
            return db.NhanViens
                    .AsNoTracking()
                     .Include(x => x.ChucVu)
                     .FirstOrDefault(x => x.MaNV == id);
        }

        public List<NhanVien> GetAll()
        {
            return db.NhanViens
                .AsNoTracking()
                     .Include(x => x.ChucVu)
                     .ToList();
        }

        public void Create(NhanVien entity)
        {
            db.NhanViens.Add(entity);
            db.SaveChanges();
        }

        public void Update(NhanVien entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var nv = db.NhanViens.Find(id);
            if (nv != null)
            {
                db.NhanViens.Remove(nv);
                db.SaveChanges();
            }
        }

        public List<NhanVien> Search(string keyword)
        {
            return db.NhanViens
                .Include(x => x.ChucVu)
                .Where(x => x.HoTen.Contains(keyword)
                         || x.MaTK.Contains(keyword))
                .ToList();
        }
    }
}
