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
    public partial class StatPanel : Panel
    {
        private GlobalApplicationObject globalObject;
        private LibraryActivityWindow parent;
        private StatControls control = new StatControls();
        public StatPanel(ref GlobalApplicationObject globalObject, LibraryActivityWindow parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.globalObject = globalObject;
            ApplicationErrorType status = control.getStatistics(ref this.globalObject);
            if (status == ApplicationErrorType.SUCCESS)
            {
                initPanel();
            }
            else
            {
                DisplayManager.displayError(status, "Errore Statistiche");
            }
        }

        private void initPanel()
        {
            this.BackColor = LayoutManager.getPanelColor();

            //Title
            TitlePanel titlePanel = new TitlePanel("Statistiche", this);
            titlePanel.Location = new Point(0, 0);
            this.Controls.Add(titlePanel);

            //left panel
            groupBox1.Location = new Point(5, titlePanel.Location.Y + titlePanel.Size.Height + 5);
            groupBox1.Size = new Size((this.Size.Width / 2) - 10, this.Size.Height - 150);
            groupBox1.BackColor = LayoutManager.getPanelColor2();
            this.Controls.Add(groupBox1);

            //right panel
            groupBox2.Location = new Point(groupBox1.Location.X + groupBox1.Size.Width + 10, titlePanel.Location.Y + titlePanel.Size.Height + 5);
            groupBox2.Size = new Size((this.Size.Width / 2) - 10, this.Size.Height - 150);
            groupBox2.BackColor = LayoutManager.getPanelColor2();
            this.Controls.Add(groupBox2);

            textLastBook.Size = new Size(groupBox2.Size.Width - 40, groupBox2.Size.Height - 40);
            textLastBook.Location = new Point(20, 20);
            textLastBook.BackColor = LayoutManager.getPanelColor2();
            groupBox2.Controls.Add(textLastBook);

            formatLastBook();


        }

        private void formatLastBook() {
            if (globalObject.libraryObject.statistiche.lastBook != null)
            {
                int startText = 0;
                string text = StringUtility.formatAuthorName(globalObject.libraryObject.statistiche.lastBook.autore);
                textLastBook.AppendText(text);
                textLastBook.Select(startText, text.Length);
                textLastBook.SelectionColor = Color.Blue;
                textLastBook.SelectionFont = new Font("Calibri", 14, FontStyle.Bold);

                textLastBook.AppendText(Environment.NewLine);

                startText = textLastBook.Text.Length;
                text = globalObject.libraryObject.statistiche.lastBook.titolo;
                textLastBook.AppendText(text);
                textLastBook.Select(startText, text.Length);
                textLastBook.SelectionFont = new Font("Calibri", 13, FontStyle.Bold);
                textLastBook.SelectionColor = Color.Black;

                textLastBook.AppendText(Environment.NewLine);

                if (globalObject.libraryObject.statistiche.lastBook.serie != null && !globalObject.libraryObject.statistiche.lastBook.serie.Equals(""))
                {
                    
                    startText = textLastBook.Text.Length;
                    text = globalObject.libraryObject.statistiche.lastBook.serie;
                    textLastBook.AppendText(text);
                    textLastBook.Select(startText, text.Length);
                    textLastBook.SelectionFont = new Font("Calibri", 12, FontStyle.Italic);
                    textLastBook.SelectionColor = Color.Black;
                }

                textLastBook.AppendText(Environment.NewLine);
                startText = textLastBook.Text.Length;
                text = globalObject.libraryObject.statistiche.lastBook.category.category;
                textLastBook.AppendText(text);
                textLastBook.Select(startText, text.Length);
                textLastBook.SelectionFont = new Font("Calibri", 11);
                textLastBook.SelectionColor = Color.Gray;

                textLastBook.AppendText(Environment.NewLine);
                textLastBook.AppendText(Environment.NewLine);
                startText = textLastBook.Text.Length;
                text = "Data di Inserimento: " + String.Format("{0:MM/dd/yyyy}", globalObject.libraryObject.statistiche.lastBook.dtInsert);
                textLastBook.AppendText(text);
                textLastBook.Select(startText, text.Length);
                textLastBook.SelectionFont = new Font("Calibri", 10, FontStyle.Italic);
                textLastBook.SelectionColor = Color.Gray;


            }
            else
            {
                textLastBook.Text = "Nessun Libro Trovato";
                textLastBook.Select(1, textLastBook.Text.Length);
                textLastBook.SelectionFont = new Font("Calibri", 12, FontStyle.Italic);
                textLastBook.SelectionColor = Color.Red;
            }
        }
    }
}
