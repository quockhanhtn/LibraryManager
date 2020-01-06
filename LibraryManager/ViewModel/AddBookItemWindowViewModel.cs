using LibraryManager.Interface;
using LibraryManager.Model;
using LibraryManager.Utility;
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
    public class AddBookItemWindowViewModel : BaseViewModel, IOKCancelCommand
    {
        private ObservableCollection<BookCategory> listBookCategory;
        private BookCategory bookCategorySelected;

        public ObservableCollection<BookCategory> ListBookCategory { get => listBookCategory; set { listBookCategory = value; OnPropertyChanged(); } }
        public BookCategory BookCategorySelected { get => bookCategorySelected; set { bookCategorySelected = value; OnPropertyChanged(); } }
        
        public ICommand AddBookCategoryCommand { get; set; }
        public ICommand OKCommand { get; set; }
        public ICommand RetypeCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public AddBookItemWindowViewModel()
        {
            ListBookCategory = LibraryDatabase.BookCategories();

            AddBookCategoryCommand = new RelayCommand<Window>((p) => { return p != null; }, (p) =>
            {
                AddBookCategoryWindow addBookCategoryWindow = new AddBookCategoryWindow();
                addBookCategoryWindow.DataContext = new AddBookCategoryWindowViewModel();
                p.Hide();
                addBookCategoryWindow.ShowDialog();
                ListBookCategory = LibraryDatabase.BookCategories();
                p.Show();
            });

            OKCommand = new RelayCommand<Window>((p) => { return (p != null); }, (p) =>
            {
                var cbxBookCategory = p.FindName("cbxBookCategory") as ComboBox;
                var tbxName = p.FindName("tbxName") as TextBox;
                var tbxAuthor = p.FindName("tbxAuthor") as TextBox;
                var tbxPublisher = p.FindName("tbxPublisher") as TextBox;
                var tbxYearPublish = p.FindName("tbxYearPublish") as TextBox;
                var tbxPrice = p.FindName("tbxPrice") as TextBox;
                var tbxNumber = p.FindName("tbxNumber") as TextBox;

                var tblBookCategoryWarning = p.FindName("tblBookCategoryWarning") as TextBlock;
                var tblNameWarning = p.FindName("tblNameWarning") as TextBlock;
                var tblAuthorWarning = p.FindName("tblAuthorWarning") as TextBlock;
                var tblPublisherWarning = p.FindName("tblPublisherWarning") as TextBlock;
                var tblYearPublishWarning = p.FindName("tblYearPublishWarning") as TextBlock;
                var tblPriceWarning = p.FindName("tblPriceWarning") as TextBlock;
                var tblNumberWarning = p.FindName("tblNumberWarning") as TextBlock;

                if (cbxBookCategory.SelectedItem == null) { tblBookCategoryWarning.Visibility = Visibility.Visible; return; }
                else { tblBookCategoryWarning.Visibility = Visibility.Hidden; }

                if (tbxName.Text == "") { tblNameWarning.Visibility = Visibility.Visible; return; }
                else { tblNameWarning.Visibility = Visibility.Hidden; }

                if (tbxAuthor.Text == "") { tblAuthorWarning.Visibility = Visibility.Visible; return; }
                else { tblAuthorWarning.Visibility = Visibility.Hidden; }

                if (tbxPublisher.Text == "") { tblPublisherWarning.Visibility = Visibility.Visible; return; }
                else { tblPublisherWarning.Visibility = Visibility.Hidden; }

                int yearPublish;
                if (tbxYearPublish.Text == "" || !int.TryParse(tbxYearPublish.Text, out yearPublish) || yearPublish < 1900 || yearPublish > DateTime.Now.Year)
                {
                    tblYearPublishWarning.Visibility = Visibility.Visible;
                    return;
                }
                else { tblYearPublishWarning.Visibility = Visibility.Hidden; }

                double price;
                if (tbxPrice.Text == "" || !double.TryParse(tbxPrice.Text, out price) || price < 1000)
                {
                    tblPriceWarning.Visibility = Visibility.Visible;
                    return;
                }
                else { tblPriceWarning.Visibility = Visibility.Hidden; }

                int number;
                if (tbxNumber.Text == "" || !int.TryParse(tbxNumber.Text, out number) || number <= 0)
                {
                    tblNumberWarning.Visibility = Visibility.Visible;
                    return;
                }
                else { tblNumberWarning.Visibility = Visibility.Hidden; }

                Book newBook = new Book(BookCategorySelected.Id, tbxName.Text, tbxAuthor.Text, tbxPublisher.Text, yearPublish, price);
                BookItem newBookItem = new BookItem(newBook.Id, number, newBook);
                newBookItem.AddToData();

                p.Close();

            });

            RetypeCommand = new RelayCommand<Window>((p) => { return (p != null); }, (p) =>
            {
                var cbxBookCategory = p.FindName("cbxBookCategory") as ComboBox;
                var tbxName = p.FindName("tbxName") as TextBox;
                var tbxAuthor = p.FindName("tbxAuthor") as TextBox;
                var tbxPublisher = p.FindName("tbxPublisher") as TextBox;
                var tbxYearPublish = p.FindName("tbxYearPublish") as TextBox;
                var tbxPrice = p.FindName("tbxPrice") as TextBox;
                var tbxNumber = p.FindName("tbxNumber") as TextBox;

                cbxBookCategory.SelectedItem = null;
                tbxYearPublish.Text = tbxNumber.Text = "";
                tbxName.Text = tbxAuthor.Text = tbxPublisher.Text = tbxPrice.Text = "";
            });

            CancelCommand = new RelayCommand<Window>((p) => { return (p != null); }, (p) => p.Close());
        }
    }
}
