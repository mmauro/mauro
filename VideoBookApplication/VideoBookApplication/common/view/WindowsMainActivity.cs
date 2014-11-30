using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoBookApplication.advanced.view;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.model;
using VideoBookApplication.common.utility;
using VideoBookApplication.library.view;


namespace VideoBookApplication.common.view
{
    public partial class WindowsMainActivity : Form
    {
        private GlobalApplicationObject globalObject;
        private LogoutPanel logoutPanel;
        public WindowsMainActivity(ref GlobalApplicationObject globalObject)
        {
            InitializeComponent();
            this.globalObject = globalObject;
            if (this.globalObject.user != null)
            {
                initFrame();
            }
            else
            {
                DisplayManager.displayError(ApplicationErrorType.INVALID_INIT);
                Utility.closeApplication();
            }
        }

        private void initFrame()
        {
            //Override Background color
            this.BackColor = LayoutManager.getColorWindow();
            this.Text = Utility.getFrameStringBorder();

            //Logout Panel
            logoutPanel = new LogoutPanel(ref globalObject, (Form)this);
            logoutPanel.Location = new Point(0, 0);
            logoutPanel.Visible = true;
            this.Controls.Add(logoutPanel);

            //Init button activation
            buttonLibrary.Enabled = globalObject.user.flLibrary;
            buttonMovie.Enabled = globalObject.user.flVideo;
            buttonMusic.Enabled = globalObject.user.flMusic;
            buttonSoftware.Enabled = globalObject.user.flSoftware;
            buttonAdvanced.Enabled = globalObject.user.flSuperUser;

            //Tooltip
            toolTip1.SetToolTip(buttonAdvanced, "Operazioni Avanzate");
            toolTip1.SetToolTip(buttonExit, "Uscita");
            toolTip1.SetToolTip(buttonLibrary, "Gestione Libreria");
            toolTip1.SetToolTip(buttonMusic, "Gestione Musica");
            toolTip1.SetToolTip(buttonSoftware, "Gestione Software");
            toolTip1.SetToolTip(buttonMovie, "Gestione Videoteca");
            toolTip1.SetToolTip(buttonInfo, "Informazioni");

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Utility.closeApplication();
        }

        private void buttonAdvanced_Click(object sender, EventArgs e)
        {
            globalObject.activity = ActivityType.ADVANCED;
            this.Visible = false;
            AdvancedActivityWindow advWin = new AdvancedActivityWindow(ref globalObject);
            advWin.ShowDialog();

        }

        private void buttonInfo_Click(object sender, EventArgs e)
        {
            globalObject.activity = ActivityType.INFO;
            AboutVideoBook infoWin = new AboutVideoBook();
            infoWin.ShowDialog();
            globalObject.activity = ActivityType.UNDEFINED;
        }

        private void buttonSoftware_Click(object sender, EventArgs e)
        {
            globalObject.activity = ActivityType.SOFTWARE;
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        private void buttonMusic_Click(object sender, EventArgs e)
        {
            globalObject.activity = ActivityType.MUSIC;
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        private void buttonMovie_Click(object sender, EventArgs e)
        {
            globalObject.activity = ActivityType.MOVIE;
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        private void buttonLibrary_Click(object sender, EventArgs e)
        {
            globalObject.activity = ActivityType.LIBRARY;
            this.Visible = false;
            LibraryActivityWindow libWin = new LibraryActivityWindow(ref globalObject);
            libWin.ShowDialog();

            //At this point close Application
            Utility.closeApplication();
        }
    }
}
