using LibraryManager.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.ViewModel
{
    public class ListBookBorrowUCViewModel : BaseViewModel
    {
        private ObservableCollection<BookBorrow> listBookBorrow;
        public ObservableCollection<BookBorrow> ListBookBorrow { get => listBookBorrow; set => listBookBorrow = value; }
        public ListBookBorrowUCViewModel(string idMember)
        {
            ListBookBorrow = Member.ListBookBorrow(idMember);
        }
    }
}
