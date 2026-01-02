using Microsoft.Reporting.WinForms;
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
    public partial class FormXemBaoCaoNhapXuatTonThietBi : Form
    {
        private List<BaoCaoNhapXuatTonEntity> _data;

        public FormXemBaoCaoNhapXuatTonThietBi()
        {
            InitializeComponent();
        }

        public FormXemBaoCaoNhapXuatTonThietBi(List<BaoCaoNhapXuatTonEntity> data)
            : this()
        {
            _data = data;
        }
        private void FormXemBaoCaoNhapXuatTonThietBi_Load(object sender, EventArgs e)
        {
            ReportDataSource reportDataSource = new ReportDataSource();
            //// Must match the DataSource in the RDLC
            reportDataSource.Name = "vBaoCaoNhapXuatTon";
            reportDataSource.Value = _data;

            this.rptViewer.ProcessingMode = ProcessingMode.Local;
            this.rptViewer.LocalReport.ReportPath = "REPORTS/RptNhapXuatTon.rdlc";

            this.rptViewer.LocalReport.DataSources.Clear();
            this.rptViewer.LocalReport.DataSources.Add(reportDataSource);
            this.rptViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.rptViewer.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.Percent;
            this.rptViewer.ZoomPercent = 100;
            this.rptViewer.RefreshReport();
            this.rptViewer.RefreshReport();
        }
    }
}
