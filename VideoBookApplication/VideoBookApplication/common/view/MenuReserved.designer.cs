namespace VideoBookApplication.common.view
{
    partial class MenuReserved
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
            this.buttonReserved = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // buttonReserved
            // 
            this.buttonReserved.Image = global::VideoBookApplication.Properties.Resources.resword;
            this.buttonReserved.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonReserved.Location = new System.Drawing.Point(0, 0);
            this.buttonReserved.Name = "buttonReserved";
            this.buttonReserved.Size = new System.Drawing.Size(127, 90);
            this.buttonReserved.TabIndex = 0;
            this.buttonReserved.Text = "Parole Riservate";
            this.buttonReserved.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonReserved.UseVisualStyleBackColor = true;
            this.buttonReserved.Click += new System.EventHandler(this.buttonReserved_Click);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button buttonReserved;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
