﻿using System;
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
using VideoBookApplication.library.utility;

namespace VideoBookApplication.library.view
{
    public partial class ShowBooksPanel : Panel
    {

        private GlobalApplicationObject globalObject;
        private LibraryActivityWindow parent;
        private GlobalOperation currentOperation = GlobalOperation.UNDEFINED;

        public ShowBooksPanel(ref GlobalApplicationObject globalObject, LibraryActivityWindow parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.globalObject = globalObject;
            this.currentOperation = this.globalObject.currentOperation;
            
            initPanel();
        }

        private void initPanel()
        {
            this.BackColor = LayoutManager.getPanelColor();

            //Title
            TitlePanel titlePanel = new TitlePanel("Elenco Libri", this);
            titlePanel.Location = new Point(0, 0);
            this.Controls.Add(titlePanel);

            labelNumBooks.Text = "Libri Trovati : " + globalObject.libraryObject.libraryInput.autore.libri.Count;
            labelNumBooks.Size = new Size(this.Size.Width, 30);
            labelNumBooks.Location = new Point(0,titlePanel.Location.Y + 20 + titlePanel.Size.Height);
            this.Controls.Add(labelNumBooks);

            textBooks.Size = new Size(this.Size.Width - 50, this.Size.Height - (titlePanel.Location.Y + 160 + titlePanel.Size.Height));
            textBooks.Location = new Point(25, titlePanel.Location.Y + titlePanel.Size.Height + 60);
            this.Controls.Add(textBooks);

            displayBooks();

            buttonOk.Location = new Point((this.Size.Width / 2) - (buttonOk.Size.Width / 2), textBooks.Location.Y + textBooks.Size.Height + 20);
            if (currentOperation == GlobalOperation.LIB_DELETE_AUTHOR)
            {
                buttonOk.Visible = false;
            }
            this.Controls.Add(buttonOk);

            toolTip1.SetToolTip(buttonOk, "Chiusura Finestra");
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
                text = "Categoria: " + DisplayUtility.formatCategoryPosition(model.category.category);
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
