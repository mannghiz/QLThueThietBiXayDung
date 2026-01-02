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
    public partial class FormCapNhatKhachHang : Form
    {
        public FormCapNhatKhachHang()
        {
            InitializeComponent();
        }

        private readonly KhachHang _Obj;
        public FormCapNhatKhachHang(KhachHang obj)
            : this()
        {
            _Obj = obj;
        }

        private readonly KhachHangBUS _khachHangBUS = new KhachHangBUS();

        private void FormCapNhatKhachHang_Load(object sender, EventArgs e)
        {
            txtMaKH.Enabled = false;

            if (_Obj != null)
            {
                txtMaKH.Text = _Obj.MaKH.ToString();
                txtHoTen.Text = _Obj.HoTen;
                txtDiaChi.Text = _Obj.DiaChi;
                txtSoDienThoai.Text = _Obj.SoDienThoai;
                txtEmail.Text = _Obj.Email;
                txtGhiChu.Text = _Obj.GhiChu;
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên khách hàng không được để trống."
                    , "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            KhachHang obj = new KhachHang
            {
                MaKH = _Obj?.MaKH ?? 0,
                HoTen = txtHoTen.Text,
                DiaChi = txtDiaChi.Text,
                SoDienThoai = txtSoDienThoai.Text,
                Email = txtEmail.Text,
                GhiChu = txtGhiChu.Text
            };

            if (_Obj == null)
            {
                // Thêm mới
                try
                {
                    _khachHangBUS.Create(obj);
                    MessageBox.Show("Thêm mới khách hàng thành công."
                        , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm mới khách hàng: " + ex.Message
                        , "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    obj.MaKH = _Obj.MaKH;
                    // Cập nhật
                    _khachHangBUS.Update(obj);

                    MessageBox.Show("Cập nhật khách hàng thành công."
                                    , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MsgBox.Error("Lỗi khi cập nhật khách hàng: " + ex.Message);
                }
            }
        }
    }
}
