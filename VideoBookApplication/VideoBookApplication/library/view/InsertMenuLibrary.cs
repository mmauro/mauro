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
    public partial class InsertMenuLibrary : Panel
    {
        private LibraryActivityWindow parent;

        private static int numButton = 4;
        private GlobalApplicationObject globalObject;

        public InsertMenuLibrary(ref GlobalApplicationObject globalObject,  LibraryActivityWindow parent)
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
            buttonAddAuthor.Location = new Point(5, 5);
            this.Controls.Add(buttonAddAuthor);

            //Button delete
            buttonAddBook.Location = new Point(5, buttonAddAuthor.Location.Y + buttonAddAuthor.Size.Height + 5);
            this.Controls.Add(buttonAddBook);

            //Button Modify
            buttonAddCategory.Location = new Point(5, buttonAddBook.Location.Y + buttonAddBook.Size.Height + 5);
            this.Controls.Add(buttonAddCategory);

            //Button Search
            buttonAddPosition.Location = new Point(5, buttonAddCategory.Location.Y + buttonAddCategory.Size.Height + 5);
            this.Controls.Add(buttonAddPosition);

            //toolTip
            toolTip1.SetToolTip(buttonAddBook, "Nuovi Libri");
            toolTip1.SetToolTip(buttonAddAuthor, "Nuovo Autore");
            toolTip1.SetToolTip(buttonAddPosition, "Nuova Posizione");
            toolTip1.SetToolTip(buttonAddCategory, "Nuova Categoria");
        }

        private void buttonAddAuthor_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        private void buttonAddBook_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        private void buttonAddCategory_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        private void buttonAddPosition_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }
    }
}
