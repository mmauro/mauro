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
using VideoBookApplication.library.controls;
using ZedGraph;

namespace VideoBookApplication.library.view
{
    public partial class StatGraphCategoryPanel : Panel
    {

        private GlobalApplicationObject globalObject;
        private LibraryActivityWindow parent;
        private StatControls control = new StatControls();

        //Grafico Numeri
        ZedGraphControl pieGraphNumberBook;

        public StatGraphCategoryPanel(ref GlobalApplicationObject globalObject, LibraryActivityWindow parent)
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
            TitlePanel titlePanel = new TitlePanel("Statistiche: Categorie", this);
            titlePanel.Location = new Point(0, 0);
            this.Controls.Add(titlePanel);

        }


        private void displayGridView()
        {
            //Grafico numero libri per categorie
            //Top 10 category in tabella
            dataGridCategory.Location = new Point(25, 25);
            dataGridCategory.BackgroundColor = LayoutManager.getPanelColor2();
            dataGridCategory.ColumnCount = 2;
            dataGridCategory.Columns[0].Name = "Categoria";
            dataGridCategory.Columns[1].Name = "Numero";

            int itemIndex = 0;
            foreach (KeyValuePair<string, int> entry in globalObject.libraryObject.statistiche.categoryDistribution)
            {
                if (itemIndex < Configurator.getInstsance().getInt("topcat.view"))
                {
                    string[] row = new string[] { StringUtility.capitalize(entry.Key), entry.Value.ToString() };
                    dataGridCategory.Rows.Add(row);
                    itemIndex++;
                }
            }

            dataGridCategory.Columns[0].Width = dataGridCategory.Size.Width / 2;
            dataGridCategory.Columns[1].Width = dataGridCategory.Size.Width / 2;

            //groupBox2.Controls.Add(dataGridCategory);
        }

        private void displayPieChartBooksNumber()
        {

            String[] key = { "Libri Cartacei", "Libri Ebook"};
            double[] values = {globalObject.libraryObject.statistiche.numLibriCarta, globalObject.libraryObject.statistiche.ebook};

            pieGraphNumberBook = new ZedGraphControl();
            pieGraphNumberBook.GraphPane.AddPieSlices(values, key);
            pieGraphNumberBook.Location = new Point(25, 25);
            //pieGraphNumberBook.Size = new Size(groupBox3.Size.Width - 40, groupBox3.Size.Height - 40);

            //groupBox3.Controls.Add(pieGraphNumberBook);
        }

        private void displayPieCharCategoryCount()
        {
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            parent.closePanel(GlobalOperation.LIB_STATS_GRAPH);
        }
    }
}
