using System;
using System.Collections.Generic;
using System.Linq;
using QLThueThietBiXayDung.DAL;

namespace QLThueThietBiXayDung.BUS
{
    public class PhieuThueBUS
    {
        private readonly PhieuThueDAL _dal = new PhieuThueDAL();
        private readonly ThietBiDAL _thietBiDal = new ThietBiDAL();

        public List<PhieuThue> Search (int? customerId, int? employeeId)
        {
            return _dal.Search(customerId, employeeId);
        }

        public PhieuThue GetById(int id)
        {
            return _dal.GetById(id);
        }

        public List<PhieuThue> GetAll()
        {
            return _dal.GetAll();
        }

        public void CreateOrUpdate(PhieuThue phieuThue)
        {
            int soNgayThue = (phieuThue.NgayTraDuKien - phieuThue.NgayThue).Days;
            if (soNgayThue <= 0)
                soNgayThue = 1;

            phieuThue.TongChiPhiDuKien = phieuThue.ChiTietPhieuThues.Sum(
                x => x.SoLuongThue * x.GiaThueNgay * soNgayThue);

            try
            {
                _dal.CreateOrUpdate(phieuThue);

                // Trừ tồn kho
                foreach (var ct in phieuThue.ChiTietPhieuThues)
                {
                    var tb = _thietBiDal.GetById(ct.MaTB);
                    if (tb.SoLuongTonKho < ct.SoLuongThue)
                        throw new Exception("Không đủ số lượng tồn kho");

                    tb.SoLuongTonKho -= ct.SoLuongThue;
                    _thietBiDal.Update(tb);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lưu phiếu thuê thất bại. " + ex.Message);

            }
        }

        public void Delete(int id)
        {
            _dal.Delete(id);
        }
    }
}
