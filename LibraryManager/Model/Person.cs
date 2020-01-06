using LibraryManager.Utility;
using System;
using System.Data;
using System.Linq;
using System.Xml.Linq;

namespace LibraryManager.Model
{
    public class Person
    {
        protected string id;
        protected string firstName;
        protected string lastName;
        protected string sex;
        protected DateTime birthDay;
        protected string email;
        protected string phone;

        public string Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = FormatData.CapitalizeEachWord(value); }
        public string LastName { get => lastName; set => lastName = FormatData.CapitalizeEachWord(value); }
        public DateTime BirthDay { get => birthDay; set => birthDay = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Sex { get => sex; set => sex = value; }
        public string FullName { get { return this.LastName + " " + this.FirstName; } }

        public Person(string fistName, string lastName, string sex, DateTime birthDay, string email, string phone)
        {
            this.firstName = fistName;
            this.lastName = lastName;
            this.sex = sex;
            this.birthDay = birthDay;
            this.email = email;
            this.phone = phone;
        }

        public Person(DataRow dataRow)
        {
            this.Id = dataRow["Id"].ToString();
            this.FirstName = dataRow["FirstName"].ToString();
            this.LastName = dataRow["LastName"].ToString();

            this.BirthDay = DateTime.Parse(dataRow["BirthDay"].ToString());

            this.Sex = dataRow["Sex"].ToString();
            this.Email = dataRow["Email"].ToString();
            this.Phone = dataRow["Phone"].ToString();
        }

        /// <summary>
        /// Cập nhật thông tin tài khoản vào data
        /// </summary>
        /// <param name="person"></param>
        /// <param name="accountType"></param>
        public virtual void Update()
        {
            /*
            string accountTypeName = "";

            switch (accountType)
            {
                case AccountType.ADMIN:
                    break;
                case AccountType.LIBRARIAN:
                    accountTypeName = "Librarian";
                    break;
                case AccountType.MEMBER:
                    accountTypeName = "Member";
                    break;
                default:
                    break;
            }

            string path = LibraryDatabase.GetDataPath() + accountTypeName + "Data.xml";
            try
            {
                XDocument DataXML = XDocument.Load(path);
                XElement updatePerson = DataXML.Descendants(accountTypeName).Where(c => c.Attribute("Id").Value.Equals(person.Id)).FirstOrDefault();

                updatePerson.Element("FirstName").Value = person.FirstName;
                updatePerson.Element("LastName").Value = person.LastName;
                updatePerson.Element("Sex").Value = person.Sex;
                updatePerson.Element("BirthDay").Value = person.BirthDay.ToString("dd/MM/yyyy");
                updatePerson.Element("Email").Value = person.Email;
                updatePerson.Element("Phone").Value = person.Phone;

                DataXML.Save(path);
            }
            catch (Exception) { }
            */
        }

        /// <summary>
        /// Thêm tài khoàn vào data
        /// </summary>
        public virtual void AddToData()
        {
        }
    }
}
