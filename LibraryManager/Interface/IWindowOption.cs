using System.Windows.Input;

namespace LibraryManager.Interface
{
    interface IWindowOption
    {
        /// <summary>
        /// Kéo thả
        /// </summary>
        public ICommand MouseMoveWindowCommand { get; set; }
        /// <summary>
        /// Ẩn Window xuống thanh taskbar
        /// </summary>
        public ICommand WindowMinimizeCommand { get; set; }
        /// <summary>
        /// Phóng to Window
        /// </summary>
        public ICommand WindowMaximizeCommand { get; set; }
    }
}
