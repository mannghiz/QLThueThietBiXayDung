using QLThueThietBiXayDung.BUS;
using QLThueThietBiXayDung.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThueThietBiXayDung.GUI
{
    public partial class FormCapNhatPhieuNhap : Form
    {
        private readonly PhieuNhap _Obj;

        public FormCapNhatPhieuNhap()
        {
            InitializeComponent();
        }

        private readonly NhanVienBUS _nhanVienBUS = new NhanVienBUS();
        private readonly PhieuNhapBUS _phieuNhapBUS = new PhieuNhapBUS();
        private readonly ThietBiBUS _thietBiBUS = new ThietBiBUS();
        BindingSource _src = new BindingSource();
        public FormCapNhatPhieuNhap(PhieuNhap obj)
            : this()
        {
            _Obj = obj;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCapNhatPhieuNhap_Load(object sender, EventArgs e)
        {
            gridDSCTPhieuNhap.AutoGenerateColumns = false;
            txtMaPhieuNhap.Enabled = false;
            gridDSCTPhieuNhap.DataSource = _src;
            _src.DataSource = new List<ChiTietPhieuNhap>();
            _src.ResetBindings(true);
            LoadComboBoxMaNV();
            LoadComboDSThietBi();
            cboTrangThai.SelectedIndex = 0;
            cboMaNV.SelectedValue = FormMain.Instance.CurrentUser.MaNV;

            if ( _Obj != null)
            {
                txtMaPhieuNhap.Text = _Obj.MaPhieuNhap.ToString();
                dtpNgayNhap.Value = _Obj.NgayNhap;
                cboMaNV.SelectedValue = _Obj.MaNV;
                cboTrangThai.SelectedItem = _Obj.TrangThai;
                txtNhaCungCap.Text = _Obj.NhaCungCap;
                txtGhiChu.Text = _Obj.GhiChu;

                if (_Obj.ChiTietPhieuNhaps != null && _Obj.ChiTietPhieuNhaps.Count > 0)
                {
                    _src.DataSource = _Obj.ChiTietPhieuNhaps;
                    _src.ResetBindings(true);
                }
            }
        }

        private void LoadComboDSThietBi()
        {
            var dsThietBi = _thietBiBUS.GetAll();
            dsThietBi.Insert(0, new ThietBi { MaTB = -1, TenThietBi = "-- Chọn thiết bị --" });
            cboThietBi.DataSource = dsThietBi;
            cboThietBi.DisplayMember = "TenThietBi";
            cboThietBi.ValueMember = "MaTB";
            cboThietBi.SelectedIndex = 0;
        }

        private void LoadComboBoxMaNV()
        {
            var dsNhanVien = _nhanVienBUS.GetAll();
            dsNhanVien.Insert(0, new NhanVien { MaNV = -1, HoTen = "-- Chọn nhân viên --" });
            cboMaNV.DataSource = dsNhanVien;
            cboMaNV.DisplayMember = "HoTen";
            cboMaNV.ValueMember = "MaNV";
            cboMaNV.SelectedIndex = 0;
        }

        private void btnThemCT_Click(object sender, EventArgs e)
        {
            if (cboThietBi.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn thiết bị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } 

            if (txtSoLuongNhap.Value <= 0)
            {
                MessageBox.Show("Số lượng nhập phải lớn hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtGiaNhap.Value <= 0)
            {
                MessageBox.Show("Giá nhập phải lớn hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ctPhieuNhap = new ChiTietPhieuNhap
            {
                MaTB = (int)cboThietBi.SelectedValue,
                TenThietBi = cboThietBi.Text,
                SoLuongNhap = (int)txtSoLuongNhap.Value,
                GiaNhap = txtGiaNhap.Value,
                GhiChu = txtCTGhiChu.Text,
                ThanhTien = txtSoLuongNhap.Value * txtGiaNhap.Value
            };

            var dsCTPhieuNhap = (List<ChiTietPhieuNhap>)_src.DataSource;

            if (dsCTPhieuNhap != null)
            {
                // Nếu có thì cộng số lượng, ngược lại thì thêm mới vào danh sách
                var existingCT = dsCTPhieuNhap.FirstOrDefault(ct => ct.MaTB == ctPhieuNhap.MaTB);
                if (existingCT != null)
                {
                    existingCT.SoLuongNhap += ctPhieuNhap.SoLuongNhap;
                    existingCT.GiaNhap = ctPhieuNhap.GiaNhap; // Cập nhật giá nhập mới
                    existingCT.ThanhTien = existingCT.SoLuongNhap * existingCT.GiaNhap;
                }
                else
                {
                    dsCTPhieuNhap.Add(ctPhieuNhap);
                }
                _src.ResetBindings(true);
            }
        }

        private void btnXoaCT_Click(object sender, EventArgs e)
        {
            // Lấy ra phần tử được chọn trong danh sách
            var selectedCT = (ChiTietPhieuNhap)gridDSCTPhieuNhap.CurrentRow?.DataBoundItem;
            
            if (selectedCT != null)
            {
                var dsCTPhieuNhap = (List<ChiTietPhieuNhap>)_src.DataSource;
                dsCTPhieuNhap.Remove(selectedCT);
                _src.ResetBindings(true);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboMaNV.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboTrangThai.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn trạng thái.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_src.DataSource == null || ((List<ChiTietPhieuNhap>)_src.DataSource).Count == 0)
            {
                MessageBox.Show("Vui lòng thêm chi tiết phiếu nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var phieuNhap = new PhieuNhap
            {
                MaPhieuNhap = _Obj != null ? _Obj.MaPhieuNhap : 0,
                NgayNhap = dtpNgayNhap.Value,
                MaNV = (int)cboMaNV.SelectedValue,
                TrangThai = cboTrangThai.SelectedItem.ToString(),
                NhaCungCap = txtNhaCungCap.Text,
                GhiChu = txtGhiChu.Text,
                TongGiaNhap = ((List<ChiTietPhieuNhap>)_src.DataSource).Sum(ct => ct.ThanhTien),
                ChiTietPhieuNhaps = (List<ChiTietPhieuNhap>)_src.DataSource
            };

            try
            {
                _phieuNhapBUS.CreateOrUpdate(phieuNhap);
                MessageBox.Show("Cập nhật thông tin phiếu nhập thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu phiếu nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
