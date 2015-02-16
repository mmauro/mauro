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


            //Gestione pulsanti
            buttonOk.Location = new Point(this.Size.Width - (10 + buttonOk.Size.Width), groupBox2.Location.Y + groupBox2.Size.Height + 10);
            this.Controls.Add(buttonOk);

            buttonClose.Location = new Point(buttonOk.Location.X - (10 + buttonClose.Size.Width), buttonOk.Location.Y);
            this.Controls.Add(buttonClose);

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            parent.closePanel();
        }
    }
}
