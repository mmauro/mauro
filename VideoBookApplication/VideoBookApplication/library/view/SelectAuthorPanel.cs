using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoBookApplication.common.model;
using VideoBookApplication.common.utility;
using VideoBookApplication.common.view;
using VideoBookApplication.common.enums;
using VideoBookApplication.library.model.database;
using VideoBookApplication.library.controls;
using VideoBookApplication.library.utility;

namespace VideoBookApplication.library.view
{
    public partial class SelectAuthorPanel : Panel
    {

        private GlobalApplicationObject globalObject;
        private LibraryActivityWindow parent;
        private GlobalOperation currentOperation = GlobalOperation.UNDEFINED;

        double numPages = 0;
        double currentPages = 0;

        private const int numMaxElement = 6;

        public SelectAuthorPanel(ref GlobalApplicationObject globalObject, LibraryActivityWindow parent)
        {
            InitializeComponent();
            this.globalObject = globalObject;
            this.parent = parent;
            this.currentOperation = globalObject.currentOperation;
            currentPages = 1;
            numPages = Math.Ceiling((double)(globalObject.libraryObject.libraryInput.autori.Count / numMaxElement));
            initPanel();
        }

        private void initPanel()
        {

            this.BackColor = LayoutManager.getPanelColor();

            //Title
            TitlePanel titlePanel = new TitlePanel("Selezione Autore", this);
            titlePanel.Location = new Point(0, 0);
            this.Controls.Add(titlePanel);

            //Group Box & Rafio Button
            groupBoxControls.Size = new Size(this.Size.Width - 20, this.Size.Height - (120 + titlePanel.Size.Height + titlePanel.Location.Y));
            groupBoxControls.Location = new Point(10, titlePanel.Location.Y + titlePanel.Size.Height + 15);
            groupBoxControls.BackColor = LayoutManager.getPanelColor2();
            this.Controls.Add(groupBoxControls);

            radioAuth1.Location = new Point(10, 15);
            radioAuth1.Visible = false;
            groupBoxControls.Controls.Add(radioAuth1);

            radioAuth2.Location = new Point(radioAuth1.Location.X, radioAuth1.Location.Y + 25);
            radioAuth2.Visible = false;
            groupBoxControls.Controls.Add(radioAuth2);

            radioAuth3.Location = new Point(radioAuth2.Location.X, radioAuth2.Location.Y + 25);
            radioAuth3.Visible = false;
            groupBoxControls.Controls.Add(radioAuth3);

            radioAuth4.Location = new Point(radioAuth3.Location.X, radioAuth3.Location.Y + 25);
            radioAuth4.Visible = false;
            groupBoxControls.Controls.Add(radioAuth4);

            radioAuth5.Location = new Point(radioAuth4.Location.X, radioAuth4.Location.Y + 25);
            radioAuth5.Visible = false;
            groupBoxControls.Controls.Add(radioAuth5);

            radioAuth6.Location = new Point(radioAuth5.Location.X, radioAuth5.Location.Y + 25);
            radioAuth6.Visible = false;
            groupBoxControls.Controls.Add(radioAuth6);

            //Pulsanti
            buttonOk.Location = new Point(this.Size.Width / 2 - (10 + buttonOk.Size.Width), groupBoxControls.Location.Y + groupBoxControls.Size.Height + 20);
            this.Controls.Add(buttonOk);

            buttonCancel.Location = new Point(this.Size.Width / 2 + 10, buttonOk.Location.Y);
            this.Controls.Add(buttonCancel);

            buttonPrev.Location = new Point(15, buttonOk.Location.Y);
            this.Controls.Add(buttonPrev);

            buttonNext.Location = new Point(this.Size.Width - (15 + buttonNext.Size.Width), buttonOk.Location.Y);
            this.Controls.Add(buttonNext);

            //tooltip
            toolTip1.SetToolTip(buttonCancel, "Annulla");
            toolTip1.SetToolTip(buttonNext, "Avanti");
            toolTip1.SetToolTip(buttonOk, "Seleziona Autore");
            toolTip1.SetToolTip(buttonPrev, "Precedente");

            //Visualizzazione dati
            displayAuthors();

        }

        private void displayAuthors()
        {
            int startElement = (int)(numMaxElement * (currentPages - 1));
            int endElement = Math.Min(globalObject.libraryObject.libraryInput.autori.Count - 1, startElement + (numMaxElement - 1));

            if (numPages >= currentPages)
            {
                buttonNext.Enabled = true;
            }
            else
            {
                buttonNext.Enabled = false;
            }

            if (currentPages > 1)
            {
                buttonPrev.Enabled = true;
            }
            else
            {
                buttonPrev.Enabled = false;
            }

            for (int i = startElement; i <= endElement; i++)
            {
                displayAuthors(i, DisplayUtility.formatAuthorName(globalObject.libraryObject.libraryInput.autori[i]));
            }

        }

        private void displayAuthors(int index, String autore)
        {
            int value = (int)((index - ((currentPages - 1) * numMaxElement)) + 1);
            switch (value)
            {
                case 1:
                    radioAuth1.Text = autore;
                    radioAuth1.Checked = true;
                    radioAuth1.Visible = true;
                    break;
                case 2:
                    radioAuth2.Text = autore;
                    radioAuth2.Visible = true;
                    break;
                case 3:
                    radioAuth3.Text = autore;
                    radioAuth3.Visible = true;
                    break;
                case 4:
                    radioAuth4.Text = autore;
                    radioAuth4.Visible = true;
                    break;
                case 5:
                    radioAuth5.Text = autore;
                    radioAuth5.Visible = true;
                    break;
                case 6:
                    radioAuth6.Text = autore;
                    radioAuth6.Visible = true;
                    break;
                default:
                    DisplayManager.displayError(ApplicationErrorType.INVALID_VALUE, "Valore " + value);
                    break;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            globalObject.libraryObject.libraryInput.destroy();
            parent.closePanel();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            ApplicationErrorType status = selectAuthor();
            if (status == ApplicationErrorType.SUCCESS)
            {
                switch (currentOperation)
                {
                    case GlobalOperation.LIB_CHOOSE_AUTHOR:
                        parent.closePanel(GlobalOperation.LIB_CHOOSE_AUTHOR);
                        parent.openPanel(GlobalOperation.LIB_NEW_BOOKS);
                        break;
                    case GlobalOperation.LIB_CHOOSE_AUTHOR_DELETE:
                        parent.closePanel(GlobalOperation.LIB_CHOOSE_AUTHOR_DELETE);
                        parent.openPanel(GlobalOperation.LIB_DELETE_AUTHOR);
                        break;
                    case GlobalOperation.LIB_CHOOSE_AUTHOR_EDIT:
                        parent.closePanel(GlobalOperation.LIB_CHOOSE_AUTHOR_EDIT);
                        parent.openPanel(GlobalOperation.LIB_EDIT_AUTHOR);                        
                        break;
                    default:
                        DisplayManager.displayError(ApplicationErrorType.NOT_ALLOWED, currentOperation.ToString());
                        break;
                }
            }
            else
            {
                DisplayManager.displayError(status);
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            currentPages++;
            displayAuthors();
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            numPages--;
            displayAuthors();
        }

        private ApplicationErrorType selectAuthor()
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;
            if (radioAuth1.Checked || radioAuth2.Checked || radioAuth3.Checked || radioAuth4.Checked || radioAuth5.Checked || radioAuth6.Checked)
            {
                int idxRadio = Configurator.getInstsance().getInt("notfound.value");
                if (radioAuth1.Checked)
                {
                    idxRadio = 1;
                }
                if (radioAuth2.Checked)
                {
                    idxRadio = 2;
                }
                if (radioAuth3.Checked)
                {
                    idxRadio = 3;
                }
                if (radioAuth4.Checked)
                {
                    idxRadio = 4;
                }
                if (radioAuth5.Checked)
                {
                    idxRadio = 5;
                }
                if (radioAuth6.Checked)
                {
                    idxRadio = 6;
                }

                int indexAuthor = getIndexAuthor(idxRadio);
                if (indexAuthor >= 0 && indexAuthor < globalObject.libraryObject.libraryInput.autori.Count)
                {
                    AuthorModel model = globalObject.libraryObject.libraryInput.autori[indexAuthor];
                    globalObject.libraryObject.libraryInput.destroy();
                    globalObject.libraryObject.libraryInput.autore = model;
                    AuthorControls control = new AuthorControls();
                    status = control.addBooksToAuthor(ref globalObject);
                }
                else
                {
                    status = ApplicationErrorType.INVALID_VALUE;
                }

            }
            else
            {
                status = ApplicationErrorType.NO_AUTHOR_SELECTED;
            }

            return status;

        }

        private int getIndexAuthor(int idxRadio)
        {
            int index = Configurator.getInstsance().getInt("notfound.value");
            index = (int)(idxRadio - 1 + ((currentPages - 1) * numMaxElement));
            return index;
        }

    }
}
