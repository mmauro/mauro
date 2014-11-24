namespace VideoBookApplication.common.view
{
    partial class InsertMenuLibrary
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
            this.buttonAddAuthor = new System.Windows.Forms.Button();
            this.buttonAddBook = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonAddCategory = new System.Windows.Forms.Button();
            this.buttonAddPosition = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAddAuthor
            // 
            this.buttonAddAuthor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAddAuthor.Image = global::VideoBookApplication.Properties.Resources.add_author;
            this.buttonAddAuthor.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonAddAuthor.Location = new System.Drawing.Point(0, 0);
            this.buttonAddAuthor.Name = "buttonAddAuthor";
            this.buttonAddAuthor.Size = new System.Drawing.Size(127, 90);
            this.buttonAddAuthor.TabIndex = 0;
            this.buttonAddAuthor.Text = "Nuovo Autore";
            this.buttonAddAuthor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonAddAuthor.UseVisualStyleBackColor = true;
            this.buttonAddAuthor.Click += new System.EventHandler(this.buttonAddAuthor_Click);
            // 
            // buttonAddBook
            // 
            this.buttonAddBook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAddBook.Image = global::VideoBookApplication.Properties.Resources.books_add;
            this.buttonAddBook.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonAddBook.Location = new System.Drawing.Point(0, 0);
            this.buttonAddBook.Name = "buttonAddBook";
            this.buttonAddBook.Size = new System.Drawing.Size(127, 90);
            this.buttonAddBook.TabIndex = 0;
            this.buttonAddBook.Text = "Nuovi Libri";
            this.buttonAddBook.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonAddBook.UseVisualStyleBackColor = true;
            this.buttonAddBook.Click += new System.EventHandler(this.buttonAddBook_Click);
            // 
            // buttonAddCategory
            // 
            this.buttonAddCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAddCategory.Image = global::VideoBookApplication.Properties.Resources.add_category;
            this.buttonAddCategory.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonAddCategory.Location = new System.Drawing.Point(0, 0);
            this.buttonAddCategory.Name = "buttonAddCategory";
            this.buttonAddCategory.Size = new System.Drawing.Size(127, 90);
            this.buttonAddCategory.TabIndex = 0;
            this.buttonAddCategory.Text = "Nuova Categoria";
            this.buttonAddCategory.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonAddCategory.UseVisualStyleBackColor = true;
            this.buttonAddCategory.Click += new System.EventHandler(this.buttonAddCategory_Click);
            // 
            // buttonAddPosition
            // 
            this.buttonAddPosition.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAddPosition.Image = global::VideoBookApplication.Properties.Resources.add_location;
            this.buttonAddPosition.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonAddPosition.Location = new System.Drawing.Point(0, 0);
            this.buttonAddPosition.Name = "buttonAddPosition";
            this.buttonAddPosition.Size = new System.Drawing.Size(127, 90);
            this.buttonAddPosition.TabIndex = 0;
            this.buttonAddPosition.Text = "Nuova Posizione";
            this.buttonAddPosition.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonAddPosition.UseVisualStyleBackColor = true;
            this.buttonAddPosition.Click += new System.EventHandler(this.buttonAddPosition_Click);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button buttonAddAuthor;
        private System.Windows.Forms.Button buttonAddBook;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonAddCategory;
        private System.Windows.Forms.Button buttonAddPosition;
    }
}
