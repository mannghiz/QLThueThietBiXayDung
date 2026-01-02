using System;
using System.Collections.Generic;
using System.Linq;
using QLThueThietBiXayDung.DAL;

namespace QLThueThietBiXayDung.BUS
{
    public class PhieuTraBUS
    {
        private readonly PhieuTraDAL _dal = new PhieuTraDAL();
        private readonly ThietBiDAL _thietBiDal = new ThietBiDAL();

        public List<PhieuTra> Search (int? employeeId)
        {
            return _dal.Search(employeeId);
        }

        public List<PhieuTra> GetAll()
        {
            return _dal.GetAll();
        }

        public PhieuTra GetById(int id)
        {
            return _dal.GetById(id);
        }

        PhieuThueBUS _phieuThueBUS = new PhieuThueBUS();
        public void CreateOrUpdate(PhieuTra phieuTra)
        {
            //phieuTra.TongChiPhiThucTe = phieuTra.ChiTietPhieuTras
            //    .Sum(x => x.PhatThem ?? 0);

            try
            {
                _dal.CreateOrUpdate(phieuTra);
                // Cập nhật lại trạng thái phiếu thuê
                var phieuThue = _phieuThueBUS.GetById(phieuTra.MaPhieuThue);
                phieuThue.TrangThai = "Đã trả";
                _phieuThueBUS.CreateOrUpdate(phieuThue);
                // Cộng tồn kho
                foreach (var ct in phieuTra.ChiTietPhieuTras)
                {
                    var tb = _thietBiDal.GetById(ct.MaTB);
                    tb.SoLuongTonKho = (tb.SoLuongTonKho ?? 0) + ct.SoLuongTra;
                    _thietBiDal.Update(tb);
                }
            } catch (Exception ex)
            {
                throw new Exception("Lỗi khi tạo hoặc cập nhật phiếu trả: " + ex.Message);
            }
        }

        public void Delete(PhieuTra obj)
        {
            _dal.Delete(obj.MaPhieuTra);
        }

        public void UpdatePaymentStatus(int id, bool status) 
        {
            _dal.UpdatePaymentStatus(id, status);
        }
    }
}
