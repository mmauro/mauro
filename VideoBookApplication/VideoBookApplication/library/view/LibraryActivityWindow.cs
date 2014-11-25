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
using VideoBookApplication.common.controls;

namespace VideoBookApplication.library.view
{
    public partial class LibraryActivityWindow : Form, IGenericActivity
    {

        private GlobalApplicationObject globalObject;
        private LogoutPanel logoutPanel = null;


        private ReservedPanel reservedPanel = null;
        private NewCategoryPanel newCatPanel = null;

        private InsertMenuLibrary insertMenu = null;

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

            panelMenu2.BackColor = LayoutManager.getMenuColor();
            panelMenu2.Size = new System.Drawing.Size(LayoutManager.menuHeight, this.Size.Height - logoutPanel.Size.Height);
            panelMenu2.Location = new Point(this.Size.Width - (panelMenu2.Size.Width + 17), logoutPanel.Size.Height);
            this.Controls.Add(panelMenu2);

            //Main Menu
            MainMenuPanel mainMenu = new MainMenuPanel(ref globalObject, this);
            mainMenu.Location = new Point(0, 0);
            panelMenu1.Controls.Add(mainMenu);

            //Reserved Menu
            MenuReserved reservedMenu = new MenuReserved(ref globalObject, this);
            reservedMenu.Location = new Point(0, mainMenu.Location.Y + mainMenu.Size.Height + 20);
            panelMenu1.Controls.Add(reservedMenu);

            MainMenuLibrary mainLibrary = new MainMenuLibrary(ref globalObject, this);
            mainLibrary.Location = new Point(0, reservedMenu.Location.Y + reservedMenu.Size.Height + 20);
            panelMenu1.Controls.Add(mainLibrary);
        }

        public void openPanel(GlobalOperation operation)
        {
            switch (operation)
            {
                case GlobalOperation.RESERVED:
                    if (reservedPanel == null)
                    {
                        reservedPanel = new ReservedPanel(ref globalObject, this);
                        reservedPanel.Location = new Point(panelMenu1.Size.Width + 15, logoutPanel.Height + 15);
                        this.Controls.Add(reservedPanel);
                    }
                    break;
                case GlobalOperation.LIB_NEW_CATEGORY:
                    if (newCatPanel == null)
                    {
                        newCatPanel = new NewCategoryPanel(ref globalObject, this);
                        newCatPanel.Location = new Point(panelMenu1.Size.Width + 15, logoutPanel.Height + 15);
                        this.Controls.Add(newCatPanel);
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
            closePanel(GlobalOperation.LIB_NEW_CATEGORY);
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
                case GlobalOperation.LIB_NEW_CATEGORY:
                    if (newCatPanel != null)
                    {
                        newCatPanel.Visible = false;
                        newCatPanel = null;
                    }
                    break;
                default:
                    DisplayManager.displayError(ApplicationErrorType.NOT_ALLOWED);
                    break;
            }
        }


        public void closeMenu()
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        public void openMenu(GlobalOperation operation)
        {
            switch (operation)
            {
                case GlobalOperation.LIB_INSERT_MENU:
                    if (insertMenu == null)
                    {
                        insertMenu = new InsertMenuLibrary(ref globalObject, this);
                        insertMenu.Location = new Point(0, 0);
                        panelMenu2.Controls.Add(insertMenu);
                    }
                    break;
                default:
                    DisplayManager.displayError(ApplicationErrorType.NOT_ALLOWED);
                    break;
            }
        }
    }
}
