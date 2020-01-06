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
    public class ReturnBookUCViewModel : BaseViewModel
    {
        private Member member;
        private string idLibrarian;
        private BookBorrow bookBorrowSelected;
        private ObservableCollection<BookBorrow> listBookBorrow;

        public ICommand ReturnBookCommand { get; set; }
        public ICommand CompleteCommand { get; set; }
        public BookBorrow BookBorrowSelected { get => bookBorrowSelected; set { bookBorrowSelected = value; OnPropertyChanged(); } }
        public ObservableCollection<BookBorrow> ListBookBorrow { get => listBookBorrow; set { listBookBorrow = value; OnPropertyChanged(); } }
        
        public string IdLibrarian { get => idLibrarian; set => idLibrarian = value; }
        public Member Member { get => member; set => member = value; }

        public ReturnBookUCViewModel(string idPersonBorrow, string idLibrarianLogin)
        {
            Member = Member.FindMemberById(idPersonBorrow);
            IdLibrarian = idLibrarianLogin;

            ListBookBorrow = Member.ListBookBorrow(Member.Id);

            ReturnBookCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                if (BookBorrowSelected == null) { return; }
                
                BookBorrowSelected.ReturnBook(Member.Id);
                BookItem.Increase(BookBorrowSelected.IdBook);
                ListBookBorrow.Remove(BookBorrowSelected);
            });

            CompleteCommand = new RelayCommand<UserControl>((p) => { return true; }, (p) =>
            {
                ReturnBookManagerUserControl(p);
                /*
                ObservableCollection<BookBorrow> listBookReturnLate = new ObservableCollection<BookBorrow>();
                foreach (var item in ListBookReturn)
                {
                    if (item.DateReturn.CompareTo(DateTime.Now) >= 0) //trả đúng hạn
                    {
                        LibraryDatabase.ReturnBook(item, idMember);
                        LibraryDatabase.IncreaseBook(item.IdBook);
                        ListBookBorrow.Remove(item);
                    }
                    else
                    {
                        listBookReturnLate.Add(item);
                    }
                }
                if (listBookReturnLate.Count > 0)
                {
                    p.Hide();
                    PunishWindow punishWindow = new PunishWindow();
                    punishWindow.DataContext = new PunishWindowViewModel(IdMember, IdLibrarian, listBookReturnLate);
                    punishWindow.ShowDialog();
                }
                p.Close();
                */
            });

            void ReturnBookManagerUserControl(UserControl uc)
            {
                var w = GetWindowParent(uc) as Window;
                var GridMain = w.FindName("GridMain") as Grid;
                GridMain.Children.Clear();

                if (IdLibrarian == "NV000")
                {
                    var wDataContext = w.DataContext as MainWindowViewModel;
                    GridMain.Children.Add(wDataContext.BookManagerUserControl);

                    //Update dữ liệu
                    var bookmanager = wDataContext.BookManagerUserControl.DataContext as BookManagerUCViewModel;
                    bookmanager.LoadList();
                }
                else
                {
                    var wDataContext = w.DataContext as LibrarianWindowViewModel;
                    GridMain.Children.Add(wDataContext.BookManagerUserControl);

                    //Update dữ liệu
                    var bookmanager = wDataContext.BookManagerUserControl.DataContext as BookManagerUCViewModel;
                    bookmanager.LoadList();
                }
            }
        }
    }
}
