using System.Windows.Input;

namespace LibraryManager.Interface
{
    interface IExitCommand
    {
        /// <summary>
        /// Hiện một thông báo hỏi người cùng có muốn thoát chương trình
        /// </summary>
        public ICommand ExitCommand { get; set; }
        /// <summary>
        /// Thoát chương trình mà không hiện thông báo
        /// </summary>
        public ICommand ExitWithoutWarningCommand { get; set; }
    }
}
