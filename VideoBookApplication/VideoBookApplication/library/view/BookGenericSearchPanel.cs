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
using VideoBookApplication.library.model.database;
using VideoBookApplication.library.controls;

namespace VideoBookApplication.library.view
{
    public partial class BookGenericSearchPanel : Panel
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private GlobalApplicationObject globalObject;
        private LibraryActivityWindow parent;
        private GlobalOperation currentOperation;
        private List<ItemCombo> listItemsCat = new List<ItemCombo>();
        private List<ItemCombo> listItemsPos = new List<ItemCombo>();
        private CategoryControls catControl = new CategoryControls();
        private PositionControls posControl = new PositionControls();
        private BooksControls bookControl = new BooksControls();

        private TabPage searchAuthorTab;
        private TabPage searchTitleTab;
        private TabPage searchCategoryTab;
        private TabPage searchPosTab;

        public BookGenericSearchPanel(ref GlobalApplicationObject globalObject, LibraryActivityWindow parent)
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

            Control[] tabControls = new Control[4];
            int iControl = 0;

            //Title
            TitlePanel titlePanel = new TitlePanel("Ricerca Libro", this);
            titlePanel.Location = new Point(0, 0);
            this.Controls.Add(titlePanel);

            //container
            containerPanel.Size = new Size(this.Size.Width, this.Size.Height - (titlePanel.Size.Height + 100));
            containerPanel.Location = new Point(0, titlePanel.Size.Height + titlePanel.Location.Y);
            containerPanel.BackColor = LayoutManager.getPanelColor();
            this.Controls.Add(containerPanel);

            //Tab Pages
            searchAuthorTab = new TabPage("Ricerca Per Autore");
            searchAuthorTab.Size = containerPanel.Size;
            searchAuthorTab.BackColor = LayoutManager.getPanelColor2();
            labelCognome.Location = new Point(30, 50);
            searchAuthorTab.Controls.Add(labelCognome);
            textCognome.Location = new Point(30, labelCognome.Location.Y + 25);
            searchAuthorTab.Controls.Add(textCognome);
            labelNome.Location = new Point(textCognome.Location.X + textCognome.Size.Width + 20, labelCognome.Location.Y);
            searchAuthorTab.Controls.Add(labelNome);
            textNome.Location = new Point(labelNome.Location.X, labelNome.Location.Y + 25);
            searchAuthorTab.Controls.Add(textNome);
            tabControls[iControl] = searchAuthorTab;
            iControl++;


            searchTitleTab = new TabPage("Ricerca per Titolo");
            searchTitleTab.Size = containerPanel.Size;
            searchTitleTab.BackColor = LayoutManager.getPanelColor2();
            labelTitle.Location = new Point(50, 50);
            searchTitleTab.Controls.Add(labelTitle);
            textTitle.Location = new Point(50, labelTitle.Location.Y + 25);
            searchTitleTab.Controls.Add(textTitle);
            tabControls[iControl] = searchTitleTab;
            iControl++;


            searchCategoryTab = new TabPage("Ricerca per Categoria");
            searchCategoryTab.Size = containerPanel.Size;
            labelCategory.Location = new Point(50, 50);
            searchCategoryTab.Controls.Add(labelCategory);
            comboCategory.Location = new Point(50, labelCategory.Location.Y + 25);
            searchCategoryTab.Controls.Add(comboCategory);
            searchCategoryTab.BackColor = LayoutManager.getPanelColor2();

            if (refreshDataCategory() == ApplicationErrorType.SUCCESS)
            {
                tabControls[iControl] = searchCategoryTab;
                iControl++;
            }
            else
            {
                log.Error("Category Tab Disabled");
            }

            searchPosTab = new TabPage("Ricerca per Posizione");
            searchPosTab.Size = containerPanel.Size;
            searchPosTab.BackColor = LayoutManager.getPanelColor2();
            labelPosition.Location = new Point(50, 50);
            searchPosTab.Controls.Add(labelPosition);
            comboPosition.Location = new Point(50, labelPosition.Location.Y + 25);
            searchPosTab.Controls.Add(comboPosition);
            if (refreshDataPosition() == ApplicationErrorType.SUCCESS)
            {
                tabControls[iControl] = searchPosTab;
                iControl++;
            }
            else
            {
                log.Error("Position Tab Disabled");
            }

            //Tab Control
            tabSearchControl.Location = new Point(0, 0);
            tabSearchControl.Size = containerPanel.Size;
            tabSearchControl.Controls.AddRange(tabControls);
            containerPanel.Controls.Add(tabSearchControl);


            //buttons
            buttonClose.Location = new Point(this.Size.Width - (25 + buttonOk.Size.Width), containerPanel.Location.Y + containerPanel.Size.Height + 20);
            this.Controls.Add(buttonClose);

            buttonOk.Location = new Point(buttonClose.Location.X - (10 + buttonOk.Size.Width), buttonClose.Location.Y);
            this.Controls.Add(buttonOk);

            toolTip1.SetToolTip(buttonClose, "Chiusura Finestra");
            toolTip1.SetToolTip(buttonOk, "");

            setImageButton();


        }


        private ApplicationErrorType refreshDataCategory()
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;

            try
            {
                //Ottengo Elenco delle categorie...
                List<CategoryModel> tmpCModel = catControl.getAllCategory(true);
                if (tmpCModel != null && tmpCModel.Count > 0)
                {
                    listItemsCat = new List<ItemCombo>();
                    foreach (CategoryModel mc in tmpCModel)
                    {
                        listItemsCat.Add(new ItemCombo(mc.category, mc.idCategory));
                    }
                }
                foreach (ItemCombo ic in listItemsCat)
                {
                    comboCategory.Items.Add(ic);
                    comboCategory.SelectedIndex = 0;
                }

            }
            catch (VideoBookException e)
            {
                log.Error(e.errorType.ToString());
                status = e.errorType;
            }

            return status;
        }

        private ApplicationErrorType refreshDataPosition()
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;

            try
            {
                //Ottengo Elenco delle categorie...
                List<PositionModel> tmpCModel = posControl.getAllPosition(true);
                if (tmpCModel != null && tmpCModel.Count > 0)
                {
                    listItemsPos = new List<ItemCombo>();
                    foreach (PositionModel mp in tmpCModel)
                    {
                        listItemsPos.Add(new ItemCombo(mp.position, mp.idPosition));
                    }
                }
                foreach (ItemCombo ic in listItemsPos)
                {
                    comboPosition.Items.Add(ic);
                    comboPosition.SelectedIndex = 0;
                }

            }
            catch (VideoBookException e)
            {
                log.Error(e.errorType.ToString());
                status = e.errorType;
            }

            return status;
        }


        private void buttonClose_Click(object sender, EventArgs e)
        {
            globalObject.libraryObject.destroy();
            parent.closePanel();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            globalObject.libraryObject.libraryInput.destroy();
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;
            TabPage currentTab = tabSearchControl.SelectedTab;
            if (currentTab == searchAuthorTab)
            {
                log.Info("Search By Author");
                status = bookControl.getBookByAuthor(ref globalObject, textCognome.Text, textNome.Text);
            }
            else if (currentTab == searchTitleTab)
            {
                log.Info("Search By Title");
                status = bookControl.getBookByTitle(ref globalObject, textTitle.Text);
            }
            else if (currentTab == searchCategoryTab)
            {
                log.Info("search By Category");
                ItemCombo catValue = (ItemCombo)comboCategory.SelectedItem;
                status = bookControl.getBookByCategory(ref globalObject, catValue.value);
            }
            else if (currentTab == searchPosTab)
            {
                log.Info("search By Position");
                ItemCombo posValue = (ItemCombo)comboPosition.SelectedItem;
                status = bookControl.getBookByPosition(ref globalObject, posValue.value);
            }
            else
            {
                status = ApplicationErrorType.INVALID_TAB;
            }

            if (status == ApplicationErrorType.SUCCESS)
            {
                switch (currentOperation)
                {
                    case GlobalOperation.LIB_SEARCHBOOK_DELETE:
                        operationDelete();
                        break;
                    case GlobalOperation.LIB_SEARCHBOOK_EDIT:
                        operationEdit();
                        break;
                    default:
                        DisplayManager.displayError(ApplicationErrorType.NOT_ALLOWED, currentOperation.ToString());
                        break;
                }
            }
            else
            {
                DisplayManager.displayError(status);
            }
        }

        private void setImageButton()
        {

            switch (currentOperation) {
                case GlobalOperation.LIB_SEARCHBOOK_DELETE:
                    this.buttonOk.BackgroundImage = global::VideoBookApplication.Properties.Resources.eraser;
                    toolTip1.SetToolTip(buttonOk, "Cancella Libro");
                    break;
                case GlobalOperation.LIB_SEARCHBOOK_EDIT:
                    this.buttonOk.BackgroundImage = global::VideoBookApplication.Properties.Resources.pen;
                    toolTip1.SetToolTip(buttonOk, "Modifica Libro");
                    break;
                default:
                    this.buttonOk.BackgroundImage = global::VideoBookApplication.Properties.Resources.eraser;
                    toolTip1.SetToolTip(buttonOk, "");
                    break;
            } 
        }

        private void operationDelete()
        {

            ApplicationErrorType status = ApplicationErrorType.SUCCESS;

            if (globalObject.libraryObject.libraryInput.libro != null)
            {
                log.Info("Libri Trovati : 1");

                //salvo anche autori per uso futuro
                globalObject.libraryObject.libraryInput.autore = globalObject.libraryObject.libraryInput.libro.autore;
                AuthorControls control = new AuthorControls();
                status = control.addBooksToAuthor(ref globalObject);
                if (status == ApplicationErrorType.SUCCESS)
                {
                    parent.closePanel();
                    parent.openPanel(GlobalOperation.LIB_DETAIL_BOOK_DELETE);
                }
                else
                {
                    DisplayManager.displayError(status);
                }
            }
            else
            {
                //Gestione caso più libri trovati
                log.Info("Libri Trovati : " + globalObject.libraryObject.libraryInput.libri.Count);
                parent.closePanel();
                parent.openPanel(GlobalOperation.LIB_CHOOSE_BOOK_DELETE);
            }
        }

        private void operationEdit()
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;

            if (globalObject.libraryObject.libraryInput.libro != null)
            {
                log.Info("Libri Trovati : 1");
                DisplayManager.displayError(ApplicationErrorType.NOT_IMPLEMENTED);
                ////salvo anche autori per uso futuro
                //globalObject.libraryObject.libraryInput.autore = globalObject.libraryObject.libraryInput.libro.autore;
                //AuthorControls control = new AuthorControls();
                //status = control.addBooksToAuthor(ref globalObject);
                //if (status == ApplicationErrorType.SUCCESS)
                //{
                //    parent.closePanel();
                //    parent.openPanel(GlobalOperation.LIB_DETAIL_BOOK_DELETE);
                //}
                //else
                //{
                //    DisplayManager.displayError(status);
                //}
            }
            else
            {
                //Gestione caso più libri trovati
                log.Info("Libri Trovati : " + globalObject.libraryObject.libraryInput.libri.Count);
                parent.closePanel();
                parent.openPanel(GlobalOperation.LIB_CHOOSE_BOOK_EDIT);
            }
        }

    }
}
