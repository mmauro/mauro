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
    public partial class SearchMenuLibrary : Panel
    {
        private LibraryActivityWindow parent;

        private static int numButton = 5;
        private GlobalApplicationObject globalObject;

        public SearchMenuLibrary(ref GlobalApplicationObject globalObject, LibraryActivityWindow parent)
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
            buttonSearchAuthor.Location = new Point(5, 5);
            this.Controls.Add(buttonSearchAuthor);

            //Button delete
            buttonSearchBook.Location = new Point(5, buttonSearchAuthor.Location.Y + buttonSearchAuthor.Size.Height + 5);
            this.Controls.Add(buttonSearchBook);

            //Button Modify
            buttonSearchCategory.Location = new Point(5, buttonSearchBook.Location.Y + buttonSearchBook.Size.Height + 5);
            this.Controls.Add(buttonSearchCategory);

            //Button Search
            buttonSearchPosition.Location = new Point(5, buttonSearchCategory.Location.Y + buttonSearchCategory.Size.Height + 5);
            this.Controls.Add(buttonSearchPosition);

            //Button Generic Search
            buttonGenericSearch.Location = new Point(5, buttonSearchPosition.Location.Y + buttonSearchPosition.Size.Height + 5);
            this.Controls.Add(buttonGenericSearch);

            //toolTip
            toolTip1.SetToolTip(buttonSearchBook, "Ricerca Libri");
            toolTip1.SetToolTip(buttonSearchAuthor, "Ricerca Autore");
            toolTip1.SetToolTip(buttonSearchPosition, "Ricerca Posizione");
            toolTip1.SetToolTip(buttonSearchCategory, "Ricerca Categoria");
            toolTip1.SetToolTip(buttonGenericSearch, "Ricerca Generica");
        }

        private void buttonSearchBook_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        private void buttonSearchAuthor_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        private void buttonSearchPosition_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        private void buttonSearchCategory_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        private void buttonGenericSearch_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }
    }
}
