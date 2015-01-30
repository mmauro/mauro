namespace VideoBookApplication.library.view
{
    partial class ShowBooksPanel
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
            this.textBooks = new System.Windows.Forms.RichTextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.labelNumBooks = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBooks
            // 
            this.textBooks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBooks.Cursor = System.Windows.Forms.Cursors.Default;
            this.textBooks.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBooks.Location = new System.Drawing.Point(0, 0);
            this.textBooks.Name = "textBooks";
            this.textBooks.ReadOnly = true;
            this.textBooks.Size = new System.Drawing.Size(100, 96);
            this.textBooks.TabIndex = 0;
            this.textBooks.Text = "";
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
            // labelNumBooks
            // 
            this.labelNumBooks.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumBooks.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelNumBooks.Location = new System.Drawing.Point(0, 0);
            this.labelNumBooks.Name = "labelNumBooks";
            this.labelNumBooks.Size = new System.Drawing.Size(100, 23);
            this.labelNumBooks.TabIndex = 0;
            this.labelNumBooks.Text = "label1";
            this.labelNumBooks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ShowBooksPanel
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Size = new System.Drawing.Size(400, 500);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox textBooks;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label labelNumBooks;
    }
}
