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
    public partial class FormCapNhatNhanVien : Form
    {
        public FormCapNhatNhanVien()
        {
            InitializeComponent();
        }

        public FormCapNhatNhanVien(NhanVien obj)
            : this()
        {
            _Obj = obj;
        }

        private readonly ChucVuBUS _chucVuBUS = new ChucVuBUS();
        private readonly NhanVienBUS _nhanVienBUS = new NhanVienBUS();
        private readonly NhanVien _Obj;

        private void FormCapNhatNhanVien_Load(object sender, EventArgs e)
        {
            cboTrangThai.SelectedIndex = 0;
            LoadComboChucVu();
            txtMaNV.Enabled = false;
            txtMatKhau.UseSystemPasswordChar = true;

            if (_Obj != null)
            {
                txtMaNV.Text = _Obj.MaNV.ToString();
                txtHoTen.Text = _Obj.HoTen;
                cboMaChucVu.SelectedValue = _Obj.MaChucVu;
                dtpNgaySinh.Value = _Obj.NgaySinh.HasValue ? _Obj.NgaySinh.Value : new DateTime(1990, 1, 1);
                txtDiaChi.Text = _Obj.DiaChi;
                txtSoDienThoai.Text = _Obj.SoDienThoai;
                txtEmail.Text = _Obj.Email;
                dtpNgayVaoLam.Value = _Obj.NgayVaoLam;
                cboTrangThai.SelectedItem = _Obj.TrangThai;
                txtMaTK.Text = _Obj.MaTK;
                txtMatKhau.Text = _Obj.MatKhau;
            }
        }

        private void LoadComboChucVu()
        {
            var dsChucVu = _chucVuBUS.GetAll();
            dsChucVu.Insert(0, new ChucVu { MaChucVu = 0, TenChucVu = "-- Chọn chức vụ --" });
            cboMaChucVu.DataSource = dsChucVu;
            cboMaChucVu.ValueMember = "MaChucVu";
            cboMaChucVu.DisplayMember = "TenChucVu";
            cboMaChucVu.SelectedIndex = 0;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên nhân viên không được để trống."
                    , "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboMaChucVu.SelectedIndex <= 0)
            {
                MsgBox.Error("Vui lòng chọn chức vụ !");
                return;
            } 

            if (cboTrangThai.SelectedIndex <= 0)
            {
                MsgBox.Error("Vui lòng chọn trạng thái !");
                return;
            } 

            if (string.IsNullOrEmpty(txtMaTK.Text))
            {
                MsgBox.Error("Mã tài khoản không được để trống !");
                return;
            } 

            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MsgBox.Error("Mật khẩu không được để trống !");
                return;
            } 

            var obj = new NhanVien
            {
                HoTen = txtHoTen.Text,
                MaChucVu = (int)cboMaChucVu.SelectedValue,
                NgaySinh = dtpNgaySinh.Value,
                DiaChi = txtDiaChi.Text,
                SoDienThoai = txtSoDienThoai.Text,
                Email = txtEmail.Text,
                NgayVaoLam = dtpNgayVaoLam.Value,
                TrangThai = cboTrangThai.SelectedItem.ToString(),
                MaTK = txtMaTK.Text,
                MatKhau = txtMatKhau.Text
            };

            if (_Obj == null)
            {
                var tonTaiTaiKhoan = _nhanVienBUS.GetAll()
                    .Any(x => x.MaTK == obj.MaTK);

                if (tonTaiTaiKhoan)
                {
                    MsgBox.Error("Đã tồn tại mã tài khoản đăng nhập này, vui lòng chọn mã khác !");
                    return;
                } 
            }
            else
            {
                obj.MaNV = _Obj.MaNV;

                if (_Obj.MaTK != obj.MaTK)
                {
                    var tonTaiTaiKhoan = _nhanVienBUS.GetAll()
                        .Any(x => x.MaTK == obj.MaTK);

                    if (tonTaiTaiKhoan)
                    {
                        MsgBox.Error("Đã tồn tại mã tài khoản này, vui lòng chọn mã khác !");
                        return;
                    }
                }
            }

            if (_Obj == null)
            {
                // Thêm mới
                try
                {
                    _nhanVienBUS.Create(obj);
                    MsgBox.Info("Thêm mới nhân viên thành công !");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MsgBox.Error("Thêm mới nhân viên thất bại !\n" + ex.Message);
                    return;
                }


            }
            else
            {
                try
                {
                    _nhanVienBUS.Update(obj);
                    MsgBox.Info("Cập nhật nhân viên thành công !");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MsgBox.Error("Cập nhật nhân viên thất bại !\n" + ex.Message);
                    return;
                }
            }
        }
    }
}
