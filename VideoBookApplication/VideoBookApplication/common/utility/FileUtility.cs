using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoBookApplication.common.utility
{
    public class FileUtility
    {
        public static string getFolder(string fileName)
        {
            int index = fileName.LastIndexOf("\\");
            if (index < 0)
            {
                index = fileName.LastIndexOf("/");
            }
            if (index >= 0)
            {
                //estrazione folder e filename
                fileName = fileName.Substring(0, index);
            }
            return fileName;
        }
    }
}
