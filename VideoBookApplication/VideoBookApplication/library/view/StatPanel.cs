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

            textNumbers.Size = new Size(groupBox1.Size.Width - 40, groupBox1.Size.Height - 40);
            textNumbers.Location = new Point(20, 20);
            textNumbers.BackColor = LayoutManager.getPanelColor2();
            groupBox1.Controls.Add(textNumbers);

            formatNumbers();

            //Gestione pulsanti
            buttonOk.Location = new Point(this.Size.Width - (20 + buttonOk.Size.Height), groupBox2.Location.Y + groupBox2.Size.Height + 10);
            this.Controls.Add(buttonOk);

            buttonGraph.Location = new Point(buttonOk.Location.X - (buttonGraph.Size.Width + 30), buttonOk.Location.Y);
            if (globalObject.libraryObject.statistiche.numAutori == 0 && globalObject.libraryObject.statistiche.numLibri == 0)
            {
                //Non ho nessuna informazione per visualizzare grafici: nascondo il pulsante
                buttonGraph.Visible = false;
            }
            this.Controls.Add(buttonGraph);

            toolTip1.SetToolTip(buttonGraph, "Visualizzazione Grafici Statistiche");
            toolTip1.SetToolTip(buttonOk, "Chiusura Statistiche");
        }

        private void formatNumbers()
        {
            int startText = 0;
            textNumbers.AppendText(Environment.NewLine);
            string text = "Numero di Autori: ";
            textNumbers.AppendText(text);
            textNumbers.Select(startText, text.Length);
            textNumbers.SelectionColor = Color.Black;
            textNumbers.SelectionFont = new Font("Calibri", 12, FontStyle.Bold);

            startText = textNumbers.Text.Length;
            text = globalObject.libraryObject.statistiche.numAutori.ToString();
            textNumbers.AppendText(text);
            textNumbers.Select(startText, text.Length);
            textNumbers.SelectionColor = Color.Gray;
            textNumbers.SelectionFont = new Font("Calibri", 12);

            textNumbers.AppendText(Environment.NewLine);
            textNumbers.AppendText(Environment.NewLine);

            startText = textNumbers.Text.Length;
            text = "Numero di Libri: ";
            textNumbers.AppendText(text);
            textNumbers.Select(startText, text.Length);
            textNumbers.SelectionColor = Color.Black;
            textNumbers.SelectionFont = new Font("Calibri", 12, FontStyle.Bold);

            startText = textNumbers.Text.Length;
            text = globalObject.libraryObject.statistiche.numLibri.ToString();
            textNumbers.AppendText(text);
            textNumbers.Select(startText, text.Length);
            textNumbers.SelectionColor = Color.Gray;
            textNumbers.SelectionFont = new Font("Calibri", 12);

            textNumbers.AppendText(Environment.NewLine);

            startText = textNumbers.Text.Length;
            text = "Numero di Libri Cartacei: ";
            textNumbers.AppendText(text);
            textNumbers.Select(startText, text.Length);
            textNumbers.SelectionColor = Color.Black;
            textNumbers.SelectionFont = new Font("Calibri", 12, FontStyle.Bold);

            startText = textNumbers.Text.Length;
            text = globalObject.libraryObject.statistiche.numLibriCarta.ToString();
            textNumbers.AppendText(text);
            textNumbers.Select(startText, text.Length);
            textNumbers.SelectionColor = Color.Gray;
            textNumbers.SelectionFont = new Font("Calibri", 12);

            textNumbers.AppendText(Environment.NewLine);

            startText = textNumbers.Text.Length;
            text = "Numero Ebook: ";
            textNumbers.AppendText(text);
            textNumbers.Select(startText, text.Length);
            textNumbers.SelectionColor = Color.Black;
            textNumbers.SelectionFont = new Font("Calibri", 12, FontStyle.Bold);

            startText = textNumbers.Text.Length;
            text = globalObject.libraryObject.statistiche.ebook.ToString();
            textNumbers.AppendText(text);
            textNumbers.Select(startText, text.Length);
            textNumbers.SelectionColor = Color.Gray;
            textNumbers.SelectionFont = new Font("Calibri", 12);

            textNumbers.AppendText(Environment.NewLine);
            textNumbers.AppendText(Environment.NewLine);

            startText = textNumbers.Text.Length;
            text = "Media Libri/Autori: ";
            textNumbers.AppendText(text);
            textNumbers.Select(startText, text.Length);
            textNumbers.SelectionColor = Color.Black;
            textNumbers.SelectionFont = new Font("Calibri", 12, FontStyle.Bold);

            startText = textNumbers.Text.Length;
            text = globalObject.libraryObject.statistiche.media.ToString();
            textNumbers.AppendText(text);
            textNumbers.Select(startText, text.Length);
            textNumbers.SelectionColor = Color.Gray;
            textNumbers.SelectionFont = new Font("Calibri", 12);

            
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

        private void buttonOk_Click(object sender, EventArgs e)
        {
            parent.closePanel();
        }

        private void buttonGraph_Click(object sender, EventArgs e)
        {
            parent.openPanel(GlobalOperation.LIB_STATS_GRAPH);
        }
    }
}
