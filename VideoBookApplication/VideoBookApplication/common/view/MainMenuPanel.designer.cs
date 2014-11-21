namespace VideoBookApplication.common.view
{
    partial class MainMenuPanel
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
            this.buttonChangeApp = new System.Windows.Forms.Button();
            this.buttonExitApp = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // buttonChangeApp
            // 
            this.buttonChangeApp.Image = global::VideoBookApplication.Properties.Resources.changeapp;
            this.buttonChangeApp.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonChangeApp.Location = new System.Drawing.Point(0, 0);
            this.buttonChangeApp.Name = "buttonChangeApp";
            this.buttonChangeApp.Size = new System.Drawing.Size(127, 90);
            this.buttonChangeApp.TabIndex = 0;
            this.buttonChangeApp.Text = "Cambia Applicazione";
            this.buttonChangeApp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonChangeApp.UseVisualStyleBackColor = true;
            this.buttonChangeApp.Click += new System.EventHandler(this.buttonChangeApp_Click);
            // 
            // buttonExitApp
            // 
            this.buttonExitApp.Image = global::VideoBookApplication.Properties.Resources.exit;
            this.buttonExitApp.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonExitApp.Location = new System.Drawing.Point(0, 0);
            this.buttonExitApp.Name = "buttonExitApp";
            this.buttonExitApp.Size = new System.Drawing.Size(127, 90);
            this.buttonExitApp.TabIndex = 0;
            this.buttonExitApp.Text = "Uscita";
            this.buttonExitApp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonExitApp.UseVisualStyleBackColor = true;
            this.buttonExitApp.Click += new System.EventHandler(this.buttonExitApp_Click);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button buttonChangeApp;
        private System.Windows.Forms.Button buttonExitApp;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
