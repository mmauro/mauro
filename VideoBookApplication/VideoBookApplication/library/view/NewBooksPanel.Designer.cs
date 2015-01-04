namespace VideoBookApplication.library.view
{
    partial class NewBooksPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelTitle = new System.Windows.Forms.Label();
            this.textTitle = new System.Windows.Forms.TextBox();
            this.labelSerie = new System.Windows.Forms.Label();
            this.textSerie = new System.Windows.Forms.TextBox();
            this.buttonGoogleBooks = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.comboCategory = new System.Windows.Forms.ComboBox();
            this.comboLocation = new System.Windows.Forms.ComboBox();
            this.labelCategory = new System.Windows.Forms.Label();
            this.labelPosition = new System.Windows.Forms.Label();
            this.buttonAddCat = new System.Windows.Forms.Button();
            this.buttonAddPos = new System.Windows.Forms.Button();
            this.checkEbook = new System.Windows.Forms.CheckBox();
            this.textNote = new System.Windows.Forms.RichTextBox();
            this.labelNote = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonAddBook = new System.Windows.Forms.Button();
            this.labelNB = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(100, 23);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Titolo";
            // 
            // textTitle
            // 
            this.textTitle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTitle.Location = new System.Drawing.Point(83, 52);
            this.textTitle.Name = "textTitle";
            this.textTitle.Size = new System.Drawing.Size(350, 27);
            this.textTitle.TabIndex = 3;
            // 
            // labelSerie
            // 
            this.labelSerie.AutoSize = true;
            this.labelSerie.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSerie.Location = new System.Drawing.Point(0, 0);
            this.labelSerie.Name = "labelSerie";
            this.labelSerie.Size = new System.Drawing.Size(100, 23);
            this.labelSerie.TabIndex = 0;
            this.labelSerie.Text = "Serie";
            // 
            // textSerie
            // 
            this.textSerie.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSerie.Location = new System.Drawing.Point(83, 52);
            this.textSerie.Name = "textSerie";
            this.textSerie.Size = new System.Drawing.Size(350, 27);
            this.textSerie.TabIndex = 3;
            // 
            // buttonGoogleBooks
            // 
            this.buttonGoogleBooks.BackgroundImage = global::VideoBookApplication.Properties.Resources.google;
            this.buttonGoogleBooks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonGoogleBooks.Location = new System.Drawing.Point(254, 136);
            this.buttonGoogleBooks.Name = "buttonGoogleBooks";
            this.buttonGoogleBooks.Size = new System.Drawing.Size(60, 60);
            this.buttonGoogleBooks.TabIndex = 1;
            this.buttonGoogleBooks.UseVisualStyleBackColor = true;
            this.buttonGoogleBooks.Click += new System.EventHandler(this.buttonGoogleBooks_Click);
            // 
            // comboCategory
            // 
            this.comboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCategory.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCategory.FormattingEnabled = true;
            this.comboCategory.Location = new System.Drawing.Point(0, 0);
            this.comboCategory.Name = "comboCategory";
            this.comboCategory.Size = new System.Drawing.Size(160, 27);
            this.comboCategory.TabIndex = 0;
            // 
            // comboLocation
            // 
            this.comboLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLocation.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboLocation.FormattingEnabled = true;
            this.comboLocation.Location = new System.Drawing.Point(0, 0);
            this.comboLocation.Name = "comboLocation";
            this.comboLocation.Size = new System.Drawing.Size(160, 27);
            this.comboLocation.TabIndex = 0;
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCategory.Location = new System.Drawing.Point(0, 0);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(100, 23);
            this.labelCategory.TabIndex = 0;
            this.labelCategory.Text = "Categoria";
            // 
            // labelPosition
            // 
            this.labelPosition.AutoSize = true;
            this.labelPosition.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPosition.Location = new System.Drawing.Point(0, 0);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(100, 23);
            this.labelPosition.TabIndex = 0;
            this.labelPosition.Text = "Posizione";
            // 
            // buttonAddCat
            // 
            this.buttonAddCat.BackgroundImage = global::VideoBookApplication.Properties.Resources.plus;
            this.buttonAddCat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAddCat.Location = new System.Drawing.Point(254, 136);
            this.buttonAddCat.Name = "buttonAddCat";
            this.buttonAddCat.Size = new System.Drawing.Size(30, 30);
            this.buttonAddCat.TabIndex = 1;
            this.buttonAddCat.UseVisualStyleBackColor = true;
            this.buttonAddCat.Click += new System.EventHandler(this.buttonAddCat_Click);
            // 
            // buttonAddPos
            // 
            this.buttonAddPos.BackgroundImage = global::VideoBookApplication.Properties.Resources.plus;
            this.buttonAddPos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAddPos.Location = new System.Drawing.Point(254, 136);
            this.buttonAddPos.Name = "buttonAddPos";
            this.buttonAddPos.Size = new System.Drawing.Size(30, 30);
            this.buttonAddPos.TabIndex = 1;
            this.buttonAddPos.UseVisualStyleBackColor = true;
            this.buttonAddPos.Click += new System.EventHandler(this.buttonAddPos_Click);
            // 
            // checkEbook
            // 
            this.checkEbook.AutoSize = true;
            this.checkEbook.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkEbook.Location = new System.Drawing.Point(0, 0);
            this.checkEbook.Name = "checkEbook";
            this.checkEbook.Size = new System.Drawing.Size(104, 24);
            this.checkEbook.TabIndex = 0;
            this.checkEbook.Text = "Libro in Formato Elettronico";
            this.checkEbook.UseVisualStyleBackColor = true;
            // 
            // textNote
            // 
            this.textNote.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNote.Location = new System.Drawing.Point(0, 0);
            this.textNote.Name = "textNote";
            this.textNote.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.textNote.Size = new System.Drawing.Size(450, 100);
            this.textNote.TabIndex = 0;
            this.textNote.Text = "";
            // 
            // labelNote
            // 
            this.labelNote.AutoSize = true;
            this.labelNote.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNote.Location = new System.Drawing.Point(0, 0);
            this.labelNote.Name = "labelNote";
            this.labelNote.Size = new System.Drawing.Size(100, 23);
            this.labelNote.TabIndex = 0;
            this.labelNote.Text = "Note";
            // 
            // buttonClose
            // 
            this.buttonClose.BackgroundImage = global::VideoBookApplication.Properties.Resources.close2;
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonClose.Location = new System.Drawing.Point(323, 136);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(48, 48);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.BackgroundImage = global::VideoBookApplication.Properties.Resources.button_ok;
            this.buttonOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonOk.Location = new System.Drawing.Point(254, 136);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(48, 48);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonAddBook
            // 
            this.buttonAddBook.BackgroundImage = global::VideoBookApplication.Properties.Resources.Books;
            this.buttonAddBook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAddBook.Location = new System.Drawing.Point(254, 136);
            this.buttonAddBook.Name = "buttonAddBook";
            this.buttonAddBook.Size = new System.Drawing.Size(48, 48);
            this.buttonAddBook.TabIndex = 1;
            this.buttonAddBook.UseVisualStyleBackColor = true;
            this.buttonAddBook.Click += new System.EventHandler(this.buttonAddBook_Click);
            // 
            // labelNB
            // 
            this.labelNB.AutoSize = true;
            this.labelNB.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNB.Location = new System.Drawing.Point(0, 0);
            this.labelNB.Name = "labelNB";
            this.labelNB.Size = new System.Drawing.Size(100, 23);
            this.labelNB.TabIndex = 0;
            this.labelNB.Text = "Serie";
            // 
            // NewBooksPanel
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Size = new System.Drawing.Size(500, 600);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textTitle;
        private System.Windows.Forms.Label labelSerie;
        private System.Windows.Forms.TextBox textSerie;
        private System.Windows.Forms.Button buttonGoogleBooks;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox comboCategory;
        private System.Windows.Forms.ComboBox comboLocation;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.Button buttonAddCat;
        private System.Windows.Forms.Button buttonAddPos;
        private System.Windows.Forms.CheckBox checkEbook;
        private System.Windows.Forms.RichTextBox textNote;
        private System.Windows.Forms.Label labelNote;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonAddBook;
        private System.Windows.Forms.Label labelNB;
    }
}
