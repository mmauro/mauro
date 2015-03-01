namespace VideoBookApplication.common.view
{
    partial class ExportReportMenu
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
            this.buttonReportCSV = new System.Windows.Forms.Button();
            this.buttonReportExcel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonReportWord = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonReportCSV
            // 
            this.buttonReportCSV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonReportCSV.Image = global::VideoBookApplication.Properties.Resources.csv;
            this.buttonReportCSV.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonReportCSV.Location = new System.Drawing.Point(0, 0);
            this.buttonReportCSV.Name = "buttonReportCSV";
            this.buttonReportCSV.Size = new System.Drawing.Size(127, 90);
            this.buttonReportCSV.TabIndex = 0;
            this.buttonReportCSV.Text = "Report CSV";
            this.buttonReportCSV.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonReportCSV.UseVisualStyleBackColor = true;
            this.buttonReportCSV.Click += new System.EventHandler(this.buttonReportCSV_Click);
            // 
            // buttonReportExcel
            // 
            this.buttonReportExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonReportExcel.Image = global::VideoBookApplication.Properties.Resources.Excel;
            this.buttonReportExcel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonReportExcel.Location = new System.Drawing.Point(0, 0);
            this.buttonReportExcel.Name = "buttonReportExcel";
            this.buttonReportExcel.Size = new System.Drawing.Size(127, 90);
            this.buttonReportExcel.TabIndex = 0;
            this.buttonReportExcel.Text = "Report EXCEL";
            this.buttonReportExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonReportExcel.UseVisualStyleBackColor = true;
            this.buttonReportExcel.Click += new System.EventHandler(this.buttonReportExcel_Click);
            // 
            // buttonReportWord
            // 
            this.buttonReportWord.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonReportWord.Image = global::VideoBookApplication.Properties.Resources.Word;
            this.buttonReportWord.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonReportWord.Location = new System.Drawing.Point(0, 0);
            this.buttonReportWord.Name = "buttonReportWord";
            this.buttonReportWord.Size = new System.Drawing.Size(127, 90);
            this.buttonReportWord.TabIndex = 0;
            this.buttonReportWord.Text = "Report WORD";
            this.buttonReportWord.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonReportWord.UseVisualStyleBackColor = true;
            this.buttonReportWord.Click += new System.EventHandler(this.buttonReportWord_Click);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Button buttonReportCSV;
        private System.Windows.Forms.Button buttonReportExcel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonReportWord;
    }
}
