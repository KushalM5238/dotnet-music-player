namespace Music_player
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_browse = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.Label();
            this.trackVolume = new System.Windows.Forms.TrackBar();
            this.lblVolume = new System.Windows.Forms.Label();
            this.playlistBox = new System.Windows.Forms.ListBox();
            this.btn_clearList = new System.Windows.Forms.Button();
            this.btn_moveUp = new System.Windows.Forms.Button();
            this.btn_moveDown = new System.Windows.Forms.Button();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.trackVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_browse
            // 
            this.btn_browse.Location = new System.Drawing.Point(124, 173);
            this.btn_browse.Margin = new System.Windows.Forms.Padding(4);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(100, 30);
            this.btn_browse.TabIndex = 1;
            this.btn_browse.Text = "Add Files";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // txtPath
            // 
            this.txtPath.AutoSize = true;
            this.txtPath.Location = new System.Drawing.Point(479, 196);
            this.txtPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(34, 16);
            this.txtPath.TabIndex = 2;
            this.txtPath.Text = "Path";
            // 
            // trackVolume
            // 
            this.trackVolume.Location = new System.Drawing.Point(487, 11);
            this.trackVolume.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.trackVolume.Maximum = 100;
            this.trackVolume.Name = "trackVolume";
            this.trackVolume.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackVolume.Size = new System.Drawing.Size(56, 130);
            this.trackVolume.TabIndex = 4;
            this.trackVolume.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackVolume.Value = 30;
            this.trackVolume.Scroll += new System.EventHandler(this.trackVolume_Scroll);
            // 
            // lblVolume
            // 
            this.lblVolume.AutoSize = true;
            this.lblVolume.Location = new System.Drawing.Point(420, 196);
            this.lblVolume.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(25, 16);
            this.lblVolume.TabIndex = 5;
            this.lblVolume.Text = "vol";
            // 
            // playlistBox
            // 
            this.playlistBox.FormattingEnabled = true;
            this.playlistBox.ItemHeight = 16;
            this.playlistBox.Location = new System.Drawing.Point(13, 1);
            this.playlistBox.Margin = new System.Windows.Forms.Padding(4);
            this.playlistBox.Name = "playlistBox";
            this.playlistBox.Size = new System.Drawing.Size(560, 164);
            this.playlistBox.TabIndex = 6;
            this.playlistBox.DoubleClick += new System.EventHandler(this.playlistBox_DoubleClick);
            // 
            // btn_clearList
            // 
            this.btn_clearList.Location = new System.Drawing.Point(332, 173);
            this.btn_clearList.Margin = new System.Windows.Forms.Padding(4);
            this.btn_clearList.Name = "btn_clearList";
            this.btn_clearList.Size = new System.Drawing.Size(100, 30);
            this.btn_clearList.TabIndex = 10;
            this.btn_clearList.Text = "Clear List";
            this.btn_clearList.UseVisualStyleBackColor = true;
            this.btn_clearList.Click += new System.EventHandler(this.btn_clearList_Click);
            // 
            // btn_moveUp
            // 
            this.btn_moveUp.Location = new System.Drawing.Point(536, 173);
            this.btn_moveUp.Margin = new System.Windows.Forms.Padding(4);
            this.btn_moveUp.Name = "btn_moveUp";
            this.btn_moveUp.Size = new System.Drawing.Size(100, 25);
            this.btn_moveUp.TabIndex = 11;
            this.btn_moveUp.Text = "Move Up";
            this.btn_moveUp.UseVisualStyleBackColor = true;
            this.btn_moveUp.Click += new System.EventHandler(this.btn_moveUp_Click);
            // 
            // btn_moveDown
            // 
            this.btn_moveDown.Location = new System.Drawing.Point(536, 215);
            this.btn_moveDown.Margin = new System.Windows.Forms.Padding(4);
            this.btn_moveDown.Name = "btn_moveDown";
            this.btn_moveDown.Size = new System.Drawing.Size(100, 25);
            this.btn_moveDown.TabIndex = 12;
            this.btn_moveDown.Text = "Move Down";
            this.btn_moveDown.UseVisualStyleBackColor = true;
            this.btn_moveDown.Click += new System.EventHandler(this.btn_moveDown_Click);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(0, 248);
            this.axWindowsMediaPlayer1.Margin = new System.Windows.Forms.Padding(4);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(647, 46);
            this.axWindowsMediaPlayer1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 366);
            this.Controls.Add(this.btn_clearList);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.btn_moveDown);
            this.Controls.Add(this.btn_moveUp);
            this.Controls.Add(this.playlistBox);
            this.Controls.Add(this.trackVolume);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Music Player";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_browse;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.TrackBar trackVolume;
        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.Label txtPath;
        private System.Windows.Forms.ListBox playlistBox;
        private System.Windows.Forms.Button btn_clearList;
        private System.Windows.Forms.Button btn_moveUp;
        private System.Windows.Forms.Button btn_moveDown;
    }
}

