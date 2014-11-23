using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoBookApplication.common.utility;
using VideoBookApplication.common.view;
using VideoBookApplication.common.model;


namespace VideoBookApplication.common.view
{
    public partial class MainMenuPanel : Panel
    {
        private Form parent;

        private static int numButton = 2;
        private GlobalApplicationObject globalObject;

        public MainMenuPanel(ref GlobalApplicationObject globalObject, Form parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.globalObject = globalObject;
            initPanel();
        }

        private void initPanel()
        {
            this.BackColor = LayoutManager.getMenuColor();
            this.Size = new Size(LayoutManager.menuHeight, (numButton*90)+(5*(numButton+1)));

            //Button changeApp
            buttonChangeApp.Location = new Point(5, 5);
            this.Controls.Add(buttonChangeApp);

            //Button Exit App
            buttonExitApp.Location = new Point(5, buttonChangeApp.Location.Y + buttonChangeApp.Size.Height + 5);
            this.Controls.Add(buttonExitApp);

            //toolTip
            toolTip1.SetToolTip(buttonExitApp, "Uscita Applicazione");
            toolTip1.SetToolTip(buttonChangeApp, "Cambia Applicazione");

        }

        private void buttonExitApp_Click(object sender, EventArgs e)
        {
            Utility.closeApplication();
        }

        private void buttonChangeApp_Click(object sender, EventArgs e)
        {
            parent.Visible = false;
            globalObject.activity = enums.ActivityType.UNDEFINED;
            WindowsMainActivity mainActivity = new WindowsMainActivity(ref globalObject);
            mainActivity.ShowDialog();
        }
    }
}
