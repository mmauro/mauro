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


namespace VideoBookApplication.common.view
{
    public partial class DeleteMenuLibrary : Panel
    {
        private LibraryActivityWindow parent;

        private static int numButton = 4;
        private GlobalApplicationObject globalObject;

        public DeleteMenuLibrary(ref GlobalApplicationObject globalObject,  LibraryActivityWindow parent)
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
            buttonDelAuthor.Location = new Point(5, 5);
            this.Controls.Add(buttonDelAuthor);

            //Button delete
            buttonDelBook.Location = new Point(5, buttonDelAuthor.Location.Y + buttonDelAuthor.Size.Height + 5);
            this.Controls.Add(buttonDelBook);

            //Button Modify
            buttonDelCategory.Location = new Point(5, buttonDelBook.Location.Y + buttonDelBook.Size.Height + 5);
            this.Controls.Add(buttonDelCategory);

            //Button Search
            buttonDelPosition.Location = new Point(5, buttonDelCategory.Location.Y + buttonDelCategory.Size.Height + 5);
            this.Controls.Add(buttonDelPosition);

            //toolTip
            toolTip1.SetToolTip(buttonDelBook, "Cancella Libri");
            toolTip1.SetToolTip(buttonDelAuthor, "Cancella Autore");
            toolTip1.SetToolTip(buttonDelPosition, "Cancella Posizione");
            toolTip1.SetToolTip(buttonDelCategory, "Cancella Categoria");
        }

        private void buttonDelAuthor_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        private void buttonDelBook_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        private void buttonDelCategory_Click(object sender, EventArgs e)
        {
            parent.closePanel();
            parent.openPanel(GlobalOperation.LIB_SEARCHCAT_DELETE);
        }

        private void buttonDelPosition_Click(object sender, EventArgs e)
        {
            parent.closePanel();
            parent.openPanel(GlobalOperation.LIB_SEARCHPOS_DELETE);
        }
    }
}
