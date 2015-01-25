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
        ZedGraphControl pieGraphCategory;

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

            groupBox1.Size = new Size(300, this.Size.Height - (titlePanel.Size.Height + titlePanel.Location.Y + 100));
            groupBox1.BackColor = LayoutManager.getPanelColor2();
            groupBox1.Location = new Point(5, titlePanel.Location.Y + 5 + titlePanel.Size.Height);
            this.Controls.Add(groupBox1);

            //Visualizzazione delle categorie + grafico
            pieGraphCategory = new ZedGraphControl();
            pieGraphCategory.Size = new Size(this.Size.Width - (groupBox1.Location.X + 15 + groupBox1.Size.Width), this.Size.Height - (titlePanel.Size.Height + titlePanel.Location.Y + 100));

            if (globalObject.libraryObject.statistiche.categoryDistribution != null && globalObject.libraryObject.statistiche.categoryDistribution.Count > 0)
            {
                displayGridView();

                displayPieCharCategoryCount();
            }

            buttonOk.Location = new Point(this.Size.Width - (buttonOk.Size.Width + 20), pieGraphCategory.Location.Y + pieGraphCategory.Size.Height + 10);
            this.Controls.Add(buttonOk);

            toolTip1.SetToolTip(buttonOk, "Chiusura Grafici");

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
            groupBox1.Controls.Add(dataGridCategory);
        }

        private void displayPieCharCategoryCount()
        {
            pieGraphCategory.Location = new Point(groupBox1.Location.X + groupBox1.Size.Width + 5, groupBox1.Location.Y);

            pieGraphCategory.GraphPane.Border.IsVisible = false;
            pieGraphCategory.GraphPane.XAxis.Scale.IsVisible = false;
            pieGraphCategory.GraphPane.YAxis.Scale.IsVisible = false;
            pieGraphCategory.GraphPane.YAxis.Title.IsVisible = false;
            pieGraphCategory.GraphPane.XAxis.Title.IsVisible = false;
            pieGraphCategory.GraphPane.Title.IsVisible = false;

            double[] values = new double[globalObject.libraryObject.statistiche.categoryDistribution.Count];
            string[] key = new string[globalObject.libraryObject.statistiche.categoryDistribution.Count];

            int index = 0;
            foreach (KeyValuePair<string, int> entry in globalObject.libraryObject.statistiche.categoryDistribution)
            {
                key[index] = entry.Key;
                values[index] = entry.Value;
                index++;
            }

            pieGraphCategory.GraphPane.AddPieSlices(values, key);

            this.Controls.Add(pieGraphCategory);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            parent.closePanel(GlobalOperation.LIB_STATS_GRAPH);
        }
    }
}
