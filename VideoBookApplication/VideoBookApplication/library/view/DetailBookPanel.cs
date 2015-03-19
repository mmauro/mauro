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
using VideoBookApplication.library.utility;
using VideoBookApplication.library.controls;

namespace VideoBookApplication.library.view
{
    public partial class DetailBookPanel : Panel
    {

        private GlobalApplicationObject globalObject;
        private LibraryActivityWindow parent;
        private GlobalOperation currentOperation = GlobalOperation.UNDEFINED;

        public DetailBookPanel(ref GlobalApplicationObject globalObject, LibraryActivityWindow parent)
        {
            InitializeComponent();
            this.globalObject = globalObject;
            this.parent = parent;
            this.currentOperation = globalObject.currentOperation;
            initPanel();
        }

        private void initPanel()
        {

            this.BackColor = LayoutManager.getPanelColor();

            //Resume Author Panel
            ResumeAuthorPanel authorPanel = new ResumeAuthorPanel(ref globalObject, this, parent);
            authorPanel.Location = new Point(0, 0);
            this.Controls.Add(authorPanel);

            //Title
            TitlePanel titlePanel = new TitlePanel("Dettaglio Libro", this);
            titlePanel.Location = new Point(0, authorPanel.Location.Y + authorPanel.Size.Height);
            this.Controls.Add(titlePanel);

            groupBox1.Size = new Size((this.Size.Width - 30) / 2, this.Size.Height - (110  + authorPanel.Size.Height + titlePanel.Size.Height));
            groupBox1.Location = new Point(10, titlePanel.Location.Y + titlePanel.Size.Height + 20);
            groupBox1.BackColor = LayoutManager.getPanelColor();
            this.Controls.Add(groupBox1);

            groupBox2.Size = new Size((this.Size.Width - 30) / 2, this.Size.Height - (110 + authorPanel.Size.Height + titlePanel.Size.Height));
            groupBox2.Location = new Point(groupBox1.Location.X + groupBox1.Size.Width + 10, groupBox1.Location.Y);
            groupBox2.BackColor = LayoutManager.getPanelColor();
            this.Controls.Add(groupBox2);

            //Informazioni libro
            labelTitle.Location = new Point(15, 30);
            groupBox1.Controls.Add(labelTitle);

            textTitle.Location = new Point(labelTitle.Location.X, labelTitle.Location.Y + 25);
            textTitle.Text = globalObject.libraryObject.libraryInput.libro.titolo;
            groupBox1.Controls.Add(textTitle);

            labelSerie.Location = new Point(labelTitle.Location.X, textTitle.Location.Y + 40);
            groupBox1.Controls.Add(labelSerie);

            textSerie.Location = new Point(labelSerie.Location.X, labelSerie.Location.Y + 25);
            if (globalObject.libraryObject.libraryInput.libro.serie != null)
            {
                textSerie.Text = globalObject.libraryObject.libraryInput.libro.serie;
            }
            groupBox1.Controls.Add(textSerie);

            labelCategory.Location = new Point(labelSerie.Location.X, textSerie.Location.Y + 40);
            groupBox1.Controls.Add(labelCategory);

            textCategory.Location = new Point(labelCategory.Location.X, labelCategory.Location.Y + 25);
            textCategory.Text = DisplayUtility.formatCategoryPosition(globalObject.libraryObject.libraryInput.libro.category.category);
            groupBox1.Controls.Add(textCategory);

            labelPosition.Location = new Point(textCategory.Location.X + textCategory.Size.Width + 20, labelCategory.Location.Y);
            groupBox1.Controls.Add(labelPosition);

            textPosition.Location = new Point(labelPosition.Location.X, textCategory.Location.Y);
            textPosition.Text = DisplayUtility.formatCategoryPosition(globalObject.libraryObject.libraryInput.libro.position.position);
            groupBox1.Controls.Add(textPosition);

            checkEbook.Location = new Point(textCategory.Location.X, textCategory.Location.Y + 50);
            checkEbook.Checked = globalObject.libraryObject.libraryInput.libro.flEbook;
            groupBox1.Controls.Add(checkEbook);

            labelNota.Location = new Point(checkEbook.Location.X, checkEbook.Location.Y + 30);
            groupBox1.Controls.Add(labelNota);

            textNote.Location = new Point(labelNota.Location.X, labelNota.Location.Y + 25);
            if (globalObject.libraryObject.libraryInput.libro.note != null && globalObject.libraryObject.libraryInput.libro.note.nota != null)
            {
                textNote.Text = globalObject.libraryObject.libraryInput.libro.note.nota;
            }
            groupBox1.Controls.Add(textNote);

            //Informazioni Aggiuntive
            if (globalObject.libraryObject.libraryInput.libro.informations != null)
            {
                imageBox.SizeMode = PictureBoxSizeMode.Zoom;
                if (globalObject.libraryObject.libraryInput.libro.informations.image != null && !globalObject.libraryObject.libraryInput.libro.informations.image.Equals(""))
                {
                    imageBox.Load(globalObject.libraryObject.libraryInput.libro.informations.image);
                }
                else
                {
                    imageBox.Image = global::VideoBookApplication.Properties.Resources.no_image;
                }
                imageBox.Location = new Point(15, 30);
                groupBox2.Controls.Add(imageBox);

                labelEditore.Location = new Point(imageBox.Location.X + imageBox.Size.Width + 15, imageBox.Location.Y);
                groupBox2.Controls.Add(labelEditore);

                textEditore.Location = new Point(labelEditore.Location.X, labelEditore.Location.Y + 25);
                textEditore.Text = globalObject.libraryObject.libraryInput.libro.informations.publisher;
                groupBox2.Controls.Add(textEditore);

                labelIsbn.Location = new Point(textEditore.Location.X, textEditore.Location.Y + 40);
                groupBox2.Controls.Add(labelIsbn);

                textIsbn.Location = new Point(labelIsbn.Location.X, labelIsbn.Location.Y + 25);
                textIsbn.Text = globalObject.libraryObject.libraryInput.libro.informations.isbn;
                groupBox2.Controls.Add(textIsbn);

                labelYear.Location = new Point(textIsbn.Location.X, textIsbn.Location.Y + 40);
                groupBox2.Controls.Add(labelYear);

                textYear.Location = new Point(labelYear.Location.X, labelYear.Location.Y + 25);
                textYear.Text = globalObject.libraryObject.libraryInput.libro.informations.year;
                groupBox2.Controls.Add(textYear);

                labelTrama.Location = new Point(15, imageBox.Location.Y + imageBox.Size.Height + 33);
                groupBox2.Controls.Add(labelTrama);

                textTrama.Location = new Point(labelTrama.Location.X, labelTrama.Location.Y + 25);
                if (globalObject.libraryObject.libraryInput.libro.informations.trama != null && !globalObject.libraryObject.libraryInput.libro.informations.trama.Trim().Equals(""))
                {
                    textTrama.Text = globalObject.libraryObject.libraryInput.libro.informations.trama;
                }
                groupBox2.Controls.Add(textTrama);


            }


            //Gestione pulsanti
            buttonClose.Location = new Point(this.Size.Width - (10 + buttonOk.Size.Width), groupBox2.Location.Y + groupBox2.Size.Height + 10);
            this.Controls.Add(buttonClose);

            buttonOk.Location = new Point(buttonClose.Location.X - (10 + buttonOk.Size.Width), buttonClose.Location.Y);
            this.Controls.Add(buttonOk);

            toolTip1.SetToolTip(buttonClose, "Annulla");
            toolTip1.SetToolTip(buttonOk, "Cancella Libro");

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            ApplicationErrorType status = ApplicationErrorType.NOT_INIT_WARN;
            LibraryControls libControl = new LibraryControls();
            if (globalObject.libraryObject.libraryInput.autore.libri.Count == 1)
            {
                //Cancellare Completamente Autore
                DisplayManager.displayWarning(ApplicationErrorType.DELETE_AUTHOR_WARN);
                status = libControl.deleteAuthorAndBook(ref globalObject);
            }
            else
            {
                //Cancellare solo il libro
                status = libControl.deleteBook(ref globalObject);
            }

            if (status == ApplicationErrorType.SUCCESS)
            {
                DisplayManager.displayMessage(status, "Libro Cancellato con Successo");
                parent.closePanel();
            }
            else
            {
                DisplayManager.displayError(status);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            parent.closePanel();
        }
    }
}
