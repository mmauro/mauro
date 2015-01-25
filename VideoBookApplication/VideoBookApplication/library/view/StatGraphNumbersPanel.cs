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
using ZedGraph;
using VideoBookApplication.common.enums;

namespace VideoBookApplication.library.view
{
    public partial class StatGraphNumbersPanel : Panel
    {

        private GlobalApplicationObject globalObject;
        private LibraryActivityWindow parent;
        ZedGraphControl pieGraphNumberBook;

        public StatGraphNumbersPanel(ref GlobalApplicationObject globalObject, LibraryActivityWindow parent)
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
            TitlePanel titlePanel = new TitlePanel("Statistiche: Numeriche Libri", this);
            titlePanel.Location = new Point(0, 0);
            this.Controls.Add(titlePanel);

            pieGraphNumberBook = new ZedGraphControl();
            pieGraphNumberBook.Size = new Size(this.Size.Width - 50, this.Size.Height - 150);
            pieGraphNumberBook.Location = new Point(25, 10 + titlePanel.Location.Y + titlePanel.Size.Height);

            //Display Graphics
            if (globalObject.libraryObject.statistiche.numLibri > 0)
            {
                displayPieChartBooksNumber();
            }

            //Pulsante OK
            buttonOk.Location = new Point(this.Size.Width - (buttonOk.Size.Width + 20), pieGraphNumberBook.Location.Y + pieGraphNumberBook.Size.Height + 10);
            this.Controls.Add(buttonOk);

            toolTip1.SetToolTip(buttonOk, "Chiusura Grafici");

        }

        private void displayPieChartBooksNumber()
        {

            String[] key = { "Libri Cartacei", "Libri Ebook" };
            double[] values = { globalObject.libraryObject.statistiche.numLibriCarta, globalObject.libraryObject.statistiche.ebook };

            //pieGraphNumberBook.BackColor = Color.Red;
            pieGraphNumberBook.GraphPane.AddPieSlices(values, key);

            pieGraphNumberBook.GraphPane.Border.IsVisible = false;
            pieGraphNumberBook.GraphPane.XAxis.Scale.IsVisible = false;
            pieGraphNumberBook.GraphPane.YAxis.Scale.IsVisible = false;
            pieGraphNumberBook.GraphPane.YAxis.Title.IsVisible = false;
            pieGraphNumberBook.GraphPane.XAxis.Title.IsVisible = false;
            pieGraphNumberBook.GraphPane.Title.IsVisible = false;

            this.Controls.Add(pieGraphNumberBook);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            parent.closePanel(GlobalOperation.LIB_STATS_GRAPH);
        }
    }
}
