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
    public partial class FormDSLoaiThietBi : Form
    {
        public FormDSLoaiThietBi()
        {
            InitializeComponent();
        }

        LoaiThietBiBUS _loaiThietBiBUS = new LoaiThietBiBUS();
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
            var items = _loaiThietBiBUS.GetAll();
            _src.DataSource = items;
            _src.ResetBindings(true);
        }

        private void FormDSLoaiThietBi_Load(object sender, EventArgs e)
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

            var items = _loaiThietBiBUS.Search(txtSearch.Text);
            _src.DataSource = items;
            _src.ResetBindings(true);
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FormCapNhatLoaiThietBi f = new FormCapNhatLoaiThietBi();
            f.StartPosition = FormStartPosition.CenterParent;
            f.FormClosed += (s, args) => LoadData();
            f.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;

            var obj = (LoaiThietBi)gridData.CurrentRow.DataBoundItem;

            if (obj == null)
            {
                MsgBox.Error("Vui lòng chọn loại thiết bị để cập nhật.");
                return;
            }

            FormCapNhatLoaiThietBi f = new FormCapNhatLoaiThietBi(obj);
            f.StartPosition = FormStartPosition.CenterParent;
            f.FormClosed += (s, args) => LoadData();
            f.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
                return;

            var obj = (LoaiThietBi)gridData.CurrentRow.DataBoundItem;

            if (obj == null)
            {
                MsgBox.Error("Vui lòng chọn loại thiết bị để xoá.");
                return;
            }

            var q = MsgBox.Question("Bạn có chắc chắn xoá loại thiết bị này không?");

            if (q)
            {
                try
                {
                    _loaiThietBiBUS.Delete(obj.MaLoai);
                    MsgBox.Info("Xoá loại thiết bị thành công.");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MsgBox.Error("Xoá loại thiết bị thất bại. Chi tiết lỗi: " + ex.Message);
                }
            }
        }
    }
}
