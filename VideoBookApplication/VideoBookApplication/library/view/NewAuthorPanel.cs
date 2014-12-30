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

namespace VideoBookApplication.library.view
{
    public partial class NewAuthorPanel : Panel
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private GlobalApplicationObject globalObject;
        private LibraryActivityWindow parent;
        private AuthorControls control = new AuthorControls();

        public NewAuthorPanel(ref GlobalApplicationObject globalObject, LibraryActivityWindow parent)
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
            TitlePanel titlePanel = new TitlePanel("Nuovo Autore", this);
            titlePanel.Location = new Point(0, 0);
            this.Controls.Add(titlePanel);

            //Labels
            labelCognome.Location = new Point(15, titlePanel.Location.X + titlePanel.Size.Height + 10);
            this.Controls.Add(labelCognome);

            labelNome.Location = new Point((this.Size.Width / 2) + 10, titlePanel.Location.X + titlePanel.Size.Height + 10);
            this.Controls.Add(labelNome);

            //text box
            textCognome.Location = new Point(labelCognome.Location.X, labelCognome.Location.Y + 30);
            this.Controls.Add(textCognome);

            textNome.Location = new Point(labelNome.Location.X, labelNome.Location.Y + 30);
            this.Controls.Add(textNome);

            //Buttons
            buttonClose.Location = new Point(this.Width - (buttonClose.Size.Width + 25), textNome.Location.Y + 60);
            this.Controls.Add(buttonClose);

            buttonOk.Location = new Point(buttonClose.Location.X - (buttonOk.Size.Width + 20), textNome.Location.Y + 60);
            this.Controls.Add(buttonOk);

            buttonCheck.Location = new Point(15, textNome.Location.Y + 60);
            this.Controls.Add(buttonCheck);

            //tooltip
            toolTip1.SetToolTip(buttonOk, "Salva Autore");
            toolTip1.SetToolTip(buttonClose, "Annulla");
            toolTip1.SetToolTip(buttonCheck, "Controlla Autore");
            


        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            parent.closePanel();
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            bool openBookPanel = false;
            ApplicationErrorType status = control.addNewAuthor(textNome.Text, textCognome.Text, ref globalObject);
            if (status == ApplicationErrorType.SUCCESS)
            {
                openBookPanel = true;
            }
            else if (status.code > ApplicationErrorType.NOT_INIT_WARN.code)
            {
                //Gestione Warning
                log.Warn(String.Format("WARN: {0} - {1}", status.code, status.message));
                DialogResult choose = MessageBox.Show(String.Format("Code: {0}" + Environment.NewLine + "Si Desidera Inserire il Nuovo Autore", status.message ), "WARNING", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (choose == DialogResult.Yes)
                {
                    openBookPanel = true;
                }
                else
                {
                    globalObject.libraryObject.libraryInput.autore = null;
                }
            }
            else
            {
                //Visualizzazione Errore
                DisplayManager.displayError(status);
            }

            if (openBookPanel)
            {
                //TODO: Apertura Pannello Aggiunta Libri
                parent.closePanel();
            }
            
        }
    }
}
