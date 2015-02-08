namespace VideoBookApplication.common.view
{
    partial class SearchMenuLibrary
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
            this.buttonSearchAuthor = new System.Windows.Forms.Button();
            this.buttonSearchBook = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonSearchCategory = new System.Windows.Forms.Button();
            this.buttonSearchPosition = new System.Windows.Forms.Button();
            this.buttonGenericSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSearchAuthor
            // 
            this.buttonSearchAuthor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSearchAuthor.Image = global::VideoBookApplication.Properties.Resources.edit_author_fw;
            this.buttonSearchAuthor.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonSearchAuthor.Location = new System.Drawing.Point(0, 0);
            this.buttonSearchAuthor.Name = "buttonSearchAuthor";
            this.buttonSearchAuthor.Size = new System.Drawing.Size(127, 90);
            this.buttonSearchAuthor.TabIndex = 0;
            this.buttonSearchAuthor.Text = "Cerca Autore";
            this.buttonSearchAuthor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonSearchAuthor.UseVisualStyleBackColor = true;
            this.buttonSearchAuthor.Click += new System.EventHandler(this.buttonSearchAuthor_Click);
            // 
            // buttonSearchBook
            // 
            this.buttonSearchBook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSearchBook.Image = global::VideoBookApplication.Properties.Resources.edit_book_fw;
            this.buttonSearchBook.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonSearchBook.Location = new System.Drawing.Point(0, 0);
            this.buttonSearchBook.Name = "buttonSearchBook";
            this.buttonSearchBook.Size = new System.Drawing.Size(127, 90);
            this.buttonSearchBook.TabIndex = 0;
            this.buttonSearchBook.Text = "Cerca Libro";
            this.buttonSearchBook.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonSearchBook.UseVisualStyleBackColor = true;
            this.buttonSearchBook.Click += new System.EventHandler(this.buttonSearchBook_Click);
            // 
            // buttonSearchCategory
            // 
            this.buttonSearchCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSearchCategory.Image = global::VideoBookApplication.Properties.Resources.edit_category_fw;
            this.buttonSearchCategory.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonSearchCategory.Location = new System.Drawing.Point(0, 0);
            this.buttonSearchCategory.Name = "buttonSearchCategory";
            this.buttonSearchCategory.Size = new System.Drawing.Size(127, 90);
            this.buttonSearchCategory.TabIndex = 0;
            this.buttonSearchCategory.Text = "Cerca Categoria";
            this.buttonSearchCategory.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonSearchCategory.UseVisualStyleBackColor = true;
            this.buttonSearchCategory.Click += new System.EventHandler(this.buttonSearchCategory_Click);
            // 
            // buttonSearchPosition
            // 
            this.buttonSearchPosition.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSearchPosition.Image = global::VideoBookApplication.Properties.Resources.edit_position_fw;
            this.buttonSearchPosition.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonSearchPosition.Location = new System.Drawing.Point(0, 0);
            this.buttonSearchPosition.Name = "buttonSearchPosition";
            this.buttonSearchPosition.Size = new System.Drawing.Size(127, 90);
            this.buttonSearchPosition.TabIndex = 0;
            this.buttonSearchPosition.Text = "Cerca Posizione";
            this.buttonSearchPosition.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonSearchPosition.UseVisualStyleBackColor = true;
            this.buttonSearchPosition.Click += new System.EventHandler(this.buttonSearchPosition_Click);
            // 
            // buttonGenericSearch
            // 
            this.buttonGenericSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonGenericSearch.Image = global::VideoBookApplication.Properties.Resources.generic_search_fw;
            this.buttonGenericSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonGenericSearch.Location = new System.Drawing.Point(0, 0);
            this.buttonGenericSearch.Name = "buttonGenericSearch";
            this.buttonGenericSearch.Size = new System.Drawing.Size(127, 90);
            this.buttonGenericSearch.TabIndex = 0;
            this.buttonGenericSearch.Text = "Ricerca Generica";
            this.buttonGenericSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonGenericSearch.UseVisualStyleBackColor = true;
            this.buttonGenericSearch.Click += new System.EventHandler(this.buttonGenericSearch_Click);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button buttonSearchAuthor;
        private System.Windows.Forms.Button buttonSearchBook;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonSearchCategory;
        private System.Windows.Forms.Button buttonSearchPosition;
        private System.Windows.Forms.Button buttonGenericSearch;
    }
}
