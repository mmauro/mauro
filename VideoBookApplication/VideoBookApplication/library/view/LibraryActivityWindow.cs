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
        private NewPositionPanel newPosPanel = null;
        private ShowCategoryPanel showCatPanel = null;
        private ShowPositionPanel showPosPanel = null;
        private NewAuthorPanel newAuthorPanel = null;

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
                case GlobalOperation.LIB_NEW_POSITION:
                    if (newPosPanel == null)
                    {
                        newPosPanel = new NewPositionPanel(ref globalObject, this);
                        newPosPanel.Location = new Point(panelMenu1.Size.Width + 15, logoutPanel.Height + 15);
                        this.Controls.Add(newPosPanel);
                    }
                    break;
                case GlobalOperation.LIB_SHOW_CAT:
                    if (showCatPanel == null)
                    {
                        if (newCatPanel != null)
                        {
                            showCatPanel = new ShowCategoryPanel(ref globalObject, this);
                            showCatPanel.Location = new Point(newCatPanel.Location.X + newCatPanel.Size.Width + 10, newCatPanel.Location.Y);
                            this.Controls.Add(showCatPanel);
                        }
                        else
                        {
                            DisplayManager.displayError(ApplicationErrorType.OPEN_PANEL_ERROR, "Show Category Error");
                        }
                    }
                    break;
                case GlobalOperation.LIB_SHOW_POS:
                    if (showPosPanel == null)
                    {
                        if (newPosPanel != null)
                        {
                            showPosPanel = new ShowPositionPanel(ref globalObject, this);
                            showPosPanel.Location = new Point(newPosPanel.Location.X + newPosPanel.Size.Width + 10, newPosPanel.Location.Y);
                            this.Controls.Add(showPosPanel);
                        }
                        else
                        {
                            DisplayManager.displayError(ApplicationErrorType.OPEN_PANEL_ERROR, "Show Position Error");
                        }
                    }
                    break;
                case GlobalOperation.LIB_NEW_AUTHOR:
                    if (newAuthorPanel == null)
                    {
                        newAuthorPanel = new NewAuthorPanel(ref globalObject, this);
                        newAuthorPanel.Location = new Point(panelMenu1.Size.Width + 15, logoutPanel.Height + 15);
                        this.Controls.Add(newAuthorPanel);
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
            closePanel(GlobalOperation.LIB_NEW_POSITION);
            closePanel(GlobalOperation.LIB_SHOW_CAT);
            closePanel(GlobalOperation.LIB_SHOW_POS);
            closePanel(GlobalOperation.LIB_NEW_AUTHOR);
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
                        closePanel(GlobalOperation.LIB_SHOW_CAT);
                    }
                    break;
                case GlobalOperation.LIB_NEW_POSITION:
                    if (newPosPanel != null)
                    {
                        newPosPanel.Visible = false;
                        newPosPanel = null;
                        closePanel(GlobalOperation.LIB_SHOW_POS);
                    }
                    break;
                case GlobalOperation.LIB_SHOW_CAT:
                    if (showCatPanel != null)
                    {
                        showCatPanel.Visible = false;
                        showCatPanel = null;
                    }
                    break;
                case GlobalOperation.LIB_SHOW_POS:
                    if (showPosPanel != null)
                    {
                        showPosPanel.Visible = false;
                        showPosPanel = null;
                    }
                    break;
                case GlobalOperation.LIB_NEW_AUTHOR:
                    if (newAuthorPanel != null)
                    {
                        newAuthorPanel.Visible = false;
                        newAuthorPanel = null;
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
