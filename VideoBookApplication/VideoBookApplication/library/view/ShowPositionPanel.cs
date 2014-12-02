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

            textPosition.ReadOnly = true;
            textPosition.Size = new System.Drawing.Size(this.Size.Width - 40, 150);
            textPosition.Location = new Point(20, titlePanel.Location.X + titlePanel.Size.Height + 20);
            this.Controls.Add(textPosition);

            buttonOk.Location = new Point((this.Size.Width / 2) - (buttonOk.Size.Width / 2), textPosition.Location.Y + textPosition.Size.Height + 15);
            this.Controls.Add(buttonOk);

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            parent.closePanel(GlobalOperation.LIB_SHOW_POS);
        }
    }
}
