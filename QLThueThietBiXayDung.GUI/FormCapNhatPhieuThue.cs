using QLThueThietBiXayDung.BUS;
using QLThueThietBiXayDung.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThueThietBiXayDung.GUI
{
    public partial class FormCapNhatPhieuThue : Form
    {
        public FormCapNhatPhieuThue()
        {
            InitializeComponent();
        }

        public FormCapNhatPhieuThue(PhieuThue obj)
            : this()
        {
            _Obj = obj;
        }

        private readonly PhieuThueBUS _phieuThueBUS = new PhieuThueBUS();
        private readonly NhanVienBUS _nhanVienBUS = new NhanVienBUS();
        private readonly KhachHangBUS _khachHangBUS = new KhachHangBUS();
        private readonly ThietBiBUS _thietBiBUS = new ThietBiBUS();
        private readonly BindingSource _src = new BindingSource();
        private readonly PhieuThue _Obj;

        private void FormCapNhatPhieuThue_Load(object sender, EventArgs e)
        {
            dtpNgayThue.Value = DateTime.Now.Date;
            dtpNgayTraDuKien.Value = DateTime.Now.Date.AddDays(7);
            gridDSCTPhieuThue.AutoGenerateColumns = false;
            gridDSCTPhieuThue.ReadOnly = true;
            gridDSCTPhieuThue.AllowUserToAddRows = false;
            gridDSCTPhieuThue.DataSource = _src;
            _src.DataSource = new List<ChiTietPhieuThue>();
            _src.ResetBindings(true);
            cboTrangThai.SelectedIndex = 0;
            LoadComboNhanVien();
            LoadComboKhachHang();
            LoadComboThietBi();

            if (_Obj != null)
            {
                txtMaPhieuThue.Text = _Obj.MaPhieuThue.ToString();
                cboMaNV.SelectedValue = _Obj.MaNV;
                cboMaKH.SelectedValue = _Obj.MaKH;
                dtpNgayThue.Value = _Obj.NgayThue;
                dtpNgayTraDuKien.Value = _Obj.NgayTraDuKien;
                cboTrangThai.SelectedItem = _Obj.TrangThai;
                txtGhiChu.Text = _Obj.GhiChu;
                var dsCTPhieuThue = _Obj.ChiTietPhieuThues.ToList();
                _src.DataSource = dsCTPhieuThue;
                _src.ResetBindings(true);
            }
            else
            {
                cboTrangThai.SelectedItem = "Chưa trả";
            }
        }

        private void LoadComboThietBi()
        {
            var dsThietbi = _thietBiBUS.GetAll();
            dsThietbi.Insert(0, new ThietBi { MaTB = -1 , TenThietBi = "-- Chọn thiết bị --" });
            cboMaTB.DataSource = dsThietbi;
            cboMaTB.DisplayMember = "TenThietBi";
            cboMaTB.ValueMember = "MaTB";
            cboMaTB.SelectedIndex = 0;
        }

        private void LoadComboKhachHang()
        {
            var dsKhachHang = _khachHangBUS.GetAll();
            dsKhachHang.Insert(0, new KhachHang { MaKH = -1, HoTen = "-- Chọn khách hàng --" });
            cboMaKH.DataSource = dsKhachHang;
            cboMaKH.DisplayMember = "HoTen";
            cboMaKH.ValueMember = "MaKH";
            cboMaKH.SelectedIndex = 0;

        }

        private void LoadComboNhanVien()
        {
           var dsNhanVien = _nhanVienBUS.GetAll();
              dsNhanVien.Insert(0, new NhanVien { MaNV = -1, HoTen = "-- Chọn nhân viên --" });
            cboMaNV.DataSource = dsNhanVien;
            cboMaNV.DisplayMember = "HoTen";
            cboMaNV.ValueMember = "MaNV";
            cboMaNV.SelectedIndex = 0;
        }

        private void dtpNgayThue_ValueChanged(object sender, EventArgs e)
        {
            dtpNgayTraDuKien.Value = dtpNgayThue.Value.Date.AddDays(7);
        }

        private void btnThemCT_Click(object sender, EventArgs e)
        {
            if (cboMaTB.SelectedIndex <= 0)
            {
                MsgBox.Alert("Vui lòng chọn thiết bị.");
                return;
            }

            var thietBi = cboMaTB.SelectedItem as ThietBi;

            if (thietBi == null)
            {
                MsgBox.Alert("Thiết bị không hợp lệ.");
                return;
            }

            var soNgayThue = (dtpNgayTraDuKien.Value.Date - dtpNgayThue.Value.Date).Days + 1;
            
            if (soNgayThue <= 0)
            {
                MsgBox.Alert("Ngày trả dự kiến phải lớn hơn ngày thuê.");
                return;
            }

            // Kiểm tra số lượng thuê không nhỏ hơn số lượng tồn hiện tại
            var dsCTPhieuThue = _src.DataSource as List<ChiTietPhieuThue>;
            var existingCT = dsCTPhieuThue.FirstOrDefault(ct => ct.MaTB == thietBi.MaTB);
            var soLuongThue = txtSoLuongThue.Value;
            if (existingCT != null)
            {
                soLuongThue += existingCT.SoLuongThue;
            }
            if (soLuongThue > thietBi.SoLuongTonKho)
            {
                MsgBox.Alert($"Số lượng thuê vượt quá số lượng tồn kho hiện tại ({thietBi.SoLuongTonKho}).");
                return;
            }

            var chiTietPhieuThue = new ChiTietPhieuThue
            {
                MaTB = thietBi.MaTB,
                TenThietBi = thietBi.TenThietBi,
                SoLuongThue = (int)txtSoLuongThue.Value,
                GiaThueNgay = thietBi.GiaThueNgay,
                ThanhTienDuKien = thietBi.GiaThueNgay * txtSoLuongThue.Value * soNgayThue,
                GhiChu = txtCTGhiChu.Text.Trim()
            };

            if (existingCT != null)
            {
                existingCT.SoLuongThue += chiTietPhieuThue.SoLuongThue;
                existingCT.ThanhTienDuKien += chiTietPhieuThue.ThanhTienDuKien;
            }
            else
            {
                dsCTPhieuThue.Add(chiTietPhieuThue);
            }

            _src.ResetBindings(false);
        }

        private void cboMaTB_DropDownClosed(object sender, EventArgs e)
        {
            if (cboMaTB.SelectedIndex <= 0)
            {
                txtSoLuongThue.Text = "";
                txtGiaThueNgay.Text = "";
                txtGhiChu.Text = "";
                return;
            }

            txtSoLuongThue.Value = 1;
            txtGiaThueNgay.Text = (cboMaTB.SelectedItem as ThietBi)?.GiaThueNgay.ToString("N0") ?? "";
            txtCTGhiChu.Text = "Thuê mới";
        }

        private void btnXoaCT_Click(object sender, EventArgs e)
        {
            var ctPhieuThue = gridDSCTPhieuThue.CurrentRow?.DataBoundItem as ChiTietPhieuThue;
            
            if (ctPhieuThue == null)
            {
                return;
            }

            var dsCTPhieuThue = _src.DataSource as List<ChiTietPhieuThue>;
            dsCTPhieuThue.Remove(ctPhieuThue);
            _src.ResetBindings(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboMaKH.SelectedIndex <= 0)
            {
                MsgBox.Alert("Vui lòng chọn khách hàng.");
                return;
            }

            if (cboMaNV.SelectedIndex <= 0)
            {
                MsgBox.Alert("Vui lòng chọn nhân viên.");
                return;
            }

            if (cboTrangThai.SelectedIndex < 0)
            {
                MsgBox.Alert("Vui lòng chọn trạng thái.");
                return;
            }

            var phieuThue = new PhieuThue
            {
                MaNV = (int)cboMaNV.SelectedValue,
                MaKH = (int)cboMaKH.SelectedValue,
                NgayThue = dtpNgayThue.Value.Date,
                NgayTraDuKien = dtpNgayTraDuKien.Value.Date,
                TrangThai = cboTrangThai.SelectedItem.ToString(),
                GhiChu = txtGhiChu.Text.Trim(),
                ChiTietPhieuThues = (_src.DataSource as List<ChiTietPhieuThue>) ?? new List<ChiTietPhieuThue>()
            };

            if (phieuThue.ChiTietPhieuThues.Count == 0)
            {
                MsgBox.Alert("Vui lòng thêm chi tiết phiếu thuê.");
                return;
            }

            try
            {
                if (_Obj != null)
                    phieuThue.MaPhieuThue = _Obj.MaPhieuThue;
                else
                {
                    phieuThue.MaPhieuThue = 0;
                    phieuThue.TrangThai = "Chưa trả";
                } 
                _phieuThueBUS.CreateOrUpdate(phieuThue);
                MsgBox.Info("Cập nhật phiếu thuê thành công.");
              
                this.Close();
            }
            catch (Exception ex)
            {
                MsgBox.Error("Lưu phiếu thuê thất bại.\n" + ex.Message);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
