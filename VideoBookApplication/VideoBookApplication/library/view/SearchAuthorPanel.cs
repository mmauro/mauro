using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoBookApplication.common.enums;
using VideoBookApplication.common.model;
using VideoBookApplication.common.utility;
using VideoBookApplication.common.view;
using VideoBookApplication.library.controls;

namespace VideoBookApplication.library.view
{
    public partial class SearchAuthorPanel : Panel
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private GlobalApplicationObject globalObject;
        private LibraryActivityWindow parent;
        private GlobalOperation currentOperation = GlobalOperation.UNDEFINED;
        private AuthorControls control = new AuthorControls();

        public SearchAuthorPanel(ref GlobalApplicationObject globalObject, LibraryActivityWindow parent)
        {
            InitializeComponent();
            this.globalObject = globalObject;
            this.parent = parent;
            this.currentOperation = this.globalObject.currentOperation;
            initPanel();
        }

        private void initPanel()
        {

            this.BackColor = LayoutManager.getPanelColor();

            //Title
            TitlePanel titlePanel = new TitlePanel("Ricerca Autore", this);
            titlePanel.Location = new Point(0, 0);
            this.Controls.Add(titlePanel);

            //Labels
            labelCognome.Location = new Point(15, titlePanel.Location.X + titlePanel.Size.Height + 10);
            this.Controls.Add(labelCognome);

            labelNome.Location = new Point((this.Size.Width / 2) + 10, titlePanel.Location.X + titlePanel.Size.Height + 10);
            this.Controls.Add(labelNome);

            //text box
            textCognome.Location = new Point(labelCognome.Location.X, labelCognome.Location.Y + 30);
            this.Controls.Add(textCognome);

            textNome.Location = new Point(labelNome.Location.X, labelNome.Location.Y + 30);
            this.Controls.Add(textNome);

            //Buttons
            buttonClose.Location = new Point(this.Width - (buttonClose.Size.Width + 25), textNome.Location.Y + 60);
            this.Controls.Add(buttonClose);

            buttonSearch.Location = new Point(buttonClose.Location.X - (buttonSearch.Size.Width + 20), textNome.Location.Y + 60);
            this.Controls.Add(buttonSearch);

            //tooltip
            toolTip1.SetToolTip(buttonSearch, "Ricerca Autore");
            toolTip1.SetToolTip(buttonClose, "Annulla");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            parent.closePanel();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            ApplicationErrorType status = control.searchAuthors(textNome.Text, textCognome.Text, ref globalObject);
            if (status == ApplicationErrorType.SUCCESS)
            {
                if (globalObject.libraryObject.libraryInput.autore != null)
                {
                    log.Info("Autori Trovati = 1");
                    status = control.addBooksToAuthor(ref globalObject);
                    if (status != ApplicationErrorType.SUCCESS)
                    {
                        DisplayManager.displayError(status);
                    }
                    else
                    {
                        switch (currentOperation)
                        {
                            case GlobalOperation.LIB_SEARCH_NEW_BOOK:
                                parent.closePanel(GlobalOperation.LIB_SEARCH_NEW_BOOK);
                                parent.openPanel(GlobalOperation.LIB_NEW_BOOKS);
                                break;
                            case GlobalOperation.LIB_SEARCHAUTHOR_DELETE:
                                parent.closePanel(GlobalOperation.LIB_SEARCHAUTHOR_DELETE);
                                parent.openPanel(GlobalOperation.LIB_DELETE_AUTHOR);
                                break;
                            case GlobalOperation.LIB_SEARCHAUTHOR_EDIT:
                                DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
                                break;
                            default:
                                DisplayManager.displayError(ApplicationErrorType.NOT_ALLOWED, currentOperation.ToString());
                                break;
                        }
                    }
                }
                else
                {
                    if (globalObject.libraryObject.libraryInput.autori != null && globalObject.libraryObject.libraryInput.autori.Count > 0)
                    {
                        log.Info("Autori Trovati = " + globalObject.libraryObject.libraryInput.autori.Count);
                        DisplayManager.displayWarning(ApplicationErrorType.AUTHOR_AMBIG_WARN, "Selezionare Un Autore Per Proseguire");
                        switch (currentOperation)
                        {
                            case GlobalOperation.LIB_SEARCH_NEW_BOOK:
                                parent.closePanel(GlobalOperation.LIB_SEARCH_NEW_BOOK);
                                parent.openPanel(GlobalOperation.LIB_CHOOSE_AUTHOR);
                                break;
                            case GlobalOperation.LIB_SEARCHAUTHOR_DELETE:
                                parent.closePanel(GlobalOperation.LIB_SEARCHAUTHOR_DELETE);
                                parent.openPanel(GlobalOperation.LIB_CHOOSE_AUTHOR_DELETE);
                                break;
                            case GlobalOperation.LIB_SEARCHAUTHOR_EDIT:
                                break;
                            default:
                                DisplayManager.displayError(ApplicationErrorType.NOT_ALLOWED, currentOperation.ToString());
                                break;
                        }
                    }
                    else
                    {
                        DisplayManager.displayError(ApplicationErrorType.FAILURE, "Unchecked Error");
                    }
                }
            }
            else
            {
                DisplayManager.displayError(status);
            }
        }

    }
}
