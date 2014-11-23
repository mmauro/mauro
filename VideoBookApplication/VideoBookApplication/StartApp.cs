using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoBookApplication.common.controls;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.model;
using VideoBookApplication.common.operations;
using VideoBookApplication.common.utility;
using VideoBookApplication.common.view;

namespace VideoBookApplication
{
    public partial class StartApp : Form
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private GlobalApplicationObject globalObject;

        public StartApp()
        {
            InitializeComponent();
            ApplicationErrorType status = initApplication();
            if (status != ApplicationErrorType.SUCCESS)
            {
                DisplayManager.displayError(status);
                Utility.closeApplication();
            }

            initFrame();
        }

        private ApplicationErrorType initApplication()
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;

            //inizializzazione Log4Net
            log4net.Config.XmlConfigurator.Configure();
            log.Info("VideoBook Project " + Application.ProductVersion + " - Start Application");

            //Testo Frame
            this.Text = Utility.getFrameStringBorder();

            this.ActiveControl = textUserName;

            //Creazione oggetto globale
            globalObject = new GlobalApplicationObject();

            //Apertura della connessione
            status = DatabaseControl.getInstance().getStatus();
            if (status == ApplicationErrorType.SUCCESS && Configurator.getInstsance().getBoolean("start.insert.value"))
            {
                InitDatabase init = new InitDatabase();
                status = init.initDatabase();
            }

            return status;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Utility.closeApplication();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getUser();
        }

        private void initFrame()
        {

            this.Text = Utility.getFrameStringBorder();

            //Display Tooltip
            toolTip.SetToolTip(buttonOk, "Esegui Login");
            toolTip.SetToolTip(buttonClose, "Uscita");

            //Override Background color
            this.BackColor = LayoutManager.getColorWindow();
        }

        private void textUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Use Enter Press
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                getUser();
            }

            //Use press Escape
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                Utility.closeApplication();
            }
        }

        private void getUser()
        {
            UsersControl control = new UsersControl();
            ApplicationErrorType status = control.selectUser(ref globalObject, textUserName.Text);
            if (status == ApplicationErrorType.SUCCESS)
            {
                
                this.Visible = false;
                WindowsMainActivity mainActivity = new WindowsMainActivity(ref globalObject);
                mainActivity.ShowDialog();

                //Se Arrivo a Questo punto chiudo tutto...
                Utility.closeApplication();

            }
            else
            {
                DisplayManager.displayError(status);
            }
        }

    }
}
