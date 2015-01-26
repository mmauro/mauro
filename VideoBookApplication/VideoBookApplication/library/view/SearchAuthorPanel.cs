﻿using System;
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
    public partial class SearchAuthorPanel : Panel
    {

        private GlobalApplicationObject globalObject;
        private LibraryActivityWindow parent;
        private AuthorControls control = new AuthorControls();

        public SearchAuthorPanel(ref GlobalApplicationObject globalObject, LibraryActivityWindow parent)
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
            TitlePanel titlePanel = new TitlePanel("Ricerca Autore", this);
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

            buttonSearch.Location = new Point(buttonClose.Location.X - (buttonSearch.Size.Width + 20), textNome.Location.Y + 60);
            this.Controls.Add(buttonSearch);

            //tooltip
            toolTip1.SetToolTip(buttonSearch, "Salva Autore");
            toolTip1.SetToolTip(buttonClose, "Annulla");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            parent.closePanel();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }

    }
}
