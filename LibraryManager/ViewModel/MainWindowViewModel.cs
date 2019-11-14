using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LibraryManager.ViewModel
{
    class MainWindowViewModel : BaseViewModel
    {
        private bool isLoaded = false;

        public ICommand LoadLoginWindowCommand { get; set; }
        public bool IsLoaded { get => isLoaded; set => isLoaded = value; }

        public MainWindowViewModel()
        {
            LoadLoginWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (p == null) { return; }

                p.Hide();

                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();

                var loginVM = loginWindow.DataContext as LoginWindowViewModel;

                switch (loginVM.LoginResult)
                {
                    // LoginResult = 0 đăng nhập thất bại
                    case 0:
                        break;
                    // LoginResult = 0 đăng nhập bằng tài quản quản trị
                    case 1:
                        p.Show();
                        break;
                    // LoginResult = 2 đăng nhập tài khoản thành viên
                    case 2:
                        MemberWindow memberWindow = new MemberWindow();
                        memberWindow.ShowDialog();
                        p.Close();
                        break;
                }
            }
            );
        }
    }
}
