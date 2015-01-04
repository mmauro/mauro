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

namespace VideoBookApplication.library.view
{
    public partial class NewBooksPanel : Panel
    {

        private GlobalApplicationObject globalObject;
        private LibraryActivityWindow parent;

        public NewBooksPanel(ref GlobalApplicationObject globalObject, LibraryActivityWindow parent)
        {
            InitializeComponent();
            this.globalObject = globalObject;
            this.parent = parent;
            initPanel();
        }

        private void initPanel()
        {
            this.BackColor = LayoutManager.getPanelColor();

            //Resume Author Panel
            ResumeAuthorPanel authorPanel = new ResumeAuthorPanel(ref globalObject, this, parent);
            authorPanel.Location =  new Point(0, 0);
            this.Controls.Add(authorPanel);

            //Title
            TitlePanel titlePanel = new TitlePanel("Nuovi Libri", this);
            titlePanel.Location = new Point(0, authorPanel.Location.Y + authorPanel.Size.Height);
            this.Controls.Add(titlePanel);

            //Titolo
            labelTitle.Location = new Point(25, titlePanel.Location.Y + titlePanel.Size.Height + 10);
            this.Controls.Add(labelTitle);

            textTitle.Location = new Point(25, labelTitle.Location.Y + 20);
            this.Controls.Add(textTitle);

            //Serie
            labelSerie.Location = new Point(25, textTitle.Location.Y + textTitle.Size.Height + 20);
            this.Controls.Add(labelSerie);

            textSerie.Location = new Point(25, labelSerie.Location.Y + 20);
            this.Controls.Add(textSerie);

            //google books
            buttonGoogleBooks.Location = new Point(textSerie.Location.X + textSerie.Size.Width + 35, labelTitle.Location.Y + 35);
            this.Controls.Add(buttonGoogleBooks);

            //categorie
            labelCategory.Location = new Point(25, textSerie.Location.Y + textSerie.Size.Height + 20);
            this.Controls.Add(labelCategory);

            comboCategory.Location = new Point(25, labelCategory.Location.Y + 20);
            this.Controls.Add(comboCategory);

            buttonAddCat.Location = new Point(comboCategory.Location.X + 10 + comboCategory.Size.Width, comboCategory.Location.Y - 1 );
            this.Controls.Add(buttonAddCat);

            //posizione
            labelPosition.Location = new Point(260, textSerie.Location.Y + textSerie.Size.Height + 20);
            this.Controls.Add(labelPosition);

            comboLocation.Location = new Point(260, labelPosition.Location.Y + 20);
            this.Controls.Add(comboLocation);

            buttonAddPos.Location = new Point(comboLocation.Location.X + comboLocation.Size.Width + 10, comboLocation.Location.Y - 1);
            this.Controls.Add(buttonAddPos);

            //Formato Elettronico
            checkEbook.Location = new Point(25, comboLocation.Location.Y + 55);
            this.Controls.Add(checkEbook);

            //Note
            labelNote.Location = new Point(25, checkEbook.Location.Y + checkEbook.Size.Height + 20);
            this.Controls.Add(labelNote);

            textNote.Location = new Point(25, labelNote.Location.Y + 20);
            this.Controls.Add(textNote);

            //Pulsanti finali
            buttonClose.Location = new Point(this.Size.Width - (buttonClose.Size.Width + 20), textNote.Location.Y + textNote.Size.Height + 30);
            this.Controls.Add(buttonClose);

            buttonOk.Location = new Point(buttonClose.Location.X - (10 + buttonOk.Size.Width), buttonClose.Location.Y);
            this.Controls.Add(buttonOk);

            buttonAddBook.Location = new Point(buttonOk.Location.X - (40 + buttonAddBook.Size.Width), buttonOk.Location.Y);
            this.Controls.Add(buttonAddBook);

            labelNB.Text = globalObject.libraryObject.libraryInput.libri.Count + " Libri da Salvare";
            labelNB.Location = new Point(25, textNote.Location.Y + textNote.Size.Height + 40);
            this.Controls.Add(labelNB);


            //Tooltip
            toolTip1.SetToolTip(buttonGoogleBooks, "Ricerca su Google del libro");
            toolTip1.SetToolTip(buttonAddCat, "Nuova Categoria");
            toolTip1.SetToolTip(buttonAddPos, "Nuova Posizione");
            toolTip1.SetToolTip(buttonClose, "Annulla");
            toolTip1.SetToolTip(buttonOk, "Salvataggio Libri");
            toolTip1.SetToolTip(buttonAddBook, "Nuovo Libro");

        }

        private void buttonGoogleBooks_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        private void buttonAddCat_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        private void buttonAddPos_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            parent.closePanel();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        private void buttonAddBook_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }
    }
}
