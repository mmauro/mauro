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
using VideoBookApplication.library.utility;

namespace VideoBookApplication.library.view
{
    public partial class ResumeAuthorPanel : Panel
    {

        private GlobalApplicationObject globalObject;
        private Panel parent;
        private LibraryActivityWindow frame;
        private GlobalOperation currentOperation;

        public ResumeAuthorPanel(ref GlobalApplicationObject globalObject, Panel parent, LibraryActivityWindow frame)
        {
            InitializeComponent();
            this.parent = parent;
            this.globalObject = globalObject;
            this.frame = frame;
            currentOperation = this.globalObject.currentOperation;
            initPanel();
        }

        private void initPanel()
        {
            if (globalObject.libraryObject.libraryInput.autore != null)
            {
                this.Size = new Size(parent.Size.Width, 70);
                this.BackColor = LayoutManager.getInnerPanelColor();

                labelTesto.Location = new Point(10, 20);
                this.Controls.Add(labelTesto);

                labelAutore.Text = DisplayUtility.formatAuthorName(globalObject.libraryObject.libraryInput.autore);
                labelAutore.Location = new Point(100, 20);
                this.Controls.Add(labelAutore);

                buttonBooks.Location = new Point(parent.Size.Width - (25 + buttonBooks.Size.Width), 10);
                this.Controls.Add(buttonBooks);
                buttonBooks.Visible = false;
                if (globalObject.libraryObject.libraryInput.autore.libri != null && globalObject.libraryObject.libraryInput.autore.libri.Count > 0)
                {
                    buttonBooks.Visible = true;
                }

                toolTip1.SetToolTip(buttonBooks, "Visualizzazione Libri");

            }
            else
            {
                DisplayManager.displayError(ApplicationErrorType.AUTHOR_NOT_FOUND);
            }

        }

        private void buttonBooks_Click(object sender, EventArgs e)
        {
            frame.closeOtherBooksPanel();
            switch (currentOperation) { 
                case GlobalOperation.LIB_NEW_BOOKS:
                    frame.openPanel(GlobalOperation.LIB_SHOW_BOOKS);
                    break;
                case GlobalOperation.LIB_DETAIL_BOOK_DELETE:
                    frame.openPanel(GlobalOperation.LIB_SHOW_BOOKS_DETAIL);
                    break;
                default:
                    DisplayManager.displayError(ApplicationErrorType.NOT_ALLOWED, currentOperation.ToString());
                    break;
            }
        }
    }
}
