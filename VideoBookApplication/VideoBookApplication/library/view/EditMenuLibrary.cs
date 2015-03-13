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
    public partial class EditMenuLibrary : Panel
    {
        private LibraryActivityWindow parent;

        private static int numButton = 4;
        private GlobalApplicationObject globalObject;

        public EditMenuLibrary(ref GlobalApplicationObject globalObject, LibraryActivityWindow parent)
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
            buttonModifyAuthor.Location = new Point(5, 5);
            this.Controls.Add(buttonModifyAuthor);

            //Button delete
            buttonModifyBook.Location = new Point(5, buttonModifyAuthor.Location.Y + buttonModifyAuthor.Size.Height + 5);
            this.Controls.Add(buttonModifyBook);

            //Button Modify
            buttonModifyCategory.Location = new Point(5, buttonModifyBook.Location.Y + buttonModifyBook.Size.Height + 5);
            this.Controls.Add(buttonModifyCategory);

            //Button Search
            buttonModifyPosition.Location = new Point(5, buttonModifyCategory.Location.Y + buttonModifyCategory.Size.Height + 5);
            this.Controls.Add(buttonModifyPosition);

            //toolTip
            toolTip1.SetToolTip(buttonModifyBook, "Modifica Libri");
            toolTip1.SetToolTip(buttonModifyAuthor, "Modifica Autore");
            toolTip1.SetToolTip(buttonModifyPosition, "Modifica Posizione");
            toolTip1.SetToolTip(buttonModifyCategory, "Modifica Categoria");
        }

        private void buttonModifyPosition_Click(object sender, EventArgs e)
        {
            parent.closePanel();
            parent.openPanel(GlobalOperation.LIB_EDIT_POS);
        }

        private void buttonModifyCategory_Click(object sender, EventArgs e)
        {
            parent.closePanel();
            parent.openPanel(GlobalOperation.LIB_EDIT_CAT);
        }

        private void buttonModifyAuthor_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        private void buttonModifyBook_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }
    }
}
