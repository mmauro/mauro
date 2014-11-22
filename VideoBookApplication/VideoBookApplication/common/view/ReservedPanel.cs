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

namespace VideoBookApplication.common.view
{
    public partial class ReservedPanel : Panel
    {
        public ReservedPanel()
        {
            InitializeComponent();
            initPanel();
        }

        private void initPanel()
        {

            this.BackColor = LayoutManager.getPanelColor();

            TitlePanel titlePanel = new TitlePanel("Parole Riservate", this);
            titlePanel.Location = new Point(0, 0);
            this.Controls.Add(titlePanel);

        }
    }
}
