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
    public partial class FormDSKhachHang : Form
    {
        public FormDSKhachHang()
        {
            InitializeComponent();
        }

        KhachHangBUS _khachHangBUS = new KhachHangBUS();
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
            var items = _khachHangBUS.GetAll();
            _src.DataSource = items;
            _src.ResetBindings(true);
        }

        private void FormDSKhachHang_Load(object sender, EventArgs e)
        {
            InitForm();
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                LoadData();
                return;
            }

            var items = _khachHangBUS.Search(txtSearch.Text);
            _src.DataSource = items;
            _src.ResetBindings(true);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FormCapNhatKhachHang f = new FormCapNhatKhachHang();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;

            KhachHang obj = (KhachHang)gridData.CurrentRow.DataBoundItem;

            if (obj == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng để cập nhật."
                    , "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 

            FormCapNhatKhachHang f = new FormCapNhatKhachHang(obj);
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;

            KhachHang obj = (KhachHang)gridData.CurrentRow.DataBoundItem;

            if (obj == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xoá."
                    , "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var q = MsgBox.Question("Bạn có chắc chắn xoá khách hàng này không?");

            if (q)
            {
                try
                {
                    _khachHangBUS.Delete(obj.MaKH);
                    MsgBox.Info("Xoá khách hàng thành công.");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MsgBox.Error("Xoá khách hàng thất bại. Chi tiết lỗi: " + ex.Message);
                }
            }
        }
    }
}
