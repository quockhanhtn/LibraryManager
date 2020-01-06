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
    public class BorrowBookUCViewModel : BaseViewModel
    {
        private Member member;
        private string idLibrarian;
        private Book bookInput;
        private ObservableCollection<BookBorrow> listBookBorrow;
        private List<BookBorrow> newListBookBorrow;

        public ICommand LoadInputIdPerSonCommand { get; set; }
        public ICommand InputBookNameCommand { get; set; }
        public ICommand TextboxIdBookChangeCommand { get; set; }
        public ICommand BorrowBookCommand { get; set; }
        public ICommand SaveChangeCommand { get; set; }
        public ICommand DiscardChangeCommand { get; set; }

        public Book BookInput { get => bookInput; set { bookInput = value; OnPropertyChanged(); } }
        public ObservableCollection<BookBorrow> ListBookBorrow { get => listBookBorrow; set { listBookBorrow = value; OnPropertyChanged(); } }
        public Member Member { get => member; set { member = value; OnPropertyChanged(); } }
        public string IdLibrarian { get => idLibrarian; set => idLibrarian = value; }
        public List<BookBorrow> NewListBookBorrow { get => newListBookBorrow; set => newListBookBorrow = value; }

        public BorrowBookUCViewModel(string idPersonBorrow, string idLibrarian)
        {
            NewListBookBorrow = new List<BookBorrow>();
            Member = Member.FindMemberById(idPersonBorrow);
            IdLibrarian = idLibrarian;

            ListBookBorrow = Member.ListBookBorrow(Member.Id);

            TextboxIdBookChangeCommand = new RelayCommand<TextBox>((p) => { return (p != null); }, (p) =>
            {
                if (p.Text == " ") { p.Text = ""; return; }
                BookInput = Book.FindBookById(p.Text);
            });

            BorrowBookCommand = new RelayCommand<TextBox>((p) => { return (p != null); }, (p) =>
            {
                if (BookInput == null) { return; }

                foreach (var item in LibraryDatabase.BookItems())
                {
                    if (item.IdBook == BookInput.Id && item.Counter == 0)
                    {
                        KBox.KMessageBox.Show("Sách đã cho được hết", "Thông báo", "OK", "", MessageBoxImage.Error);
                        //MessageBox.Show("Sách đã cho được hết", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }

                foreach (var item in ListBookBorrow)
                {
                    if (item.IdBook == BookInput.Id)
                    {
                        KBox.KMessageBox.Show("Sách \"" + BookInput.Name + "\" đã được mượn rồi", "Thông báo", "OK", "", MessageBoxImage.Error);
                        //MessageBox.Show("Sách \"" + BookInput.Name + "\" đã được mượn rồi", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
                BookBorrow borrow = new BookBorrow(Member.Id, IdLibrarian, BookInput.Id, DateTime.Now);
                ListBookBorrow.Add(borrow);
                NewListBookBorrow.Add(borrow);
            });

            SaveChangeCommand = new RelayCommand<UserControl>((p) => { return (p != null); }, (p) =>
            {
                foreach (var bookBorrow in NewListBookBorrow)
                {
                    bookBorrow.AddBorrowBook(Member.Id);
                    BookItem.Decrease(bookBorrow.IdBook);
                }
                ReturnBookManagerUserControl(p);
            });

            DiscardChangeCommand = new RelayCommand<UserControl>((p) => { return (p != null); }, (p) => { ReturnBookManagerUserControl(p); });
        }

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
