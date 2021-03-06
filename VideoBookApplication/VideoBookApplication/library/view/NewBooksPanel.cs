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
using VideoBookApplication.library.model.database;

namespace VideoBookApplication.library.view
{
    public partial class NewBooksPanel : Panel
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private GlobalApplicationObject globalObject;
        private LibraryActivityWindow parent;
        private List<ItemCombo> listItemsCat = new List<ItemCombo>();
        private List<ItemCombo> listItemsPos = new List<ItemCombo>();
        private bool refreshCat = false;
        private bool refreshPos = false;
        private bool callInfoBook = true;
        private bool userDeleteInfo = false;

        private BooksControls bookControl = new BooksControls();

        public NewBooksPanel(ref GlobalApplicationObject globalObject, LibraryActivityWindow parent)
        {
            InitializeComponent();
            ApplicationErrorType status = refreshData();
            if (status == ApplicationErrorType.SUCCESS)
            {
                this.globalObject = globalObject;
                this.parent = parent;
                initPanel();
            }
            else
            {
                DisplayManager.displayError(status);
                parent.closePanel();
            }
        }

        private void initPanel()
        {
            this.BackColor = LayoutManager.getPanelColor();

            //Resume Author Panel
            ResumeAuthorPanel authorPanel = new ResumeAuthorPanel(ref globalObject, this, parent);
            authorPanel.Location =  new Point(0, 0);
            this.Controls.Add(authorPanel);

            //Title
            TitlePanel titlePanel = new TitlePanel("Nuovi Libri", this);
            titlePanel.Location = new Point(0, authorPanel.Location.Y + authorPanel.Size.Height);
            this.Controls.Add(titlePanel);

            //Titolo
            labelTitle.Location = new Point(25, titlePanel.Location.Y + titlePanel.Size.Height + 10);
            this.Controls.Add(labelTitle);

            textTitle.Location = new Point(25, labelTitle.Location.Y + 20);
            this.Controls.Add(textTitle);

            //Serie
            labelSerie.Location = new Point(25, textTitle.Location.Y + textTitle.Size.Height + 20);
            this.Controls.Add(labelSerie);

            textSerie.Location = new Point(25, labelSerie.Location.Y + 20);
            this.Controls.Add(textSerie);

            //google books
            buttonGoogleBooks.Location = new Point(textSerie.Location.X + textSerie.Size.Width + 35, labelTitle.Location.Y + 35);
            this.Controls.Add(buttonGoogleBooks);

            //categorie
            labelCategory.Location = new Point(25, textSerie.Location.Y + textSerie.Size.Height + 20);
            this.Controls.Add(labelCategory);

            comboCategory.Location = new Point(25, labelCategory.Location.Y + 20);
            this.Controls.Add(comboCategory);

            buttonAddCat.Location = new Point(comboCategory.Location.X + 10 + comboCategory.Size.Width, comboCategory.Location.Y - 1 );
            this.Controls.Add(buttonAddCat);

            //posizione
            labelPosition.Location = new Point(260, textSerie.Location.Y + textSerie.Size.Height + 20);
            this.Controls.Add(labelPosition);

            comboLocation.Location = new Point(260, labelPosition.Location.Y + 20);
            this.Controls.Add(comboLocation);
           
            //Refresh Combo
            refreshCombo();

            buttonAddPos.Location = new Point(comboLocation.Location.X + comboLocation.Size.Width + 10, comboLocation.Location.Y - 1);
            this.Controls.Add(buttonAddPos);

            //Formato Elettronico
            checkEbook.Location = new Point(25, comboLocation.Location.Y + 55);
            this.Controls.Add(checkEbook);

            //Note
            labelNote.Location = new Point(25, checkEbook.Location.Y + checkEbook.Size.Height + 20);
            this.Controls.Add(labelNote);

            textNote.Location = new Point(25, labelNote.Location.Y + 20);
            this.Controls.Add(textNote);

            //Pulsanti finali
            buttonClose.Location = new Point(this.Size.Width - (buttonClose.Size.Width + 20), textNote.Location.Y + textNote.Size.Height + 30);
            this.Controls.Add(buttonClose);

            buttonOk.Location = new Point(buttonClose.Location.X - (10 + buttonOk.Size.Width), buttonClose.Location.Y);
            this.Controls.Add(buttonOk);

            buttonAddBook.Location = new Point(buttonOk.Location.X - (40 + buttonAddBook.Size.Width), buttonOk.Location.Y);
            this.Controls.Add(buttonAddBook);

            labelNB.Text = globalObject.libraryObject.libraryInput.libri.Count + " Libri da Salvare";
            labelNB.Location = new Point(25, textNote.Location.Y + textNote.Size.Height + 40);
            this.Controls.Add(labelNB);


            //Tooltip
            toolTip1.SetToolTip(buttonGoogleBooks, "Ricerca su Google del libro");
            toolTip1.SetToolTip(buttonAddCat, "Nuova Categoria");
            toolTip1.SetToolTip(buttonAddPos, "Nuova Posizione");
            toolTip1.SetToolTip(buttonClose, "Annulla");
            toolTip1.SetToolTip(buttonOk, "Salvataggio Libri");
            toolTip1.SetToolTip(buttonAddBook, "Nuovo Libro");

        }

        public ApplicationErrorType refreshData()
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;

            try
            {
                CategoryControls catControls = new CategoryControls();
                List<CategoryModel> tmpCModel = catControls.getAllCategory(true);
                if (tmpCModel != null && tmpCModel.Count > 0)
                {
                    if (tmpCModel.Count != listItemsCat.Count)
                    {
                        refreshCat = true;
                        listItemsCat = new List<ItemCombo>();
                        foreach (CategoryModel mc in tmpCModel)
                        {
                            listItemsCat.Add(new ItemCombo(mc.category, mc.idCategory));
                        }
                    }
                    else
                    {
                        refreshCat = false;
                    }
                }
            }
            catch (VideoBookException e)
            {
                status = ApplicationErrorType.CATEGORY_ERROR;
            }

            if (status == ApplicationErrorType.SUCCESS)
            {
                try
                {
                    PositionControls posControl = new PositionControls();
                    List<PositionModel> tmpPModel = posControl.getAllPosition(true);
                    if (tmpPModel != null && tmpPModel.Count > 0)
                    {
                        if (tmpPModel.Count != listItemsPos.Count)
                        {
                            refreshPos = true;
                            listItemsPos = new List<ItemCombo>();
                            foreach (PositionModel mc in tmpPModel)
                            {
                                listItemsPos.Add(new ItemCombo(mc.position, mc.idPosition));
                            }
                        }
                        else
                        {
                            refreshPos = false;
                        }
                    }
                }
                catch (VideoBookException e)
                {
                    status = ApplicationErrorType.POSITION_ERROR;
                }

            }

            return status;
        }

        public void refreshCombo() {
            if (refreshPos) 
            {
                comboLocation.Items.Clear();
                foreach (ItemCombo ic in listItemsPos)
                {
                    comboLocation.Items.Add(ic);
                    comboLocation.SelectedIndex = 0;
                }

            }

            if (refreshCat)
            {
                comboCategory.Items.Clear();
                foreach (ItemCombo ic in listItemsCat)
                {
                    comboCategory.Items.Add(ic);
                    comboCategory.SelectedIndex = 0;
                }
            }
        }



        private void buttonGoogleBooks_Click(object sender, EventArgs e)
        {

            try
            {
                if (callInfoBook)
                {
                    callInfoBook = false;
                    ItemCombo catValue = (ItemCombo)comboCategory.SelectedItem;
                    ItemCombo posValue = (ItemCombo)comboLocation.SelectedItem;
                    globalObject.libraryObject.tempModel.infoModel = bookControl.getBookInfoModel(textTitle.Text, globalObject.libraryObject.libraryInput.autore.cognome);
                    globalObject.libraryObject.tempModel.libro = bookControl.getBooksModel(textTitle.Text, textSerie.Text, textNote.Text, catValue.value, posValue.value, checkEbook.Checked);
                }
                if (globalObject.libraryObject.tempModel.infoModel != null)
                {
                    parent.openPanel(GlobalOperation.LIB_INFOBOOK);
                }
                else
                {
                    if (userDeleteInfo)
                    {
                        DisplayManager.displayWarning(ApplicationErrorType.INFO_DELETE_BYUSER_WARN);
                    }
                    else
                    {
                        DisplayManager.displayError(ApplicationErrorType.INFOBOOK_NOT_FOUND);
                    }
                }

            }
            catch (VideoBookException vbe)
            {
                DisplayManager.displayError(vbe.errorType);
                callInfoBook = true;
            }
        }

        private void buttonAddCat_Click(object sender, EventArgs e)
        {
            parent.closeOtherBooksPanel();
            parent.openPanel(GlobalOperation.LIB_NEW_BOOKS_CATEGORY);
        }

        private void buttonAddPos_Click(object sender, EventArgs e)
        {
            parent.closeOtherBooksPanel();
            parent.openPanel(GlobalOperation.LIB_NEW_BOOKS_POSITION);
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            bool close = true;
            if (globalObject.libraryObject.libraryInput.libri.Count > 0)
            {
                DialogResult responce = MessageBox.Show("Le informazioni andranno perse. Si desidera continuare ?", "ATTENZIONE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (responce.Equals(DialogResult.Yes))
                {
                    close = true;
                }
                else
                {
                    close = false;
                }
            }

            if (close)
            {
                globalObject.libraryObject.destroy();
                parent.closePanel();
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ApplicationErrorType status = addBook();
            if (status == ApplicationErrorType.SUCCESS)
            {
                LibraryControls control = new LibraryControls();
                status = control.write(ref globalObject);
                if (status != ApplicationErrorType.SUCCESS)
                {
                    DisplayManager.displayError(status);
                }
                else
                {
                    globalObject.libraryObject.destroy();
                    DisplayManager.displayMessage(ApplicationErrorType.SUCCESS, "Salvataggio Avvenuto con Successo");
                    parent.closePanel();
                }
            }
            else
            {
                DisplayManager.displayError(status);
            }
            Cursor.Current = Cursors.Default;
        }

        private void buttonAddBook_Click(object sender, EventArgs e)
        {
            ApplicationErrorType status = addBook();
            if (status == ApplicationErrorType.SUCCESS)
            {
                resetPanelInfo();
            }
            else
            {
                DisplayManager.displayError(status);
            }
             
        }

        private void textTitle_TextChanged(object sender, EventArgs e)
        {
            callInfoBook = true;
        }

        public void refreshTitle()
        {
            if (globalObject.libraryObject.tempModel.libro != null)
            {
                textTitle.Text = globalObject.libraryObject.tempModel.libro.titolo;
            }
        }

        private ApplicationErrorType addBook()
        {
            ApplicationErrorType status = ApplicationErrorType.SUCCESS;
            BookModel model = null;
            if (textTitle.Text != null && !textTitle.Text.Trim().Equals(""))
            {
                try
                {
                    //Creo il libro...
                    ItemCombo catValue = (ItemCombo)comboCategory.SelectedItem;
                    ItemCombo posValue = (ItemCombo)comboLocation.SelectedItem;
                    model = bookControl.getBooksModel(textTitle.Text, textSerie.Text, textNote.Text, catValue.value, posValue.value, checkEbook.Checked);

                }
                catch (VideoBookException e2)
                {
                    status = e2.errorType;
                }

                if (status == ApplicationErrorType.SUCCESS)
                {
                    try
                    {
                        if (callInfoBook)
                        {
                            model.informations = bookControl.getBookInfoModel(textTitle.Text, globalObject.libraryObject.libraryInput.autore.cognome);
                        }
                        else
                        {
                            //Ho già chiamato InfoBook...
                            model.informations = globalObject.libraryObject.tempModel.infoModel;
                        }
                    }
                    catch (VideoBookException e3)
                    {
                        status = e3.errorType;
                    }
                }

                if (status == ApplicationErrorType.SUCCESS)
                {
                    globalObject.libraryObject.libraryInput.libri.Add(model);
                }

            }
            else
            {
                status = ApplicationErrorType.EMPTY_TITLE;
            }

            return status;
        }

        public void deleteInfo()
        {
            userDeleteInfo = true;
            globalObject.libraryObject.tempModel.infoModel = null;
            globalObject.libraryObject.tempModel.libro.informations = null;
        }

        private void resetPanelInfo()
        {
            labelNB.Text = globalObject.libraryObject.libraryInput.libri.Count + " Libri da Salvare";
            textTitle.Text = "";
            textSerie.Text = "";
            checkEbook.Checked = false;
            textNote.Text = "";
            refreshCat = true;
            refreshPos = true;
            refreshCombo();
            globalObject.libraryObject.tempModel.destroy();
            callInfoBook = true;
        }
    }
}
