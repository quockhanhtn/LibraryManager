using LibraryManager.CustomUserControl;
using LibraryManager.Interface;
using LibraryManager.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LibraryManager.ViewModel
{
    public class MainWindowViewModel : BaseViewModel, IExitCommand, IWindowOption, IAccountCommand
    {
        public ICommand LoadLoginWindowCommand { get; set; }
        public ICommand MenuSelectionChangedCommand { get; set; }
        public ICommand ChangeLibraryNameCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand ExitWithoutWarningCommand { get; set; }
        public ICommand MouseMoveWindowCommand { get; set; }
        public ICommand WindowMinimizeCommand { get; set; }
        public ICommand WindowMaximizeCommand { get; set; }
        public ICommand AccountInfoCommand { get; set; }
        public ICommand ChangePasswordCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        public UserControl LibrarianManagerUserControl { get => librarianManagerUserControl; set => librarianManagerUserControl = value; }
        public UserControl BookManagerUserControl { get => bookManagerUserControl; set => bookManagerUserControl = value; }
        public UserControl BookCategoryManagerUserControl { get => bookCategoryManagerUserControl; set => bookCategoryManagerUserControl = value; }
        public UserControl MemberManagerUserControl { get => memberManagerUserControl; set => memberManagerUserControl = value; }

        private UserControl librarianManagerUserControl;
        private UserControl bookManagerUserControl;
        private UserControl bookCategoryManagerUserControl;
        private UserControl memberManagerUserControl;

        public MainWindowViewModel()
        {
            LoadLoginWindowCommand = new RelayCommand<Window>((p) => { return (p != null); }, (p) =>
            {
                p.Hide();

                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();

                var loginVM = loginWindow.DataContext as LoginWindowViewModel;

                if (loginVM.LoginSuccess)
                {
                    switch (loginVM.UserType)
                    {
                        case AccountType.ADMIN:
                            InitUserControl();
                            var GridMain = p.FindName("GridMain") as Grid;
                            GridMain.Children.Clear();
                            GridMain.Children.Add(LibrarianManagerUserControl);
                            p.Show();
                            break;

                        case AccountType.LIBRARIAN:
                            LibrarianWindow librarianWindow = new LibrarianWindow();
                            librarianWindow.DataContext = new LibrarianWindowViewModel(loginVM.PersonId);
                            librarianWindow.ShowDialog();
                            p.Close();
                            break;

                        case AccountType.MEMBER:
                            MemberWindow memberWindow = new MemberWindow();
                            memberWindow.DataContext = new MemberWindowViewModel(loginVM.PersonId);
                            memberWindow.ShowDialog();
                            p.Close();
                            break;
                        default:
                            break;
                    }
                    loginVM.LoginSuccess = false;
                }
                else { p.Close(); }
            });

            MenuSelectionChangedCommand = new RelayCommand<Window>((p) => { return (p != null); }, (p) =>
            {
                var GridMain = p.FindName("GridMain") as Grid;
                var ListViewMenu = p.FindName("ListViewMenu") as ListView;
                GridMain.Children.Clear();

                switch (((ListViewItem)(ListViewMenu).SelectedItem).Name)
                {
                    case "LibrarianManager":
                        GridMain.Children.Add(LibrarianManagerUserControl);
                        break;
                    case "MemberManager":
                        GridMain.Children.Add(MemberManagerUserControl);
                        break;
                    case "BookManager":
                        GridMain.Children.Add(BookManagerUserControl);
                        break;
                    case "BookCategoryManager":
                        GridMain.Children.Add(BookCategoryManagerUserControl);
                        break;
                    default:
                        break;
                }
            });

            ChangeLibraryNameCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                string name = KBox.KInputBox.Show(Application.Current.Resources["LibraryName"].ToString(), "TÊN THƯ VIỆN", "OK", "Cancel");
                if (name != "")
                {
                    string filePath = LibraryDatabase.GetApplicationFolderPath() + "\\library.info";
                    using (StreamWriter sw = new StreamWriter(filePath))
                    {
                        sw.WriteLine(name.ToUpper());
                    }
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

            WindowMinimizeCommand = new RelayCommand<Window>((p) => { return (p != null); }, (p) =>
            {
                if (p.WindowState != WindowState.Minimized) { p.WindowState = WindowState.Minimized; }
            });

            WindowMaximizeCommand = new RelayCommand<Window>((p) => { return (p != null); }, (p) =>
            {
                var btn = p.FindName("btnWindowMaximize") as Button;
                if (p.WindowState != WindowState.Maximized)
                {
                    p.WindowState = WindowState.Maximized;
                    btn.Content = "Thu nhỏ";
                }
                else
                {
                    p.WindowState = WindowState.Normal;
                    btn.Content = "Phóng to";
                }
            });
            #endregion

            #region IAccountCommand Define
            AccountInfoCommand = new RelayCommand<Window>((p) => { return (p != null); }, (p) =>
            {
                var GridMain = p.FindName("GridMain") as Grid;
                GridMain.Children.Clear();
                //GridMain.Children.Add(AccountSetttingUserControl);
            });

            ChangePasswordCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                KBox.KChangePasswordBox.Show("0", AccountType.ADMIN);
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

        void InitUserControl()
        {
            //Quản lý nhân viên
            LibrarianManagerUserControl = new LibrarianManagerUC();
            LibrarianManagerUserControl.DataContext = new LibrarianManagerUCViewModel();

            //Quản lý sách
            BookManagerUserControl = new BookManagerUC();
            BookManagerUserControl.DataContext = new BookManagerUCViewModel("NV000");

            //Quản lý chuyên mục sách
            BookCategoryManagerUserControl = new BookCategoryManagerUC();

            //Quản lý thành viên
            MemberManagerUserControl = new MemberManagerUC();
            MemberManagerUserControl.DataContext = new MemberManagerUCViewModel("NV000");
        }
    }
}
