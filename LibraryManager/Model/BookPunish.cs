using LibraryManager.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Model
{
    public class BookPunish
    {
        private string idMember;
        private string idLibrarian;
        private string idBook;
        private DateTime dateBorrow;
        private DateTime datePunish;

        private Book book;

        public string IdMember { get => idMember; set => idMember = value; }
        public string IdLibrarian { get => idLibrarian; set => idLibrarian = value; }
        public string IdBook { get => idBook; set => idBook = value; }
        public DateTime DateBorrow { get => dateBorrow; set => dateBorrow = value; }
        public DateTime DatePunish { get => datePunish; set => datePunish = value; }
        public Book Book { get => book; set => book = value; }

        public BookPunish(DataRow dataRow)
        {
            this.IdMember = dataRow["IdMember"].ToString();
            this.IdBook = dataRow["IdBook"].ToString();
            this.IdLibrarian = dataRow["IdLibrarian"].ToString();
            string[] dayData = dataRow["DateBorrow"].ToString().Split('/');
            this.DateBorrow = new DateTime(FormatData.StringToInt(dayData[2]), FormatData.StringToInt(dayData[1]), FormatData.StringToInt(dayData[1]));

            this.Book = Book.FindBookById(this.IdBook);
        }
        public BookPunish(string idMember, string idLibrarian, string idBook, DateTime dateBorrow)
        {
            this.IdMember = idMember;
            this.IdLibrarian = idLibrarian;
            this.IdBook = idBook;
            this.DateBorrow = dateBorrow;

            this.Book = Book.FindBookById(this.IdBook);
        }

        public DateTime DateReturn { get { return this.DateBorrow.AddDays(Book.MaxDayBorrow(this.IdBook)); } }
        public string DateBorrowDisplay { get { return this.DateBorrow.ToString("dd/MM/yyyy"); } }
        public string DateReturnDisplay { get { return this.DateReturn.ToString("dd/MM/yyyy"); } }
        public string Librarian { get { Librarian librarian = Model.Librarian.FindLibrarianById(this.IdLibrarian); return librarian.FullName; } }
        public string Member { get { Member member = Model.Member.FindMemberById(this.IdMember); return member.FullName; } }
    }
}
