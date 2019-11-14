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
    class ControlBarViewModel : BaseViewModel
    {
        private ICommand mouseMoveWindowCommand;
        private ICommand windowMinimizeCommand;
        private ICommand windowMaximizeCommand;
        private ICommand windowCloseCommand;

        public ICommand MouseMoveWindowCommand { get => mouseMoveWindowCommand; set => mouseMoveWindowCommand = value; }
        public ICommand WindowMinimizeCommand { get => windowMinimizeCommand; set => windowMinimizeCommand = value; }
        public ICommand WindowMaximizeCommand { get => windowMaximizeCommand; set => windowMaximizeCommand = value; }
        public ICommand WindowCloseCommand { get => windowCloseCommand; set => windowCloseCommand = value; }
        public ControlBarViewModel()
        {
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
                Window window = GetWindowParent(p) as Window;
                if (window != null)
                {
                    if (window.WindowState != WindowState.Maximized) { window.WindowState = WindowState.Maximized; }
                    else { window.WindowState = WindowState.Normal; }
                }
            });

            WindowCloseCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) =>
            {
                Window window = GetWindowParent(p) as Window;
                if (window != null) { window.Close(); }
            });
        }

        FrameworkElement GetWindowParent(UserControl p)
        {
            FrameworkElement parent = p;

            while (parent.Parent != null)
            {
                parent = parent.Parent as FrameworkElement;
            }

            return parent;
        }
    }
}
