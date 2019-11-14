using LibraryManager.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Model
{
    public class User
    {
        private string sUsername;
        private string sPassword;
        private int iUserType;
        private string sPersonID;

        public string Username { get => sUsername; set => sUsername = value; }
        public string Password { get => sPassword; set => sPassword = value; }
        public int UserType { get => iUserType; set => iUserType = value; }
        public string PersonID { get => sPersonID; set => sPersonID = value; }

        public User() { }

        public User(string userName, string passWord)
        {
            this.Username = userName;
            this.Password = passWord;
        }

        public User(DataRow dataRow)
        {
            this.Username = dataRow["Username"].ToString();
            this.Password = dataRow["Password"].ToString();
            this.UserType = FomatData.StringToInt(dataRow["UserType"].ToString());
            this.PersonID = dataRow["PersonID"].ToString();
        }
    }
}
