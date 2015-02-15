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
using VideoBookApplication.common.enums;
using VideoBookApplication.common.utility;
using VideoBookApplication.common.view;

namespace VideoBookApplication.library.view
{
    public partial class DetailBookPanel : Panel
    {

        private GlobalApplicationObject globalObject;
        private LibraryActivityWindow parent;
        private GlobalOperation currentOperation = GlobalOperation.UNDEFINED;

        public DetailBookPanel(ref GlobalApplicationObject globalObject, LibraryActivityWindow parent)
        {
            InitializeComponent();
            this.globalObject = globalObject;
            this.parent = parent;
            this.currentOperation = globalObject.currentOperation;
            initPanel();
        }

        private void initPanel()
        {

            this.BackColor = LayoutManager.getPanelColor();

            //Resume Author Panel
            ResumeAuthorPanel authorPanel = new ResumeAuthorPanel(ref globalObject, this, parent);
            authorPanel.Location = new Point(0, 0);
            this.Controls.Add(authorPanel);

            //Title
            TitlePanel titlePanel = new TitlePanel("Dettaglio Libro", this);
            titlePanel.Location = new Point(0, authorPanel.Location.Y + authorPanel.Size.Height);
            this.Controls.Add(titlePanel);

        }
    }
}
