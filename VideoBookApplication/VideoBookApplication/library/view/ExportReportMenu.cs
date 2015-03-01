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
    public partial class ExportReportMenu : Panel
    {
        private LibraryActivityWindow parent;

        private static int numButton = 3;
        private GlobalApplicationObject globalObject;

        public ExportReportMenu(ref GlobalApplicationObject globalObject, LibraryActivityWindow parent)
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
            buttonReportCSV.Location = new Point(5, 5);
            this.Controls.Add(buttonReportCSV);

            //Button delete
            buttonReportExcel.Location = new Point(5, buttonReportCSV.Location.Y + buttonReportCSV.Size.Height + 5);
            this.Controls.Add(buttonReportExcel);

            //Button Modify
            buttonReportWord.Location = new Point(5, buttonReportExcel.Location.Y + buttonReportExcel.Size.Height + 5);
            this.Controls.Add(buttonReportWord);


            //toolTip
            toolTip1.SetToolTip(buttonReportExcel, "Crea Report in formato Excel");
            toolTip1.SetToolTip(buttonReportCSV, "Crea Report in formato CSV");
            toolTip1.SetToolTip(buttonReportWord, "Crea Report in formato Word");
        }

        private void buttonReportCSV_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        private void buttonReportExcel_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        private void buttonReportWord_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }

    }
}
