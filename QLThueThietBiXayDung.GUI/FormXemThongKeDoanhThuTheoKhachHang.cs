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
    public partial class FormXemThongKeDoanhThuTheoKhachHang : Form
    {
        public FormXemThongKeDoanhThuTheoKhachHang()
        {
            InitializeComponent();
        }

        ThongKeDoanhThuBUS _thongKeDoanhThuBUS = new ThongKeDoanhThuBUS();
        BindingSource _src = new BindingSource();

        private void FormXemThongKeDoanhThuTheoKhachHang_Load(object sender, EventArgs e)
        {
            gridData.DataSource = _src;
            LoadGrid();
        }

        private void LoadGrid()
        {
            var dsDoanhThu = _thongKeDoanhThuBUS.ThongKeDoanhThuTheoKhachHang();
            _src.DataSource = dsDoanhThu;
            _src.ResetBindings(true);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var dsDoanhThu = _src.DataSource as List<DoanhThuTheoKhachHangEntity>;
            var f = new FormInThongKeDoanhThuTheoKhachHang(dsDoanhThu);
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var dsDoanhThu = _thongKeDoanhThuBUS.ThongKeDoanhThuTheoKhachHang();
            dsDoanhThu = dsDoanhThu.Where(x =>
                (string.IsNullOrEmpty(txtSearch.Text) || x.MaKH.ToString().Contains(txtSearch.Text))
                || (string.IsNullOrEmpty(txtSearch.Text) || x.HoTen.IndexOf(txtSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0)
            ).ToList();

            _src.DataSource = dsDoanhThu;
            _src.ResetBindings(true);
        }
    }
}
