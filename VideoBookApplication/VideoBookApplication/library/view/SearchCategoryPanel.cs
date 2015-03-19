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
using VideoBookApplication.library.controls;
using VideoBookApplication.common.view;
using VideoBookApplication.common.utility;
using VideoBookApplication.common.enums;
using VideoBookApplication.library.model.database;

namespace VideoBookApplication.library.view
{
    public partial class SearchCategoryPanel : Panel
    {
        private GlobalApplicationObject globalObject;
        private LibraryActivityWindow parent;
        private List<ItemCombo> listItemsCat = new List<ItemCombo>();
        private CategoryModel defaultCategory = null;
        private CategoryControls catControl = new CategoryControls();
        private LibraryControls libControl = new LibraryControls();
        private GlobalOperation currentOperation = GlobalOperation.UNDEFINED;

        public SearchCategoryPanel(ref GlobalApplicationObject globalObject, LibraryActivityWindow parent)
        {
            InitializeComponent();
            this.globalObject = globalObject;
            this.parent = parent;
            this.currentOperation = this.globalObject.currentOperation;
            ApplicationErrorType status = refreshData();
            if (status == ApplicationErrorType.SUCCESS)
            {
                initPanel();
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
            TitlePanel titlePanel = new TitlePanel("Ricerca Categoria", this);
            titlePanel.Location = new Point(0, 0);
            this.Controls.Add(titlePanel);

            labelCategory.Location = new Point(25, titlePanel.Location.Y + titlePanel.Size.Height + 10);
            this.Controls.Add(labelCategory);

            comboCategory.Location = new Point(15, labelCategory.Location.Y + 25);
            comboCategory.Size = new Size(this.Size.Width - 50, 27);
            foreach (ItemCombo ic in listItemsCat)
            {
                comboCategory.Items.Add(ic);
                comboCategory.SelectedIndex = 0;
            }
            this.Controls.Add(comboCategory);

            buttonClose.Location = new Point(this.Size.Width - (buttonOk.Size.Width + 25), comboCategory.Location.Y + 45);
            this.Controls.Add(buttonClose);

            buttonOk.Location = new Point(buttonClose.Location.X - (buttonOk.Size.Width + 10), buttonClose.Location.Y);
            this.Controls.Add(buttonOk);

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

                //Ottengo categoria di default...
                defaultCategory = catControl.read(Configurator.getInstsance().get("catpos.default.value"));
                if (defaultCategory == null)
                {
                    status = ApplicationErrorType.EMPTY_CATEGORY;
                }

            }
            catch (VideoBookException e)
            {
                status = e.errorType;
            }

            return status;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;
            switch (currentOperation)
            {
                case GlobalOperation.LIB_SEARCHCAT_DELETE:
                    ItemCombo catValue = (ItemCombo)comboCategory.SelectedItem;
                    status = libControl.deleteCategory(catValue.value, defaultCategory.idCategory);
                    if (status == ApplicationErrorType.SUCCESS)
                    {
                        DisplayManager.displayMessage(ApplicationErrorType.SUCCESS, "Categoria Cancellata con Successo");
                        parent.closePanel();
                    }
                    else
                    {
                        DisplayManager.displayError(status);
                    }

                    break;
                default:
                    DisplayManager.displayError(ApplicationErrorType.NOT_ALLOWED, currentOperation.ToString());
                    break;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            parent.closePanel();
        }
    }
}
