using QLThueThietBiXayDung.BUS;
using QLThueThietBiXayDung.DAL.Entity;
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
    public partial class FormXemThongKeDoanhThuTheoThietBi : Form
    {
        public FormXemThongKeDoanhThuTheoThietBi()
        {
            InitializeComponent();
        }

        ThongKeDoanhThuBUS _thongKeDoanhThuBUS = new ThongKeDoanhThuBUS();
        BindingSource _src = new BindingSource();

        private void FormXemThongKeDoanhThuTheoThietBi_Load(object sender, EventArgs e)
        {
            gridData.DataSource = _src;
            LoadGrid();
        }

        private void LoadGrid()
        {
            var dsDoanhThu = _thongKeDoanhThuBUS.ThongKeDoanhThuTheoThietBi();
            _src.DataSource = dsDoanhThu;
            _src.ResetBindings(true);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var dsDoanhThu = _thongKeDoanhThuBUS.ThongKeDoanhThuTheoThietBi();
            dsDoanhThu = dsDoanhThu.Where(x =>
                (string.IsNullOrEmpty(txtSearch.Text) || x.MaTB.ToString().Contains(txtSearch.Text))
                || (string.IsNullOrEmpty(txtSearch.Text) || x.TenThietBi.IndexOf(txtSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0)
            ).ToList();
            _src.DataSource = dsDoanhThu;
            _src.ResetBindings(true);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var dsDoanhThu = _src.DataSource as List<DoanhThuTheoThietBiEntity>;
            var f = new FormInThongKeDoanhThuTheoThietBi(dsDoanhThu);
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }
    }
}
