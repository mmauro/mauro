namespace VideoBookApplication.library.view
{
    partial class InfoBookPanel
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
            this.labelTitleOrig = new System.Windows.Forms.Label();
            this.textTitleOrig = new System.Windows.Forms.TextBox();
            this.imageBox = new System.Windows.Forms.PictureBox();
            this.buttonKeepTitle = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.labelEditore = new System.Windows.Forms.Label();
            this.labelYear = new System.Windows.Forms.Label();
            this.textPublisher = new System.Windows.Forms.TextBox();
            this.textYear = new System.Windows.Forms.TextBox();
            this.labelIsbn = new System.Windows.Forms.Label();
            this.textIsbn = new System.Windows.Forms.TextBox();
            this.labelTrama = new System.Windows.Forms.Label();
            this.textTrama = new System.Windows.Forms.RichTextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonWeb = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitleOrig
            // 
            this.labelTitleOrig.AutoSize = true;
            this.labelTitleOrig.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleOrig.Location = new System.Drawing.Point(0, 0);
            this.labelTitleOrig.Name = "labelTitleOrig";
            this.labelTitleOrig.Size = new System.Drawing.Size(100, 23);
            this.labelTitleOrig.TabIndex = 0;
            this.labelTitleOrig.Text = "Titolo Originale";
            // 
            // textTitleOrig
            // 
            this.textTitleOrig.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTitleOrig.Location = new System.Drawing.Point(83, 52);
            this.textTitleOrig.Name = "textTitleOrig";
            this.textTitleOrig.ReadOnly = true;
            this.textTitleOrig.Size = new System.Drawing.Size(500, 27);
            this.textTitleOrig.TabIndex = 3;
            // 
            // imageBox
            // 
            this.imageBox.ErrorImage = global::VideoBookApplication.Properties.Resources.no_image;
            this.imageBox.Location = new System.Drawing.Point(0, 0);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(150, 200);
            this.imageBox.TabIndex = 0;
            this.imageBox.TabStop = false;
            // 
            // buttonKeepTitle
            // 
            this.buttonKeepTitle.BackgroundImage = global::VideoBookApplication.Properties.Resources.keep_title;
            this.buttonKeepTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonKeepTitle.Location = new System.Drawing.Point(254, 136);
            this.buttonKeepTitle.Name = "buttonKeepTitle";
            this.buttonKeepTitle.Size = new System.Drawing.Size(30, 30);
            this.buttonKeepTitle.TabIndex = 1;
            this.buttonKeepTitle.UseVisualStyleBackColor = true;
            this.buttonKeepTitle.Click += new System.EventHandler(this.buttonKeepTitle_Click);
            // 
            // labelEditore
            // 
            this.labelEditore.AutoSize = true;
            this.labelEditore.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEditore.Location = new System.Drawing.Point(0, 0);
            this.labelEditore.Name = "labelEditore";
            this.labelEditore.Size = new System.Drawing.Size(100, 23);
            this.labelEditore.TabIndex = 0;
            this.labelEditore.Text = "Editore";
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelYear.Location = new System.Drawing.Point(0, 0);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(100, 23);
            this.labelYear.TabIndex = 0;
            this.labelYear.Text = "Anno Pubblicazione";
            // 
            // textPublisher
            // 
            this.textPublisher.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPublisher.Location = new System.Drawing.Point(83, 52);
            this.textPublisher.Name = "textPublisher";
            this.textPublisher.ReadOnly = true;
            this.textPublisher.Size = new System.Drawing.Size(220, 27);
            this.textPublisher.TabIndex = 3;
            // 
            // textYear
            // 
            this.textYear.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textYear.Location = new System.Drawing.Point(83, 52);
            this.textYear.Name = "textYear";
            this.textYear.ReadOnly = true;
            this.textYear.Size = new System.Drawing.Size(140, 27);
            this.textYear.TabIndex = 3;
            // 
            // labelIsbn
            // 
            this.labelIsbn.AutoSize = true;
            this.labelIsbn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIsbn.Location = new System.Drawing.Point(0, 0);
            this.labelIsbn.Name = "labelIsbn";
            this.labelIsbn.Size = new System.Drawing.Size(100, 23);
            this.labelIsbn.TabIndex = 0;
            this.labelIsbn.Text = "ISBN";
            // 
            // textIsbn
            // 
            this.textIsbn.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textIsbn.Location = new System.Drawing.Point(83, 52);
            this.textIsbn.Name = "textIsbn";
            this.textIsbn.ReadOnly = true;
            this.textIsbn.Size = new System.Drawing.Size(220, 27);
            this.textIsbn.TabIndex = 3;
            // 
            // labelTrama
            // 
            this.labelTrama.AutoSize = true;
            this.labelTrama.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTrama.Location = new System.Drawing.Point(0, 0);
            this.labelTrama.Name = "labelTrama";
            this.labelTrama.Size = new System.Drawing.Size(100, 23);
            this.labelTrama.TabIndex = 0;
            this.labelTrama.Text = "Trama";
            // 
            // textTrama
            // 
            this.textTrama.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTrama.Location = new System.Drawing.Point(0, 0);
            this.textTrama.Name = "textTrama";
            this.textTrama.ReadOnly = true;
            this.textTrama.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.textTrama.Size = new System.Drawing.Size(360, 120);
            this.textTrama.TabIndex = 0;
            this.textTrama.Text = "";
            // 
            // buttonOk
            // 
            this.buttonOk.BackgroundImage = global::VideoBookApplication.Properties.Resources.save;
            this.buttonOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonOk.Location = new System.Drawing.Point(254, 136);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(48, 48);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
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
            // buttonWeb
            // 
            this.buttonWeb.BackgroundImage = global::VideoBookApplication.Properties.Resources.browser;
            this.buttonWeb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonWeb.Location = new System.Drawing.Point(254, 136);
            this.buttonWeb.Name = "buttonWeb";
            this.buttonWeb.Size = new System.Drawing.Size(48, 48);
            this.buttonWeb.TabIndex = 1;
            this.buttonWeb.UseVisualStyleBackColor = true;
            this.buttonWeb.Click += new System.EventHandler(this.buttonWeb_Click);
            // 
            // InfoBookPanel
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Size = new System.Drawing.Size(600, 600);
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitleOrig;
        private System.Windows.Forms.TextBox textTitleOrig;
        private System.Windows.Forms.PictureBox imageBox;
        private System.Windows.Forms.Button buttonKeepTitle;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label labelEditore;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.TextBox textPublisher;
        private System.Windows.Forms.TextBox textYear;
        private System.Windows.Forms.Label labelIsbn;
        private System.Windows.Forms.TextBox textIsbn;
        private System.Windows.Forms.Label labelTrama;
        private System.Windows.Forms.RichTextBox textTrama;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonWeb;
    }
}
