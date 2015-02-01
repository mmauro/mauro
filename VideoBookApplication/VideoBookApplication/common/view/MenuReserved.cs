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
using VideoBookApplication.common.view;
using VideoBookApplication.common.model;
using VideoBookApplication.common.enums;
using VideoBookApplication.library.view;


namespace VideoBookApplication.common.view
{
    public partial class MenuReserved : Panel
    {
        private Form parent;

        private static int numButton = 1;
        private GlobalApplicationObject globalObject;

        public MenuReserved(ref GlobalApplicationObject globalObject, Form parent)
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

            //Button changeApp
            buttonReserved.Location = new Point(5, 5);
            this.Controls.Add(buttonReserved);

            //toolTip
            toolTip1.SetToolTip(buttonReserved, "Gestione Parole Riservate");

        }

        private void buttonReserved_Click(object sender, EventArgs e)
        {
            openPanel();
        }

        private void openPanel()
        {
            switch (globalObject.activity)
            {
                case ActivityType.LIBRARY:
                    LibraryActivityWindow mainWin = (LibraryActivityWindow)parent;
                    mainWin.openPanel(GlobalOperation.RESERVED);
                    break;
                default:
                    DisplayManager.displayError(ApplicationErrorType.NOT_ALLOWED);
                    break;
            }
        }

    }
}
