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
        }
    }
}
