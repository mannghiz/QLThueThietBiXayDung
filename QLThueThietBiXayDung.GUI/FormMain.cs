using QLThueThietBiXayDung.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThueThietBiXayDung.GUI
{
    public partial class FormMain : Form
    {

        public readonly NhanVien CurrentUser;

        private FormMain()
        {
            InitializeComponent();
            Instance = this;
        }

        public FormMain(NhanVien  currentUser)
            : this()
        {
            CurrentUser = currentUser;
        }

        public static FormMain Instance;

        private Form _activeForm;

        public void OpenChildForm(Form childForm)
        {
            if (_activeForm != null)
            {
                _activeForm.Close();
            }
            //ActiveButton(btnSender);
            _activeForm = childForm;
            childForm.BackColor = Color.White;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(childForm);
            this.pnlMain.Tag = childForm;
            this.lblTitle.Text = childForm.Text;
            childForm.BringToFront();
            childForm.Show();
            //lblHeadTitle.Text = childForm.Text;
        }

        private void btnQLKhachHang_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormDSKhachHang());
        }

        private void btnQLDSLoaiThietBi_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormDSLoaiThietBi());
        }

        private void btnQLDSThietBi_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormDSThietBi());
        }

        private void btnQLDSPhieuNhap_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormDSPhieuNhap());
        }

        private void btnQLDSPhieuThue_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormDSPhieuThue());
        }

        private void btnQLDSPhieuTra_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormDSPhieuTra());
        }

        private void btnQLDSNhanVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormDSNhanVien());
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            lblUserName.Text = CurrentUser.HoTen;
            lblVaiTro.Text = " (" + CurrentUser.TenChucVu + ") ";
            PhanQuyen();
        }

        private void PhanQuyen()
        {
            btnQLDSLoaiThietBi.Enabled = false;
            btnQLDSThietBi.Visible = false;
            btnQLKhachHang.Enabled = false;
            btnQLDSPhieuNhap.Enabled = false;
            btnQLDSPhieuThue.Enabled = false;
            btnQLDSPhieuTra.Enabled = false;
            btnBaoCaoNhapXuatTon.Enabled = false;
            btnBaoCaoDoanhThuTheoThietBi.Enabled = false;
            btnBCDoanhThuTheoKhach.Enabled = false;
            btnQLDSNhanVien.Enabled = false;

            if (CurrentUser.MaChucVu == 1) // quản lý
            {
                btnQLDSLoaiThietBi.Enabled = true;
                btnQLDSThietBi.Visible = true;
                btnQLKhachHang.Enabled = true;
                btnQLDSPhieuNhap.Enabled = true;
                btnQLDSPhieuThue.Enabled = true;
                btnQLDSPhieuTra.Enabled = true;
                btnBaoCaoNhapXuatTon.Enabled = true;
                btnBaoCaoDoanhThuTheoThietBi.Enabled = true;
                btnBCDoanhThuTheoKhach.Enabled = true;
                btnQLDSNhanVien.Enabled = true;
            }

            if (CurrentUser.MaChucVu == 2) // Nhân viên kho
            {
                btnQLDSLoaiThietBi.Enabled = false;
                btnQLDSThietBi.Visible = true;
                btnQLKhachHang.Enabled = false;
                btnQLDSPhieuNhap.Enabled = true;
                btnQLDSPhieuThue.Enabled = false;
                btnQLDSPhieuTra.Enabled = false;
                btnBaoCaoNhapXuatTon.Enabled = true;
                btnBaoCaoDoanhThuTheoThietBi.Enabled = false;
                btnBCDoanhThuTheoKhach.Enabled = false;
                btnQLDSNhanVien.Enabled = false;
            }

            if (CurrentUser.MaChucVu == 3) // Kế toán
            {
                btnQLDSLoaiThietBi.Enabled = false;
                btnQLDSThietBi.Visible = false;
                btnQLKhachHang.Enabled = false;
                btnQLDSPhieuNhap.Enabled = false;
                btnQLDSPhieuThue.Enabled = false;
                btnQLDSPhieuTra.Enabled = false;
                btnBaoCaoNhapXuatTon.Enabled = false;
                btnBaoCaoDoanhThuTheoThietBi.Enabled = true;
                btnBCDoanhThuTheoKhach.Enabled = true;
                btnQLDSNhanVien.Enabled = false;
            }

            if (CurrentUser.MaChucVu == 4) // Bán hàng
            {
                btnQLDSLoaiThietBi.Enabled = false;
                btnQLDSThietBi.Visible = false;
                btnQLKhachHang.Enabled = true;
                btnQLDSPhieuNhap.Enabled = false;
                btnQLDSPhieuThue.Enabled = true;
                btnQLDSPhieuTra.Enabled = true;
                btnBaoCaoNhapXuatTon.Enabled = false;
                btnBaoCaoDoanhThuTheoThietBi.Enabled = true;
                btnBCDoanhThuTheoKhach.Enabled = true;
                btnQLDSNhanVien.Enabled = false;
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBaoCaoNhapXuatTon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormNhapXuatTonThietBi());
        }

        private void btnBaoCaoDoanhThuTheoThietBi_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormXemThongKeDoanhThuTheoThietBi());
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormXemThongKeDoanhThuTheoKhachHang());
        }
    }
}
