﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoBookApplication.common.model;
using VideoBookApplication.common.utility;
using VideoBookApplication.common.view;
using VideoBookApplication.common.enums;
using VideoBookApplication.library.controls;

namespace VideoBookApplication.library.view
{
    public partial class StatGraphPanel : Panel
    {

        private GlobalApplicationObject globalObject;
        private LibraryActivityWindow parent;
        private StatControls control = new StatControls();

        public StatGraphPanel(ref GlobalApplicationObject globalObject, LibraryActivityWindow parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.globalObject = globalObject;
            ApplicationErrorType status = control.getCategoryCount(ref this.globalObject);
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
            TitlePanel titlePanel = new TitlePanel("Grafici Statistiche", this);
            titlePanel.Location = new Point(0, 0);
            this.Controls.Add(titlePanel);

            groupBox1.Size = new Size((this.Size.Width / 3) - 10, this.Size.Height - 150);
            groupBox1.Location = new Point(5, titlePanel.Location.Y + titlePanel.Size.Height + 5);
            groupBox1.BackColor = LayoutManager.getPanelColor2();
            this.Controls.Add(groupBox1);

            groupBox2.Size = new Size((this.Size.Width / 3) - 10, this.Size.Height - 150);
            groupBox2.Location = new Point(groupBox1.Location.X + 10 + groupBox1.Size.Width, groupBox1.Location.Y);
            groupBox2.BackColor = LayoutManager.getPanelColor2();
            this.Controls.Add(groupBox2);

            groupBox3.Size = new Size((this.Size.Width / 3) - 10, this.Size.Height - 150);
            groupBox3.Location = new Point(groupBox2.Location.X + 10 + groupBox2.Size.Width, groupBox2.Location.Y);
            groupBox3.BackColor = LayoutManager.getPanelColor2();
            this.Controls.Add(groupBox3);

            //Gestione pulsanti
            buttonOk.Location = new Point(this.Size.Width - (20 + buttonOk.Size.Height), groupBox3.Location.Y + groupBox3.Size.Height + 10);
            this.Controls.Add(buttonOk);

            if (globalObject.libraryObject.statistiche.categoryDistribution != null && globalObject.libraryObject.statistiche.categoryDistribution.Count > 0)
            {
                
            }

            //Disegno pie chart con numero libri carta / numero libri ebook
            if (globalObject.libraryObject.statistiche.numLibri > 0)
            {
            }

        }

        private void displayPieChartBooksNumber()
        {
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            parent.closePanel(GlobalOperation.LIB_STATS_GRAPH);
        }
    }
}