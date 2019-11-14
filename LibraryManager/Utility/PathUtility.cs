using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Utility
{
    public static class PathUtility
    {
        public static string GetApplicationDirectory()
        {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            path = path.Substring(0, path.LastIndexOf("\\"));
            return path;
        }
    }
}
