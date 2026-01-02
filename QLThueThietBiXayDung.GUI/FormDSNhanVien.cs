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
    public partial class FormDSNhanVien : Form
    {
        public FormDSNhanVien()
        {
            InitializeComponent();
        }

        NhanVienBUS _nhanVienBUS = new NhanVienBUS();
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
            var items = _nhanVienBUS.GetAll();
            _src.DataSource = items;
            _src.ResetBindings(true);
        }

        private void FormDSNhanVien_Load(object sender, EventArgs e)
        {
            InitForm();
            LoadData();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FormCapNhatNhanVien f = new FormCapNhatNhanVien();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa."
                    , "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var obj = (NhanVien)gridData.CurrentRow.DataBoundItem;

            if (obj== null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa."
                    , "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 

            FormCapNhatNhanVien f = new FormCapNhatNhanVien(obj);
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.Index < 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa."
                    , "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var obj = (NhanVien)gridData.CurrentRow.DataBoundItem;

            if (obj == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa."
                    , "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?"
                , "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;
            try
            {
                _nhanVienBUS.Delete(obj.MaNV);
                MsgBox.Info("Xóa nhân viên thành công.", "Thông báo");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa nhân viên không thành công.\n"
                    + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
