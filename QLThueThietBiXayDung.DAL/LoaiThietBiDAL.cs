using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThueThietBiXayDung.DAL
{
    public class LoaiThietBiDAL : BaseDAL
    {
        public List<LoaiThietBi> GetAll()
        {
            return db.LoaiThietBis.ToList();
        }

        public LoaiThietBi GetById(int id)
        {
            return db.LoaiThietBis.FirstOrDefault(x => x.MaLoai == id);
        }

        public void Create(LoaiThietBi entity)
        {
            db.LoaiThietBis.Add(entity);
            db.SaveChanges();
        }

        public void Update(LoaiThietBi entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var obj = db.LoaiThietBis.Find(id);
            if (obj != null)
            {
                db.LoaiThietBis.Remove(obj);
                db.SaveChanges();
            }
        }

        public List<LoaiThietBi> Search(string keyword)
        {
            return db.LoaiThietBis
                .Where(x => x.TenLoai.Contains(keyword))
                .ToList();
        }
    }
}
