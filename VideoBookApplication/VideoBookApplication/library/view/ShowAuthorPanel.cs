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
using VideoBookApplication.library.model.database;
using VideoBookApplication.common.enums;
using VideoBookApplication.library.utility;

namespace VideoBookApplication.library.view
{
    public partial class ShowAuthorPanel : Panel
    {

        private GlobalApplicationObject globalObject;
        private LibraryActivityWindow parent;
        public ShowAuthorPanel(ref GlobalApplicationObject globalObject, LibraryActivityWindow parent)
        {
            InitializeComponent();
            this.globalObject = globalObject;
            this.parent = parent;
            initPanel();
        }

        private void initPanel()
        {
            this.BackColor = LayoutManager.getPanelColor();
            TitlePanel titlePanel = new TitlePanel("Visualizzazione Autori", this);
            titlePanel.Location = new Point(0, 0);
            this.Controls.Add(titlePanel);

            textAuthor.ReadOnly = true;
            textAuthor.Size = new System.Drawing.Size(this.Size.Width - 40, 150);
            textAuthor.Location = new Point(20, titlePanel.Location.X + titlePanel.Size.Height + 20);
            this.Controls.Add(textAuthor);

            buttonOk.Location = new Point((this.Size.Width / 2) - (buttonOk.Size.Width / 2), textAuthor.Location.Y + textAuthor.Size.Height + 15);
            this.Controls.Add(buttonOk);

            //tooltip
            toolTip1.SetToolTip(buttonOk, "Chiusura Finestra");

            displayElements();

        }

        private void displayElements()
        {
            foreach (AuthorModel model in globalObject.libraryObject.libraryInput.autori) {
                textAuthor.AppendText(DisplayUtility.formatAuthorName(model));
                textAuthor.AppendText(Environment.NewLine);
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            parent.closePanel(GlobalOperation.LIB_SHOW_AUTHOR);
        }
    }
}
