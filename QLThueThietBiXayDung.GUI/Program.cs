using QLThueThietBiXayDung.BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThueThietBiXayDung.GUI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SqlServerTypes.Utilities.LoadNativeAssemblies(AppDomain.CurrentDomain.BaseDirectory);
            // Fix for EF6 SqlServer provider not loading
            var _ = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new NhanVienBUS().GetAll();
            Application.Run(new FormLogin());
        }
    }
}
