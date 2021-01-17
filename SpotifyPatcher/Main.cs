using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace SpotifyPatcher
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            //SPOTIFYPATCHER
            //AUTHOR - TAKAOVI
            //GITHUB - https://github.com/Takaovi/SpotifyPatcher
        }

        //Movable form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        //1
        private void InstallSpotify(bool i)
        {

            Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"\Resources\Exe\Spotify.exe");

            if (i) { Worker.RunWorkerAsync(); }
        }

        //2
        private void PatchAds(bool i, bool c)
        {
            //If user pressed patch all button
            if (i)
            {

                var p = Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"\Resources\Batch\NoAds.bat");
                p.EnableRaisingEvents = true;
                p.Exited += new EventHandler(p_Exited);
                //p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                if (c)
                {
                    Worker.CancelAsync();
                    p.Start();
                }

            }
            //If user pressed Disable ads button only
            else if (!i)
            {
                var p = Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"\Resources\Batch\NoAds.bat");
                p.EnableRaisingEvents = true;
                p.Exited += new EventHandler(p_Exited);
                //p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.Start();
            }
            //Batch file exited
            void p_Exited(object sender, EventArgs e)
            {
                if (i)
                {
                    PatchUpdate(true);
                }
                if (!i)
                {
                    if (!System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Spotify"))
                    {
                        MessageBox.Show("Please make sure Spotify has been installed successfully", "Patch possibly failed", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
                    }
                    else
                    {
                        MessageBox.Show("If the patch is not working, please create a bug report to the Github page", "Patched successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
                    }
                }
            }
        }

        //3
        private void PatchUpdate(bool i)
        {
            var p = Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"\Resources\Batch\NoUpdates.bat");
            p.EnableRaisingEvents = true;
            p.Exited += new EventHandler(p_Exited);
            //p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();

            //Batch file exited
            void p_Exited(object sender, EventArgs e)
            {
                if (i)
                {
                    if (System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Spotify"))
                    {
                        MessageBox.Show("To make sure it works, reboot your pc and check if you get ads. \n\nVisit my Github @Takaovi if you want to contribute or report bugs", "Spotify Patch Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
                    }
                    else
                    {
                        MessageBox.Show("Spotify got removed during installation. The cause is unknown.", "Patch unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
                    }
                }
                if (!System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Spotify"))
                {
                    MessageBox.Show("Please make sure Spotify has been installed successfully", "Patch possibly failed", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
                }
                else if (!i)
                {
                    MessageBox.Show("If the patch is not working, please create a bug report to the Github page.", "Patched successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
                }
            }
        }

        //Part of 1 and 2
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            bool c = true;

            if (this.Worker.CancellationPending)
            {
                c = false;
                e.Cancel = true;
                return;
            }

            while (c)
                if (Process.GetProcessesByName("Spotify").Length > 3)
                {
                    c = false;
                    PatchAds(true, true);
                }
        }

        //Panel moves form
        private void DragBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        //1' Button
        private void InstallSpotifyButton_Click(object sender, EventArgs e)
        {
            try { InstallSpotify(false); }
            catch (Exception ex) { MessageBox.Show(ex.Message + " \n\nYou are most likely missing a file from the Resources folder. Are the exe and the Resource folder in the same directory?", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000); }
        }

        //2' Buttom
        private void PatchAdsButton_Click(object sender, EventArgs e)
        {
            try { PatchAds(false, false); }
            catch (Exception ex) { MessageBox.Show(ex.Message + " \n\nYou are most likely missing a file from the Resources folder. Are the exe and the Resource folder in the same directory?", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000); }
        }

        //3' Button
        private void PatchUpdateButton_Click(object sender, EventArgs e)
        {
            try { PatchUpdate(false); }
            catch (Exception ex) { MessageBox.Show(ex.Message + " \n\nYou are most likely missing a file from the Resources folder. Are the exe and the Resource folder in the same directory?", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000); }
        }

        //Do every patch
        private void DoEverythingButton_Click(object sender, EventArgs e)
        {
            try {
                foreach (Process p in Process.GetProcessesByName("Spotify")) {
                    //This currently kills every process other than SpotifyWebHelper.exe
                    p.Kill();
                }
                Start:
                if (Process.GetProcessesByName("Spotify").Length < 2)
                    InstallSpotify(true);
                else goto Start;
            } catch { /*Do Nothing*/ }
        }

        private void UninstallSpotifyButton_Click(object sender, EventArgs e)
        {
            try { Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Spotify\Spotify.exe", "/uninstall"); }
            catch { MessageBox.Show(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Spotify\Spotify.exe" + " was not found. Have you installed Spotify?", "Fatal error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000); }

        }

        private void GithubButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Takaovi/SpotifyPatcher");
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (this.Worker.IsBusy)
            {
                Worker.CancelAsync();
            }
            Application.Exit();
        }
    }
}