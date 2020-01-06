using LibraryManager.Interface;
using LibraryManager.Model;
using LibraryManager.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace LibraryManager.ViewModel
{
    public class LoginWindowViewModel : BaseViewModel, IExitCommand
    {
        private ICommand loginCommand;
        private bool loginSuccess;
        private string personId;
        private AccountType userType;

        public ICommand LoginCommand { get => loginCommand; set => loginCommand = value; }
        public ICommand ClosingLoginWindowCommand { get; set; }
        public bool LoginSuccess { get => loginSuccess; set => loginSuccess = value; }
        public string PersonId { get => personId; set => personId = value; }

        public AccountType UserType { get => userType; set => userType = value; }
        public ICommand ExitCommand { get; set; }
        public ICommand ExitWithoutWarningCommand { get ; set; }
        public ICommand MouseMoveWindowCommand { get; set; }

        public ICommand ShowPasswordCommand { get; set; }

        public LoginWindowViewModel()
        {
            LoginCommand = new RelayCommand<Window>((p) => { return !(p == null); }, (p) =>
            {
                var tbxUserName = p.FindName("tbxUserName") as TextBox;
                var tbxPassWord = p.FindName("tbxPassWord") as PasswordBox;
                var tbxPassWordShow = p.FindName("tbxPassWordShow") as TextBox;
                var imgIconShowPassword = p.FindName("imgIconShowPassword") as Image;
                var tblLoginFail = p.FindName("tblLoginFail") as TextBlock;

                var rbtnMember = p.FindName("rbtnMember") as RadioButton;
                var rbtnLibrarian = p.FindName("rbtnLibrarian") as RadioButton;
                var rbtnAdmin = p.FindName("rbtnAdmin") as RadioButton;

                if (rbtnMember.IsChecked.Value) { this.UserType = AccountType.MEMBER; }
                else if (rbtnLibrarian.IsChecked.Value) { this.UserType = AccountType.LIBRARIAN; }
                else if (rbtnAdmin.IsChecked.Value) { this.UserType = AccountType.ADMIN; }

                if (imgIconShowPassword.Source == Application.Current.Resources["IconShowPassword"])
                {
                    (this.LoginSuccess, this.PersonId) = User.Login(tbxUserName.Text, tbxPassWord.Password, UserType);
                }
                else
                {
                    (this.LoginSuccess, this.PersonId) = User.Login(tbxUserName.Text, tbxPassWordShow.Text, UserType);
                }
                
                if (!LoginSuccess) { tblLoginFail.Visibility = Visibility.Visible; }
                else { p.Close(); }
            });

            MouseMoveWindowCommand = new RelayCommand<Window>((p) => { return p != null; }, (p) => { p.DragMove(); });

            ShowPasswordCommand = new RelayCommand<Window>((p) => { return !(p == null); }, (p) =>
            {
                var tbxPassWord = p.FindName("tbxPassWord") as PasswordBox;
                var tbxPassWordShow = p.FindName("tbxPassWordShow") as TextBox;
                var imgIconShowPassword = p.FindName("imgIconShowPassword") as Image;

                if (imgIconShowPassword.Source == Application.Current.Resources["IconShowPassword"])
                {
                    imgIconShowPassword.Source = Application.Current.Resources["IconHidePassword"] as BitmapImage;
                    tbxPassWord.Visibility = Visibility.Hidden;
                    tbxPassWordShow.Text = tbxPassWord.Password;
                    tbxPassWordShow.Visibility = Visibility.Visible;

                    tbxPassWordShow.Focus();
                    tbxPassWordShow.SelectionStart = tbxPassWordShow.Text.Length;
                }
                else
                {
                    imgIconShowPassword.Source = Application.Current.Resources["IconShowPassword"] as BitmapImage;
                    tbxPassWord.Visibility = Visibility.Visible;
                    tbxPassWord.Password = tbxPassWordShow.Text;
                    tbxPassWordShow.Visibility = Visibility.Hidden;

                    tbxPassWord.Focus();
                }
            });

            #region IExitCommand Define
            ExitCommand = new RelayCommand<Window>((p) => { return (p != null); }, (p) =>
            {
                p.Hide();
                if (!KBox.KMessageBox.Show("Bạn có muốn thoát chương trình ?", "Cảnh báo", "Có", "Không", MessageBoxImage.Warning)) { p.Show(); return; }
                this.LoginSuccess = false;
                p.Close();
            });
            ExitWithoutWarningCommand = new RelayCommand<Window>((p) => { return (p != null); }, (p) => { this.LoginSuccess = false; p.Close(); });
            #endregion
        }
    }
}
