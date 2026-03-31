using System;
using System.Collections.Generic;
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
        private bool trackEndedHandled = false;
        private IWMPPlaylist wmpPlaylist;

        public Form1()
        {
            InitializeComponent();
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

                        // Add to Windows Media Player playlist
                        try
                        {
                            IWMPMedia media = axWindowsMediaPlayer1.newMedia(file);
                            wmpPlaylist.appendItem(media);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error adding to WMP playlist: " + ex.Message);
                        }
                    }
                }
            }
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
                try
                {
                    // Stop current playback first
                    axWindowsMediaPlayer1.Ctlcontrols.stop();

                    // Clear the current URL
                    axWindowsMediaPlayer1.URL = "";

                    // Set the new URL
                    axWindowsMediaPlayer1.URL = playlist[index];

                    // Start playback
                    axWindowsMediaPlayer1.Ctlcontrols.play();

                    playlistBox.SelectedIndex = index;
                    txtPath.Text = System.IO.Path.GetFileName(playlist[index]);
                    trackEndedHandled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error playing track: " + ex.Message);
                }
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
                    currentTrackIndex = playlist.Count - 1;
                    MessageBox.Show("Queue finished. Use the player controls to restart.");
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
            // Create a new WMP playlist
            try
            {
                wmpPlaylist = axWindowsMediaPlayer1.playlistCollection.newPlaylist("CustomPlaylist");
                axWindowsMediaPlayer1.currentPlaylist = wmpPlaylist;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating WMP playlist: " + ex.Message);
            }

            // Initialize volume settings
            trackVolume.Value = 30;
            axWindowsMediaPlayer1.settings.volume = 30;

            // Show Windows Media Player controls
            axWindowsMediaPlayer1.uiMode = "full";

            // Setup timer to check playback state for queue progression
            playStateCheckTimer = new Timer();
            playStateCheckTimer.Interval = 1000; // Check every second
            playStateCheckTimer.Tick += PlayStateCheckTimer_Tick;
            playStateCheckTimer.Start();
        }

        private void PlayStateCheckTimer_Tick(object sender, EventArgs e)
        {
            // Check if current track has stopped
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
                // Stop playback
                try
                {
                    axWindowsMediaPlayer1.Ctlcontrols.stop();
                }
                catch { }

                // Clear the playlist
                playlist.Clear();
                playlistBox.Items.Clear();

                // Reset WMP playlist
                try
                {
                    wmpPlaylist = axWindowsMediaPlayer1.playlistCollection.newPlaylist("CustomPlaylist");
                    axWindowsMediaPlayer1.currentPlaylist = wmpPlaylist;
                }
                catch { }

                // Reset player state
                currentTrackIndex = -1;
                txtPath.Text = "Path";
                axWindowsMediaPlayer1.URL = "";

                MessageBox.Show("Playlist cleared successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_moveUp_Click(object sender, EventArgs e)
        {
            if (playlistBox.SelectedIndex <= 0)
            {
                MessageBox.Show("Select a track to move up (not the first one).");
                return;
            }

            int selectedIndex = playlistBox.SelectedIndex;
            int newIndex = selectedIndex - 1;

            // Swap in playlist
            string temp = playlist[selectedIndex];
            playlist[selectedIndex] = playlist[newIndex];
            playlist[newIndex] = temp;

            // Swap in listbox
            object tempItem = playlistBox.Items[selectedIndex];
            playlistBox.Items[selectedIndex] = playlistBox.Items[newIndex];
            playlistBox.Items[newIndex] = tempItem;

            // Swap in WMP playlist
            try
            {
                IWMPMedia mediaSelected = wmpPlaylist.get_Item(selectedIndex);
                IWMPMedia mediaNew = wmpPlaylist.get_Item(newIndex);

                wmpPlaylist.removeItem(mediaSelected);
                wmpPlaylist.insertItem(newIndex, mediaSelected);
            }
            catch { }

            // Update current track index if needed
            if (currentTrackIndex == selectedIndex)
                currentTrackIndex = newIndex;
            else if (currentTrackIndex == newIndex)
                currentTrackIndex = selectedIndex;

            // Select the moved item
            playlistBox.SelectedIndex = newIndex;
        }

        private void btn_moveDown_Click(object sender, EventArgs e)
        {
            if (playlistBox.SelectedIndex < 0 || playlistBox.SelectedIndex >= playlistBox.Items.Count - 1)
            {
                MessageBox.Show("Select a track to move down (not the last one).");
                return;
            }

            int selectedIndex = playlistBox.SelectedIndex;
            int newIndex = selectedIndex + 1;

            // Swap in playlist
            string temp = playlist[selectedIndex];
            playlist[selectedIndex] = playlist[newIndex];
            playlist[newIndex] = temp;

            // Swap in listbox
            object tempItem = playlistBox.Items[selectedIndex];
            playlistBox.Items[selectedIndex] = playlistBox.Items[newIndex];
            playlistBox.Items[newIndex] = tempItem;

            // Swap in WMP playlist
            try
            {
                IWMPMedia mediaSelected = wmpPlaylist.get_Item(selectedIndex);
                IWMPMedia mediaNew = wmpPlaylist.get_Item(newIndex);

                wmpPlaylist.removeItem(mediaNew);
                wmpPlaylist.insertItem(selectedIndex, mediaNew);
            }
            catch { }

            // Update current track index if needed
            if (currentTrackIndex == selectedIndex)
                currentTrackIndex = newIndex;
            else if (currentTrackIndex == newIndex)
                currentTrackIndex = selectedIndex;

            // Select the moved item
            playlistBox.SelectedIndex = newIndex;
        }
    }
}
