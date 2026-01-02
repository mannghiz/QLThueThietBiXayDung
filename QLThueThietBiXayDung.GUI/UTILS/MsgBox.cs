using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThueThietBiXayDung.GUI
{
    public class MsgBox
    {
        public static void Alert(string msg, string title = "Cảnh báo")
        {
            MessageBox.Show(msg, title
                , MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Info(string msg, string title = "Thông báo")
        {
            MessageBox.Show(msg, title
                , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Error(string msg, string title = "Lỗi")
        {
            MessageBox.Show(msg, title
                , MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool Question(string msg, string title = "Xác nhận")
        {
            return MessageBox.Show(msg
                , title
                , MessageBoxButtons.YesNo
                , MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}
