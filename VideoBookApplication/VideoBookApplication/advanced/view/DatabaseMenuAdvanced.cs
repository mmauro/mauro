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
using VideoBookApplication.common.view;


namespace VideoBookApplication.advanced.view
{
    public partial class DatabaseMenuAdvanced : Panel
    {
        private AdvancedActivityWindow parent;

        private static int numButton = 2;
        private GlobalApplicationObject globalObject;

        public DatabaseMenuAdvanced(ref GlobalApplicationObject globalObject, AdvancedActivityWindow parent)
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
            buttonRestore.Location = new Point(5, 5);
            this.Controls.Add(buttonRestore);

            //Button delete
            buttonDump.Location = new Point(5, buttonRestore.Location.Y + buttonRestore.Size.Height + 5);
            this.Controls.Add(buttonDump);

            //toolTip
            toolTip1.SetToolTip(buttonDump, "Dump Database");
            toolTip1.SetToolTip(buttonRestore, "Restore Database");
        }

        private void buttonDump_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        private void buttonRestore_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }
    }
}
