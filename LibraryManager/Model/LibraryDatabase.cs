using LibraryManager.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace LibraryManager.Model
{
    public static class LibraryDatabase
    {
        /// <summary>
        /// Lấy danh sách tài khoản từ thư mục UserData
        /// </summary>
        /// <param name="accountType"></param>
        /// <returns>Danh sách tài khảon có UserType = accountType truyền vào</returns>
        public static List<User> Users(AccountType accountType)
        {
            string path = GetDataPath() + "UserData\\";
            List<User> users = new List<User>();

            switch (accountType)
            {
                case AccountType.ADMIN:
                    path += "AdminUserData.xml";
                    break;
                case AccountType.LIBRARIAN:
                    path += "LibrarianUserData.xml";
                    break;
                default:
                    path += "MemberUserData.xml";
                    break;
            }

            try
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(path);
                DataTable dt = new DataTable();
                dt = dataSet.Tables["User"];

                foreach (DataRow dr in dt.Rows)
                {
                    User user = new User(dr, accountType);
                    users.Add(user);
                }
            }
            catch (Exception) { }

            return users;
        }
        /// <summary>
        /// Lấy danh sách nhân viên thư viện từ thư mục Data
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Librarian> Librarians()
        {
            string path = GetDataPath() + "LibrarianData.xml";
            ObservableCollection<Librarian> librarians = new ObservableCollection<Librarian>();

            try
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(path);
                DataTable dt = new DataTable();
                dt = dataSet.Tables["Librarian"];

                foreach (DataRow dr in dt.Rows)
                {
                    Librarian librarian = new Librarian(dr);
                    if (librarian.Id == "NV000") { continue; }
                    librarians.Add(librarian);
                }
            }
            catch (Exception) { }

            return librarians;
        }
        /// <summary>
        /// Trả về danh sách Member có IsActive == isActiveFilter
        /// </summary>
        /// <param name="isActiveFilter"></param>
        /// <returns></returns>
        public static ObservableCollection<Librarian> Librarians(bool isActiveFilter)
        {
            string path = GetDataPath() + "LibrarianData.xml";
            ObservableCollection<Librarian> librarians = new ObservableCollection<Librarian>();

            try
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(path);
                DataTable dt = new DataTable();
                dt = dataSet.Tables["Librarian"];

                foreach (DataRow dr in dt.Rows)
                {
                    Librarian librarian = new Librarian(dr);
                    if (librarian.IsActive == isActiveFilter && librarian.Id != "NV000")
                    {
                        librarians.Add(librarian);
                    }
                }
            }
            catch (Exception) { }

            return librarians;
        }
        /// <summary>
        /// Lấy danh sách thành viên thư viện từ thư mục Data
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Member> Members()
        {
            string path = GetDataPath() + "MemberData.xml";
            ObservableCollection<Member> members = new ObservableCollection<Member>();

            try
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(path);
                DataTable dt = new DataTable();
                dt = dataSet.Tables["Member"];

                foreach (DataRow dr in dt.Rows)
                {
                    Member member = new Member(dr);
                    members.Add(member);
                }
            }
            catch (Exception) { }

            return members;
        }

        /// <summary>
        /// Trả về danh sách Member có IsBlock == isBlockFilter
        /// </summary>
        /// <param name="isBlockFilter"></param>
        /// <returns></returns>
        public static ObservableCollection<Member> Members(bool isBlockFilter)
        {
            string path = GetDataPath() + "MemberData.xml";
            ObservableCollection<Member> members = new ObservableCollection<Member>();

            try
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(path);
                DataTable dt = new DataTable();
                dt = dataSet.Tables["Member"];

                foreach (DataRow dr in dt.Rows)
                {
                    Member member = new Member(dr);
                    if (member.IsBlock == isBlockFilter) { members.Add(member); }
                }
            }
            catch (Exception) { }

            return members;
        }

        /// <summary>
        /// Lấy danh sách BookCategory từ thư mục Data
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<BookCategory> BookCategories()
        {
            string path = GetDataPath() + "BookCategoryData.xml";
            ObservableCollection<BookCategory> bookCategories = new ObservableCollection<BookCategory>();

            try
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(path);
                DataTable dt = new DataTable();
                dt = dataSet.Tables["BookCategory"];

                foreach (DataRow dr in dt.Rows)
                {
                    BookCategory bookCategory = new BookCategory(dr);
                    bookCategories.Add(bookCategory);
                }
            }
            catch (Exception) { }

            return bookCategories;
        }
        /// <summary>
        /// Lấy danh sách Book từ thư mục Data
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<Book> Books()
        {
            string path = GetDataPath() + "BookData.xml";
            ObservableCollection<Book> books = new ObservableCollection<Book>();

            try
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(path);
                DataTable dt = new DataTable();
                dt = dataSet.Tables["Book"];

                foreach (DataRow dr in dt.Rows)
                {
                    Book book = new Book(dr);
                    books.Add(book);
                }
            }
            catch (Exception) { }

            return books;
        }
        /// <summary>
        /// Lấy danh sách BookItem từ thư mục Data
        /// </summary>
        /// <returns></returns>
        public static ObservableCollection<BookItem> BookItems()
        {
            string path = GetDataPath() + "BookItemData.xml";
            ObservableCollection<BookItem> bookItems = new ObservableCollection<BookItem>();

            try
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(path);
                DataTable dt = new DataTable();
                dt = dataSet.Tables["BookItem"];

                foreach (DataRow dr in dt.Rows)
                {
                    BookItem bookItem = new BookItem(dr);
                    bookItems.Add(bookItem);
                }
            }
            catch (Exception) { }

            return bookItems;
        }
        /// <summary>
        /// Lấy danh sách BookItem từ thư mục Data theo chuyên mục sách
        /// </summary>
        /// <param name="bookCategoryFilter"></param>
        /// <returns></returns>
        public static ObservableCollection<BookItem> BookItems(BookCategory bookCategoryFilter)
        {
            string path = GetDataPath() + "BookItemData.xml";
            ObservableCollection<BookItem> bookItems = new ObservableCollection<BookItem>();

            try
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(path);
                DataTable dt = new DataTable();
                dt = dataSet.Tables["BookItem"];

                if (bookCategoryFilter.Id == "0" || bookCategoryFilter == null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BookItem bookItem = new BookItem(dr);
                        bookItems.Add(bookItem);
                    }
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        BookItem bookItem = new BookItem(dr);
                        if (bookItem.Book.BookCategory == bookCategoryFilter.Name)
                        {
                            bookItems.Add(bookItem);
                        }
                    }
                }
            }
            catch (Exception) { }

            return bookItems;
        }
        /// <summary>
        /// Kiểm tra mật khẩu
        /// </summary>
        /// <param name="idPerson"></param>
        /// <param name="passWord"></param>
        /// <param name="accountType"></param>
        /// <returns></returns>
        public static bool CheckPassword(string idPerson, string passWord, AccountType accountType)
        {
            string path = GetDataPath() + "UserData\\";

            switch (accountType)
            {
                case AccountType.ADMIN:
                    path += "AdminUserData.xml";
                    break;
                case AccountType.LIBRARIAN:
                    path += "LibrarianUserData.xml";
                    break;
                default:
                    path += "MemberUserData.xml";
                    break;
            }

            try
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(path);
                DataTable dt = new DataTable();
                dt = dataSet.Tables["User"];

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["PersonID"].ToString() == idPerson && dr["Password"].ToString() == PassWordEncode.MD5Hash(PassWordEncode.Base64Encode(passWord)))
                    {
                        return true;
                    }
                }
            }
            catch (Exception) { }

            return false;
        }
        /// <summary>
        /// Đặt mật khẩu mới
        /// </summary>
        /// <param name="idPerson"></param>
        /// <param name="passWord"></param>
        /// <param name="accountType"></param>
        public static void SetNewPassword(string idPerson, string passWord, AccountType accountType)
        {
            string path = GetDataPath() + "UserData\\";

            switch (accountType)
            {
                case AccountType.ADMIN:
                    path += "AdminUserData.xml";
                    break;
                case AccountType.LIBRARIAN:
                    path += "LibrarianUserData.xml";
                    break;
                default:
                    path += "MemberUserData.xml";
                    break;
            }

            try
            {
                XDocument DataXML = XDocument.Load(path);
                XElement updateUser = DataXML.Descendants("User").Where(c => c.Attribute("PersonID").Value.Equals(idPerson)).FirstOrDefault();

                updateUser.Element("Password").Value = PassWordEncode.MD5Hash(PassWordEncode.Base64Encode(passWord));

                DataXML.Save(path);
            }
            catch (Exception) { }
        }
        /// <summary>
        /// Thông kê những người đã mượn sách có mã là "idBook"
        /// </summary>
        /// <param name="idBook"></param>
        /// <returns></returns>
        public static ObservableCollection<BookBorrow> BookBorrowList(string idBook)
        {
            ObservableCollection<BookBorrow> borrows = new ObservableCollection<BookBorrow>();
            foreach (var item in LibraryDatabase.Users(AccountType.MEMBER))
            {
                foreach (var borrowItem in Member.ListBookBorrow(item.PersonID))
                {
                    if (borrowItem.IdBook == idBook)
                    {
                        borrows.Add(borrowItem);
                    }
                }
            }
            return borrows;
        }

        /// <summary>
        /// Trả về đường dẫn đến thư mục Data
        /// </summary>
        /// <returns>string path</returns>
        public static string GetDataPath()
        {
            return LibraryDatabase.GetApplicationFolderPath() + "\\Data\\";
        }

        /// <summary>
        /// Trả về đường dẫn đến thư mục chứa chương trình
        /// </summary>
        /// <returns>string path</returns>
        public static string GetApplicationFolderPath()
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            path = path.Substring(0, path.LastIndexOf("\\"));
            return path;
        }
    }
}
