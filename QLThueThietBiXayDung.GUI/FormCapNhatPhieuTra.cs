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
    public partial class FormCapNhatPhieuTra : Form
    {
        public FormCapNhatPhieuTra()
        {
            InitializeComponent();
        }

        public FormCapNhatPhieuTra(PhieuTra obj)
            : this()
        {
            _Obj = obj;
        }

        private readonly PhieuThueBUS _phieuThueBUS = new PhieuThueBUS();
        private readonly PhieuTraBUS _phieuTraBUS = new PhieuTraBUS();
        private readonly NhanVienBUS _nhanVienBUS = new NhanVienBUS();
        private readonly ThietBiBUS _thietBiBUS = new ThietBiBUS();
        private readonly BindingSource _src = new BindingSource();
        private readonly PhieuTra _Obj;

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCapNhatPhieuTra_Load(object sender, EventArgs e)
        {
            dtpNgayTraThucTe.Value = DateTime.Now;
            cboTrangThai.SelectedIndex = 0;
            gridDSCTPhieuTra.AutoGenerateColumns = false;
            gridDSCTPhieuTra.ReadOnly = true;
            gridDSCTPhieuTra.AllowUserToAddRows = false;
            gridDSCTPhieuTra.DataSource = _src;
            _src.DataSource = new List<ChiTietPhieuTra>();
            _src.ResetBindings(true);
            LoadComboPhieuThue();
            LoadComboNhanVien();
            LoadComboThietBi();

            if (_Obj != null)
            {
                txtMaPhieuTra.Text = _Obj.MaPhieuTra.ToString();
                cboMaNV.SelectedValue = _Obj.MaNV;
                cboMaPhieuThue.SelectedValue = _Obj.MaPhieuThue;
                dtpNgayTraThucTe.Value = _Obj.NgayTraThucTe;
                cboTrangThai.SelectedItem = _Obj.TrangThai;
                txtGhiChu.Text = _Obj.GhiChu;
                txtTongChiPhiThucTe.Text = _Obj.TongChiPhiThucTe?.ToString("N2");
                var dsCTPhieuTra = _Obj.ChiTietPhieuTras.ToList();
                _src.DataSource = dsCTPhieuTra;
                _src.ResetBindings(true);
            }
        }

        private void LoadComboThietBi()
        {
            var dsThietBi = _thietBiBUS.GetAll();
            dsThietBi.Insert(0, new ThietBi { MaTB = 0, TenThietBi = " -- Chọn --" });
            cboMaTB.DataSource = dsThietBi;
            cboMaTB.DisplayMember = "TenThietBi";
            cboMaTB.ValueMember = "MaTB";
            cboMaTB.SelectedIndex = 0;
        }

        private void LoadComboNhanVien()
        {
            var dsNhanVien = _nhanVienBUS.GetAll();
            dsNhanVien.Insert(0, new NhanVien { MaNV = 0, HoTen = " -- Chọn --" });
            cboMaNV.DataSource = dsNhanVien;
            cboMaNV.DisplayMember = "HoTen";
            cboMaNV.ValueMember = "MaNV";
            cboMaNV.SelectedIndex = 0;
        }

        private void LoadComboPhieuThue()
        {
            var dsPhieuThue = _phieuThueBUS.GetAll();
            dsPhieuThue.Insert(0, new PhieuThue { MaPhieuThue = 0, MaKH = 0, MaNV = 0, Info = "-- Chọn --" });
            cboMaPhieuThue.DataSource = dsPhieuThue;
            cboMaPhieuThue.DisplayMember = "Info";
            cboMaPhieuThue.ValueMember = "MaPhieuThue";
            cboMaPhieuThue.SelectedIndex = 0;
        }

        private void cboMaPhieuThue_DropDownClosed(object sender, EventArgs e)
        {
            PhieuThue obj = cboMaPhieuThue.SelectedItem as PhieuThue;

            if (obj != null && obj.MaPhieuThue > 0)
            {
                if (obj.TrangThai == "Đã trả")
                {
                    MessageBox.Show("Phiếu thuê này đã được trả thiết bị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboMaPhieuThue.SelectedIndex = 0;
                    return;
                }

                txtTongChiPhiThucTe.Text = obj.TongChiPhiDuKien?.ToString("N2");
                var dsCTPhieuThue = obj.ChiTietPhieuThues.ToList();
                List<ChiTietPhieuTra> dsCTPhieuTra = new List<ChiTietPhieuTra>();
                foreach (var ct in dsCTPhieuThue)
                {
                    var ctPhieuTra = new ChiTietPhieuTra
                    {
                        MaTB = ct.MaTB,
                        TenThietBi = ct.ThietBi.TenThietBi,
                        SoLuongTra = ct.SoLuongThue,
                        TinhTrang = "Tốt",
                        PhatThem = 0,
                        GhiChu = "Trạng thái tốt"
                    };
                    dsCTPhieuTra.Add(ctPhieuTra);
                }
                _src.DataSource = dsCTPhieuTra;
                _src.ResetBindings(true);
            }
            else
            {
                _src.DataSource = new List<ChiTietPhieuTra>();
                _src.ResetBindings(true);
            }

            cboMaTB.SelectedIndex = 0;
            txtSoLuongTra.Value = 1;
            cboTinhTrang.SelectedIndex = 0;
            txtPhatThem.Text = "0";
            txtCTGhiChu.Text = string.Empty;
        }

        private void gridDSCTPhieuTra_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            var ctPhieuTra = gridDSCTPhieuTra.CurrentRow?.DataBoundItem as ChiTietPhieuTra;

            if (ctPhieuTra != null)
            {
                cboMaTB.SelectedValue = ctPhieuTra.MaTB;
                txtSoLuongTra.Value = ctPhieuTra.SoLuongTra;
                cboTinhTrang.SelectedItem = ctPhieuTra.TinhTrang;
                txtPhatThem.Text = ctPhieuTra.PhatThem?.ToString("N2");
                txtCTGhiChu.Text = ctPhieuTra.GhiChu;
            }
        }

        private void btnCapNhatCT_Click(object sender, EventArgs e)
        {
            var ctPhieuTra = gridDSCTPhieuTra.CurrentRow?.DataBoundItem as ChiTietPhieuTra;

            if (ctPhieuTra != null)
            {
                ctPhieuTra.SoLuongTra = (int)txtSoLuongTra.Value;
                ctPhieuTra.TinhTrang = cboTinhTrang.SelectedItem.ToString();
                decimal phatThem;
                if (decimal.TryParse(txtPhatThem.Text, out phatThem))
                {
                    ctPhieuTra.PhatThem = phatThem;
                }
                else
                {
                    ctPhieuTra.PhatThem = 0;
                }
                ctPhieuTra.GhiChu = txtCTGhiChu.Text;
                _src.ResetBindings(true);

                // Tính lại tổng chi phí thực tế
                PhieuThue phieuThue = cboMaPhieuThue.SelectedItem as PhieuThue;
                if (phieuThue != null)
                {
                    decimal tongChiPhiThucTe = phieuThue.TongChiPhiDuKien ?? 0;
                    foreach (var ct in (List<ChiTietPhieuTra>)_src.DataSource)
                    {
                        if (ct.PhatThem.HasValue)
                        {
                            tongChiPhiThucTe += ct.PhatThem.Value;
                        }
                    }
                    txtTongChiPhiThucTe.Text = tongChiPhiThucTe.ToString("N2");
                } 
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboMaPhieuThue.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn phiếu thuê.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } 

            PhieuThue phieuThue = cboMaPhieuThue.SelectedItem as PhieuThue;

            if (phieuThue == null)
            {
                MessageBox.Show("Phiếu thuê không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpNgayTraThucTe.Value < phieuThue.NgayThue)
            {
                MessageBox.Show("Ngày trả thực tế không được trước ngày thuê.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboMaNV.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboTrangThai.SelectedIndex <= 0)
            {
                MessageBox.Show("Vui lòng chọn trạng thái phiếu trả.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PhieuTra obj = new PhieuTra
            {
                MaPhieuTra = _Obj != null ? _Obj.MaPhieuTra : 0,
                MaPhieuThue = phieuThue.MaPhieuThue,
                MaNV = (int)cboMaNV.SelectedValue,
                NgayTraThucTe = dtpNgayTraThucTe.Value,
                TrangThai = cboTrangThai.SelectedItem.ToString(),
                GhiChu = txtGhiChu.Text,
                ChiTietPhieuTras = ((List<ChiTietPhieuTra>)_src.DataSource)
            };

            if (obj.ChiTietPhieuTras.Count == 0)
            {
                MessageBox.Show("Phiếu trả không có chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tính tổng chi phí thực tế
            decimal tongChiPhiThucTe = phieuThue.TongChiPhiDuKien.Value;

            foreach (var ct in obj.ChiTietPhieuTras)
            {
                if (ct.PhatThem.HasValue)
                {
                    tongChiPhiThucTe += ct.PhatThem.Value;
                }
            }

            obj.TongChiPhiThucTe = tongChiPhiThucTe;

            try
            {
                _phieuTraBUS.CreateOrUpdate(obj);
                MessageBox.Show("Lưu phiếu trả thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            } 
            catch (Exception ex)
            {
                MessageBox.Show("Lưu phiếu trả thất bại.\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
