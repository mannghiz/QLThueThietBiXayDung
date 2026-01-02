using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThueThietBiXayDung.GUI
{
    public static class Helpers
    {
        public static bool IsValidVietnamPhoneNumber(this string phoneNumber)
        {
            // Loại bỏ khoảng trắng, dấu gạch ngang hoặc ký tự không cần thiết
            phoneNumber = phoneNumber.Trim().Replace(" ", "").Replace("-", "");

            // Biểu thức chính quy cho số điện thoại Việt Nam
            string pattern = @"^(03[2-9]|05[6-9]|07[0-9]|08[1-9]|09[0-9])[0-9]{7}$";

            // Kiểm tra độ dài và định dạng
            if (phoneNumber.Length != 10)
                return false;

            // Kiểm tra bằng Regex
            return Regex.IsMatch(phoneNumber, pattern);
        }

        public static bool IsValidEmail(this string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            // Biểu thức chính quy kiểm tra định dạng email
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

            // Kiểm tra bằng Regex
            return Regex.IsMatch(email, pattern);
        }

        public static void InvokeControlAction<t>(t control, Action action) where t : Control
        {
            if (control.InvokeRequired)
                control.Invoke(new Action<t, Action>(InvokeControlAction), new object[] { control, action });
            else
                action();
        }

        public static void Invoke<t>(this t control, Action action) where t : Control
        {
            InvokeControlAction<t>(control, action);
        }

    }
}
