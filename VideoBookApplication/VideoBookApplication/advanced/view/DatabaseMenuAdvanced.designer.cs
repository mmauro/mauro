namespace VideoBookApplication.advanced.view
{
    partial class DatabaseMenuAdvanced
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
            this.buttonRestore = new System.Windows.Forms.Button();
            this.buttonDump = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // buttonRestore
            // 
            this.buttonRestore.Image = global::VideoBookApplication.Properties.Resources.restore_db;
            this.buttonRestore.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonRestore.Location = new System.Drawing.Point(0, 0);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(127, 90);
            this.buttonRestore.TabIndex = 0;
            this.buttonRestore.Text = "Restore Database";
            this.buttonRestore.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonRestore.UseVisualStyleBackColor = true;
            this.buttonRestore.Click += new System.EventHandler(this.buttonRestore_Click);
            // 
            // buttonDump
            // 
            this.buttonDump.Image = global::VideoBookApplication.Properties.Resources.dump_db;
            this.buttonDump.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonDump.Location = new System.Drawing.Point(0, 0);
            this.buttonDump.Name = "buttonDump";
            this.buttonDump.Size = new System.Drawing.Size(127, 90);
            this.buttonDump.TabIndex = 0;
            this.buttonDump.Text = "Dump Database";
            this.buttonDump.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonDump.UseVisualStyleBackColor = true;
            this.buttonDump.Click += new System.EventHandler(this.buttonDump_Click);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button buttonRestore;
        private System.Windows.Forms.Button buttonDump;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
