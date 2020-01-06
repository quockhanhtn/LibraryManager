using LibraryManager.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.ViewModel
{
    public class StatisticBookWindowViewModel : BaseViewModel
    {
        private string bookName;
        private ObservableCollection<BookBorrow> listBorrow;

        public string BookName { get => bookName; set { bookName = value.ToUpper(); OnPropertyChanged(); } }

        public ObservableCollection<BookBorrow> ListBorrow { get => listBorrow; set { listBorrow = value; OnPropertyChanged(); } }

        public StatisticBookWindowViewModel(Book book)
        {
            BookName = "SÁCH \"" + book.Name + "\"";
            ListBorrow = LibraryDatabase.BookBorrowList(book.Id);
        }
    }
}
