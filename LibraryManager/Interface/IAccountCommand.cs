using System.Windows.Input;

namespace LibraryManager.Interface
{
    interface IAccountCommand
    {
        /// <summary>
        /// Xem thông tin và sửa đổi thông tin tài khoản
        /// </summary>
        public ICommand AccountInfoCommand { get; set; }
        /// <summary>
        /// Đăng xuất
        /// </summary>
        public ICommand LogoutCommand { get; set; }
        /// <summary>
        /// Đổi mật khẩu
        /// </summary>
        public ICommand ChangePasswordCommand { get; set; }
    }
}
