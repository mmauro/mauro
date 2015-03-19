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
    public partial class SearchPositionPanel : Panel
    {
        private GlobalApplicationObject globalObject;
        private LibraryActivityWindow parent;
        private List<ItemCombo> listItemsCat = new List<ItemCombo>();
        private PositionModel defaultPos = null;
        private PositionControls posControl = new PositionControls();
        private LibraryControls libControl = new LibraryControls();
        private GlobalOperation currentOperation = GlobalOperation.UNDEFINED;

        public SearchPositionPanel(ref GlobalApplicationObject globalObject, LibraryActivityWindow parent)
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
            TitlePanel titlePanel = new TitlePanel("Ricerca Poaizione", this);
            titlePanel.Location = new Point(0, 0);
            this.Controls.Add(titlePanel);

            labelPos.Location = new Point(25, titlePanel.Location.Y + titlePanel.Size.Height + 10);
            this.Controls.Add(labelPos);

            comboPosition.Location = new Point(15, labelPos.Location.Y + 25);
            comboPosition.Size = new Size(this.Size.Width - 50, 27);
            foreach (ItemCombo ic in listItemsCat)
            {
                comboPosition.Items.Add(ic);
                comboPosition.SelectedIndex = 0;
            }
            this.Controls.Add(comboPosition);


            buttonClose.Location = new Point(this.Size.Width - (buttonOk.Size.Width + 25), comboPosition.Location.Y + 45);
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
                List<PositionModel> tmpPModel = posControl.getAllPosition(false);
                if (tmpPModel != null && tmpPModel.Count > 0)
                {
                    listItemsCat = new List<ItemCombo>();
                    foreach (PositionModel mc in tmpPModel)
                    {
                        listItemsCat.Add(new ItemCombo(mc.position, mc.idPosition));
                    }
                }

                //Ottengo categoria di default...
                defaultPos = posControl.read(Configurator.getInstsance().get("catpos.default.value"));
                if (defaultPos == null)
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
            switch (currentOperation) {
                case GlobalOperation.LIB_SEARCHPOS_DELETE:
                    ItemCombo posValue = (ItemCombo)comboPosition.SelectedItem;
                    ApplicationErrorType status = libControl.deletePosition(posValue.value, defaultPos.idPosition);
                    if (status == ApplicationErrorType.SUCCESS)
                    {
                        DisplayManager.displayMessage(ApplicationErrorType.SUCCESS, "Posizione Cancellata con Successo");
                        parent.closePanel();
                    }
                    else
                    {
                        DisplayManager.displayError(status);
                    }

                    break;
                default:
                    DisplayManager.displayError(ApplicationErrorType.NOT_ALLOWED);
                    break;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            parent.closePanel();
        }
    }
}
