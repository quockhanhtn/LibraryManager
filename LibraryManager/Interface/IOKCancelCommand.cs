using System.Windows.Input;

namespace LibraryManager.Interface
{
    interface IOKCancelCommand
    {
        public ICommand OKCommand { get; set; }
        public ICommand CancelCommand { get; set; }
    }
}
