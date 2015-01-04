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
    public partial class ResumeAuthorPanel : Panel
    {

        private GlobalApplicationObject globalObject;
        private Panel parent;
        private LibraryActivityWindow frame;
        public ResumeAuthorPanel(ref GlobalApplicationObject globalObject, Panel parent, LibraryActivityWindow frame)
        {
            InitializeComponent();
            this.parent = parent;
            this.globalObject = globalObject;
            this.frame = frame;
            initPanel();
        }

        private void initPanel()
        {
            if (globalObject.libraryObject.libraryInput.autore != null)
            {
                this.Size = new Size(parent.Size.Width, 70);
                this.BackColor = LayoutManager.getInnerPanelColor();

                labelTesto.Location = new Point(10, 20);
                this.Controls.Add(labelTesto);

                labelAutore.Text = StringUtility.formatAuthorName(globalObject.libraryObject.libraryInput.autore);
                labelAutore.Location = new Point(100, 20);
                this.Controls.Add(labelAutore);

                buttonBooks.Location = new Point(parent.Size.Width - (25 + buttonBooks.Size.Width), 10);
                this.Controls.Add(buttonBooks);

                toolTip1.SetToolTip(buttonBooks, "Visualizzazione Libri");

            }
            else
            {
                DisplayManager.displayError(ApplicationErrorType.AUTHOR_NOT_FOUND);
            }

        }

        private void buttonBooks_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }
    }
}
