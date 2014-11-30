namespace VideoBookApplication.advanced.view
{
    partial class AdvancedActivityWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMenu1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelMenu1
            // 
            this.panelMenu1.Location = new System.Drawing.Point(25, 60);
            this.panelMenu1.Name = "panelMenu1";
            this.panelMenu1.Size = new System.Drawing.Size(235, 141);
            this.panelMenu1.TabIndex = 1;
            // 
            // AdvancedActivityWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.ControlBox = false;
            this.Controls.Add(this.panelMenu1);
            this.Name = "AdvancedActivityWindow";
            this.Text = "AdvancedActivityWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu1;
    }
}