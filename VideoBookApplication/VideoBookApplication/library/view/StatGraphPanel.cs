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

namespace VideoBookApplication.library.view
{
    public partial class StatGraphPanel : Panel
    {

        private GlobalApplicationObject globalObject;
        private LibraryActivityWindow parent;

        public StatGraphPanel(ref GlobalApplicationObject globalObject, LibraryActivityWindow parent)
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
            TitlePanel titlePanel = new TitlePanel("Grafici Statistiche", this);
            titlePanel.Location = new Point(0, 0);
            this.Controls.Add(titlePanel);
        }
    }
}
