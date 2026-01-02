using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace QLThueThietBiXayDung.GUI
{
    public partial class FormThanhToanQR : Form
    {
        private decimal _amount;
        private string _description;

        public FormThanhToanQR(decimal amount, string description)
        {
            InitializeComponent();
            _amount = amount;
            _description = description;
        }

        private void FormThanhToanQR_Load(object sender, EventArgs e)
        {
            lblAmount.Text = string.Format("Số tiền: {0:N0} VNĐ", _amount);
            lblDesc.Text = _description;

            // Generate VietQR URL
            // Format: https://img.vietqr.io/image/{BANK_ID}-{ACCOUNT_NO}-{TEMPLATE}.png?amount={AMOUNT}&addInfo={CONTENT}
            // Using placeholder: MB Bank, 0000000000
            
            string bankId = "MB";
            string accountNo = "0937704360";
            string template = "compact2";
            string content = Uri.EscapeDataString(_description);
            
            string url = string.Format("https://img.vietqr.io/image/{0}-{1}-{2}.png?amount={3}&addInfo={4}",
                bankId, accountNo, template, _amount, content);

            try 
            {
                picQR.Load(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải mã QR: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
