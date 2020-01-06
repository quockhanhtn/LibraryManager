using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using LibraryManager.Utility;

namespace LibraryManager.Model
{
    public class BookItem
    {
        protected string idBook;
        protected int number;   // số sách ban đầu
        protected int counter;  // số lượng còn lại

        protected Book book;

        public string IdBook { get => idBook; set => idBook = value; }
        public int Number { get => number; set => number = value; }
        public int Counter { get => counter; set => counter = value; }

        public Book Book { get => book; set => book = value; }

        public BookItem(DataRow dataRow)
        {
            this.IdBook = dataRow["IdBook"].ToString();
            this.Number = FormatData.StringToInt(dataRow["Number"].ToString());
            this.Counter = FormatData.StringToInt(dataRow["Counter"].ToString());

            this.Book = Book.FindBookById(dataRow["IdBook"].ToString());
        }

        public BookItem(string idBook, int number, Book book)
        {
            this.IdBook = idBook;
            this.Number = number;
            this.Counter = number;

            this.Book = book;
        }

        public void Update()
        {
            this.Book.Update();

            string path = LibraryDatabase.GetDataPath() + "BookItemData.xml";
            try
            {
                XDocument DataXML = XDocument.Load(path);
                XElement updateLibrarian = DataXML.Descendants("BookItem").Where(c => c.Attribute("IdBook").Value.Equals(this.IdBook)).FirstOrDefault();

                updateLibrarian.Element("Number").Value = this.Number.ToString();
                updateLibrarian.Element("Counter").Value = this.Counter.ToString();

                DataXML.Save(path);
            }
            catch (Exception) { }
        }

        public void AddToData()
        {
            this.Book.AddToData();

            string path = LibraryDatabase.GetDataPath() + "BookItemData.xml";

            try
            {
                XDocument DataXML = XDocument.Load(path);
                XElement newLibrarian = new XElement("BookItem",
                    new XElement("Number", this.Number),
                    new XElement("Counter", this.Counter));

                newLibrarian.SetAttributeValue("IdBook", this.IdBook);

                DataXML.Element("BookItems").Add(newLibrarian);
                DataXML.Save(path);
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Xuất số lượng "numberExport" sách ra khỏi thư viên
        /// </summary>
        /// <param name="numberExport"></param>
        public void Export(int numberExport)
        {
            string path = LibraryDatabase.GetDataPath() + "BookItemData.xml";

            try
            {
                XDocument DataXML = XDocument.Load(path);
                XElement bookItem = DataXML.Descendants("BookItem").Where(c => c.Attribute("IdBook").Value.Equals(this.IdBook)).FirstOrDefault();
                bookItem.Element("Counter").Value = (int.Parse(bookItem.Element("Counter").Value.ToString()) - numberExport).ToString();
                bookItem.Element("Number").Value = (int.Parse(bookItem.Element("Number").Value.ToString()) - numberExport).ToString();
                DataXML.Save(path);
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Xóa bookItem và book
        /// </summary>
        public void Remove()
        {
            this.Book.Remove();

            string path = LibraryDatabase.GetDataPath() + "BookItemData.xml";
            try
            {
                XDocument DataXML = XDocument.Load(path);
                XElement bookItemDelete = DataXML.Descendants("BookItem").Where(c => c.Attribute("IdBook").Value.Equals(this.IdBook)).FirstOrDefault();
                bookItemDelete.Remove();
                DataXML.Save(path);
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Tăng Counter thêm 1
        /// </summary>
        /// <param name="idBook"></param>
        public static void Increase(string idBook)
        {
            string path = LibraryDatabase.GetDataPath() + "BookItemData.xml";

            try
            {
                XDocument DataXML = XDocument.Load(path);
                XElement bookItem = DataXML.Descendants("BookItem").Where(c => c.Attribute("IdBook").Value.Equals(idBook)).FirstOrDefault();
                bookItem.Element("Counter").Value = (int.Parse(bookItem.Element("Counter").Value.ToString()) + 1).ToString();
                DataXML.Save(path);
            }
            catch (Exception) { }
        }
        /// <summary>
        /// Giảm Counter thêm 1
        /// </summary>
        /// <param name="idBook"></param>
        public static void Decrease(string idBook)
        {
            string path = LibraryDatabase.GetDataPath() + "BookItemData.xml";

            try
            {
                XDocument DataXML = XDocument.Load(path);
                XElement bookItem = DataXML.Descendants("BookItem").Where(c => c.Attribute("IdBook").Value.Equals(idBook)).FirstOrDefault();
                bookItem.Element("Counter").Value = (int.Parse(bookItem.Element("Counter").Value.ToString()) - 1).ToString();
                DataXML.Save(path);
            }
            catch (Exception) { }
        }
    }
}
