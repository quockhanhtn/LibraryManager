using LibraryManager.Utility;
using LibraryManager.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibraryManager.Model
{
    public class BookBorrow
    {
        private string idMember;
        private string idLibrarian;
        private string idBook;
        private DateTime dateBorrow;

        private Book book;

        public string IdMember { get => idMember; set => idMember = value; }
        public string IdLibrarian { get => idLibrarian; set => idLibrarian = value; }
        public string IdBook { get => idBook; set => idBook = value; }
        public DateTime DateBorrow { get => dateBorrow; set => dateBorrow = value; }
        public Book Book { get => book; set => book = value; }
        public DateTime DateReturn { get { return this.DateBorrow.AddDays(Book.MaxDayBorrow(this.IdBook)); } }
        public string Librarian
        {
            get
            {
                if (IdLibrarian == "NV000")
                {
                    return "Quản trị viên";
                }
                Librarian librarian = Model.Librarian.FindLibrarianById(this.IdLibrarian);
                return librarian.FullName;
            }
        }
        public string Member { get { Member member = Model.Member.FindMemberById(this.IdMember); return member.LastName + " " + member.FirstName; } }

        public BookBorrow(DataRow dataRow, string idMember)
        {
            this.IdMember = idMember;
            this.IdBook = dataRow["IdBook"].ToString();
            this.IdLibrarian = dataRow["IdLibrarian"].ToString();

            this.DateBorrow = DateTime.Parse(dataRow["DateBorrow"].ToString());

            this.Book = Book.FindBookById(this.IdBook);
        }
        public BookBorrow(string idMember, string idLibrarian, string idBook, DateTime dateBorrow)
        {
            this.IdMember = idMember;
            this.IdLibrarian = idLibrarian;
            this.IdBook = idBook;
            this.DateBorrow = dateBorrow;

            this.Book = Book.FindBookById(this.IdBook);
        }

        public void AddBorrowBook(string idMember)
        {
            string path = LibraryDatabase.GetDataPath() + "BookBorrowData\\" + idMember + ".xml";

            try
            {
                XDocument DataXML = XDocument.Load(path);
                XElement newLibrarian = new XElement("BookBorrow",
                    new XElement("IdLibrarian", this.IdLibrarian),
                    new XElement("DateBorrow", this.DateBorrow.ToString("dd/MM/yyyy")));
                newLibrarian.SetAttributeValue("IdBook", this.IdBook);

                DataXML.Element("BookBorrows").Add(newLibrarian);
                DataXML.Save(path);
            }
            catch (Exception) { }
        }

        public void ReturnBook(string idMember)
        {
            string path = LibraryDatabase.GetDataPath() + "BookBorrowData\\" + idMember + ".xml";

            try
            {
                XDocument DataXML = XDocument.Load(path);
                XElement cBookBorrow = DataXML.Descendants("BookBorrow").Where(c => c.Attribute("IdBook").Value.Equals(this.IdBook)).FirstOrDefault();
                cBookBorrow.Remove();
                DataXML.Save(path);
            }
            catch (Exception) { }
        }
    }
}
