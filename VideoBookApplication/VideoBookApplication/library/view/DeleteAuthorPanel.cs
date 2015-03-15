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
    public partial class DeleteAuthorPanel : Panel
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private GlobalApplicationObject globalObject;
        private LibraryActivityWindow parent;
        private GlobalOperation currentOperation = GlobalOperation.UNDEFINED;
        private AuthorControls control = new AuthorControls();

        public DeleteAuthorPanel(ref GlobalApplicationObject globalObject, LibraryActivityWindow parent)
        {
            InitializeComponent();
            this.globalObject = globalObject;
            this.parent = parent;
            this.currentOperation = this.globalObject.currentOperation;
            initPanel();
        }

        private void initPanel()
        {

            this.BackColor = LayoutManager.getPanelColor();

            //Title
            TitlePanel titlePanel = new TitlePanel("Autore Da Cancellare", this);
            titlePanel.Location = new Point(0, 0);
            this.Controls.Add(titlePanel);

            //Labels
            labelCognome.Location = new Point(15, titlePanel.Location.X + titlePanel.Size.Height + 10);
            this.Controls.Add(labelCognome);

            labelNome.Location = new Point((this.Size.Width / 2) + 10, titlePanel.Location.X + titlePanel.Size.Height + 10);
            this.Controls.Add(labelNome);

            //text box
            textCognome.Location = new Point(labelCognome.Location.X, labelCognome.Location.Y + 30);
            textCognome.ReadOnly = isReadOnlyText();
            textCognome.Text = globalObject.libraryObject.libraryInput.autore.cognome;
            this.Controls.Add(textCognome);

            textNome.Location = new Point(labelNome.Location.X, labelNome.Location.Y + 30);
            textNome.ReadOnly = isReadOnlyText();
            textNome.Text = globalObject.libraryObject.libraryInput.autore.nome;
            this.Controls.Add(textNome);

            //Buttons
            buttonClose.Location = new Point(this.Width - (buttonClose.Size.Width + 25), textNome.Location.Y + 60);
            this.Controls.Add(buttonClose);

            buttonOk.Location = new Point(buttonClose.Location.X - (buttonOk.Size.Width + 20), textNome.Location.Y + 60);
            this.Controls.Add(buttonOk);

            //tooltip
            toolTip1.SetToolTip(buttonOk, "Cancella Autore");
            toolTip1.SetToolTip(buttonClose, "Annulla");

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            globalObject.libraryObject.destroy();
            parent.closePanel();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            switch (currentOperation)
            {
                case GlobalOperation.LIB_DELETE_AUTHOR:
                    deleteAutore();
                    break;
                default:
                    DisplayManager.displayError(ApplicationErrorType.NOT_ALLOWED, currentOperation.ToString());
                    break;
            }
        }


        private void deleteAutore()
        {
            LibraryControls controls = new LibraryControls();
            ApplicationErrorType status = controls.deleteAuthorAndBook(ref globalObject);
            if (status == ApplicationErrorType.SUCCESS)
            {
                DisplayManager.displayMessage(ApplicationErrorType.SUCCESS, "Cancellazione di Auore e Libri Riuscita");
                globalObject.libraryObject.destroy();
                parent.closePanel();
            }
            else
            {
                DisplayManager.displayError(status);
            }
        }

        private string getTitleLabel()
        {
            switch (currentOperation)
            {
                case GlobalOperation.LIB_DELETE_AUTHOR:
                    return "Autore da Cancellare";
                default:
                    return "";
            }
        }

        private bool isReadOnlyText()
        {
            switch (currentOperation)
            {
                case GlobalOperation.LIB_DELETE_AUTHOR:
                    return true;
                default:
                    return true;
            }
        }
    }
}
