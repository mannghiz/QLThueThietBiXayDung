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
    public partial class FormDSPhieuThue : Form
    {
        public FormDSPhieuThue()
        {
            InitializeComponent();
        }

        PhieuThueBUS _phieuThueBUS = new PhieuThueBUS();
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
            var items = _phieuThueBUS.GetAll();
            _src.DataSource = items;
            _src.ResetBindings(true);
        }

        private void FormDSPhieuThue_Load(object sender, EventArgs e)
        {
            InitForm();
            LoadData();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            FormCapNhatPhieuThue f = new FormCapNhatPhieuThue();
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var obj = gridData.CurrentRow?.DataBoundItem as PhieuThue;

            if (obj == null)
            {
                MsgBox.Alert("Vui lòng chọn phiếu thuê để sửa.");
                return;
            } 

            FormCapNhatPhieuThue f = new FormCapNhatPhieuThue(obj);
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var obj = gridData.CurrentRow?.DataBoundItem as PhieuThue;

            if (obj == null)
            {
                MsgBox.Alert("Vui lòng chọn phiếu thuê để xóa.");
                return;
            }

            var confirm = MsgBox.Question("Bạn có chắc chắn muốn xóa phiếu thuê này không?");

            if (!confirm)
                return;

            try
            {
                _phieuThueBUS.Delete(obj.MaPhieuThue);
                MsgBox.Info("Xóa phiếu thuê thành công.");
                LoadData();
            }
            catch (Exception ex)
            {
                MsgBox.Error("Xóa phiếu thuê thất bại.\n" + ex.Message);
            }
        }
    }
}
