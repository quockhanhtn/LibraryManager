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
    public class AddBookCategoryWindowViewModel : BaseViewModel, IOKCancelCommand
    {
        public ICommand OKCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public AddBookCategoryWindowViewModel()
        {
            OKCommand = new RelayCommand<Window>((p) => { return p != null; }, (p) =>
            {
                var tbxId = p.FindName("tbxId") as TextBox;
                var tblIdWarning = p.FindName("tblIdWarning") as TextBlock;
                var tbxName = p.FindName("tbxName") as TextBox;
                var tblNameWarning = p.FindName("tblNameWarning") as TextBlock;
                var tbxBorrowTime = p.FindName("tbxBorrowTime") as TextBox;
                var tblBorrowTimeWarning = p.FindName("tblBorrowTimeWarning") as TextBlock;

                if (tbxId.Text == "") { tblIdWarning.Visibility = Visibility.Visible; return; }
                else { tblIdWarning.Visibility = Visibility.Hidden; }

                if (tbxName.Text == "") { tblNameWarning.Visibility = Visibility.Visible; return; }
                else { tblNameWarning.Visibility = Visibility.Hidden; }

                int borrowTime;
                if (tbxBorrowTime.Text == "" || !int.TryParse(tbxBorrowTime.Text, out borrowTime) || borrowTime <= 0) { tblBorrowTimeWarning.Visibility = Visibility.Visible; return; }
                else { tblBorrowTimeWarning.Visibility = Visibility.Hidden; }

                BookCategory newBookCategory = new BookCategory(tbxId.Text, tbxName.Text, borrowTime);
                newBookCategory.AddToData();

                p.Close();
            });

            CancelCommand = new RelayCommand<Window>((p) => { return p != null; }, (p) => p.Close());
        }
    }
}
