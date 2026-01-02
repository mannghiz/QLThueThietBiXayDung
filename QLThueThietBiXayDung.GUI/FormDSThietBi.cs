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
    public partial class FormDSThietBi : Form
    {
        public FormDSThietBi()
        {
            InitializeComponent();
        }

        ThietBiBUS _thietBiBUS = new ThietBiBUS();
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
            var items = _thietBiBUS.GetAll();
            _src.DataSource = items;
            _src.ResetBindings(true);
        }

        private void FormDSThietBi_Load(object sender, EventArgs e)
        {
            InitForm();
            LoadData();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FormCapNhatThietBi f = new FormCapNhatThietBi();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
            {
                MsgBox.Error("Vui lòng chọn thiết bị để cập nhật.");
                return;
            } 

            var obj = (ThietBi)gridData.CurrentRow.DataBoundItem;

            if (obj == null)
            {
                MsgBox.Error("Vui lòng chọn thiết bị để cập nhật.");
                return;
            }

            FormCapNhatThietBi f = new FormCapNhatThietBi(obj);
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridData.CurrentRow == null || gridData.CurrentRow.IsNewRow)
            {
                MsgBox.Error("Vui lòng chọn thiết bị để xoá.");
                return;
            }

            var obj = (ThietBi)gridData.CurrentRow.DataBoundItem;

            if (obj == null)
            {
                MsgBox.Error("Vui lòng chọn thiết bị để xoá.");
                return;
            }

            var confirm = MsgBox.Question("Bạn có chắc chắn xoá thiết bị này?");

            if (confirm)
            {
                try
                {
                    _thietBiBUS.Delete(obj.MaTB);
                    MsgBox.Info("Xoá thiết bị thành công.");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MsgBox.Error("Xoá thiết bị thất bại. Chi tiết lỗi: " + ex.Message);
                }
            }
        }
    }
}
