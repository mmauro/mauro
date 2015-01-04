namespace VideoBookApplication.library.view
{
    partial class ResumeAuthorPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResumeAuthorPanel));
            this.labelTesto = new System.Windows.Forms.Label();
            this.labelAutore = new System.Windows.Forms.Label();
            this.buttonBooks = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // labelTesto
            // 
            this.labelTesto.AutoSize = true;
            this.labelTesto.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTesto.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelTesto.Location = new System.Drawing.Point(0, 0);
            this.labelTesto.Name = "labelTesto";
            this.labelTesto.Size = new System.Drawing.Size(100, 23);
            this.labelTesto.TabIndex = 0;
            this.labelTesto.Text = "Autore:";
            // 
            // labelAutore
            // 
            this.labelAutore.AutoSize = true;
            this.labelAutore.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAutore.ForeColor = System.Drawing.SystemColors.WindowText;
            this.labelAutore.Location = new System.Drawing.Point(0, 0);
            this.labelAutore.Name = "labelAutore";
            this.labelAutore.Size = new System.Drawing.Size(100, 23);
            this.labelAutore.TabIndex = 0;
            this.labelAutore.Text = "label2";
            // 
            // buttonBooks
            // 
            this.buttonBooks.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonBooks.BackgroundImage")));
            this.buttonBooks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonBooks.Location = new System.Drawing.Point(0, 0);
            this.buttonBooks.Name = "buttonBooks";
            this.buttonBooks.Size = new System.Drawing.Size(50, 50);
            this.buttonBooks.TabIndex = 0;
            this.buttonBooks.UseVisualStyleBackColor = true;
            this.buttonBooks.Click += new System.EventHandler(this.buttonBooks_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTesto;
        private System.Windows.Forms.Label labelAutore;
        private System.Windows.Forms.Button buttonBooks;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
