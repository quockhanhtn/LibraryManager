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
    public class LibrarianWindowViewModel : BaseViewModel, IExitCommand, IAccountCommand
    {
        private Librarian librarianLogin;
        public ICommand LoadedCommand { get; set; }
        public ICommand MenuSelectionChangedCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand ExitWithoutWarningCommand { get; set; }
        public ICommand MouseMoveWindowCommand { get; set; }
        public ICommand AccountInfoCommand { get; set; }
        public ICommand ChangePasswordCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        public Librarian LibrarianLogin { get => librarianLogin; set { librarianLogin = value; OnPropertyChanged(); } }

        public UserControl BookManagerUserControl { get => bookManagerUserControl; set => bookManagerUserControl = value; }
        public UserControl BookCategoryManagerUserControl { get => bookCategoryManagerUserControl; set => bookCategoryManagerUserControl = value; }
        public UserControl MemberManagerUserControl { get => memberManagerUserControl; set => memberManagerUserControl = value; }
        public UserControl AccountSetttingUserControl { get => accountSetttingUserControl; set => accountSetttingUserControl = value; }

        private UserControl bookManagerUserControl;
        private UserControl bookCategoryManagerUserControl;
        private UserControl memberManagerUserControl;
        private UserControl accountSetttingUserControl;

        public LibrarianWindowViewModel(string idLibrarian)
        {
            LibrarianLogin = Librarian.FindLibrarianById(idLibrarian);

            if (LibrarianLogin == null) { return; }

            LoadedCommand = new RelayCommand<Window>((p) => { return (p != null); }, (p) => 
            {
                //Quản lý sách
                BookManagerUserControl = new BookManagerUC();
                BookManagerUserControl.DataContext = new BookManagerUCViewModel(idLibrarian);

                //Quản lý chuyên mục sách
                BookCategoryManagerUserControl = new BookCategoryManagerUC();

                //Quản lý thành viên
                MemberManagerUserControl = new MemberManagerUC();
                MemberManagerUserControl.DataContext = new MemberManagerUCViewModel(idLibrarian);
                
                //Cài dặt  tài khoản
                AccountSetttingUserControl = new AccountSetttingUC();
                AccountSetttingUserControl.DataContext = new AccountSetttingUCViewModel(idLibrarian, AccountType.LIBRARIAN);

                var GridMain = p.FindName("GridMain") as Grid;
                GridMain.Children.Clear();
                GridMain.Children.Add(BookManagerUserControl);

                var chipAccount = p.FindName("chipAccount") as MaterialDesignThemes.Wpf.Chip;
                chipAccount.Icon = LibrarianLogin.FirstName[0].ToString();
            });

            MenuSelectionChangedCommand = new RelayCommand<Window>((p) => { return (p != null); }, (p) =>
            {
                var GridMain = p.FindName("GridMain") as Grid;
                var ListViewMenu = p.FindName("ListViewMenu") as ListView;
                GridMain.Children.Clear();

                switch (((ListViewItem)(ListViewMenu).SelectedItem).Name)
                {
                    case "MemberManager":
                        GridMain.Children.Add(MemberManagerUserControl);
                        break;
                    case "BookManager":
                        GridMain.Children.Add(BookManagerUserControl);
                        break;
                    case "BookCategoryManager":
                        GridMain.Children.Add(BookCategoryManagerUserControl);
                        break;
                    case "AccountManager":
                        GridMain.Children.Add(AccountSetttingUserControl);
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
                KBox.KChangePasswordBox.Show(idLibrarian, AccountType.LIBRARIAN);
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
