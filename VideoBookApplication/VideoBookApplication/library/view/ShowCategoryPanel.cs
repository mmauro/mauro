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
using VideoBookApplication.library.controls;
using VideoBookApplication.library.model.database;

namespace VideoBookApplication.library.view
{
    public partial class ShowCategoryPanel : Panel
    {
        private GlobalApplicationObject globalObject;
        private LibraryActivityWindow parent;
        private List<CategoryModel> listElements = null;

        public ShowCategoryPanel(ref GlobalApplicationObject globalObject, LibraryActivityWindow parent)
        {
            InitializeComponent();
            this.globalObject = globalObject;
            this.parent = parent;


            try
            {
                CategoryControls cc = new CategoryControls();
                listElements = cc.getAllCategory(false);
                initPanel();
            }
            catch (VideoBookException e)
            {
                DisplayManager.displayError(e.errorType);
            }
        }

        private void initPanel()
        {
            this.BackColor = LayoutManager.getPanelColor();
            TitlePanel titlePanel = new TitlePanel("Visualizzazione Categorie", this);
            titlePanel.Location = new Point(0, 0);
            this.Controls.Add(titlePanel);

            textCategory.ReadOnly = true;
            textCategory.Size = new System.Drawing.Size(this.Size.Width - 40, 150);
            textCategory.Location = new Point(20, titlePanel.Location.X + titlePanel.Size.Height + 20);
            this.Controls.Add(textCategory);

            buttonOk.Location = new Point((this.Size.Width / 2) - (buttonOk.Size.Width / 2), textCategory.Location.Y + textCategory.Size.Height + 15);
            this.Controls.Add(buttonOk);

            displayElements();

            toolTip1.SetToolTip(buttonOk, "Chiusura Finestra");

        }

        private void displayElements()
        {
            string value = "";
            if (listElements != null && listElements.Count > 0)
            {
                foreach (CategoryModel model in listElements)
                {
                    value += model.category + Environment.NewLine;
                }
            }
            else
            {
                value = "Nessuna Categoria Presente";
            }
            textCategory.Text = value;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            parent.closePanel(GlobalOperation.LIB_SHOW_CAT);
        }
    }
}
