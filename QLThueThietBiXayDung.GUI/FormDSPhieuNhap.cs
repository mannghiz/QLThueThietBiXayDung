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
    public partial class FormDSPhieuNhap : Form
    {
        public FormDSPhieuNhap()
        {
            InitializeComponent();
        }

        PhieuNhapBUS _phieuNhapBUS = new PhieuNhapBUS();
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
            var items = _phieuNhapBUS.GetAll();
            _src.DataSource = items;
            _src.ResetBindings(true);
        }

        private void FormDSPhieuNhap_Load(object sender, EventArgs e)
        {
            InitForm();
            LoadData();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FormCapNhatPhieuNhap f = new FormCapNhatPhieuNhap();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var obj = gridData.CurrentRow?.DataBoundItem as PhieuNhap;

            if (obj != null)
            {
                FormCapNhatPhieuNhap f = new FormCapNhatPhieuNhap(obj);
                f.StartPosition = FormStartPosition.CenterParent;
                f.ShowDialog();
                LoadData();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } 
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var obj = gridData.CurrentRow?.DataBoundItem as PhieuNhap;

            if (obj != null)
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu nhập này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _phieuNhapBUS.Delete(obj.MaPhieuNhap);
                        MsgBox.Info("Xóa phiếu nhập thành công!", "Thông báo");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa phiếu nhập thất bại! Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
