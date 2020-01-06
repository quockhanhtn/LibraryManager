using LibraryManager.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LibraryManager.ViewModel
{
    public class BookCategoryManagerUCViewModel : BaseViewModel
    {
        private ObservableCollection<BookCategory> listBookCategory;
        private BookCategory bookCategorySelected;

        public ICommand AddBookCategoryCommand { get; set; }
        public ICommand UpdateBookCategoryCommand { get; set; }
        public ICommand RemoveBookCategoryCommand { get; set; }
        public BookCategoryManagerUCViewModel()
        {
            ListBookCategory = LibraryDatabase.BookCategories();

            AddBookCategoryCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                AddBookCategoryWindow addBookCategoryWindow = new AddBookCategoryWindow();
                addBookCategoryWindow.DataContext = new AddBookCategoryWindowViewModel();
                addBookCategoryWindow.ShowDialog();
                ListBookCategory = LibraryDatabase.BookCategories();
            });

            UpdateBookCategoryCommand = new RelayCommand<UserControl>((p) => { return p != null; }, (p) =>
            {
                var tbxName = p.FindName("tbxName") as TextBox;
                var tbxBorrowTime = p.FindName("tbxBorrowTime") as TextBox;
                var tblNameWarning = p.FindName("tblNameWarning") as TextBlock;
                var tblBorrowTimeWarning = p.FindName("tblBorrowTimeWarning") as TextBlock;

                if (tbxName.Text == "") { tblNameWarning.Visibility = Visibility.Visible; return; }
                else { tblNameWarning.Visibility = Visibility.Hidden; }

                int newBorrowTime;
                if (tbxBorrowTime.Text == "" || int.TryParse(tbxBorrowTime.Text, out newBorrowTime) == false)
                {
                    tblBorrowTimeWarning.Visibility = Visibility.Visible;
                    return;
                }
                else { tblBorrowTimeWarning.Visibility = Visibility.Hidden; }

                BookCategorySelected.Name = tbxName.Text.Substring(0, 1).ToUpper() + tbxName.Text.Substring(1);
                BookCategorySelected.BorrowTime = newBorrowTime;
                bookCategorySelected.Update();
                ListBookCategory = LibraryDatabase.BookCategories();
            });

            RemoveBookCategoryCommand = new RelayCommand<object>((p) => { return (BookCategorySelected != null && BookCategorySelected.NumberOfBook == 0); }, (p) =>
            {
                /*
                MessageBoxResult messageBoxResult = MessageBox.Show("Bạn có muốn xóa chuyên mục \"" + BookCategorySelected.Name + "\" không ?", "Cảnh báo", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No);
                if (messageBoxResult == MessageBoxResult.No) { return; }
                */

                if (!KBox.KMessageBox.Show("Bạn có muốn xóa chuyên mục \"" + BookCategorySelected.Name + "\" không ?", "Cảnh báo", "Có", "Không", MessageBoxImage.Warning)) { return; }
                
                BookCategorySelected.RemoveFromData();
                ListBookCategory.Remove(BookCategorySelected);
            });
        }

        public ObservableCollection<BookCategory> ListBookCategory { get => listBookCategory; set { listBookCategory = value; OnPropertyChanged(); } }
        public BookCategory BookCategorySelected { get => bookCategorySelected; set { bookCategorySelected = value; OnPropertyChanged(); } }
    }
}
