namespace VideoBookApplication.common.view
{
    partial class ReservedPanel
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
            this.labelReserved = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.textReserved = new System.Windows.Forms.TextBox();
            this.comboTypeReserved = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelReserved
            // 
            this.labelReserved.AutoSize = true;
            this.labelReserved.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReserved.Location = new System.Drawing.Point(0, 0);
            this.labelReserved.Name = "labelReserved";
            this.labelReserved.Size = new System.Drawing.Size(100, 23);
            this.labelReserved.TabIndex = 0;
            this.labelReserved.Text = "Riservata";
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelType.Location = new System.Drawing.Point(0, 0);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(100, 23);
            this.labelType.TabIndex = 0;
            this.labelType.Text = "Tipo";
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
            // textReserved
            // 
            this.textReserved.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textReserved.Location = new System.Drawing.Point(83, 52);
            this.textReserved.Name = "textReserved";
            this.textReserved.Size = new System.Drawing.Size(288, 27);
            this.textReserved.TabIndex = 3;
            // 
            // comboTypeReserved
            // 
            this.comboTypeReserved.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTypeReserved.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboTypeReserved.FormattingEnabled = true;
            this.comboTypeReserved.Location = new System.Drawing.Point(0, 0);
            this.comboTypeReserved.Name = "comboTypeReserved";
            this.comboTypeReserved.Size = new System.Drawing.Size(288, 21);
            this.comboTypeReserved.TabIndex = 0;
            // 
            // ReservedPanel
            // 
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Size = new System.Drawing.Size(400, 250);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelReserved;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox textReserved;
        private System.Windows.Forms.ComboBox comboTypeReserved;
    }
}
