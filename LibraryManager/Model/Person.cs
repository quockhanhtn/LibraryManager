using LibraryManager.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Model
{
    public class Person
    {
        protected string sId;
        protected string sFirstName;
        protected string sLastName;
        protected Date dBirthDay;
        protected string sEmail;
        protected string sPhone;

        public string Id { get => sId; set => sId = value; }
        public string FirstName { get => sFirstName; set => sFirstName = FomatData.StringName(value); }
        public string LastName { get => sLastName; set => sLastName = FomatData.StringName(value); }
        public Date BirthDay { get => dBirthDay; set => dBirthDay = value; }
        public string Email { get => sEmail; set => sEmail = value; }
        public string Phone { get => sPhone; set => sPhone = value; }

        public Person(string id, string firstName, string lastName, Date birthday, string email, string phone)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDay = birthday;
            this.Email = email;
            this.Phone = phone;
        }

        public Person(string id, string firstName, string lastName, string birthday, string email, string phone)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDay = new Date(birthday);
            this.Email = email;
            this.Phone = phone;
        }
    }
}
