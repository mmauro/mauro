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
            this.labelTitleOrig = new System.Windows.Forms.Label();
            this.textTitleOrig = new System.Windows.Forms.TextBox();
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
            this.textTitleOrig.Size = new System.Drawing.Size(300, 27);
            this.textTitleOrig.TabIndex = 3;
            // 
            // InfoBookPanel
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Size = new System.Drawing.Size(600, 600);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitleOrig;
        private System.Windows.Forms.TextBox textTitleOrig;
    }
}
