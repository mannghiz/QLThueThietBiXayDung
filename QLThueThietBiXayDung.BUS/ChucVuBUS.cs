using System.Collections.Generic;
using QLThueThietBiXayDung.DAL;

namespace QLThueThietBiXayDung.BUS
{
    public class ChucVuBUS
    {
        private readonly ChucVuDAL _dal = new ChucVuDAL();

        public ChucVu GetById(int id)
        {
            return _dal.GetById(id);
        }

        public List<ChucVu> GetAll()
        {
            return _dal.GetAll();
        }

        public void Create(ChucVu chucVu)
        {
            _dal.Create(chucVu);
        }

        public void Update(ChucVu chucVu)
        {
            _dal.Update(chucVu);
        }

        public void Delete(int id)
        {
            _dal.Delete(id);
        }

        public List<ChucVu> Search(string keyword)
        {
            return _dal.Search(keyword);
        }
    }
}
