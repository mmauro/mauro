namespace VideoBookApplication.library.view
{
    partial class StatPanel
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textLastBook = new System.Windows.Forms.RichTextBox();
            this.textNumbers = new System.Windows.Forms.RichTextBox();
            this.buttonGraph = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Numeriche";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(8, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ultimo Libro";
            // 
            // textLastBook
            // 
            this.textLastBook.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textLastBook.Cursor = System.Windows.Forms.Cursors.Default;
            this.textLastBook.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textLastBook.Location = new System.Drawing.Point(0, 0);
            this.textLastBook.Name = "textLastBook";
            this.textLastBook.ReadOnly = true;
            this.textLastBook.Size = new System.Drawing.Size(100, 96);
            this.textLastBook.TabIndex = 0;
            this.textLastBook.Text = "";
            // 
            // textNumbers
            // 
            this.textNumbers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textNumbers.Cursor = System.Windows.Forms.Cursors.Default;
            this.textNumbers.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNumbers.Location = new System.Drawing.Point(0, 0);
            this.textNumbers.Name = "textNumbers";
            this.textNumbers.ReadOnly = true;
            this.textNumbers.Size = new System.Drawing.Size(100, 96);
            this.textNumbers.TabIndex = 0;
            this.textNumbers.Text = "";
            // 
            // buttonGraph
            // 
            this.buttonGraph.BackgroundImage = global::VideoBookApplication.Properties.Resources.chart;
            this.buttonGraph.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonGraph.Location = new System.Drawing.Point(323, 136);
            this.buttonGraph.Name = "buttonGraph";
            this.buttonGraph.Size = new System.Drawing.Size(48, 48);
            this.buttonGraph.TabIndex = 0;
            this.buttonGraph.UseVisualStyleBackColor = true;
            this.buttonGraph.Click += new System.EventHandler(this.buttonGraph_Click);
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
            // StatPanel
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Size = new System.Drawing.Size(600, 350);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox textLastBook;
        private System.Windows.Forms.RichTextBox textNumbers;
        private System.Windows.Forms.Button buttonGraph;
        private System.Windows.Forms.Button buttonOk;



    }
}
