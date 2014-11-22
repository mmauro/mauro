using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoBookApplication.common.utility;
using VideoBookApplication.common.view;
using VideoBookApplication.common.model;
using VideoBookApplication.common.enums;

namespace VideoBookApplication.library.view
{
    public partial class LibraryActivityWindow : Form
    {

        private GlobalApplicationObject globalObject;
        private ReservedPanel reservedPanel = null;
        LogoutPanel logoutPanel = null;

        public LibraryActivityWindow(ref GlobalApplicationObject globalObject)
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

            //Reserved Menu
            MenuReserved reservedMenu = new MenuReserved(ref globalObject, this);
            reservedMenu.Location = new Point(0, mainMenu.Location.Y + mainMenu.Size.Height + 20);
            panelMenu1.Controls.Add(reservedMenu);

        }

        public void openPanel(GlobalOperation operation)
        {
            switch (operation)
            {
                case GlobalOperation.RESERVED:
                    if (reservedPanel == null)
                    {
                        reservedPanel = new ReservedPanel();
                        reservedPanel.Location = new Point(panelMenu1.Size.Width + 15, logoutPanel.Height + 15);
                        this.Controls.Add(reservedPanel);
                    }
                    break;
                default:
                    DisplayManager.displayError(ApplicationErrorType.NOT_ALLOWED);
                    break;
            }
        }

        public void closePanel()
        {
            closePanel(GlobalOperation.RESERVED);
        }

        public void closePanel(GlobalOperation operation)
        {
            switch (operation)
            {
                case GlobalOperation.RESERVED:
                    if (reservedPanel != null)
                    {
                        reservedPanel.Visible = false;
                        reservedPanel = null;
                    }
                    break;
                default:
                    DisplayManager.displayError(ApplicationErrorType.NOT_ALLOWED);
                    break;
            }
        }
    }
}
