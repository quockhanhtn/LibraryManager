using LibraryManager.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibraryManager.Model
{
    public class Librarian : Person
    {
        protected bool isActive;

        public bool IsActive { get => isActive; set => isActive = value; }

        public string Note { get { return (IsActive == true) ? "" : "Đã nghỉ"; } }

        public Librarian(DataRow dataRow) : base(dataRow)
        {
            AutoLibrarianID.LastAutoID.Value = dataRow["Id"].ToString();
            this.IsActive = (dataRow["IsActive"].ToString() == "0") ? false : true;
        }

        public Librarian(string fistName, string lastName, string sex, DateTime birthDay, string email, string phone)
            : base(fistName, lastName, sex, birthDay, email, phone)
        {
            this.id = (new AutoLibrarianID()).Value;
            this.isActive = true;
        }

        /// <summary>
        /// Cập nhật thông tin như họ, tên, ngày sinh, giới tính, email, số điện thoại vào data
        /// </summary>
        public override void Update()
        {
            string path = LibraryDatabase.GetDataPath() + "LibrarianData.xml";
            try
            {
                XDocument DataXML = XDocument.Load(path);
                XElement update = DataXML.Descendants("Librarian").Where(c => c.Attribute("Id").Value.Equals(this.Id)).FirstOrDefault();

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
        /// Thêm dữ liệu nhân viên vào data
        /// </summary>
        public override void AddToData()
        {
            base.AddToData();
            //Thêm user đăng nhập
            string userPath = LibraryDatabase.GetDataPath() + "UserData\\LibrarianUserData.xml";
            try
            {
                XDocument DataXML = XDocument.Load(userPath);
                XElement newUser = new XElement("User",
                    new XElement("Username", this.Id),
                    new XElement("Password", PassWordEncode.MD5Hash(PassWordEncode.Base64Encode(this.Id))));
                newUser.SetAttributeValue("PersonID", this.Id);

                DataXML.Element("Users").Add(newUser);
                DataXML.Save(userPath);
            }
            catch (Exception) { }


            // Thêm thông tin
            string path = LibraryDatabase.GetDataPath() + "LibrarianData.xml";

            try
            {
                XDocument DataXML = XDocument.Load(path);
                XElement newLibrarian = new XElement("Librarian",
                    new XElement("FirstName", this.FirstName),
                    new XElement("LastName", this.LastName),
                    new XElement("Sex", this.Sex),
                    new XElement("BirthDay", this.BirthDay.ToString("dd/MM/yyyy")),
                    new XElement("Email", this.Email),
                    new XElement("Phone", this.Phone),
                    new XElement("IsActive", this.IsActive ? "1" : "0"));

                newLibrarian.SetAttributeValue("Id", this.Id);

                DataXML.Element("Librarians").Add(newLibrarian);
                DataXML.Save(path);
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Đang làm -> Thôi việc, Thôi việc -> Đang làm
        /// </summary>
        public void StopWork()
        {
            this.IsActive = !this.IsActive;

            string path = LibraryDatabase.GetDataPath() + "LibrarianData.xml";
            try
            {
                XDocument DataXML = XDocument.Load(path);
                XElement update = DataXML.Descendants("Librarian").Where(c => c.Attribute("Id").Value.Equals(this.Id)).FirstOrDefault();

                update.Element("IsActive").Value = (this.IsActive) ? "1" : "0";
                DataXML.Save(path);
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Tìm kiếm Librarian theo Id, nếu không tìm thấy trả về null
        /// </summary>
        /// <param name="idLibrarian"></param>
        /// <returns></returns>
        public static Librarian FindLibrarianById(string idLibrarian)
        {
            string path = LibraryDatabase.GetDataPath() + "LibrarianData.xml";

            try
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(path);
                DataTable dt = new DataTable();
                dt = dataSet.Tables["Librarian"];

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["Id"].ToString() == idLibrarian)
                    {
                        return new Librarian(dr);
                    }
                }
            }
            catch (Exception) { }

            return null;

            /*
            foreach (var item in LibraryDatabase.Librarians())
            {
                if (item.Id == idLibrarian)
                {
                    return item;
                }
            }
            return null;
            */
        }

        /// <summary>
        /// Tạo mã tự tăng cho lớp Librarian
        /// </summary>
        public class AutoLibrarianID
        {
            private static AutoLibrarianID lastAutoID = new AutoLibrarianID("NV0000");
            private string value;

            public string Value { get => value; set => this.value = value; }
            public static AutoLibrarianID LastAutoID { get => lastAutoID; set => lastAutoID = value; }

            private AutoLibrarianID(string v)
            {
                this.Value = v;
            }
            public AutoLibrarianID()
            {
                LastAutoID++;
                this.Value = LastAutoID.Value;
            }

            /// <summary>
            /// Tăng mã lên một đơn vị
            /// </summary>
            /// <param name="auto"></param>
            /// <returns></returns>
            public static AutoLibrarianID operator ++(AutoLibrarianID auto)
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

                return new AutoLibrarianID(text + number);
            }
        }
    }
}
