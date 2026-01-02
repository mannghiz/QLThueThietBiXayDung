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
    public partial class FormCapNhatLoaiThietBi : Form
    {
        private readonly LoaiThietBi _Obj;
        private readonly LoaiThietBiBUS _loaiThietBiBUS = new LoaiThietBiBUS();

        public FormCapNhatLoaiThietBi()
        {
            InitializeComponent();
        }

        public FormCapNhatLoaiThietBi(LoaiThietBi obj)
            : this()
        {
            _Obj = obj;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCapNhatLoaiThietBi_Load(object sender, EventArgs e)
        {
            if (_Obj != null)
            {
                // Chế độ Cập nhật
                txtMaLoai.Enabled = false;
                txtMaLoai.Text = _Obj.MaLoai.ToString();
                txtTenLoai.Text = _Obj.TenLoai;
                txtMoTa.Text = _Obj.MoTa;
            }
            else
            {
                // Chế độ Thêm mới
                txtMaLoai.Text = "Tự động tăng";
                txtMaLoai.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(txtTenLoai.Text))
            {
                MessageBox.Show("Tên loại thiết bị không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenLoai.Focus();
                return;
            }

            // 2. Tạo đối tượng LoaiThietBi
            // Sử dụng toán tử kiểm tra null để tránh lỗi MaLoai = _Obj.MaLoai khi thêm mới
            LoaiThietBi obj = new LoaiThietBi
            {
                MaLoai = (_Obj != null) ? _Obj.MaLoai : 0,
                TenLoai = txtTenLoai.Text.Trim(),
                MoTa = txtMoTa.Text.Trim()
            };

            // 3. Thực hiện lưu dữ liệu
            try
            {
                if (_Obj == null)
                {
                    // Thêm mới
                    _loaiThietBiBUS.Create(obj);
                    MessageBox.Show("Thêm mới loại thiết bị thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Cập nhật
                    _loaiThietBiBUS.Update(obj);
                    MessageBox.Show("Cập nhật loại thiết bị thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Gán DialogResult = OK để Form cha biết cần load lại dữ liệu
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                string action = (_Obj == null) ? "thêm mới" : "cập nhật";
                MessageBox.Show($"Lỗi khi {action} loại thiết bị: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}