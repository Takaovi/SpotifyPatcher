using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
/*
    SPOTIFYPATCHER
    AUTHOR - TAKAOVI
    GITHUB - https://github.com/Takaovi/SpotifyPatcher
*/
namespace SpotifyPatcher
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            NoButtonBorders();
            EditRegedit();

            foreach (var scrn in Screen.AllScreens)
            {
                if (scrn.Bounds.Contains(Location))
                {
                    Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - Width) / 2, scrn.Bounds.Top);
                    return;
                }
            }
        }

        // Movable form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        // Panel moves form
        void DragBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        void NoButtonBorders()
        {
            DoEverythingButton.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            InstallSpotifyButton.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            UninstallSpotifyButton.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            PatchAdsButton.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            PatchUpdateButton.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            GithubButton.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
        }

        void EditRegedit()
        {
            // Add program to startup
            try
            {
                var rk = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                rk.SetValue("SpotifyStopUpdate", AppDomain.CurrentDomain.BaseDirectory + @"Resources\Batch\Regedit.bat");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Critical error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000); this.Close(); }
        }

        // 1
        void InstallSpotify(bool i)
        {
            Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"\Resources\Exe\Spotify.exe");

            if (i) Worker.RunWorkerAsync();
        }

        // 2
        void PatchAds(bool i, bool c)
        {
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Spotify"))
            {
                // Start NoAds batch file 
                var p = Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"Resources\Batch\NoAds.bat");
                p.EnableRaisingEvents = true;
                p.Exited += new EventHandler(p_Exited);
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                if (c)
                {
                    Worker.CancelAsync();
                }

                // Batch file exited
                void p_Exited(object sender, EventArgs e)
                {
                    // If user wanted to patch all
                    if (i)
                    {
                        PatchUpdate(true);
                    }
                    // If user simply used the patch ads button only
                    if (!i)
                    {
                        MessageBox.Show("If the patch is not working, please create a bug report to the Github page", "Patched successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please make sure Spotify has been installed successfully", "Patch failed", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
            }
        }

        // 3
        void PatchUpdate(bool i)
        {
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Spotify"))
            {
                SecondWorker.RunWorkerAsync();

                var proc = Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Spotify\Spotify.exe");
                proc.EnableRaisingEvents = true;
                proc.Exited += new EventHandler(proc_Exited);
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.Start();

                void proc_Exited(object sndr, EventArgs x)
                {
                    Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"Resources\Batch\NoUpdates.bat");

                    Worker.CancelAsync();
                    var p = Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"Resources\Batch\ModifyHosts.bat");
                    p.EnableRaisingEvents = true;
                    p.Exited += new EventHandler(p_Exited);
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                    // Batch file exited
                    void p_Exited(object sender, EventArgs e)
                    {
                        // If user wanted to patch all
                        // Patch all is done, inform the user
                        if (i)
                        {
                            MessageBox.Show("To make sure it works, reboot your pc and check if you get ads. \n\nVisit my Github @Takaovi if you want to contribute or report bugs. \n\nSpotify will now automatically start after you close this window...", "Spotify Patch Success", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
                            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Spotify\Spotify.exe");
                        }
                        // If user simply used the patch update button only
                        else if (!i)
                        {
                            MessageBox.Show("If the patch is not working, please create a bug report to the Github page.", "Patched successfully", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
                        }
                    }
                }
            }
            else MessageBox.Show("Spotify is not installed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
        }

        // Part of 1 and 2
        void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            bool c = true;

            if (Worker.CancellationPending)
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

        void SecondWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            bool c = true;

            if (Worker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            while (c)
                if (Process.GetProcessesByName("Spotify").Length > 3)
                {
                    c = false;
                    Process.Start(AppDomain.CurrentDomain.BaseDirectory + @"Resources\Batch\Regedit.bat");
                }
        }

        // 1' Button
        void InstallSpotifyButton_Click(object sender, EventArgs e)
        {
            try { InstallSpotify(false); }
            catch (Exception ex) { MessageBox.Show(ex.Message + " \n\nYou are most likely missing a file from the Resources folder. Are the exe and the Resource folder in the same directory?", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000); }
        }

        // 2' Buttom
        void PatchAdsButton_Click(object sender, EventArgs e)
        {
            try { PatchAds(false, false); }
            catch (Exception ex) { MessageBox.Show(ex.Message + " \n\nYou are most likely missing a file from the Resources folder. Are the exe and the Resource folder in the same directory?", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000); }
        }

        // 3' Button
        void PatchUpdateButton_Click(object sender, EventArgs e)
        {
            try { PatchUpdate(false); }
            catch (Exception ex) { MessageBox.Show(ex.Message + " \n\nYou are most likely missing a file from the Resources folder. Are the exe and the Resource folder in the same directory?", "Critical error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000); }
        }

        // Do every patch
        void DoEverythingButton_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(Application.StartupPath + @"\Resources"))
            {
                MessageBox.Show("You're missing the resources folder, the patcher can not continue.", "Critical error!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
            }
            else
            {
                try
                {
                    foreach (Process p in Process.GetProcessesByName("Spotify"))
                        // This currently kills every process other than SpotifyWebHelper.exe
                        p.Kill();

                    Start:
                    if (Process.GetProcessesByName("Spotify").Length < 2)
                        InstallSpotify(true);
                    else goto Start;
                }
                catch { /*Do Nothing*/ }
            }
        }

        void UninstallSpotifyButton_Click(object sender, EventArgs e)
        {
            try { Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Spotify\Spotify.exe", "/uninstall"); }
            catch { MessageBox.Show(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Spotify\Spotify.exe" + " was not found. Have you installed Spotify?", "Fatal error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000); }
        }

        void GithubButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Takaovi/SpotifyPatcher");
        }

        void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Worker.IsBusy)
            {
                Worker.CancelAsync();
            }

            if (SecondWorker.IsBusy)
            {
                SecondWorker.CancelAsync();
            }
        }
    }
}