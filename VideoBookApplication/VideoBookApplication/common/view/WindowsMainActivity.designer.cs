namespace VideoBookApplication.common.view
{
    partial class WindowsMainActivity
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
            this.components = new System.ComponentModel.Container();
            this.buttonLibrary = new System.Windows.Forms.Button();
            this.buttonMovie = new System.Windows.Forms.Button();
            this.buttonMusic = new System.Windows.Forms.Button();
            this.buttonSoftware = new System.Windows.Forms.Button();
            this.buttonAdvanced = new System.Windows.Forms.Button();
            this.buttonInfo = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonLibrary
            // 
            this.buttonLibrary.BackgroundImage = global::VideoBookApplication.Properties.Resources.Books;
            this.buttonLibrary.Location = new System.Drawing.Point(58, 95);
            this.buttonLibrary.Name = "buttonLibrary";
            this.buttonLibrary.Size = new System.Drawing.Size(64, 64);
            this.buttonLibrary.TabIndex = 6;
            this.buttonLibrary.UseVisualStyleBackColor = true;
            this.buttonLibrary.Click += new System.EventHandler(this.buttonLibrary_Click);
            // 
            // buttonMovie
            // 
            this.buttonMovie.BackgroundImage = global::VideoBookApplication.Properties.Resources.Movie;
            this.buttonMovie.Location = new System.Drawing.Point(163, 95);
            this.buttonMovie.Name = "buttonMovie";
            this.buttonMovie.Size = new System.Drawing.Size(64, 64);
            this.buttonMovie.TabIndex = 7;
            this.buttonMovie.UseVisualStyleBackColor = true;
            this.buttonMovie.Click += new System.EventHandler(this.buttonMovie_Click);
            // 
            // buttonMusic
            // 
            this.buttonMusic.BackgroundImage = global::VideoBookApplication.Properties.Resources.music;
            this.buttonMusic.Location = new System.Drawing.Point(58, 185);
            this.buttonMusic.Name = "buttonMusic";
            this.buttonMusic.Size = new System.Drawing.Size(64, 64);
            this.buttonMusic.TabIndex = 8;
            this.buttonMusic.UseVisualStyleBackColor = true;
            this.buttonMusic.Click += new System.EventHandler(this.buttonMusic_Click);
            // 
            // buttonSoftware
            // 
            this.buttonSoftware.BackgroundImage = global::VideoBookApplication.Properties.Resources.sw;
            this.buttonSoftware.Location = new System.Drawing.Point(163, 185);
            this.buttonSoftware.Name = "buttonSoftware";
            this.buttonSoftware.Size = new System.Drawing.Size(64, 64);
            this.buttonSoftware.TabIndex = 9;
            this.buttonSoftware.UseVisualStyleBackColor = true;
            this.buttonSoftware.Click += new System.EventHandler(this.buttonSoftware_Click);
            // 
            // buttonAdvanced
            // 
            this.buttonAdvanced.BackgroundImage = global::VideoBookApplication.Properties.Resources.advancedsettings;
            this.buttonAdvanced.Location = new System.Drawing.Point(108, 278);
            this.buttonAdvanced.Name = "buttonAdvanced";
            this.buttonAdvanced.Size = new System.Drawing.Size(64, 64);
            this.buttonAdvanced.TabIndex = 10;
            this.buttonAdvanced.UseVisualStyleBackColor = true;
            this.buttonAdvanced.Click += new System.EventHandler(this.buttonAdvanced_Click);
            // 
            // buttonInfo
            // 
            this.buttonInfo.BackgroundImage = global::VideoBookApplication.Properties.Resources.Info;
            this.buttonInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonInfo.Location = new System.Drawing.Point(58, 397);
            this.buttonInfo.Name = "buttonInfo";
            this.buttonInfo.Size = new System.Drawing.Size(64, 64);
            this.buttonInfo.TabIndex = 11;
            this.buttonInfo.UseVisualStyleBackColor = true;
            this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackgroundImage = global::VideoBookApplication.Properties.Resources.exit;
            this.buttonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonExit.Location = new System.Drawing.Point(163, 397);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(64, 64);
            this.buttonExit.TabIndex = 12;
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // WindowsMainActivity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 473);
            this.ControlBox = false;
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonInfo);
            this.Controls.Add(this.buttonAdvanced);
            this.Controls.Add(this.buttonSoftware);
            this.Controls.Add(this.buttonMusic);
            this.Controls.Add(this.buttonMovie);
            this.Controls.Add(this.buttonLibrary);
            this.Name = "WindowsMainActivity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VideoBookApplication";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLibrary;
        private System.Windows.Forms.Button buttonMovie;
        private System.Windows.Forms.Button buttonMusic;
        private System.Windows.Forms.Button buttonSoftware;
        private System.Windows.Forms.Button buttonAdvanced;
        private System.Windows.Forms.Button buttonInfo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonExit;
    }
}