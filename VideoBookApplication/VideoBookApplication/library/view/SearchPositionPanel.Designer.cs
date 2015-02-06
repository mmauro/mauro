namespace VideoBookApplication.library.view
{
    partial class SearchPositionPanel
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
            this.comboPosition = new System.Windows.Forms.ComboBox();
            this.labelPos = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboPosition
            // 
            this.comboPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPosition.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboPosition.FormattingEnabled = true;
            this.comboPosition.Location = new System.Drawing.Point(0, 0);
            this.comboPosition.Name = "comboPosition";
            this.comboPosition.Size = new System.Drawing.Size(350, 27);
            this.comboPosition.TabIndex = 0;
            // 
            // labelPos
            // 
            this.labelPos.AutoSize = true;
            this.labelPos.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPos.Location = new System.Drawing.Point(0, 0);
            this.labelPos.Name = "labelPos";
            this.labelPos.Size = new System.Drawing.Size(100, 23);
            this.labelPos.TabIndex = 0;
            this.labelPos.Text = "Selezione Categoria";
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
            // SearchPositionPanel
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Size = new System.Drawing.Size(400, 200);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboPosition;
        private System.Windows.Forms.Label labelPos;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonOk;
    }
}
