using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThueThietBiXayDung.DAL
{
    public class KhachHangDAL : BaseDAL
    {
        public List<KhachHang> GetAll()
        {
            return db.KhachHangs
                .AsNoTracking()
                .ToList();
        }
        public KhachHang GetById(int id)
        {
            return db.KhachHangs.FirstOrDefault(x => x.MaKH == id);
        }
        public void Create(KhachHang entity)
        {
            db.KhachHangs.Add(entity);
            db.SaveChanges();
        }
        public void Update(KhachHang entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var obj = db.KhachHangs.Find(id);
            if (obj != null)
            {
                db.KhachHangs.Remove(obj);
                db.SaveChanges();
            }
        }
        public List<KhachHang> Search(string keyword)
        {
            return db.KhachHangs
                .AsNoTracking()
                .Where(x => x.HoTen.Contains(keyword) || x.Email.Contains(keyword) || x.DiaChi.Contains(keyword))
                .ToList();
        }
    }
}
