using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibraryManager.Utility
{
    public static class FormatData
    {
        public static string CapitalizeEachWord(string str)
        {
            if (str == "") { return null; }

            //Xóa các khoảng cách ở đầu và cuối
            str = str.Trim();

            //Xóa dấu tab
            while (str.IndexOf("\t") != -1)
            {
                str = str.Replace("\t", " ");
            }

            //Xóa kí tự đặc biệt và số
            for (int i = str.Length - 1; i >= 0; i--)
            {
                if (!(char.IsLetter(str, i) || char.IsWhiteSpace(str, i)))
                {
                    str = str.Remove(i, 1);
                }
            }

            //Xóa khoảng trắng thừa
            while (str.IndexOf("  ") != -1)
            {
                str = str.Replace("  ", " ");
            }

            if (str == "") { return ""; }
            //str += " ";

            //Viết hoa mỗi từ
            string[] words = str.Split(' ');
            str = "";

            for (int i = 0; i < words.Length; i++)
            {
                str += words[i].Substring(0, 1).ToUpper() + words[i].Substring(1).ToLower() + " ";
            }

            //Xóa khoảng trắng thừa ở cuối
            str = str.TrimEnd();

            return str;
        }

        public static int StringToInt(string str)
        {
            int intNumber;
            if (!int.TryParse(str, out intNumber))
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (!char.IsDigit(str[i]))
                    {
                        str = str.Remove(i, 1);
                        i--;
                    }
                }
            }

            if (!int.TryParse(str, out intNumber)) { intNumber = 0; }
            return intNumber;
        }

        public static double StringToDouble(string str)
        {
            double doubleNumber;
            if (!double.TryParse(str, out doubleNumber))
            {
                while (str.IndexOf(".") != str.LastIndexOf("."))
                {
                    str = str.Remove(str.LastIndexOf("."), 1);
                }
                for (int i = 0; i < str.Length; i++)
                {
                    if ((!char.IsDigit(str[i])) && (str[i] != '.'))
                    {
                        str = str.Remove(i, 1);
                        i--;
                    }
                }
            }

            if (!double.TryParse(str, out doubleNumber)) { doubleNumber = 0; }
            return doubleNumber;
        }

        /// <summary>
        /// Kiểm tra định dạng chuỗi "str" có phải là địa chỉ email hay không ?
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEmail(string str)
        {
            if (str.Length < 5) { return false; }
            //Có nhiều ký tự @
            if (str.IndexOf("@") != str.LastIndexOf("@")) { return false; }
            //Không có ký tự @
            if (str.IndexOf("@") == -1) { return false; }
            //Không có dấu .
            if (str.IndexOf(".") == -1) { return false; }

            return true;
        }

        /// <summary>
        /// Kiểm tra định dạng chuỗi "str" có phải là số điện thoại
        /// Số điện thoại đúng : có ít nhất 10 số, kí tự đầu tiên có thể là số hoặc dấu "+"
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsPhone(string str)
        {
            if (str.Length < 10) { return false; }

            if (!(str[0] == '+' && char.IsDigit(str[0]))) { return false; }

            for (int i = 1; i < str.Length; i++) { if (!char.IsDigit(str[i])) { return false; } }

            return true;
        }

        /// <summary>
        /// Chuyển chuỗi str từ có dấu thành không dấu
        /// VD
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string StringConvertToUnSign(string str)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = str.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
    }
}
