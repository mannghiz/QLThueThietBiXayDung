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
    public partial class FormNhapXuatTonThietBi : Form
    {
        public FormNhapXuatTonThietBi()
        {
            InitializeComponent();
        }

        private readonly BaoCaoXuatNhapTonBUS _baoCaoXuatNhapTonBUS = new BaoCaoXuatNhapTonBUS();
        BindingSource _src = new BindingSource();

        private void FormNhapXuatTonThietBi_Load(object sender, EventArgs e)
        {
            gridData.DataSource = _src;
            LoadGrid();
        }

        private void LoadGrid()
        {
            var dsXNT = _baoCaoXuatNhapTonBUS.ThongKeXuatNhapTon();
            _src.DataSource = dsXNT;
            _src.ResetBindings(true);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var dsXNT = _baoCaoXuatNhapTonBUS.ThongKeXuatNhapTon();
            dsXNT = dsXNT.Where(x =>
                (string.IsNullOrEmpty(txtSearch.Text) || x.MaTB.ToString().Contains(txtSearch.Text))
                || (string.IsNullOrEmpty(txtSearch.Text) || x.TenThietBi.IndexOf(txtSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0)
            ).ToList();
            _src.DataSource = dsXNT;
            _src.ResetBindings(true);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var dsXNT = _src.DataSource as List<BaoCaoNhapXuatTonEntity>;
            var f = new FormXemBaoCaoNhapXuatTonThietBi(dsXNT);
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }
    }
}
