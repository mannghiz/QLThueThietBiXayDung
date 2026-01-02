using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace QLThueThietBiXayDung.DAL
{
    public class ThietBiDAL : BaseDAL
    {
        public ThietBi GetById(int id)
        {
            return db.ThietBis
                .AsNoTracking()
                     .Include(x => x.LoaiThietBi)
                     .FirstOrDefault(x => x.MaTB == id);
        }

        public List<ThietBi> GetAll()
        {
            return db.ThietBis
                .AsNoTracking()
                     .Include(x => x.LoaiThietBi)
                     .ToList();
        }

        public void Create(ThietBi entity)
        {
            db.ThietBis.Add(entity);
            db.SaveChanges();
        }

        public void Update(ThietBi entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var tb = db.ThietBis.Find(id);
            if (tb != null)
            {
                db.ThietBis.Remove(tb);
                db.SaveChanges();
            }
        }

        public List<ThietBi> Search(string keyword)
        {
            return db.ThietBis
                .AsNoTracking()
                .Include(x => x.LoaiThietBi)
                .Where(x => x.TenThietBi.Contains(keyword)
                         || x.SerialNumber.Contains(keyword))
                .ToList();
        }
    }
}
