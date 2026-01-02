using System.Collections.Generic;
using System.Linq;

namespace QLThueThietBiXayDung.DAL
{
    public class ChucVuDAL : BaseDAL
    {
        public ChucVu GetById(int id)
        {
            return db.ChucVus.Find(id);
        }

        public List<ChucVu> GetAll()
        {
            return db.ChucVus
                .AsNoTracking()
                .ToList();
        }

        public void Create(ChucVu entity)
        {
            db.ChucVus.Add(entity);
            db.SaveChanges();
        }

        public void Update(ChucVu entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var obj = db.ChucVus.Find(id);
            if (obj != null)
            {
                db.ChucVus.Remove(obj);
                db.SaveChanges();
            }
        }

        public List<ChucVu> Search(string keyword)
        {
            return db.ChucVus
                .AsNoTracking()
                .Where(x => x.TenChucVu.Contains(keyword))
                .ToList();
        }
    }
}
