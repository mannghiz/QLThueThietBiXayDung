using QLThueThietBiXayDung.BUS;
using QLThueThietBiXayDung.DAL;
using System;
using System.CodeDom;
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
    public partial class FormCapNhatThietBi : Form
    {
        public FormCapNhatThietBi()
        {
            InitializeComponent();
        }

        public FormCapNhatThietBi(ThietBi obj)
            : this()
        {
            _Obj = obj;
        }
        LoaiThietBiBUS _loaiThietBiBUS = new LoaiThietBiBUS();
        ThietBiBUS _thietBiBUS = new ThietBiBUS();
        private readonly ThietBi _Obj;

        private void FormCapNhatThietBi_Load(object sender, EventArgs e)
        {
            LoadComboLoaiThietBi();
            cboTrangThai.SelectedIndex = 0;
            txtSoLuongTonKho.Enabled = false;
            txtMaTB.Enabled = false;

            if (_Obj != null)
            {
                txtMaTB.Text = _Obj.MaTB.ToString();
                txtTenThietBi.Text = _Obj.TenThietBi;
                cboMaLoai.SelectedValue = _Obj.MaLoai;
                txtSerialNumber.Text = _Obj.SerialNumber;
                txtGiaThueNgay.Value = _Obj.GiaThueNgay;
                cboTrangThai.SelectedItem = _Obj.TrangThai;
                txtSoLuongTonKho.Value = _Obj.SoLuongTonKho ?? 0;
                txtGhiChu.Text = _Obj.GhiChu;
            }
        }

        private void LoadComboLoaiThietBi()
        {
            var dsLoai = _loaiThietBiBUS.GetAll();
            dsLoai.Insert(0, new LoaiThietBi() { MaLoai = -1, TenLoai = "-- Chọn --" });
            cboMaLoai.DataSource = dsLoai;
            cboMaLoai.ValueMember = "MaLoai";
            cboMaLoai.DisplayMember = "TenLoai";
            cboMaLoai.SelectedIndex = 0;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenThietBi.Text))
            {
                MsgBox.Error("Tên thiết bị không được để trống !");
                return;
            } 

            if (cboMaLoai.SelectedIndex <= 0)
            {
                MsgBox.Error("Vui lòng chọn loại thiết bị !");
                return;
            }

            if (cboTrangThai.SelectedIndex <= 0)
            {
                MsgBox.Error("Vui lòng chọn trạng thái thiết bị !");
                return;
            }

            if (txtGiaThueNgay.Value <= 0)
            {
                MsgBox.Error("Giá thuê ngày phải lớn hơn 0 !");
                return;
            }

            var obj = new ThietBi
            {
                TenThietBi = txtTenThietBi.Text,
                MaLoai = (int)cboMaLoai.SelectedValue,
                SerialNumber = txtSerialNumber.Text,
                GiaThueNgay = txtGiaThueNgay.Value,
                TrangThai = cboTrangThai.SelectedItem.ToString(),
                SoLuongTonKho = (int)txtSoLuongTonKho.Value,
                GhiChu = txtGhiChu.Text
            };

            if (_Obj == null)
            {
                // Thêm mới
                try
                {
                    _thietBiBUS.Create(obj);
                    MsgBox.Info("Thêm mới thiết bị thành công.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MsgBox.Error("Thêm mới thiết bị thất bại. Chi tiết lỗi: " + ex.Message);
                }
            }
            else
            {
                // Cập nhật
                try
                {
                    obj.MaTB = _Obj.MaTB;
                    _thietBiBUS.Update(obj);
                    MsgBox.Info("Cập nhật thiết bị thành công.");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MsgBox.Error("Cập nhật thiết bị thất bại. Chi tiết lỗi: " + ex.Message);
                }
            }

        }
    }
}
