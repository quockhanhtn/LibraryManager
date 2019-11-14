using LibraryManager.Model;
using LibraryManager.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Data
{
    public class Database
    {
        public static List<User> Users()
        {
            string path = GetDataPath() + "UserData.xml";
            List<User> users = new List<User>();

            try
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(path);
                DataTable dt = new DataTable();
                dt = dataSet.Tables["User"];

                foreach (DataRow dr in dt.Rows)
                {
                    User user = new User(dr);
                    users.Add(user);
                }
            }
            catch (Exception) { }

            return users;
        }

        public static string GetDataPath()
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            path = path.Substring(0, path.LastIndexOf("\\"));
            return path + "\\Data\\";
        }
    }
}
