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
    public partial class ShowPositionPanel : Panel
    {
        private GlobalApplicationObject globalObject;
        private LibraryActivityWindow parent;
        private List<PositionModel> listElements = null;
        public ShowPositionPanel(ref GlobalApplicationObject globalObject, LibraryActivityWindow parent)
        {
            InitializeComponent();
            this.globalObject = globalObject;
            this.parent = parent;

            try
            {
                PositionControls pc = new PositionControls();
                listElements = pc.getAllPosition(false);
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
            TitlePanel titlePanel = new TitlePanel("Visualizzazione Posizioni", this);
            titlePanel.Location = new Point(0, 0);
            this.Controls.Add(titlePanel);

            textPosition.ReadOnly = true;
            textPosition.Size = new System.Drawing.Size(this.Size.Width - 40, 150);
            textPosition.Location = new Point(20, titlePanel.Location.X + titlePanel.Size.Height + 20);
            this.Controls.Add(textPosition);

            buttonOk.Location = new Point((this.Size.Width / 2) - (buttonOk.Size.Width / 2), textPosition.Location.Y + textPosition.Size.Height + 15);
            this.Controls.Add(buttonOk);

            displayElements();

            toolTip1.SetToolTip(buttonOk, "Chiusura Finestra");
        }

        private void displayElements()
        {
            string value = "";
            if (listElements != null && listElements.Count > 0)
            {
                foreach (PositionModel model in listElements)
                {
                    value += model.position + Environment.NewLine;
                }
            }
            else
            {
                value = "Nessuna Categoria Presente";
            }
            textPosition.Text = value;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            parent.closePanel(GlobalOperation.LIB_SHOW_POS);
        }
    }
}
