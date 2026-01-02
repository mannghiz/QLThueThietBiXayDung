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
    public partial class FormDSPhieuTra : Form
    {
        public FormDSPhieuTra()
        {
            InitializeComponent();
        }

        PhieuTraBUS _phieuTraBUS = new PhieuTraBUS();
        BindingSource _src = new BindingSource();

        private void InitForm()
        {
            gridData.AutoGenerateColumns = false;
            gridData.ReadOnly = true;
            gridData.AllowUserToAddRows = false;
            gridData.DataSource = _src;
        }

        private void LoadData()
        {
            var items = _phieuTraBUS.GetAll();
            _src.DataSource = items;
            _src.ResetBindings(true);
        }

        private void FormDSPhieuTra_Load(object sender, EventArgs e)
        {
            InitForm();
            LoadData();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FormCapNhatPhieuTra f = new FormCapNhatPhieuTra();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var obj = gridData.CurrentRow?.DataBoundItem as PhieuTra;
            if (obj == null)
            {
                MsgBox.Alert("Vui lòng chọn phiếu trả để sửa.");
                return;
            }

            FormCapNhatPhieuTra f = new FormCapNhatPhieuTra(obj);
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var obj = gridData.CurrentRow?.DataBoundItem as PhieuTra;

            if (obj == null)
            {
                MsgBox.Alert("Vui lòng chọn phiếu trả để xóa.");
                return;
            }

            var confirm = MsgBox.Question("Bạn có chắc chắn muốn xóa phiếu trả này không?");

            if (confirm)
            {
                try
                {
                    _phieuTraBUS.Delete(obj);
                    MsgBox.Info("Xóa phiếu trả thành công.");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MsgBox.Error("Xóa phiếu trả thất bại. " + ex.Message);
                }
            }
        }

        private void btnThanhToanQR_Click(object sender, EventArgs e)
        {
            var obj = gridData.CurrentRow?.DataBoundItem as PhieuTra;

            if (obj == null)
            {
                MsgBox.Alert("Vui lòng chọn phiếu trả để thanh toán.");
                return;
            }

            if (obj.TongChiPhiThucTe == null || obj.TongChiPhiThucTe <= 0)
            {
                MsgBox.Alert("Phiếu trả này không có chi phí cần thanh toán.");
                return;
            }

            decimal amount = obj.TongChiPhiThucTe.Value;
            string description = string.Format("Thanh toan phieu tra {0}", obj.MaPhieuTra);

            FormThanhToanQR f = new FormThanhToanQR(amount, description);
            if (f.ShowDialog() == DialogResult.OK)
            {
                // Chỉ cập nhật trạng thái thanh toán, tránh gọi CreateOrUpdate gây lỗi attached entity
                _phieuTraBUS.UpdatePaymentStatus(obj.MaPhieuTra, true);
                MsgBox.Info("Đã xác nhận thanh toán thành công!");
                LoadData();
            }
        }
    }
}
