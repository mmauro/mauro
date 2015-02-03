namespace VideoBookApplication.common.view
{
    partial class DeleteMenuLibrary
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
            this.buttonDelAuthor = new System.Windows.Forms.Button();
            this.buttonDelBook = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonDelCategory = new System.Windows.Forms.Button();
            this.buttonDelPosition = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonDelAuthor
            // 
            this.buttonDelAuthor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDelAuthor.Image = global::VideoBookApplication.Properties.Resources.remove_author_fw;
            this.buttonDelAuthor.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonDelAuthor.Location = new System.Drawing.Point(0, 0);
            this.buttonDelAuthor.Name = "buttonDelAuthor";
            this.buttonDelAuthor.Size = new System.Drawing.Size(127, 90);
            this.buttonDelAuthor.TabIndex = 0;
            this.buttonDelAuthor.Text = "Canc.  Autore";
            this.buttonDelAuthor.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonDelAuthor.UseVisualStyleBackColor = true;
            this.buttonDelAuthor.Click += new System.EventHandler(this.buttonDelAuthor_Click);
            // 
            // buttonDelBook
            // 
            this.buttonDelBook.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDelBook.Image = global::VideoBookApplication.Properties.Resources.remove_books_fw;
            this.buttonDelBook.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonDelBook.Location = new System.Drawing.Point(0, 0);
            this.buttonDelBook.Name = "buttonDelBook";
            this.buttonDelBook.Size = new System.Drawing.Size(127, 90);
            this.buttonDelBook.TabIndex = 0;
            this.buttonDelBook.Text = "Canc. Libro";
            this.buttonDelBook.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonDelBook.UseVisualStyleBackColor = true;
            this.buttonDelBook.Click += new System.EventHandler(this.buttonDelBook_Click);
            // 
            // buttonDelCategory
            // 
            this.buttonDelCategory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDelCategory.Image = global::VideoBookApplication.Properties.Resources.remove_category_fw;
            this.buttonDelCategory.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonDelCategory.Location = new System.Drawing.Point(0, 0);
            this.buttonDelCategory.Name = "buttonDelCategory";
            this.buttonDelCategory.Size = new System.Drawing.Size(127, 90);
            this.buttonDelCategory.TabIndex = 0;
            this.buttonDelCategory.Text = "Canc. Categoria";
            this.buttonDelCategory.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonDelCategory.UseVisualStyleBackColor = true;
            this.buttonDelCategory.Click += new System.EventHandler(this.buttonDelCategory_Click);
            // 
            // buttonDelPosition
            // 
            this.buttonDelPosition.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDelPosition.Image = global::VideoBookApplication.Properties.Resources.remove_position_fw;
            this.buttonDelPosition.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonDelPosition.Location = new System.Drawing.Point(0, 0);
            this.buttonDelPosition.Name = "buttonDelPosition";
            this.buttonDelPosition.Size = new System.Drawing.Size(127, 90);
            this.buttonDelPosition.TabIndex = 0;
            this.buttonDelPosition.Text = "Canc. Posizione";
            this.buttonDelPosition.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonDelPosition.UseVisualStyleBackColor = true;
            this.buttonDelPosition.Click += new System.EventHandler(this.buttonDelPosition_Click);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button buttonDelAuthor;
        private System.Windows.Forms.Button buttonDelBook;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonDelCategory;
        private System.Windows.Forms.Button buttonDelPosition;
    }
}
