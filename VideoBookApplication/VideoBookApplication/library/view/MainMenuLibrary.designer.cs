namespace VideoBookApplication.common.view
{
    partial class MainMenuLibrary
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
            this.buttonNew = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonModify = new System.Windows.Forms.Button();
            this.buttonReport = new System.Windows.Forms.Button();
            this.buttonStats = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonNew
            // 
            this.buttonNew.Image = global::VideoBookApplication.Properties.Resources.write;
            this.buttonNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonNew.Location = new System.Drawing.Point(0, 0);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(127, 90);
            this.buttonNew.TabIndex = 0;
            this.buttonNew.Text = "Inserimento...";
            this.buttonNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.buttonNew_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Image = global::VideoBookApplication.Properties.Resources.trash;
            this.buttonDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonDelete.Location = new System.Drawing.Point(0, 0);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(127, 90);
            this.buttonDelete.TabIndex = 0;
            this.buttonDelete.Text = "Cancellazione...";
            this.buttonDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Image = global::VideoBookApplication.Properties.Resources.search;
            this.buttonSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonSearch.Location = new System.Drawing.Point(0, 0);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(127, 90);
            this.buttonSearch.TabIndex = 0;
            this.buttonSearch.Text = "Cerca...";
            this.buttonSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonModify
            // 
            this.buttonModify.Image = global::VideoBookApplication.Properties.Resources.TextEdit;
            this.buttonModify.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonModify.Location = new System.Drawing.Point(0, 0);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Size = new System.Drawing.Size(127, 90);
            this.buttonModify.TabIndex = 0;
            this.buttonModify.Text = "Modifica...";
            this.buttonModify.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonModify.UseVisualStyleBackColor = true;
            this.buttonModify.Click += new System.EventHandler(this.buttonModify_Click);
            // 
            // buttonReport
            // 
            this.buttonReport.Image = global::VideoBookApplication.Properties.Resources.document;
            this.buttonReport.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonReport.Location = new System.Drawing.Point(0, 0);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(127, 90);
            this.buttonReport.TabIndex = 0;
            this.buttonReport.Text = "Report";
            this.buttonReport.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonReport.UseVisualStyleBackColor = true;
            this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // buttonStats
            // 
            this.buttonStats.Image = global::VideoBookApplication.Properties.Resources.kchart;
            this.buttonStats.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonStats.Location = new System.Drawing.Point(0, 0);
            this.buttonStats.Name = "buttonStats";
            this.buttonStats.Size = new System.Drawing.Size(127, 90);
            this.buttonStats.TabIndex = 0;
            this.buttonStats.Text = "Statistiche";
            this.buttonStats.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonStats.UseVisualStyleBackColor = true;
            this.buttonStats.Click += new System.EventHandler(this.buttonStats_Click);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonModify;
        private System.Windows.Forms.Button buttonReport;
        private System.Windows.Forms.Button buttonStats;
    }
}
