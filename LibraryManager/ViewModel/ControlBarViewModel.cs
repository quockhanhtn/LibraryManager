using LibraryManager.Interface;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;

namespace LibraryManager.ViewModel
{
    public class ControlBarViewModel : BaseViewModel, IWindowOption
    {

        public ICommand MouseMoveWindowCommand { get; set; }
        public ICommand WindowMinimizeCommand { get; set; }
        public ICommand WindowMaximizeCommand { get; set; }
        public ICommand WindowCloseCommand { get; set; }
        public ControlBarViewModel()
        {
            #region Define Command
            MouseMoveWindowCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) =>
            {
                Window window = GetWindowParent(p) as Window;
                if (window != null) { window.DragMove(); }
            });

            WindowMinimizeCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) =>
            {
                Window window = GetWindowParent(p) as Window;
                if (window != null)
                {
                    if (window.WindowState != WindowState.Minimized) { window.WindowState = WindowState.Minimized; }
                }
            });

            WindowMaximizeCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) =>
            {
                var iconWindowMaximize = p.FindName("iconWindowMaximize") as PackIcon;
                var btnWindowMaximize = p.FindName("btnWindowMaximize") as Button;

                Window window = GetWindowParent(p) as Window;

                if (window != null)
                {
                    if (window.WindowState != WindowState.Maximized) 
                    { 
                        window.WindowState = WindowState.Maximized;
                        iconWindowMaximize.Kind = PackIconKind.WindowRestore;
                        btnWindowMaximize.ToolTip = "Restore";
                    }
                    else 
                    { 
                        window.WindowState = WindowState.Normal;
                        iconWindowMaximize.Kind = PackIconKind.WindowMaximize;
                        btnWindowMaximize.ToolTip = "Maximize";
                    }
                }
            });

            WindowCloseCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) =>
            {
                Window window = GetWindowParent(p) as Window;
                if (window != null) { window.Close(); }
            });
            #endregion
        }
    }
}
