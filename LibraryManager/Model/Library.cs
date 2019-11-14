using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Model
{
    public static class Library
    {
        public static List<User> ListUser { get; set; }

        static Library()
        {
            ListUser = new List<User>();
        }
    }
}
