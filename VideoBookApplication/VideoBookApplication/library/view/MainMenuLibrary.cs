using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoBookApplication.common.utility;
using VideoBookApplication.library.view;
using VideoBookApplication.common.model;
using VideoBookApplication.common.enums;


namespace VideoBookApplication.common.view
{
    public partial class MainMenuLibrary : Panel
    {
        private LibraryActivityWindow parent;

        private static int numButton = 6;
        private GlobalApplicationObject globalObject;

        public MainMenuLibrary(ref GlobalApplicationObject globalObject,  LibraryActivityWindow parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.globalObject = globalObject;
            initPanel();
        }

        private void initPanel()
        {
            this.BackColor = LayoutManager.getMenuColor();
            this.Size = new Size(LayoutManager.menuHeight, (numButton*90)+(5*(numButton+1)));

            //Button new
            buttonNew.Location = new Point(5, 5);
            this.Controls.Add(buttonNew);

            //Button delete
            buttonDelete.Location = new Point(5, buttonNew.Location.Y + buttonNew.Size.Height + 5);
            this.Controls.Add(buttonDelete);

            //Button Modify
            buttonModify.Location = new Point(5, buttonDelete.Location.Y + buttonDelete.Size.Height + 5);
            this.Controls.Add(buttonModify);

            //Button Search
            buttonSearch.Location = new Point(5, buttonModify.Location.Y + buttonModify.Size.Height + 5);
            this.Controls.Add(buttonSearch);

            //Button report
            buttonReport.Location = new Point(5, buttonSearch.Location.Y + buttonSearch.Size.Height + 5);
            this.Controls.Add(buttonReport);

            //Button stats
            buttonStats.Location = new Point(5, buttonReport.Location.Y + buttonReport.Size.Height + 5);
            this.Controls.Add(buttonStats);

            //toolTip
            toolTip1.SetToolTip(buttonDelete, "Cancellazione");
            toolTip1.SetToolTip(buttonNew, "Inserimento");
            toolTip1.SetToolTip(buttonModify, "Modifica");
            toolTip1.SetToolTip(buttonStats, "Statistiche");
            toolTip1.SetToolTip(buttonSearch, "Ricerca");
            toolTip1.SetToolTip(buttonReport, "Prepara Report");
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        private void buttonStats_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }
    }
}
