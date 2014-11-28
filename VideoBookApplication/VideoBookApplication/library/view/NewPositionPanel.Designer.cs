namespace VideoBookApplication.library.view
{
    partial class NewPositionPanel
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
            this.labelPosition = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.textPosition = new System.Windows.Forms.TextBox();
            this.buttonShowPos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelPosition
            // 
            this.labelPosition.AutoSize = true;
            this.labelPosition.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPosition.Location = new System.Drawing.Point(0, 0);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(100, 23);
            this.labelPosition.TabIndex = 0;
            this.labelPosition.Text = "Posizione";
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
            // textPosition
            // 
            this.textPosition.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPosition.Location = new System.Drawing.Point(83, 52);
            this.textPosition.Name = "textPosition";
            this.textPosition.Size = new System.Drawing.Size(288, 27);
            this.textPosition.TabIndex = 3;
            // 
            // buttonShowPos
            // 
            this.buttonShowPos.BackgroundImage = global::VideoBookApplication.Properties.Resources.show;
            this.buttonShowPos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonShowPos.Location = new System.Drawing.Point(323, 136);
            this.buttonShowPos.Name = "buttonShowPos";
            this.buttonShowPos.Size = new System.Drawing.Size(48, 48);
            this.buttonShowPos.TabIndex = 0;
            this.buttonShowPos.UseVisualStyleBackColor = true;
            this.buttonShowPos.Click += new System.EventHandler(this.buttonShowPos_Click);
            // 
            // NewPositionPanel
            // 
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Size = new System.Drawing.Size(400, 200);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox textPosition;
        private System.Windows.Forms.Button buttonShowPos;
    }
}
