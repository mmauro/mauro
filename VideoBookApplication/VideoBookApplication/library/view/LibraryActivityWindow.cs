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
        private NewBooksPanel newBooksPanel = null;
        private InfoBookPanel infoPanel = null;
        private StatPanel statPanel = null;
        private StatGraphCategoryPanel graphPanel = null;
        private StatGraphNumbersPanel graphNumberPanel = null;
        private SearchAuthorPanel searchAuthorPanel = null;
        private ShowBooksPanel showBooksPanel = null;
        private SelectAuthorPanel selectAuthorPanel = null;

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
                case GlobalOperation.LIB_NEW_BOOKS:
                    if (newBooksPanel == null)
                    {
                        newBooksPanel = new NewBooksPanel(ref globalObject, this);
                        newBooksPanel.Location = new Point(panelMenu1.Size.Width + 15, logoutPanel.Height + 15);
                        this.Controls.Add(newBooksPanel);
                    }
                    break;
                case GlobalOperation.LIB_STATS:
                    if (statPanel == null)
                    {
                        statPanel = new StatPanel(ref globalObject, this);
                        statPanel.Location = new Point(panelMenu1.Size.Width + 15, logoutPanel.Height + 15);
                        this.Controls.Add(statPanel);
                    }
                    break;
                case GlobalOperation.LIB_NEW_BOOKS_CATEGORY:
                    if (newCatPanel == null)
                    {
                        if (newBooksPanel != null)
                        {
                            newCatPanel = new NewCategoryPanel(ref globalObject, this);
                            newCatPanel.Location = new Point(newBooksPanel.Location.X + newBooksPanel.Size.Width + 10, newBooksPanel.Location.Y);
                            this.Controls.Add(newCatPanel);
                        }
                        else
                        {
                            DisplayManager.displayError(ApplicationErrorType.OPEN_PANEL_ERROR, "Category Panel Error");
                        }
                    }
                    break;
                case GlobalOperation.LIB_NEW_BOOKS_POSITION:
                    if (newPosPanel == null)
                    {
                        if (newBooksPanel != null)
                        {
                            newPosPanel = new NewPositionPanel(ref globalObject, this);
                            newPosPanel.Location = new Point(newBooksPanel.Location.X + newBooksPanel.Size.Width + 10, newBooksPanel.Location.Y);
                            this.Controls.Add(newPosPanel);
                        }
                        else
                        {
                            DisplayManager.displayError(ApplicationErrorType.OPEN_PANEL_ERROR, "Position Panel Error");
                        }
                    }
                    break;
                case GlobalOperation.LIB_INFOBOOK:
                    if (infoPanel == null)
                    {
                        if (newBooksPanel != null)
                        {
                            infoPanel = new InfoBookPanel(ref globalObject, this);
                            infoPanel.Location = new Point(newBooksPanel.Location.X + newBooksPanel.Size.Width + 10, newBooksPanel.Location.Y);
                            this.Controls.Add(infoPanel);
                        }
                        else
                        {
                            DisplayManager.displayError(ApplicationErrorType.OPEN_PANEL_ERROR, "Info Panel Error");
                        }
                    }
                    break;
                case GlobalOperation.LIB_SHOW_BOOKS:
                    if (showBooksPanel == null)
                    {
                        if (newBooksPanel != null)
                        {
                            showBooksPanel = new ShowBooksPanel(ref globalObject, this);
                            showBooksPanel.Location = new Point(newBooksPanel.Location.X + newBooksPanel.Size.Width + 10, newBooksPanel.Location.Y);
                            this.Controls.Add(showBooksPanel);
                        }
                        else
                        {
                            DisplayManager.displayError(ApplicationErrorType.OPEN_PANEL_ERROR, "Show Book Panel Error");
                        }
                    }

                    break;
                case GlobalOperation.LIB_STATS_GRAPH:
                    if (graphPanel == null && graphNumberPanel == null)
                    {
                        if (statPanel != null)
                        {
                            graphPanel = new StatGraphCategoryPanel(ref globalObject, this);
                            graphPanel.Location = new Point(statPanel.Location.X + statPanel.Size.Width + 10, statPanel.Location.Y);
                            this.Controls.Add(graphPanel);

                            graphNumberPanel = new StatGraphNumbersPanel(ref globalObject, this);
                            graphNumberPanel.Location = new Point(statPanel.Location.X, statPanel.Location.Y + statPanel.Size.Height + 10);
                            this.Controls.Add(graphNumberPanel);

                        }
                        else
                        {
                            DisplayManager.displayError(ApplicationErrorType.OPEN_PANEL_ERROR, "Graph Panel Error");
                        }
                    }
                    break;
                case GlobalOperation.LIB_SEARCH_NEW_BOOK:
                    if (searchAuthorPanel == null)
                    {
                        searchAuthorPanel = new SearchAuthorPanel(ref globalObject, this);
                        searchAuthorPanel.Location = new Point(panelMenu1.Size.Width + 15, logoutPanel.Height + 15);
                        this.Controls.Add(searchAuthorPanel);

                    }
                    break;
                case GlobalOperation.LIB_CHOOSE_AUTHOR:
                    if (selectAuthorPanel == null)
                    {
                        selectAuthorPanel = new SelectAuthorPanel(ref globalObject, this);
                        selectAuthorPanel.Location = new Point(panelMenu1.Size.Width + 15, logoutPanel.Height + 15);
                        this.Controls.Add(selectAuthorPanel);
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
            closePanel(GlobalOperation.LIB_NEW_BOOKS);
            closePanel(GlobalOperation.LIB_NEW_BOOKS_CATEGORY);
            closePanel(GlobalOperation.LIB_NEW_BOOKS_POSITION);
            closePanel(GlobalOperation.LIB_INFOBOOK);
            closePanel(GlobalOperation.LIB_STATS);
            closePanel(GlobalOperation.LIB_STATS_GRAPH);
            closePanel(GlobalOperation.LIB_SEARCH_NEW_BOOK);
            closePanel(GlobalOperation.LIB_SHOW_BOOKS);
            closePanel(GlobalOperation.LIB_CHOOSE_AUTHOR);
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
                case GlobalOperation.LIB_NEW_BOOKS_CATEGORY:
                    if (newCatPanel != null)
                    {
                        newCatPanel.Visible = false;
                        newCatPanel = null;
                        closePanel(GlobalOperation.LIB_SHOW_CAT);

                        if (newBooksPanel != null)
                        {
                            newBooksPanel.refreshData();
                            newBooksPanel.refreshCombo();
                        }

                    }
                    break;
                case GlobalOperation.LIB_NEW_POSITION:
                case GlobalOperation.LIB_NEW_BOOKS_POSITION:
                    if (newPosPanel != null)
                    {
                        newPosPanel.Visible = false;
                        newPosPanel = null;
                        closePanel(GlobalOperation.LIB_SHOW_POS);

                        //Refresh dei dati dove necessario
                        if (newBooksPanel != null)
                        {
                            newBooksPanel.refreshData();
                            newBooksPanel.refreshCombo();
                        }

                    }
                    break;
                case GlobalOperation.LIB_SHOW_CAT:
                    if (showCatPanel != null)
                    {
                        showCatPanel.Visible = false;
                        showCatPanel = null;
                    }
                    break;
                case GlobalOperation.LIB_STATS:
                    if (statPanel != null)
                    {
                        statPanel.Visible = false;
                        statPanel = null;
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
                case GlobalOperation.LIB_NEW_BOOKS:
                    if (newBooksPanel != null)
                    {
                        newBooksPanel.Visible = false;
                        newBooksPanel = null;
                    }
                    break;
                case GlobalOperation.LIB_INFOBOOK:
                    if (infoPanel != null)
                    {
                        infoPanel.Visible = false;
                        infoPanel = null;
                    }
                    break;
                case GlobalOperation.LIB_STATS_GRAPH:
                    if (graphPanel != null)
                    {
                        graphPanel.Visible = false;
                        graphPanel = null;
                    }

                    if (graphNumberPanel != null)
                    {
                        graphNumberPanel.Visible = false;
                        graphNumberPanel = null;
                    }
                    break;
                case GlobalOperation.LIB_SEARCH_NEW_BOOK:
                    if (searchAuthorPanel != null)
                    {
                        searchAuthorPanel.Visible = false;
                        searchAuthorPanel = null;
                    }
                    break;
                case GlobalOperation.LIB_SHOW_BOOKS:
                    if (showBooksPanel != null)
                    {
                        showBooksPanel.Visible = false;
                        showBooksPanel = null;
                    }
                    break;
                case GlobalOperation.LIB_CHOOSE_AUTHOR:
                    if (selectAuthorPanel != null)
                    {
                        selectAuthorPanel.Visible = false;
                        selectAuthorPanel = null;
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


        public void executeOperations(GlobalOperation operation)
        {
            switch (operation)
            {
                case GlobalOperation.LIB_KEEP_TITLE:
                    if (infoPanel != null && newBooksPanel != null)
                    {
                        newBooksPanel.refreshTitle();
                    }
                    else
                    {
                        DisplayManager.displayError(ApplicationErrorType.OPERATION_ERROR, "Keep Title Error");
                    }
                    break;
                case GlobalOperation.LIB_DELETE_INFOBOOK:
                    if (infoPanel != null && newBooksPanel != null)
                    {
                        newBooksPanel.deleteInfo();
                    }
                    else
                    {
                        DisplayManager.displayError(ApplicationErrorType.OPERATION_ERROR, "Keep Title Error");
                    }
                    break;
                default:
                    DisplayManager.displayError(ApplicationErrorType.NOT_ALLOWED);
                    break;
            }
        }

        public void closeOtherBooksPanel()
        {
            closePanel(GlobalOperation.LIB_NEW_BOOKS_CATEGORY);
            closePanel(GlobalOperation.LIB_NEW_BOOKS_POSITION);
            closePanel(GlobalOperation.LIB_SHOW_CAT);
            closePanel(GlobalOperation.LIB_SHOW_POS);
            closePanel(GlobalOperation.LIB_INFOBOOK);
            closePanel(GlobalOperation.LIB_SHOW_BOOKS);
        }
    }
}
