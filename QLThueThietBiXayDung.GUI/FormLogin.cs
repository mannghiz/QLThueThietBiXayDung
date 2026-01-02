using QLThueThietBiXayDung.BUS;
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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        NhanVienBUS nvBUS = new NhanVienBUS();

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MsgBox.Alert("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.");
                return;
            }

            var nhanVien = nvBUS.GetAll()
                .Where(x => x.MaTK == txtUsername.Text)
                .FirstOrDefault();

            if (nhanVien == null || nhanVien.MatKhau != txtPassword.Text)
            {
                MsgBox.Error("Tên đăng nhập hoặc mật khẩu không đúng!");
                return;
            }

            // Đăng nhập thành công
            FormMain frm = new FormMain(nhanVien);
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
