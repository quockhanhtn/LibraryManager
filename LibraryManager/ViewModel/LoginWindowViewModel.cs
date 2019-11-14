using LibraryManager.Data;
using LibraryManager.Model;
using LibraryManager.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LibraryManager.ViewModel
{
    public class LoginWindowViewModel : BaseViewModel
    {
        private ICommand loginCommand;
        private string fileAccountPath = PathUtility.GetApplicationDirectory() + @"\account.txt";
        private int loginResult;

        public ICommand LoginCommand { get => loginCommand; set => loginCommand = value; }
        public int LoginResult { get => loginResult; set => loginResult = value; }

        public LoginWindowViewModel()
        {
            LoginCommand = new RelayCommand<Window>((p) => { return p == null ? false : true; }, (p) =>
            {
                var tbxUserName = p.FindName("tbxUserName") as TextBox;
                var tbxPassWord = p.FindName("tbxPassWord") as PasswordBox;
                var tblLoginFail = p.FindName("tblLoginFail") as TextBlock;

                if (tbxUserName == null || tbxPassWord == null || tblLoginFail == null) { return; }

                Login(tbxUserName.Text,tbxPassWord.Password);

                if (LoginResult == 0)
                {
                    tblLoginFail.Visibility = Visibility.Visible;
                }
                else
                {
                    p.Close();
                }
            });
        }

        private void Login(string userName, string passWord)
        {
            Library.ListUser = Database.Users();
            foreach (var user in Library.ListUser)
            {
                if (user.Username == userName && user.Password == MD5Hash(Base64Encode(passWord)))
                {
                    LoginResult = user.UserType;
                    return;
                }
            }
            LoginResult = 0;
        }

        private string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        private string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
