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
using VideoBookApplication.common.enums;
using VideoBookApplication.common.utility;
using VideoBookApplication.common.view;
using VideoBookApplication.library.model.database;
using VideoBookApplication.library.utility;
using VideoBookApplication.library.controls;

namespace VideoBookApplication.library.view
{
    public partial class SelectBookPanel : Panel
    {

        private const int numMaxElement = 6;

        private GlobalApplicationObject globalObject;
        private LibraryActivityWindow parent;

        private double numPages;
        private double currentPages;

        public SelectBookPanel(ref GlobalApplicationObject globalObject, LibraryActivityWindow parent)
        {
            InitializeComponent();
            this.globalObject = globalObject;
            this.parent = parent;
            currentPages = 1;
            numPages = Math.Ceiling((double)(globalObject.libraryObject.libraryInput.libri.Count / numMaxElement));
            initPanel();
        }

        private void initPanel()
        {
            this.BackColor = LayoutManager.getPanelColor();

            //Title
            TitlePanel titlePanel = new TitlePanel("Selezione Libro", this);
            titlePanel.Location = new Point(0, 0);
            this.Controls.Add(titlePanel);

            //Group Box & Rafio Button
            groupBoxControls.Size = new Size(this.Size.Width - 20, this.Size.Height - (120 + titlePanel.Size.Height + titlePanel.Location.Y));
            groupBoxControls.Location = new Point(10, titlePanel.Location.Y + titlePanel.Size.Height + 15);
            groupBoxControls.BackColor = LayoutManager.getPanelColor();
            this.Controls.Add(groupBoxControls);

            //RichTextBox
            textAuth1.Size = new Size(groupBoxControls.Size.Width - 70, (groupBoxControls.Size.Height - ((numMaxElement + 1) *10) ) / numMaxElement );
            textAuth1.Location = new Point(5, 10);
            textAuth1.BackColor = LayoutManager.getPanelColor2();
            textAuth1.Visible = false;
            groupBoxControls.Controls.Add(textAuth1);

            textAuth2.Size = new Size(groupBoxControls.Size.Width - 70, (groupBoxControls.Size.Height - ((numMaxElement + 1) * 10)) / numMaxElement);
            textAuth2.Location = new Point(5, textAuth1.Location.Y + textAuth1.Size.Height + 10);
            textAuth2.BackColor = LayoutManager.getPanelColor2();
            textAuth2.Visible = false;
            groupBoxControls.Controls.Add(textAuth2);

            textAuth3.Size = new Size(groupBoxControls.Size.Width - 70, (groupBoxControls.Size.Height - ((numMaxElement + 1) * 10)) / numMaxElement);
            textAuth3.Location = new Point(5, textAuth2.Location.Y + textAuth2.Size.Height + 10);
            textAuth3.BackColor = LayoutManager.getPanelColor2();
            textAuth3.Visible = false;
            groupBoxControls.Controls.Add(textAuth3);

            textAuth4.Size = new Size(groupBoxControls.Size.Width - 70, (groupBoxControls.Size.Height - ((numMaxElement + 1) * 10)) / numMaxElement);
            textAuth4.Location = new Point(5, textAuth3.Location.Y + textAuth3.Size.Height + 10);
            textAuth4.BackColor = LayoutManager.getPanelColor2();
            textAuth4.Visible = false;
            groupBoxControls.Controls.Add(textAuth4);

            textAuth5.Size = new Size(groupBoxControls.Size.Width - 70, (groupBoxControls.Size.Height - ((numMaxElement + 1) * 10)) / numMaxElement);
            textAuth5.Location = new Point(5, textAuth4.Location.Y + textAuth4.Size.Height + 10);
            textAuth5.BackColor = LayoutManager.getPanelColor2();
            textAuth5.Visible = false;
            groupBoxControls.Controls.Add(textAuth5);

            textAuth6.Size = new Size(groupBoxControls.Size.Width - 70, (groupBoxControls.Size.Height - ((numMaxElement + 1) * 10)) / numMaxElement);
            textAuth6.Location = new Point(5, textAuth5.Location.Y + textAuth5.Size.Height + 10);
            textAuth6.BackColor = LayoutManager.getPanelColor2();
            textAuth6.Visible = false;
            groupBoxControls.Controls.Add(textAuth6);


            //Radio Button
            radioAuth1.Location = new Point(groupBoxControls.Size.Width - 50, textAuth1.Location.Y + ((textAuth1.Size.Height / 2) - (radioAuth1.Size.Height / 2)));
            radioAuth1.Text = "";
            radioAuth1.Visible = false;
            groupBoxControls.Controls.Add(radioAuth1);

            radioAuth2.Location = new Point(groupBoxControls.Size.Width - 50, textAuth2.Location.Y + ((textAuth2.Size.Height / 2) - (radioAuth2.Size.Height / 2)));
            radioAuth2.Text = "";
            radioAuth2.Visible = false;
            groupBoxControls.Controls.Add(radioAuth2);

            radioAuth3.Location = new Point(groupBoxControls.Size.Width - 50, textAuth3.Location.Y + ((textAuth3.Size.Height / 2) - (radioAuth3.Size.Height / 2)));
            radioAuth3.Text = "";
            radioAuth3.Visible = false;
            groupBoxControls.Controls.Add(radioAuth3);

            radioAuth4.Location = new Point(groupBoxControls.Size.Width - 50, textAuth4.Location.Y + ((textAuth4.Size.Height / 2) - (radioAuth4.Size.Height / 2)));
            radioAuth4.Text = "";
            radioAuth4.Visible = false;
            groupBoxControls.Controls.Add(radioAuth4);

            radioAuth5.Location = new Point(groupBoxControls.Size.Width - 50, textAuth5.Location.Y + ((textAuth5.Size.Height / 2) - (radioAuth5.Size.Height / 2)));
            radioAuth5.Text = "";
            radioAuth5.Visible = false;
            groupBoxControls.Controls.Add(radioAuth5);

            radioAuth6.Location = new Point(groupBoxControls.Size.Width - 50, textAuth6.Location.Y + ((textAuth6.Size.Height / 2) - (radioAuth6.Size.Height / 2)));
            radioAuth6.Text = "";
            radioAuth6.Visible = false;
            groupBoxControls.Controls.Add(radioAuth6);


            //Display Elements
            displayBooks();


            //pulsanti
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

        }

        private void displayBooks()
        {
            int startElement = (int)(numMaxElement * (currentPages - 1));
            int endElement = Math.Min(globalObject.libraryObject.libraryInput.libri.Count - 1, startElement + (numMaxElement - 1));

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
                displayBooks(i);
            }
        }

        private void displayBooks(int index)
        {
            BookModel model = globalObject.libraryObject.libraryInput.libri[index];
            int value = (int)((index - ((currentPages - 1) * numMaxElement)) + 1);
            switch (value)
            {
                case 1:
                    radioAuth1.Checked = true;
                    displayBooks(model, ref textAuth1);
                    radioAuth1.Visible = true;
                    textAuth1.Visible = true;
                    break;
                case 2:
                    radioAuth2.Visible = true;
                    displayBooks(model, ref textAuth2);
                    textAuth2.Visible = true;
                    break;
                case 3:
                    radioAuth3.Visible = true;
                    displayBooks(model, ref textAuth3);
                    textAuth3.Visible = true;
                    break;
                case 4:
                    radioAuth4.Visible = true;
                    displayBooks(model, ref textAuth4);
                    textAuth4.Visible = true;
                    break;
                case 5:
                    radioAuth5.Visible = true;
                    displayBooks(model, ref textAuth5);
                    textAuth5.Visible = true;
                    break;
                case 6:
                    radioAuth6.Visible = true;
                    displayBooks(model, ref textAuth6);
                    textAuth6.Visible = true;
                    break;
                default:
                    DisplayManager.displayError(ApplicationErrorType.INVALID_VALUE, "Valore " + value);
                    break;
            }
        }

        private void displayBooks(BookModel model, ref RichTextBox textArea)
        {
            textArea.Text = "";
            int startText = 0;
            string text = DisplayUtility.formatAuthorName(model.autore);
            textArea.AppendText(text);
            textArea.Select(startText, text.Length);
            textArea.SelectionColor = Color.Blue;
            textArea.SelectionFont = new Font("Calibri", 14, FontStyle.Bold);

            textArea.AppendText(Environment.NewLine);

            startText = textArea.Text.Length;
            text = model.titolo;
            textArea.AppendText(text);
            textArea.Select(startText, text.Length);
            textArea.SelectionFont = new Font("Calibri", 13, FontStyle.Bold);
            textArea.SelectionColor = Color.Black;

            textArea.AppendText(Environment.NewLine);

            if (model.serie != null && !model.serie.Equals(""))
            {
                startText = textArea.Text.Length;
                text = model.serie;
                textArea.AppendText(text);
                textArea.Select(startText, text.Length);
                textArea.SelectionFont = new Font("Calibri", 12, FontStyle.Italic);
                textArea.SelectionColor = Color.Black;
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            globalObject.libraryObject.destroy();
            parent.closePanel();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            currentPages++;
            displayBooks();
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            currentPages--;
            displayBooks();
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            ApplicationErrorType status = selectAuthor();
            if (status == ApplicationErrorType.SUCCESS)
            {
                parent.closePanel();
                parent.openPanel(GlobalOperation.LIB_DETAIL_BOOK_DELETE);
            }
            else
            {
                DisplayManager.displayError(status);
            }
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

                int indexAuthor = getIndexBook(idxRadio);
                if (indexAuthor >= 0 && indexAuthor < globalObject.libraryObject.libraryInput.libri.Count)
                {
                    BookModel tmpModel = globalObject.libraryObject.libraryInput.libri[indexAuthor];
                    globalObject.libraryObject.libraryInput.destroy();
                    globalObject.libraryObject.libraryInput.libro = tmpModel;

                    //salvo anche autori per uso futuro
                    globalObject.libraryObject.libraryInput.autore = tmpModel.autore;
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
                status = ApplicationErrorType.NO_BOOK_SELECTED;
            }
            return status;
        }


        private int getIndexBook(int idxRadio)
        {
            int index = Configurator.getInstsance().getInt("notfound.value");
            index = (int)(idxRadio - 1 + ((currentPages - 1) * numMaxElement));
            return index;
        }


    }
}
