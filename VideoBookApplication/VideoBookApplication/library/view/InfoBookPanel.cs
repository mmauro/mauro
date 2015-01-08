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

namespace VideoBookApplication.library.view
{
    public partial class InfoBookPanel : Panel
    {

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
                //Calcolare distanza di Levensthein
            }
            textTitleOrig.Location = new Point(labelTitleOrig.Location.X + labelTitleOrig.Size.Width + 20, labelTitleOrig.Location.Y - 2 );
            this.Controls.Add(textTitleOrig);


        }
    }
}
