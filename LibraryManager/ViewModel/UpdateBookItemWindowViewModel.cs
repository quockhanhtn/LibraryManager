using LibraryManager.Interface;
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
    public class UpdateBookItemWindowViewModel : BaseViewModel, IOKCancelCommand
    {
        private BookItem updateBookItem;
        private ObservableCollection<BookCategory> listBookCategory;
        private BookCategory bookCategorySelected;

        public ObservableCollection<BookCategory> ListBookCategory { get => listBookCategory; set { listBookCategory = value; OnPropertyChanged(); } }
        public BookCategory BookCategorySelected { get => bookCategorySelected; set { bookCategorySelected = value; OnPropertyChanged(); } }
        public ICommand AddBookCategoryCommand { get; set; }
        public ICommand OKCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public BookItem UpdateBookItem { get => updateBookItem; set { updateBookItem = value; OnPropertyChanged(); } }

        public UpdateBookItemWindowViewModel(BookItem updateBookItem)
        {
            UpdateBookItem = updateBookItem;

            ListBookCategory = LibraryDatabase.BookCategories();

            foreach (var item in ListBookCategory)
            {
                if (item.Id == UpdateBookItem.Book.IdBookCategory)
                {
                    BookCategorySelected = item;
                    break;
                }
            }

            AddBookCategoryCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                AddBookCategoryWindow addBookCategoryWindow = new AddBookCategoryWindow();
                addBookCategoryWindow.DataContext = new AddBookCategoryWindowViewModel();
                p.Hide();
                addBookCategoryWindow.ShowDialog();
                ListBookCategory = LibraryDatabase.BookCategories();
                p.Show();
            });

            OKCommand = new RelayCommand<Window>((p) => { return p != null; }, (p) =>
            {
                UpdateBookItem.Book.IdBookCategory = BookCategorySelected.Id;

                UpdateBookItem.Update();

                p.Close();

            });

            CancelCommand = new RelayCommand<Window>((p) => { return p!=null; }, (p) => p.Close());
        }
    }
}
