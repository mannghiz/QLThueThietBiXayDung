using QLThueThietBiXayDung.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThueThietBiXayDung.BUS
{
    public class KhachHangBUS
    {
        KhachHangDAL _dal = new KhachHangDAL();

        public KhachHang GetById(int id)
        {
            return _dal.GetById(id);
        }

        public List<KhachHang> GetAll()
        {
            return _dal.GetAll();
        }

        public void Create(KhachHang entity)
        {
            if (string.IsNullOrEmpty(entity.HoTen))
                throw new Exception("Tên khách hàng không được rỗng");
            _dal.Create(entity);
        }

        public void Update(KhachHang entity)
        {
            _dal.Update(entity);
        }

        public void Delete(int id)
        {
            _dal.Delete(id);
        }

        public List<KhachHang> Search(string keyword)
        {
            return _dal.Search(keyword);
        }
    }
}
