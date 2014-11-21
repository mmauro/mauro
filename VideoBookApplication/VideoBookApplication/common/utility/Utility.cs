using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoBookApplication.common.controls;

namespace VideoBookApplication.common.utility
{
    public class Utility
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static bool toBoolean(String value)
        {
            bool retValue = false;
            if (value != null && (value.ToLower().Equals("true") || value.Equals("1"))) {
                retValue = true;
            }
            return retValue;
        }

        public static void closeApplication()
        {
            log.Info("Exit Application");
            if (DatabaseControl.isOpenConnection)
            {
                DatabaseControl.getInstance().closeConnection();
            }
            Environment.Exit(0);
        }

        public static string getFrameStringBorder()
        {
            return "VideoBook Project v. " + Application.ProductVersion;
        }
    }
}
