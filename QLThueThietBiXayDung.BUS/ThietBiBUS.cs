using System.Collections.Generic;
using QLThueThietBiXayDung.DAL;

namespace QLThueThietBiXayDung.BUS
{
    public class ThietBiBUS
    {
        private readonly ThietBiDAL _dal = new ThietBiDAL();

        public ThietBi GetById(int id)
        {
            return _dal.GetById(id);
        }

        public List<ThietBi> GetAll()
        {
            return _dal.GetAll();
        }

        public void Create(ThietBi tb)
        {
            if (tb.GiaThueNgay <= 0)
                throw new System.Exception("Giá thuê không hợp lệ");

            _dal.Create(tb);
        }

        public void Update(ThietBi tb)
        {
            _dal.Update(tb);
        }

        public void Delete(int id)
        {
            _dal.Delete(id);
        }

        public List<ThietBi> Search(string keyword)
        {
            return _dal.Search(keyword);
        }
    }
}
