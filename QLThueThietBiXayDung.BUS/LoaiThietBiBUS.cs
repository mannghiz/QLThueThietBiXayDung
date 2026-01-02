using QLThueThietBiXayDung.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThueThietBiXayDung.BUS
{
    public class LoaiThietBiBUS
    {
        LoaiThietBiDAL _dal = new LoaiThietBiDAL();

        public LoaiThietBi GetById(int id)
        {
            return _dal.GetById(id);
        }
        public List<LoaiThietBi> GetAll()
        {
            return _dal.GetAll();
        }

        public void Create(LoaiThietBi entity)
        {
            if (string.IsNullOrEmpty(entity.TenLoai))
                throw new Exception("Tên loại thiết bị không được rỗng");
            _dal.Create(entity);
        }

        public void Update(LoaiThietBi entity)
        {
            _dal.Update(entity);
        }

        public void Delete(int id)
        {
            _dal.Delete(id);
        }

        public List<LoaiThietBi> Search(string keyword)
        {
            return _dal.Search(keyword);
        }
    }
}
