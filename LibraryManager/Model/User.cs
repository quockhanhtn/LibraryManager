using LibraryManager.Utility;
using LibraryManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum AccountType
{
    ADMIN, LIBRARIAN, MEMBER
}

namespace LibraryManager.Model
{
    public class User
    {
        private string username;
        private string password;
        private AccountType accountType;
        private string personID;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public AccountType AccountType { get => accountType; set => accountType = value; }
        public string PersonID { get => personID; set => personID = value; }

        public User(DataRow dataRow, AccountType accountType)
        {
            this.Username = dataRow["Username"].ToString();
            this.Password = dataRow["Password"].ToString();
            this.AccountType = accountType;
            this.PersonID = dataRow["PersonID"].ToString();
        }

        /// <summary>
        /// Kiểm tra tài khoản có "userName" và "passWord" loại "accountType" có đúng không Đúng trả về (true, "<PersonID>")Sai trả về (false, "")
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <param name="accountType"></param>
        /// <returns></returns>
        public static (bool,string) Login(string userName, string passWord, AccountType accountType)
        {
            foreach (var user in LibraryDatabase.Users(accountType))
            {
                if (user.Username == userName && user.Password == PassWordEncode.MD5Hash(PassWordEncode.Base64Encode(passWord)))
                {
                    return (true, user.PersonID);
                }
            }
            return (false,"");
        }
    }
}
