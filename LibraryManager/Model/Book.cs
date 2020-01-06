using LibraryManager.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibraryManager.Model
{
    public class Book
    {
        protected string id;
        protected string name;
        protected string author;
        protected string publisher;
        protected int yearPublish;
        protected string idBookCategory;
        protected double price;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Author { get => author; set => author = FormatData.CapitalizeEachWord(value); }
        public string Publisher { get => publisher; set => publisher = value; }
        public int YearPublish { get => yearPublish; set => yearPublish = value; }
        public string IdBookCategory { get => idBookCategory; set => idBookCategory = value; }
        public double Price { get => price; set => price = value; }

        public int BorrowTime
        {
            get 
            {
                ObservableCollection<BookCategory> bookCategories = LibraryDatabase.BookCategories();
                foreach (var item in bookCategories)
                {
                    if (item.Id == this.idBookCategory)
                    {
                        return item.BorrowTime;
                    }
                }
                return 0;
            }
        }

        public string BookCategory
        {
            get
            {
                ObservableCollection<BookCategory> bookCategories = LibraryDatabase.BookCategories();
                foreach (var item in bookCategories)
                {
                    if (item.Id == this.idBookCategory)
                    {
                        return item.Name;
                    }
                }
                return "";
            }
        }

        public Book(DataRow dataRow)
        {
            AutoBookID.LastAutoID.Value = dataRow["Id"].ToString();

            this.Id = dataRow["Id"].ToString();
            this.Name = dataRow["Name"].ToString();
            this.Author = dataRow["Author"].ToString();
            this.Publisher = dataRow["Publisher"].ToString();
            this.YearPublish = FormatData.StringToInt(dataRow["YearPublish"].ToString());
            this.IdBookCategory = dataRow["IdBookCategory"].ToString();
            this.Price = FormatData.StringToDouble(dataRow["Price"].ToString());
        }

        public Book(string idBookCategory, string name, string author, string publisher, int year, double price)
        {
            this.IdBookCategory = idBookCategory;
            this.Id = (new AutoBookID()).Value;
            this.Name = name;
            this.Author = author;
            this.Publisher = publisher;
            this.YearPublish = year;
            this.Price = price;
        }

        public void Update()
        {
            string path = LibraryDatabase.GetDataPath() + "BookData.xml";
            try
            {
                XDocument DataXML = XDocument.Load(path);
                XElement updateLibrarian = DataXML.Descendants("Book").Where(c => c.Attribute("Id").Value.Equals(this.Id)).FirstOrDefault();

                updateLibrarian.Element("Name").Value = this.Name;
                updateLibrarian.Element("Author").Value = this.Author;
                updateLibrarian.Element("Publisher").Value = this.Publisher;
                updateLibrarian.Element("YearPublish").Value = this.YearPublish.ToString();
                updateLibrarian.Element("IdBookCategory").Value = this.IdBookCategory;
                updateLibrarian.Element("Price").Value = this.Price.ToString();

                DataXML.Save(path);
            }
            catch (Exception) { }
        }

        public void Remove()
        {
            string path = LibraryDatabase.GetDataPath() + "BookData.xml";

            try
            {
                XDocument DataXML = XDocument.Load(path);
                XElement bookDelete = DataXML.Descendants("Book").Where(c => c.Attribute("Id").Value.Equals(this.Id)).FirstOrDefault();
                bookDelete.Remove();
                DataXML.Save(path);
            }
            catch (Exception) { }
        }
        public void AddToData()
        {
            string path = LibraryDatabase.GetDataPath() + "BookData.xml";

            try
            {
                XDocument DataXML = XDocument.Load(path);
                XElement newLibrarian = new XElement("Book",
                    new XElement("Name", this.Name),
                    new XElement("Author", this.Author),
                    new XElement("Publisher", this.Publisher),
                    new XElement("YearPublish", this.YearPublish),
                    new XElement("IdBookCategory", this.IdBookCategory),
                    new XElement("Price", this.Price));

                newLibrarian.SetAttributeValue("Id", this.Id);

                DataXML.Element("Books").Add(newLibrarian);
                DataXML.Save(path);
            }
            catch (Exception) { }
        }

        public static Book FindBookById(string idBook)
        {
            foreach (var item in LibraryDatabase.Books())
            {
                if (item.Id == idBook)
                {
                    return item;
                }
            }

            return null;
        }

        public static int MaxDayBorrow(string idBook)
        {
            Book book = Book.FindBookById(idBook);

            foreach (var item in LibraryDatabase.BookCategories())
            {
                if (item.Id == book.IdBookCategory)
                {
                    return item.BorrowTime;
                }
            }
            return 0;
        }

        private class AutoBookID
        {
            private static AutoBookID lastAutoID = new AutoBookID("B00000");
            private string value;

            public string Value { get => value; set => this.value = value; }
            public static AutoBookID LastAutoID { get => lastAutoID; set => lastAutoID = value; }

            private AutoBookID(string v)
            {
                this.Value = v;
            }
            public AutoBookID()
            {
                LastAutoID++;
                this.Value = LastAutoID.Value;
            }

            public static AutoBookID operator ++(AutoBookID auto)
            {
                string text = "";
                int len = auto.Value.Length;

                for (int i = 0; i < auto.Value.Length; i++)
                {
                    if (!char.IsDigit(auto.Value[i]))
                    {
                        text += auto.Value[i].ToString();
                        auto.Value = auto.Value.Remove(i, 1);
                        i--;
                    }
                }

                string number = (double.Parse(auto.Value) + 1).ToString();

                while (number.Length < len - text.Length)
                {
                    number = "0" + number;
                }

                return new AutoBookID(text + number);
            }
        }
    }
}
