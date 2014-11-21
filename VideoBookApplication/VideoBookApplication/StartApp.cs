using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoBookApplication.common.enums;

namespace VideoBookApplication
{
    public partial class StartApp : Form
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public StartApp()
        {
            InitializeComponent();
            initApplication();
        }

        private ApplicationErrorType initApplication()
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;

            //inizializzazione Log4Net
            log4net.Config.XmlConfigurator.Configure();
            log.Info("VideoBook Project " + Application.ProductVersion + " - Start Application");

            return status;
        }
    }
}
