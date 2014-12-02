using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        }
    }
}
