using System.Collections.Generic;
using System.Linq;
using QLThueThietBiXayDung.DAL;

namespace QLThueThietBiXayDung.BUS
{
    public class PhieuNhapBUS
    {
        private readonly PhieuNhapDAL _dal = new PhieuNhapDAL();
        private readonly ThietBiDAL _thietBiDal = new ThietBiDAL();

        public List<PhieuNhap> Search (System.DateTime? fromDate, System.DateTime? toDate, int? employeeId)
        {
            return _dal.Search(fromDate, toDate, employeeId);
        }

        public List<PhieuNhap> GetAll()
        {
            return _dal.GetAll();
        }

        public PhieuNhap GetById(int id)
        {
            return _dal.GetById(id);
        }

        public void CreateOrUpdate(PhieuNhap phieuNhap)
        {
            // Tính tổng tiền nhập
            phieuNhap.TongGiaNhap = phieuNhap.ChiTietPhieuNhaps
                .Sum(x => x.SoLuongNhap * x.GiaNhap);

            _dal.CreateOrUpdate(phieuNhap);

            // Cập nhật tồn kho
            foreach (var ct in phieuNhap.ChiTietPhieuNhaps)
            {
                var tb = _thietBiDal.GetById(ct.MaTB);
                tb.SoLuongTonKho = (tb.SoLuongTonKho ?? 0) + ct.SoLuongNhap;
                _thietBiDal.Update(tb);
            }
        }

        public void Delete(int id)
        {
            _dal.Delete(id);
        }
    }
}
