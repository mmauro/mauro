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
using VideoBookApplication.common.view;
using VideoBookApplication.common.utility;
using VideoBookApplication.common.enums;
using VideoBookApplication.library.model.database;

namespace VideoBookApplication.library.view
{
    public partial class ShowBooksPanel : Panel
    {

        private GlobalApplicationObject globalObject;
        private LibraryActivityWindow parent;

        public ShowBooksPanel(ref GlobalApplicationObject globalObject, LibraryActivityWindow parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.globalObject = globalObject;
            
            initPanel();
        }

        private void initPanel()
        {
            this.BackColor = LayoutManager.getPanelColor();

            //Title
            TitlePanel titlePanel = new TitlePanel("Elenco Libri", this);
            titlePanel.Location = new Point(0, 0);
            this.Controls.Add(titlePanel);

            textBooks.Size = new Size(this.Size.Width - 50, this.Size.Height - (titlePanel.Location.Y + 130 + titlePanel.Size.Height));
            textBooks.Location = new Point(25, titlePanel.Location.Y + titlePanel.Size.Height + 10);
            this.Controls.Add(textBooks);

            displayBooks();

            buttonOk.Location = new Point((this.Size.Width / 2) - (buttonOk.Size.Width / 2), textBooks.Location.Y + textBooks.Size.Height + 20);
            this.Controls.Add(buttonOk);
        }


        private void displayBooks()
        {
            int i = 0;
            textBooks.Text = "";
            foreach (BookModel model in globalObject.libraryObject.libraryInput.autore.libri)
            {
                int startText = textBooks.Text.Length;
                String text = "";
                if (i > 0)
                {
                    text = Environment.NewLine;
                }
                text += model.titolo;
                textBooks.AppendText(text);
                textBooks.Select(startText, text.Length);
                textBooks.SelectionColor = Color.Blue;
                textBooks.SelectionFont = new Font("Calibri", 13, FontStyle.Bold);

                if (model.serie != null && !model.serie.Trim().Equals(""))
                {
                    startText = textBooks.Text.Length;
                    text = "";
                    text = Environment.NewLine;
                    text += model.serie;
                    textBooks.AppendText(text);
                    textBooks.Select(startText, text.Length);
                    textBooks.SelectionColor = Color.Black;
                    textBooks.SelectionFont = new Font("Calibri", 12, FontStyle.Italic);
                }

                text = "";
                textBooks.AppendText(Environment.NewLine);
                startText = textBooks.Text.Length;
                text = model.category.category;
                textBooks.AppendText(text);
                textBooks.Select(startText, text.Length);
                textBooks.SelectionFont = new Font("Calibri", 11);
                textBooks.SelectionColor = Color.Gray;

                textBooks.AppendText(Environment.NewLine);


                i++;
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            parent.closePanel(GlobalOperation.LIB_SHOW_BOOKS);
        }
    }
}
