using LibraryManager.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace LibraryManager.Model
{
    public class BookCategory
    {
        protected string id;
        protected string name;
        protected int borrowTime;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int BorrowTime { get => borrowTime; set => borrowTime = value; }
        public int NumberOfBook 
        { 
            get 
            {
                int number = 0;
                foreach (var book in LibraryDatabase.Books())
                {
                    if (book.IdBookCategory == this.Id) { number++; }
                }
                return number;
            } 
        }

        public BookCategory()
        {
            this.Id = "0";
            this.Name = "Tất cả";
        }

        public BookCategory(DataRow dataRow)
        {
            this.Id = dataRow["Id"].ToString();
            this.Name = dataRow["Name"].ToString();
            this.BorrowTime = FormatData.StringToInt(dataRow["BorrowTime"].ToString());
        }

        public BookCategory(string id, string name, int borrowTime)
        {
            this.Id = id;
            this.Name = name;
            this.BorrowTime = borrowTime;
        }

        public void AddToData()
        {
            string path = LibraryDatabase.GetDataPath() + "BookCategoryData.xml";
            try
            {
                XDocument DataXML = XDocument.Load(path);
                XElement newBookCategory = new XElement("BookCategory",
                    new XElement("Name", this.Name),
                    new XElement("BorrowTime", this.BorrowTime));
                newBookCategory.SetAttributeValue("Id", this.Id);

                DataXML.Element("BookCategories").Add(newBookCategory);
                DataXML.Save(path);
            }
            catch (Exception) { }
        }

        public void Update()
        {
            string path = LibraryDatabase.GetDataPath() + "BookCategoryData.xml";
            try
            {
                XDocument DataXML = XDocument.Load(path);
                XElement update = DataXML.Descendants("BookCategory").Where(c => c.Attribute("Id").Value.Equals(this.Id)).FirstOrDefault();

                update.Element("Name").Value = this.Name;
                update.Element("BorrowTime").Value = this.BorrowTime.ToString();
                DataXML.Save(path);
            }
            catch (Exception) { }
        }

        public void RemoveFromData()
        {
            if (this.NumberOfBook != 0) { return; }

            string path = LibraryDatabase.GetDataPath() + "BookCategoryData.xml";

            try
            {
                XDocument DataXML = XDocument.Load(path);
                XElement bookCategoryDelete = DataXML.Descendants("BookCategory").Where(c => c.Attribute("Id").Value.Equals(this.Id)).FirstOrDefault();
                bookCategoryDelete.Remove();
                DataXML.Save(path);
            }
            catch (Exception) { }
        }

        public static BookCategory AllBookCategory()
        {
            return new BookCategory();
        }
    }
}
