namespace VideoBookApplication.library.view
{
    partial class SearchCategoryPanel
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
            this.comboCategory = new System.Windows.Forms.ComboBox();
            this.labelCategory = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboCategory
            // 
            this.comboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCategory.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCategory.FormattingEnabled = true;
            this.comboCategory.Location = new System.Drawing.Point(0, 0);
            this.comboCategory.Name = "comboCategory";
            this.comboCategory.Size = new System.Drawing.Size(350, 27);
            this.comboCategory.TabIndex = 0;
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCategory.Location = new System.Drawing.Point(0, 0);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(100, 23);
            this.labelCategory.TabIndex = 0;
            this.labelCategory.Text = "Selezione Categoria";
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
            this.buttonOk.BackgroundImage = global::VideoBookApplication.Properties.Resources.eraser;
            this.buttonOk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonOk.Location = new System.Drawing.Point(254, 136);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(48, 48);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // SearchCategoryPanel
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Size = new System.Drawing.Size(400, 200);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboCategory;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonOk;
    }
}
