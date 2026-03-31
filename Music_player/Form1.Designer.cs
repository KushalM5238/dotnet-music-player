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
            this.btn_play = new System.Windows.Forms.Button();
            this.btn_browse = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.Label();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.trackVolume = new System.Windows.Forms.TrackBar();
            this.lblVolume = new System.Windows.Forms.Label();
            this.playlistBox = new System.Windows.Forms.ListBox();
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_previous = new System.Windows.Forms.Button();
            this.pictureBox_AlbumArt = new System.Windows.Forms.PictureBox();
            this.btn_clearList = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_AlbumArt)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_play
            // 
            this.btn_play.Location = new System.Drawing.Point(157, 315);
            this.btn_play.Margin = new System.Windows.Forms.Padding(4);
            this.btn_play.Name = "btn_play";
            this.btn_play.Size = new System.Drawing.Size(100, 30);
            this.btn_play.TabIndex = 0;
            this.btn_play.Text = "Play";
            this.btn_play.UseVisualStyleBackColor = true;
            this.btn_play.Click += new System.EventHandler(this.btn_play_Click);
            // 
            // btn_browse
            // 
            this.btn_browse.Location = new System.Drawing.Point(413, 315);
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
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(0, 288);
            this.axWindowsMediaPlayer1.Margin = new System.Windows.Forms.Padding(4);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(647, 46);
            this.axWindowsMediaPlayer1.TabIndex = 3;
            // 
            // trackVolume
            // 
            this.trackVolume.Location = new System.Drawing.Point(591, 174);
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
            this.playlistBox.Location = new System.Drawing.Point(259, 14);
            this.playlistBox.Margin = new System.Windows.Forms.Padding(4);
            this.playlistBox.Name = "playlistBox";
            this.playlistBox.Size = new System.Drawing.Size(388, 292);
            this.playlistBox.TabIndex = 6;
            this.playlistBox.DoubleClick += new System.EventHandler(this.playlistBox_DoubleClick);
            // 
            // btn_next
            // 
            this.btn_next.Location = new System.Drawing.Point(288, 315);
            this.btn_next.Margin = new System.Windows.Forms.Padding(4);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(100, 30);
            this.btn_next.TabIndex = 7;
            this.btn_next.Text = "Next";
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // btn_previous
            // 
            this.btn_previous.Location = new System.Drawing.Point(16, 315);
            this.btn_previous.Margin = new System.Windows.Forms.Padding(4);
            this.btn_previous.Name = "btn_previous";
            this.btn_previous.Size = new System.Drawing.Size(100, 30);
            this.btn_previous.TabIndex = 8;
            this.btn_previous.Text = "Previous";
            this.btn_previous.UseVisualStyleBackColor = true;
            this.btn_previous.Click += new System.EventHandler(this.btn_previous_Click);
            // 
            // pictureBox_AlbumArt
            // 
            this.pictureBox_AlbumArt.BackColor = System.Drawing.Color.LightGray;
            this.pictureBox_AlbumArt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_AlbumArt.Location = new System.Drawing.Point(16, 41);
            this.pictureBox_AlbumArt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox_AlbumArt.Name = "pictureBox_AlbumArt";
            this.pictureBox_AlbumArt.Size = new System.Drawing.Size(214, 221);
            this.pictureBox_AlbumArt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_AlbumArt.TabIndex = 9;
            this.pictureBox_AlbumArt.TabStop = false;
            // 
            // btn_clearList
            // 
            this.btn_clearList.Location = new System.Drawing.Point(536, 315);
            this.btn_clearList.Margin = new System.Windows.Forms.Padding(4);
            this.btn_clearList.Name = "btn_clearList";
            this.btn_clearList.Size = new System.Drawing.Size(100, 30);
            this.btn_clearList.TabIndex = 10;
            this.btn_clearList.Text = "Clear List";
            this.btn_clearList.UseVisualStyleBackColor = true;
            this.btn_clearList.Click += new System.EventHandler(this.btn_clearList_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 366);
            this.Controls.Add(this.btn_clearList);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.btn_play);
            this.Controls.Add(this.pictureBox_AlbumArt);
            this.Controls.Add(this.btn_previous);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.playlistBox);
            this.Controls.Add(this.trackVolume);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Music Player";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_AlbumArt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.Button btn_browse;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.TrackBar trackVolume;
        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.Label txtPath;
        private System.Windows.Forms.ListBox playlistBox;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Button btn_previous;
        private System.Windows.Forms.PictureBox pictureBox_AlbumArt;
        private System.Windows.Forms.Button btn_clearList;
    }
}

