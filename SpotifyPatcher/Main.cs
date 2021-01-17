using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Drawing;

namespace SpotifyPatcher
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            foreach (var scrn in Screen.AllScreens)
            {
                if (scrn.Bounds.Contains(this.Location))
                {
                    this.Location = new Point(scrn.Bounds.Right - this.Width, scrn.Bounds.Top);
                    return;
                }
            }
            /*

            SPOTIFYPATCHER
            AUTHOR - TAKAOVI
            GITHUB - https://github.com/Takaovi/SpotifyPatcher

            */
        }

        //Movable form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

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

        //1
        private void InstallSpotify(bool i)
        {
            Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"\Resources\Exe\Spotify.exe");

            if (i) Worker.RunWorkerAsync();
        }

        //2
        private void PatchAds(bool i, bool c)
        {
            if (System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Spotify"))
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
                        MessageBox.Show("If the patch is not working, please create a bug report to the Github page", "Patched successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please make sure Spotify has been installed successfully", "Patch possibly failed", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
            }
        }

        //3
        private void PatchUpdate(bool i)
        {
            if (System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Spotify"))
            {
                SecondWorker.RunWorkerAsync();

                var proc = Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Spotify\Spotify.exe");
                proc.EnableRaisingEvents = true;
                proc.Exited += new EventHandler(proc_Exited);
                //p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.Start();

                void proc_Exited(object sndr, EventArgs x)
                {
                    Worker.CancelAsync();
                    var p = Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"\Resources\Batch\NoUpdates.bat");
                    p.EnableRaisingEvents = true;
                    p.Exited += new EventHandler(p_Exited);
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    p.Start();

                    //Batch file exited
                    void p_Exited(object sender, EventArgs e)
                    {
                        //If user wanted to patch all
                        if (i)
                        {
                            MessageBox.Show("To make sure it works, reboot your pc and check if you get ads. \n\nVisit my Github @Takaovi if you want to contribute or report bugs", "Spotify Patch Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
                        }
                        //If user simply used the patch update button
                        else if (!i)
                        {
                            MessageBox.Show("If the patch is not working, please create a bug report to the Github page.", "Patched successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
                        }
                    }
                }
            }
            else MessageBox.Show("Spotify is not installed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
        }

        //Part of 1 and 2
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            bool c = true;

            if (this.Worker.CancellationPending)
            {
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

        private void SecondWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            bool c = true;

            if (this.Worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            while (c)
                if (Process.GetProcessesByName("Spotify").Length > 3)
                {
                    c = false;
                    Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"\Resources\Batch\Regedit.bat");
                    foreach (Process p in Process.GetProcessesByName("Spotify"))
                    {
                        //This currently kills every process other than SpotifyWebHelper.exe
                        p.Kill();
                    }
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
            if (this.SecondWorker.IsBusy)
            {
                SecondWorker.CancelAsync();
            }
            Application.Exit();
        }
    }
}