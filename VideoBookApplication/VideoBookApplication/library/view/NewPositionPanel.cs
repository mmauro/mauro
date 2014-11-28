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
using VideoBookApplication.common.model;
using VideoBookApplication.common.enums;
using VideoBookApplication.library.view;
using VideoBookApplication.common.controls;
using VideoBookApplication.common.view;
using VideoBookApplication.library.controls;

namespace VideoBookApplication.library.view
{
    public partial class NewPositionPanel : Panel
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private GlobalApplicationObject globalObject;
        private LibraryActivityWindow parent;

        private PositionControl control = new PositionControl();

        public NewPositionPanel(ref GlobalApplicationObject globalObject, LibraryActivityWindow parent)
        {
            InitializeComponent();
            this.globalObject = globalObject;
            this.parent = parent;
            initPanel();

        }

        private void initPanel()
        {

            this.BackColor = LayoutManager.getPanelColor();

            //Title
            TitlePanel titlePanel = new TitlePanel("Nuova Posizione", this);
            titlePanel.Location = new Point(0, 0);
            this.Controls.Add(titlePanel);

            //Labels
            labelPosition.Location = new Point(10, titlePanel.Size.Height + 15);
            this.Controls.Add(labelPosition);

            //TextBox
            textPosition.Location = new Point(95, labelPosition.Location.Y - 4);
            this.Controls.Add(textPosition);


            //Buttons
            buttonClose.Location = new Point(this.Size.Width - (20 + buttonClose.Size.Width), this.Size.Height - (20 + buttonClose.Size.Width));
            this.Controls.Add(buttonClose);

            buttonOk.Location = new Point(buttonClose.Location.X - (10 + buttonOk.Size.Width), buttonClose.Location.Y);
            this.Controls.Add(buttonOk);

            buttonShowPos.Location = new Point(20, buttonClose.Location.Y);
            this.Controls.Add(buttonShowPos);

            //Tooltip
            toolTip1.SetToolTip(buttonOk, "Inserisci Nuova Posizione");
            toolTip1.SetToolTip(buttonClose, "Annulla");
            toolTip1.SetToolTip(buttonShowPos, "Visualizza Posizioni Esistenti");


        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            closePanel();
        }

        private void closePanel()
        {
            parent.closePanel(GlobalOperation.LIB_NEW_POSITION);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            ApplicationErrorType status = control.write(textPosition.Text);
            if (status != ApplicationErrorType.SUCCESS)
            {
                DisplayManager.displayError(status);
            }
            else
            {
                log.Info("Position Write With Success");
                closePanel();
            }
        }

        private void buttonShowPos_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }
    }
}
