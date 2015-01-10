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

namespace VideoBookApplication.library.view
{
    public partial class InfoBookPanel : Panel
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private GlobalApplicationObject globalObject;
        private LibraryActivityWindow parent;

        public InfoBookPanel(ref GlobalApplicationObject globalObject, LibraryActivityWindow parent)
        {
            InitializeComponent();
            this.globalObject = globalObject;
            this.parent = parent;
            initPanel();
        }

        private void initPanel()
        {

            int levensthein = 0;

            this.BackColor = LayoutManager.getPanelColor();

            //Title
            TitlePanel titlePanel = new TitlePanel("Informazioni Aggiuntive", this);
            titlePanel.Location = new Point(0, 0);
            this.Controls.Add(titlePanel);

            //Title Orig
            labelTitleOrig.Location = new Point(15, titlePanel.Location.Y + titlePanel.Size.Height + 15);
            this.Controls.Add(labelTitleOrig);

            if (globalObject.libraryObject.tempModel.infoModel.titleOrig != null)
            {
                textTitleOrig.Text = globalObject.libraryObject.tempModel.infoModel.titleOrig;
                levensthein = StringUtility.levenshteinDistance(globalObject.libraryObject.tempModel.infoModel.titleOrig.ToLower(), globalObject.libraryObject.tempModel.libro.titolo.ToLower());
                log.Info("TITLE DISTANCE = " + levensthein);
            }
            textTitleOrig.Location = new Point(labelTitleOrig.Location.X , labelTitleOrig.Location.Y + 20 );
            this.Controls.Add(textTitleOrig);

            buttonKeepTitle.Location = new Point(textTitleOrig.Location.X + textTitleOrig.Size.Width + 20, textTitleOrig.Location.Y - 2);
            this.Controls.Add(buttonKeepTitle);

            //Caricamento Immagine
            imageBox.SizeMode = PictureBoxSizeMode.Zoom;
            if (globalObject.libraryObject.tempModel.infoModel.image != null && !globalObject.libraryObject.tempModel.infoModel.image.Equals(""))
            {
                imageBox.Load(globalObject.libraryObject.tempModel.infoModel.image);
            }
            else
            {
                imageBox.Image = global::VideoBookApplication.Properties.Resources.no_image;
            }
            imageBox.Location = new Point(30, textTitleOrig.Location.Y + 70);
            this.Controls.Add(imageBox);

            //Editore e Anno
            labelEditore.Location = new Point(imageBox.Location.X + imageBox.Size.Width + 25, imageBox.Location.Y);
            this.Controls.Add(labelEditore);

            textPublisher.Location = new Point(labelEditore.Location.X, labelEditore.Location.Y + 20);
            if (globalObject.libraryObject.tempModel.infoModel.publisher != null)
            {
                textPublisher.Text = globalObject.libraryObject.tempModel.infoModel.publisher;
            }
            this.Controls.Add(textPublisher);

            labelYear.Location = new Point(labelEditore.Location.X + labelEditore.Size.Width + 180, labelEditore.Location.Y);
            this.Controls.Add(labelYear);

            textYear.Location = new Point(labelYear.Location.X, labelYear.Location.Y + 20);
            if (globalObject.libraryObject.tempModel.infoModel.year != null)
            {
                textYear.Text = globalObject.libraryObject.tempModel.infoModel.year;
            }
            this.Controls.Add(textYear);

            //ISBN
            labelIsbn.Location = new Point(labelEditore.Location.X, textPublisher.Location.Y + 60);
            this.Controls.Add(labelIsbn);

            textIsbn.Location = new Point(labelIsbn.Location.X, labelIsbn.Location.Y + 20);
            if (globalObject.libraryObject.tempModel.infoModel.isbn != null)
            {
                textIsbn.Text = globalObject.libraryObject.tempModel.infoModel.isbn;
            }
            this.Controls.Add(textIsbn);

            //trama
            labelTrama.Location = new Point(textIsbn.Location.X, textIsbn.Location.Y + 60);
            this.Controls.Add(labelTrama);

            textTrama.Location = new Point(labelTrama.Location.X, labelTrama.Location.Y + 20);
            if (globalObject.libraryObject.tempModel.infoModel.trama != null)
            {
                textTrama.Text = globalObject.libraryObject.tempModel.infoModel.trama;
            }
            this.Controls.Add(textTrama);

            //Pulsanti Finali
            buttonClose.Location = new Point(this.Size.Width - (35 + buttonClose.Size.Width), textTrama.Location.Y + textTrama.Size.Height + 50);
            this.Controls.Add(buttonClose);

            buttonOk.Location = new Point(buttonClose.Location.X - (buttonOk.Size.Width + 15), buttonClose.Location.Y);
            this.Controls.Add(buttonOk);

            //tooltip
            toolTip1.SetToolTip(buttonKeepTitle, "Utilizza Questo Titolo");
            toolTip1.SetToolTip(buttonOk, "Salva Informazioni Aggiuntive");
            toolTip1.SetToolTip(buttonClose, "Elimina Informazioni Aggiuntive");

            if (levensthein > Configurator.getInstsance().getInt("levensthein.max.distance"))
            {
                DisplayManager.displayWarning(ApplicationErrorType.TITLE_DIFFERENT_WARN);
            }

        }

        private void buttonKeepTitle_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            globalObject.libraryObject.tempModel.infoModel = null;
            parent.closePanel(GlobalOperation.LIB_INFOBOOK);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }
    }
}
