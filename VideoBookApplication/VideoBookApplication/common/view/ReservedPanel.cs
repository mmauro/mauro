﻿using System;
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

namespace VideoBookApplication.common.view
{
    public partial class ReservedPanel : Panel
    {

        private GlobalApplicationObject globalObject;
        private Form parent;

        public ReservedPanel(ref GlobalApplicationObject globalObject, Form parent)
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
            TitlePanel titlePanel = new TitlePanel("Parole Riservate", this);
            titlePanel.Location = new Point(0, 0);
            this.Controls.Add(titlePanel);

            //Labels
            labelReserved.Location = new Point(10, titlePanel.Size.Height + 15);
            this.Controls.Add(labelReserved);

            labelType.Location = new Point(10, labelReserved.Location.Y + 50);
            this.Controls.Add(labelType);

            //TextBox
            textReserved.Location = new Point(95, labelReserved.Location.Y - 4);
            this.Controls.Add(textReserved);

            //ComboBox
            comboTypeReserved.Location = new Point(95, labelType.Location.Y - 4);
            this.Controls.Add(comboTypeReserved);

            //Buttons
            buttonClose.Location = new Point(this.Size.Width - (20 + buttonClose.Size.Width), this.Size.Height - (20 + buttonClose.Size.Width));
            this.Controls.Add(buttonClose);

            buttonOk.Location = new Point(buttonClose.Location.X - (10 + buttonOk.Size.Width), buttonClose.Location.Y);
            this.Controls.Add(buttonOk);

            //Tooltip
            toolTip1.SetToolTip(buttonOk, "Inserisci Rieservata");
            toolTip1.SetToolTip(buttonClose, "Annulla");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            switch (globalObject.activity)
            {
                case ActivityType.LIBRARY:
                    LibraryActivityWindow law = (LibraryActivityWindow)parent;
                    law.closePanel(GlobalOperation.RESERVED);
                    break;
                default:
                    DisplayManager.displayError(ApplicationErrorType.NOT_ALLOWED);
                    break;
            }

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
        }
    }
}
