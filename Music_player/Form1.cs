using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using WMPLib;

namespace Music_player
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        private List<string> playlist = new List<string>();
        private int currentTrackIndex = -1;
        private bool isAutoPlay = true;
        private bool loopQueue = false;
        private Timer playStateCheckTimer;
        private Bitmap defaultAlbumArt;
        private bool trackEndedHandled = false;

        public Form1()
        {
            InitializeComponent();
            CreateDefaultAlbumArt();
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            if (playlist.Count == 0)
            {
                MessageBox.Show("Playlist is empty. Please add files.");
                return;
            }

            if (currentTrackIndex < 0)
            {
                currentTrackIndex = 0;
            }

            if (btn_play.Text == "Play")
            {
                // Check if we're resuming the same track or starting a new one
                if (axWindowsMediaPlayer1.URL != playlist[currentTrackIndex])
                {
                    // New track - load it
                    axWindowsMediaPlayer1.URL = playlist[currentTrackIndex];
                    LoadAlbumArt(playlist[currentTrackIndex]);
                }

                // Resume playback from current position
                axWindowsMediaPlayer1.Ctlcontrols.play();
                btn_play.Text = "Pause";
                playlistBox.SelectedIndex = currentTrackIndex;
                txtPath.Text = System.IO.Path.GetFileName(playlist[currentTrackIndex]);
                trackEndedHandled = false;
            }
            else if (btn_play.Text == "Pause")
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
                btn_play.Text = "Play";
            }
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select MP3 Files";
            ofd.Filter = "MP3 Files (*.mp3)|*.mp3|All Files (*.*)|*.*";
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in ofd.FileNames)
                {
                    if (!playlist.Contains(file))
                    {
                        playlist.Add(file);
                        playlistBox.Items.Add(System.IO.Path.GetFileName(file));
                    }
                }
            }
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (playlist.Count == 0)
            {
                MessageBox.Show("Playlist is empty.");
                return;
            }

            currentTrackIndex++;
            if (currentTrackIndex >= playlist.Count)
            {
                currentTrackIndex = 0;
            }

            PlayTrack(currentTrackIndex);
        }

        private void btn_previous_Click(object sender, EventArgs e)
        {
            if (playlist.Count == 0)
            {
                MessageBox.Show("Playlist is empty.");
                return;
            }

            currentTrackIndex--;
            if (currentTrackIndex < 0)
            {
                currentTrackIndex = playlist.Count - 1;
            }

            PlayTrack(currentTrackIndex);
        }

        private void playlistBox_DoubleClick(object sender, EventArgs e)
        {
            if (playlistBox.SelectedIndex >= 0)
            {
                currentTrackIndex = playlistBox.SelectedIndex;
                PlayTrack(currentTrackIndex);
            }
        }

        private void PlayTrack(int index)
        {
            if (index >= 0 && index < playlist.Count)
            {
                axWindowsMediaPlayer1.URL = playlist[index];
                axWindowsMediaPlayer1.Ctlcontrols.play();
                btn_play.Text = "Pause";
                playlistBox.SelectedIndex = index;
                txtPath.Text = System.IO.Path.GetFileName(playlist[index]);
                LoadAlbumArt(playlist[index]);
                trackEndedHandled = false;
            }
        }

        private void CreateDefaultAlbumArt()
        {
            // Create a default album art image (music note symbol)
            defaultAlbumArt = new Bitmap(165, 165);
            using (Graphics g = Graphics.FromImage(defaultAlbumArt))
            {
                g.Clear(Color.LightGray);
                using (Pen pen = new Pen(Color.DarkGray, 3))
                {
                    // Draw a simple music note
                    g.DrawEllipse(pen, 50, 100, 30, 30);
                    g.DrawLine(pen, 80, 100, 85, 40);
                    g.DrawArc(pen, 85, 35, 40, 30, 0, 180);
                }
                g.DrawString("♪ Music ♪", new Font("Arial", 16, FontStyle.Bold), 
                    new SolidBrush(Color.DarkGray), new PointF(15, 60));
            }
            pictureBox_AlbumArt.Image = defaultAlbumArt;
        }

        private void LoadAlbumArt(string filePath)
        {
            try
            {
                // Check if there's an associated image file in the same directory
                string directory = Path.GetDirectoryName(filePath);
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);

                // Look for common album art file names
                string[] albumArtNames = {
                    Path.Combine(directory, "cover.jpg"),
                    Path.Combine(directory, "cover.png"),
                    Path.Combine(directory, "album.jpg"),
                    Path.Combine(directory, "album.png"),
                    Path.Combine(directory, fileNameWithoutExtension + ".jpg"),
                    Path.Combine(directory, fileNameWithoutExtension + ".png")
                };

                foreach (string artPath in albumArtNames)
                {
                    if (File.Exists(artPath))
                    {
                        try
                        {
                            // Create a copy of the image to avoid file locking issues
                            Bitmap albumArt = new Bitmap(artPath);
                            Bitmap displayImage = new Bitmap(albumArt);
                            albumArt.Dispose();

                            // Dispose old image if it's not the default
                            if (pictureBox_AlbumArt.Image != null && pictureBox_AlbumArt.Image != defaultAlbumArt)
                            {
                                pictureBox_AlbumArt.Image.Dispose();
                            }

                            pictureBox_AlbumArt.Image = displayImage;
                            return;
                        }
                        catch
                        {
                            // If loading fails, continue to next option
                        }
                    }
                }

                // No album art file found, use default
                if (pictureBox_AlbumArt.Image != defaultAlbumArt)
                {
                    if (pictureBox_AlbumArt.Image != null)
                    {
                        pictureBox_AlbumArt.Image.Dispose();
                    }
                    pictureBox_AlbumArt.Image = defaultAlbumArt;
                }
            }
            catch
            {
                // If any error occurs, show default album art
                pictureBox_AlbumArt.Image = defaultAlbumArt;
            }
        }

        private void HandleTrackEnded()
        {
            if (!isAutoPlay)
                return;

            // Move to next track in queue
            currentTrackIndex++;

            if (currentTrackIndex >= playlist.Count)
            {
                if (loopQueue)
                {
                    // Loop back to beginning
                    currentTrackIndex = 0;
                    PlayTrack(currentTrackIndex);
                }
                else
                {
                    // Stop at end of queue
                    btn_play.Text = "Play";
                    currentTrackIndex = playlist.Count - 1;
                    MessageBox.Show("Queue finished. Click Play to restart.");
                }
            }
            else
            {
                // Play next track
                PlayTrack(currentTrackIndex);
            }
        }

        private void trackVolume_Scroll(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.volume = trackVolume.Value;
            lblVolume.Text = "Volume: " + trackVolume.Value + "%";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize volume settings
            trackVolume.Value = 30;
            axWindowsMediaPlayer1.settings.volume = 30;

            // Show Windows Media Player controls
            axWindowsMediaPlayer1.uiMode = "full";

            // Ensure picture box is visible and shows default album art
            pictureBox_AlbumArt.Visible = true;
            pictureBox_AlbumArt.Image = defaultAlbumArt;

            // Setup timer to check playback state for queue progression
            playStateCheckTimer = new Timer();
            playStateCheckTimer.Interval = 1000; // Check every second
            playStateCheckTimer.Tick += PlayStateCheckTimer_Tick;
            playStateCheckTimer.Start();
        }

        private void PlayStateCheckTimer_Tick(object sender, EventArgs e)
        {
            // Check if current track has stopped
            // WMPPlayState.wmppsStopped = 1
            if (axWindowsMediaPlayer1.playState == WMPPlayState.wmppsStopped && currentTrackIndex >= 0 && !trackEndedHandled)
            {
                trackEndedHandled = true;
                HandleTrackEnded();
            }
        }

        private void btn_clearList_Click(object sender, EventArgs e)
        {
            // Confirm before clearing the playlist
            DialogResult result = MessageBox.Show(
                "Are you sure you want to clear the entire playlist?",
                "Clear Playlist",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Stop playback if playing
                if (btn_play.Text == "Pause")
                {
                    axWindowsMediaPlayer1.Ctlcontrols.stop();
                }

                // Clear the playlist
                playlist.Clear();
                playlistBox.Items.Clear();

                // Reset player state
                currentTrackIndex = -1;
                btn_play.Text = "Play";
                txtPath.Text = "Path";
                axWindowsMediaPlayer1.URL = "";

                // Show default album art
                pictureBox_AlbumArt.Image = defaultAlbumArt;

                MessageBox.Show("Playlist cleared successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
