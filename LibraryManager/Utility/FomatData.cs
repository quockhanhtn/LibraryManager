using LibraryManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Utility
{
    public static class FomatData
    {
        public static string StringName(string str)
        {
            //Xóa các khoảng cách ở đầu và cuối
            str = str.Trim();

            while (str.IndexOf("\t") != -1)
            {
                str = str.Replace("\t", " ");
            }
            while (str.IndexOf("  ") != -1)
            {
                str = str.Replace("  ", " ");
            }


            //Viết hoa đầu dòng
            string[] words = str.Split(' ');
            str = "";

            for (int i = 0; i < words.Length; i++)
            {
                str += words[i].Substring(0, 1).ToUpper() + words[i].Substring(1).ToLower() + " ";
            }

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
    }
}
