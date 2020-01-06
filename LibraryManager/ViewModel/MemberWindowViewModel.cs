using LibraryManager.CustomUserControl;
using LibraryManager.Interface;
using LibraryManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LibraryManager.ViewModel
{
    public class MemberWindowViewModel : BaseViewModel, IExitCommand, IAccountCommand
    {
        private Member memberLogin;
        public ICommand LoadedCommand { get; set; }
        public ICommand MenuSelectionChangedCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand ExitWithoutWarningCommand { get; set; }
        public ICommand MouseMoveWindowCommand { get; set; }
        public ICommand AccountInfoCommand { get; set; }
        public ICommand ChangePasswordCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        public Member MemberLogin { get => memberLogin; set { memberLogin = value; OnPropertyChanged(); } }

        public UserControl AccountSetttingUserControl { get => accountSetttingUserControl; set { accountSetttingUserControl = value; OnPropertyChanged(); } }
        public UserControl ListBookBorrowUserControl { get => listBookBorrowUserControl; set => listBookBorrowUserControl = value; }

        private UserControl accountSetttingUserControl;
        private UserControl listBookBorrowUserControl;
        public MemberWindowViewModel(string idMember)
        {
            MemberLogin = Member.FindMemberById(idMember);

            if (MemberLogin == null) { return; }

            LoadedCommand = new RelayCommand<Window>((p) => { return (p != null); }, (p) =>
            {
                var chipAccount = p.FindName("chipAccount") as MaterialDesignThemes.Wpf.Chip;
                chipAccount.Icon = MemberLogin.FirstName[0].ToString();

                AccountSetttingUserControl = new AccountSetttingUC();
                AccountSetttingUserControl.DataContext = new AccountSetttingUCViewModel(idMember, AccountType.MEMBER);

                ListBookBorrowUserControl = new ListBookBorrowUC();
                ListBookBorrowUserControl.DataContext = new ListBookBorrowUCViewModel(idMember);

                var GridMain = p.FindName("GridMain") as Grid;
                GridMain.Children.Clear();
                GridMain.Children.Add(AccountSetttingUserControl);
            });

            MenuSelectionChangedCommand = new RelayCommand<Window>((p) => { return (p != null); }, (p) =>
            {
                var GridMain = p.FindName("GridMain") as Grid;
                var ListViewMenu = p.FindName("ListViewMenu") as ListView;
                GridMain.Children.Clear();

                switch (((ListViewItem)(ListViewMenu).SelectedItem).Name)
                {
                    case "AccountManager":
                        GridMain.Children.Add(AccountSetttingUserControl);
                        break;
                    case "ListBookBorrow":
                        GridMain.Children.Add(ListBookBorrowUserControl);
                        break;
                    default:
                        break;
                }
            });

            #region IExitCommand Define
            ExitCommand = new RelayCommand<Window>((p) => { return (p != null); }, (p) =>
            {
                p.Hide();
                if (!KBox.KMessageBox.Show("Bạn có muốn thoát chương trình ?", "Cảnh báo", "Có", "Không", MessageBoxImage.Warning)) { p.Show(); return; }
                p.Close();
            });
            ExitWithoutWarningCommand = new RelayCommand<Window>((p) => { return (p != null); }, (p) => { p.Close(); });
            #endregion

            #region IWindowOption Define
            MouseMoveWindowCommand = new RelayCommand<Window>((p) => { return (p != null); }, (p) => { p.DragMove(); });
            #endregion

            #region IAccountCommand Define
            AccountInfoCommand = new RelayCommand<Window>((p) => { return (p != null); }, (p) =>
            {
                var GridMain = p.FindName("GridMain") as Grid;
                GridMain.Children.Clear();
                GridMain.Children.Add(AccountSetttingUserControl);
            });

            ChangePasswordCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                KBox.KChangePasswordBox.Show(MemberLogin.Id, AccountType.MEMBER);
            });

            LogoutCommand = new RelayCommand<Window>((p) => { return (p != null); }, (p) =>
            {
                p.Hide();
                MainWindow mainWindow = new MainWindow();
                mainWindow.ShowDialog();
                p.Close();
            });
            #endregion
        }
    }
}
