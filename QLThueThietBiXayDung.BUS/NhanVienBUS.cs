using System.Collections.Generic;
using System.Linq;
using QLThueThietBiXayDung.DAL;

namespace QLThueThietBiXayDung.BUS
{
    public class NhanVienBUS
    {
        private readonly NhanVienDAL _dal = new NhanVienDAL();

        public NhanVien GetById(int id)
        {
            return _dal.GetById(id);
        }

        public List<NhanVien> GetAll()
        {
            return _dal.GetAll();
        }

        public void Create(NhanVien nv)
        {
            if (string.IsNullOrEmpty(nv.MaTK))
                throw new System.Exception("Mã tài khoản không được rỗng");

            _dal.Create(nv);
        }

        public void Update(NhanVien nv)
        {
            _dal.Update(nv);
        }

        public void Delete(int id)
        {
            _dal.Delete(id);
        }

        public List<NhanVien> Search(string keyword)
        {
            return _dal.Search(keyword);
        }

        public NhanVien Login(string maTK, string matKhau)
        {
            return _dal.GetAll()
                       .FirstOrDefault(x => x.MaTK == maTK && x.MatKhau == matKhau);
        }
    }
}
