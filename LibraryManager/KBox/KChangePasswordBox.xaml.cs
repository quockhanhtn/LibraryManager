using LibraryManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LibraryManager.KBox
{
    /// <summary>
    /// Interaction logic for KChangePasswordBox.xaml
    /// </summary>
    public partial class KChangePasswordBox : Window
    {
        private string idPerson;
        private AccountType accountT;
        public KChangePasswordBox(string _idPerson, AccountType _accountType)
        {
            InitializeComponent();
            this.idPerson = _idPerson;
            this.accountT = _accountType;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (pwxPassword.Password == "" || !LibraryDatabase.CheckPassword(this.idPerson, pwxPassword.Password, this.accountT))
            {
                tblPasswordWarning.Visibility = Visibility.Visible;
                return;
            }
            else { tblPasswordWarning.Visibility = Visibility.Hidden; }

            if (pwxPasswordNew.Password.Length < 5) { tblPasswordNewWarning.Visibility = Visibility.Visible; return; }
            else { tblPasswordNewWarning.Visibility = Visibility.Hidden; }

            if (pwxRetypePasswordNew.Password != pwxPasswordNew.Password) { tblRetypePasswordNewWarning.Visibility = Visibility.Visible; return; }
            else { tblRetypePasswordNewWarning.Visibility = Visibility.Hidden; }

            LibraryDatabase.SetNewPassword(this.idPerson, pwxPasswordNew.Password, this.accountT);

            this.Hide();
            KBox.KMessageBox.Show("Đổi mật khẩu thành công !", "Thông báo", "OK", "", MessageBoxImage.Information);
            pwxPassword.Password = pwxPasswordNew.Password = pwxRetypePasswordNew.Password = "";

            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        public static void Show(string idPerson, AccountType accountType)
        {
            KChangePasswordBox changePasswordBox = new KChangePasswordBox(idPerson, accountType);
            changePasswordBox.Show();
        }
    }
}
