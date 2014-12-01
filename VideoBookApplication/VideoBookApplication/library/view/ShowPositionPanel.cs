using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoBookApplication.common.model;
using VideoBookApplication.common.utility;
using VideoBookApplication.common.view;

namespace VideoBookApplication.library.view
{
    public partial class ShowPositionPanel : Panel
    {
        private GlobalApplicationObject globalObject;
        private LibraryActivityWindow parent;
        public ShowPositionPanel(ref GlobalApplicationObject globalObject, LibraryActivityWindow parent)
        {
            InitializeComponent();
            this.globalObject = globalObject;
            this.parent = parent;
            initPanel();
        }

        private void initPanel()
        {
            this.BackColor = LayoutManager.getPanelColor();
            TitlePanel titlePanel = new TitlePanel("Visualizzazione Posizioni", this);
            titlePanel.Location = new Point(0, 0);
            this.Controls.Add(titlePanel);
        }
    }
}
