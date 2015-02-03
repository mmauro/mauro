namespace VideoBookApplication.common.view
{
    partial class EditMenuLibrary
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
            this.buttonModifyAuthor = new System.Windows.Forms.Button();
            this.buttonModifyBook = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonModifyCategory = new System.Windows.Forms.Button();
            this.buttonModifyPosition = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonModifyAuthor
            // 
            this.buttonModifyAuthor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonModifyAuthor.Image = global::VideoBookApplication.Properties.Resources.edit_author_fw;
            this.buttonModifyAuthor.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonModifyAuthor.Location = new System.Drawing.Point(0, 0);
            this.buttonModifyAuthor.Name = "buttonModifyAuthor";
            this.buttonModifyAuthor.Size = new System.Drawing.Size(127, 90);
            this.buttonModifyAuthor.TabIndex = 0;
            this.buttonModifyAuthor.Text = "Modif. Autore";
            this.buttonModifyAuthor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonModifyAuthor.UseVisualStyleBackColor = true;
            this.buttonModifyAuthor.Click += new System.EventHandler(this.buttonModifyAuthor_Click);
            // 
            // buttonModifyBook
            // 
            this.buttonModifyBook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonModifyBook.Image = global::VideoBookApplication.Properties.Resources.edit_book_fw;
            this.buttonModifyBook.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonModifyBook.Location = new System.Drawing.Point(0, 0);
            this.buttonModifyBook.Name = "buttonModifyBook";
            this.buttonModifyBook.Size = new System.Drawing.Size(127, 90);
            this.buttonModifyBook.TabIndex = 0;
            this.buttonModifyBook.Text = "Modif. Libro";
            this.buttonModifyBook.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonModifyBook.UseVisualStyleBackColor = true;
            this.buttonModifyBook.Click += new System.EventHandler(this.buttonModifyBook_Click);
            // 
            // buttonModifyCategory
            // 
            this.buttonModifyCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonModifyCategory.Image = global::VideoBookApplication.Properties.Resources.edit_category_fw;
            this.buttonModifyCategory.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonModifyCategory.Location = new System.Drawing.Point(0, 0);
            this.buttonModifyCategory.Name = "buttonModifyCategory";
            this.buttonModifyCategory.Size = new System.Drawing.Size(127, 90);
            this.buttonModifyCategory.TabIndex = 0;
            this.buttonModifyCategory.Text = "Modif. Categoria";
            this.buttonModifyCategory.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonModifyCategory.UseVisualStyleBackColor = true;
            this.buttonModifyCategory.Click += new System.EventHandler(this.buttonModifyCategory_Click);
            // 
            // buttonModifyPosition
            // 
            this.buttonModifyPosition.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonModifyPosition.Image = global::VideoBookApplication.Properties.Resources.edit_position_fw;
            this.buttonModifyPosition.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonModifyPosition.Location = new System.Drawing.Point(0, 0);
            this.buttonModifyPosition.Name = "buttonModifyPosition";
            this.buttonModifyPosition.Size = new System.Drawing.Size(127, 90);
            this.buttonModifyPosition.TabIndex = 0;
            this.buttonModifyPosition.Text = "Modif. Posizione";
            this.buttonModifyPosition.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonModifyPosition.UseVisualStyleBackColor = true;
            this.buttonModifyPosition.Click += new System.EventHandler(this.buttonModifyPosition_Click);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button buttonModifyAuthor;
        private System.Windows.Forms.Button buttonModifyBook;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonModifyCategory;
        private System.Windows.Forms.Button buttonModifyPosition;
    }
}
