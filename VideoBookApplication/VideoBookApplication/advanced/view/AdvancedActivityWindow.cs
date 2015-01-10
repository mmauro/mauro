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
using VideoBookApplication.common.model;
using VideoBookApplication.common.utility;
using VideoBookApplication.common.view;

namespace VideoBookApplication.advanced.view
{
    public partial class AdvancedActivityWindow : Form, IGenericActivity
    {

        private GlobalApplicationObject globalObject;
        private LogoutPanel logoutPanel = null;

        public AdvancedActivityWindow(ref GlobalApplicationObject globalObject)
        {
            InitializeComponent();
            this.globalObject = globalObject;
            initFrame();
        }

        private void initFrame()
        {
            //Init Frame
            this.BackColor = LayoutManager.getColorWindow();
            this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.Text = Utility.getFrameStringBorder();

            //Logout Panel
            logoutPanel = new LogoutPanel(ref globalObject, this);
            logoutPanel.Location = new Point(0, 0);
            this.Controls.Add(logoutPanel);

            //Panel for menu
            panelMenu1.BackColor = LayoutManager.getMenuColor();
            panelMenu1.Size = new System.Drawing.Size(LayoutManager.menuHeight, this.Size.Height - logoutPanel.Size.Height);
            panelMenu1.Location = new Point(0, logoutPanel.Size.Height);
            this.Controls.Add(panelMenu1);

            //Main Menu
            MainMenuPanel mainMenu = new MainMenuPanel(ref globalObject, this);
            mainMenu.Location = new Point(0, 0);
            panelMenu1.Controls.Add(mainMenu);

            //Database operation menu
            DatabaseMenuAdvanced databaseMenu = new DatabaseMenuAdvanced(ref globalObject, this);
            databaseMenu.Location = new Point(0, mainMenu.Location.Y + mainMenu.Size.Height + 20);
            panelMenu1.Controls.Add(databaseMenu);

        }

        public void openPanel(common.enums.GlobalOperation operation)
        {
            throw new NotImplementedException();
        }

        public void closePanel()
        {
            throw new NotImplementedException();
        }

        public void closePanel(common.enums.GlobalOperation operation)
        {
            throw new NotImplementedException();
        }

        public void closeMenu()
        {
            throw new NotImplementedException();
        }

        public void openMenu(common.enums.GlobalOperation operation)
        {
            throw new NotImplementedException();
        }


        public void executeOperations(common.enums.GlobalOperation operation)
        {
            throw new NotImplementedException();
        }
    }
}
