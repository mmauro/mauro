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
using VideoBookApplication.common.utility;
using VideoBookApplication.common.view;
using VideoBookApplication.common.enums;
using VideoBookApplication.library.model.database;
using VideoBookApplication.library.controls;

namespace VideoBookApplication.library.view
{
    public partial class EditCategoryPanel : Panel
    {

        private LibraryActivityWindow parent;
        private GlobalApplicationObject globalObject;

        private List<ItemCombo> listItemsCat = new List<ItemCombo>();
        private CategoryControls catControl = new CategoryControls();

        public EditCategoryPanel(ref GlobalApplicationObject globalObject, LibraryActivityWindow parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.globalObject = globalObject;
            ApplicationErrorType status = refreshData();
            if (status == ApplicationErrorType.SUCCESS)
            {
                if (listItemsCat.Count > 0)
                {
                    initPanel();
                }
                else
                {
                    DisplayManager.displayWarning(ApplicationErrorType.NO_CATEGORY_WARN);
                }
            }
            else
            {
                DisplayManager.displayError(status);
            }
        }

        private void initPanel()
        {

            this.BackColor = LayoutManager.getPanelColor();

            //Title
            TitlePanel titlePanel = new TitlePanel("Modifica Categoria", this);
            titlePanel.Location = new Point(0, 0);
            this.Controls.Add(titlePanel);

            //Labels
            labelCategory.Location = new Point(30, titlePanel.Size.Height + 15);
            this.Controls.Add(labelCategory);

            //combo category
            comboCategory.Location = new Point(labelCategory.Location.X, labelCategory.Location.Y + 25);
            foreach (ItemCombo ic in listItemsCat)
            {
                comboCategory.Items.Add(ic);
                comboCategory.SelectedIndex = 0;
            }
            this.Controls.Add(comboCategory);


            //text category
            labelNewCat.Location = new Point(comboCategory.Location.X, comboCategory.Location.Y + 50);
            this.Controls.Add(labelNewCat);

            textCategory.Location = new Point(comboCategory.Location.X, labelNewCat.Location.Y + 25);
            textCategory.Text = comboCategory.Text;
            this.Controls.Add(textCategory);

            //pulsanti
            buttonClose.Location = new Point(this.Size.Width - (15 + buttonClose.Size.Width), textCategory.Location.Y + 60);
            this.Controls.Add(buttonClose);

            buttonOk.Location = new Point(buttonClose.Location.X - (10 + buttonOk.Size.Width), buttonClose.Location.Y);
            this.Controls.Add(buttonOk);

            toolTip1.SetToolTip(buttonClose, "Annulla");
            toolTip1.SetToolTip(buttonOk, "Modifica Categoria");

        }

        private ApplicationErrorType refreshData()
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;

            try
            {
                //Ottengo Elenco delle categorie...
                List<CategoryModel> tmpCModel = catControl.getAllCategory(false);
                if (tmpCModel != null && tmpCModel.Count > 0)
                {
                    listItemsCat = new List<ItemCombo>();
                    foreach (CategoryModel mc in tmpCModel)
                    {
                        listItemsCat.Add(new ItemCombo(mc.category, mc.idCategory));
                    }
                }
            }
            catch (VideoBookException e)
            {
                status = e.errorType;
            }

            return status;
        }

        private void comboCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            textCategory.Text = comboCategory.Text;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            parent.closePanel();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }
    }
}
