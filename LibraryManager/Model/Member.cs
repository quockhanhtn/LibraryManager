using LibraryManager.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace LibraryManager.Model
{
    public class Member : Person
    {
        protected bool isBlock;
        private string reasonBlock;
        private string idLibrarianBlock;

        public bool IsBlock { get => isBlock; set => isBlock = value; }
        /// <summary>
        /// Lý do bị khóa tài khoản
        /// </summary>
        public string ReasonBlock { get => reasonBlock; set => reasonBlock = value; }
        /// <summary>
        /// Id người khóa tài khoản
        /// </summary>
        public string IdLibrarianBlock { get => idLibrarianBlock; set => idLibrarianBlock = value; }
        /// <summary>
        /// Nếu IsBlock == true trả về "Khóa", ngược lại trả về "Mở khóa"
        /// </summary>
        public string Note { get { return (IsBlock == true) ? "Khóa" : "Mở khóa"; } }

        public Member(DataRow dataRow) : base(dataRow) 
        {
            AutoMemberID.LastAutoID.Value = dataRow["Id"].ToString();

            this.IsBlock = (dataRow["IsBlock"].ToString() == "1") ? true : false;

            if (this.IsBlock == true)
            {
                ReasonBlock = dataRow["ReasonBlock"].ToString();
                IdLibrarianBlock = dataRow["IdLibrarianBlock"].ToString();
            }
            else
            {
                ReasonBlock = "";
                IdLibrarianBlock = "";
            }

            //Tạo ra file lưu sách mượn

            string path = LibraryDatabase.GetDataPath() + "BookBorrowData\\" + this.Id + ".xml";
            if (!System.IO.File.Exists(path))
            {
                new XDocument(new XElement("BookBorrows")).Save(path);
            }
        }

        public Member(string fistName, string lastName, string sex, DateTime birthDay, string email, string phone)
            : base(fistName, lastName, sex, birthDay, email, phone)
        {
            this.Id = (new AutoMemberID()).Value;
            this.IsBlock = true;
            ReasonBlock = "";
            IdLibrarianBlock = "";
        }

        /// <summary>
        /// khóa tài khoản thành viên, nếu thành viên bị khóa thì mở khóa
        /// </summary>
        /// <param name="idLibrarian">Mã nhân viên chặn</param>
        /// <param name="reasonBlock">Lý do chặn</param>
        public void Block(string idLibrarian, string reasonBlock)
        {
            if (this.IsBlock)
            {
                this.IsBlock = false;
                this.IdLibrarianBlock = "";
                this.ReasonBlock = "";
            }
            else
            {
                this.IsBlock = true;
                this.IdLibrarianBlock = idLibrarian;
                this.ReasonBlock = reasonBlock;
            }

            string path = LibraryDatabase.GetDataPath() + "MemberData.xml";
            try
            {
                XDocument DataXML = XDocument.Load(path);
                XElement update = DataXML.Descendants("Member").Where(c => c.Attribute("Id").Value.Equals(this.Id)).FirstOrDefault();

                update.Element("IsBlock").Value = (this.IsBlock) ? "1" : "0";
                update.Element("IdLibrarianBlock").Value = this.IdLibrarianBlock;
                update.Element("ReasonBlock").Value = this.ReasonBlock;
                DataXML.Save(path);
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Cập nhật thông tin như họ, tên, ngày sinh, giới tính, email, số điện thoại vào data
        /// </summary>
        public override void Update()
        {
            string path = LibraryDatabase.GetDataPath() + "MemberData.xml";
            try
            {
                XDocument DataXML = XDocument.Load(path);
                XElement update = DataXML.Descendants("Member").Where(c => c.Attribute("Id").Value.Equals(this.Id)).FirstOrDefault();

                update.Element("FirstName").Value = this.FirstName;
                update.Element("LastName").Value = this.LastName;
                update.Element("Sex").Value = this.Sex;
                update.Element("BirthDay").Value = this.BirthDay.ToString("dd/MM/yyyy");
                update.Element("Email").Value = this.Email;
                update.Element("Phone").Value = this.Phone;
                DataXML.Save(path);
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Thêm thành viên vào data
        /// </summary>
        public override void AddToData()
        {
            base.AddToData();
            //Thêm user đăng nhập
            string userPath = LibraryDatabase.GetDataPath() + "UserData\\MemberUserData.xml";
            try
            {
                XDocument DataXML = XDocument.Load(userPath);
                XElement newUser = new XElement("User",
                    new XElement("Username", this.Id),
                    new XElement("Password", PassWordEncode.MD5Hash(PassWordEncode.Base64Encode("12345"))));
                newUser.SetAttributeValue("PersonID", this.Id);

                DataXML.Element("Users").Add(newUser);
                DataXML.Save(userPath);
            }
            catch (Exception) { }


            // Thêm thông tin
            string path = LibraryDatabase.GetDataPath() + "MemberData.xml";

            try
            {
                XDocument DataXML = XDocument.Load(path);
                XElement newMember = new XElement("Member",
                    new XElement("FirstName", this.FirstName),
                    new XElement("LastName", this.LastName),
                    new XElement("Sex", this.Sex),
                    new XElement("BirthDay", this.BirthDay.ToString("dd/MM/yyyy")),
                    new XElement("Email", this.Email),
                    new XElement("Phone", this.Phone),
                    new XElement("IsBlock", "0"),
                    new XElement("IdLibrarianBlock", ""),
                    new XElement("ReasonBlock", ""));

                newMember.SetAttributeValue("Id", this.Id);

                DataXML.Element("Members").Add(newMember);
                DataXML.Save(path);
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Tìm kiếm Member theo Id, nếu không tìm thấy trả về null
        /// </summary>
        /// <param name="idMember"></param>
        /// <returns></returns>
        public static Member FindMemberById(string idMember)
        {
            string path = LibraryDatabase.GetDataPath() + "MemberData.xml";

            try
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(path);
                DataTable dt = new DataTable();
                dt = dataSet.Tables["Member"];

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["Id"].ToString() == idMember)
                    {
                        return new Member(dr);
                    }
                }
            }
            catch (Exception) { }

            return null;
        }
        /// <summary>
        /// Trả về Danh sách BookBorrow của thành viên có mã là "idMember" đã mượn
        /// </summary>
        /// <param name="idMember"></param>
        /// <returns></returns>
        public static ObservableCollection<BookBorrow> ListBookBorrow(string idMember)
        {
            string path = LibraryDatabase.GetDataPath() + "BookBorrowData\\" + idMember + ".xml";
            ObservableCollection<BookBorrow> bookBorrows = new ObservableCollection<BookBorrow>();

            try
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(path);
                DataTable dt = new DataTable();
                dt = dataSet.Tables["BookBorrow"];

                foreach (DataRow dr in dt.Rows)
                {
                    BookBorrow borrow = new BookBorrow(dr, idMember);
                    bookBorrows.Add(borrow);
                }
            }
            catch (Exception) { }

            return bookBorrows;
        }

        /// <summary>
        /// Tạo mã tự tăng cho lớp Member
        /// </summary>
        public class AutoMemberID
        {
            private static AutoMemberID lastAutoID = new AutoMemberID("M00000");
            private string value;

            public string Value { get => value; set => this.value = value; }
            public static AutoMemberID LastAutoID { get => lastAutoID; set => lastAutoID = value; }

            private AutoMemberID(string v)
            {
                this.Value = v;
            }
            public AutoMemberID()
            {
                LastAutoID++;
                this.Value = LastAutoID.Value;
            }

            public static AutoMemberID operator ++(AutoMemberID auto)
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

                return new AutoMemberID(text + number);
            }
        }
    }
}
