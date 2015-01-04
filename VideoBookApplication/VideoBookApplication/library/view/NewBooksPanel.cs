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
    public partial class NewBooksPanel : Panel
    {

        private GlobalApplicationObject globalObject;
        private LibraryActivityWindow parent;

        public NewBooksPanel(ref GlobalApplicationObject globalObject, LibraryActivityWindow parent)
        {
            InitializeComponent();
            this.globalObject = globalObject;
            this.parent = parent;
            initPanel();
        }

        private void initPanel()
        {
            this.BackColor = LayoutManager.getPanelColor();

            ResumeAuthorPanel authorPanel = new ResumeAuthorPanel(ref globalObject, this, parent);
            authorPanel.Location =  new Point(0, 0);
            this.Controls.Add(authorPanel);

            //Title
            TitlePanel titlePanel = new TitlePanel("Nuovi Libri", this);
            titlePanel.Location = new Point(0, authorPanel.Location.Y + authorPanel.Size.Height);
            this.Controls.Add(titlePanel);


        }
    }
}
