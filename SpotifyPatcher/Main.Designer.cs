namespace SpotifyPatcher
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.PatchUpdateButton = new System.Windows.Forms.Button();
            this.InstallSpotifyButton = new System.Windows.Forms.Button();
            this.PatchAdsButton = new System.Windows.Forms.Button();
            this.DoEverythingButton = new System.Windows.Forms.Button();
            this.UninstallSpotifyButton = new System.Windows.Forms.Button();
            this.Worker = new System.ComponentModel.BackgroundWorker();
            this.DragBar = new System.Windows.Forms.Panel();
            this.CloseButton = new System.Windows.Forms.Label();
            this.GithubButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SecondWorker = new System.ComponentModel.BackgroundWorker();
            this.panel4 = new System.Windows.Forms.Panel();
            this.DragBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // PatchUpdateButton
            // 
            this.PatchUpdateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.PatchUpdateButton.FlatAppearance.BorderSize = 0;
            this.PatchUpdateButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.PatchUpdateButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.PatchUpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PatchUpdateButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PatchUpdateButton.ForeColor = System.Drawing.Color.White;
            this.PatchUpdateButton.Location = new System.Drawing.Point(610, 46);
            this.PatchUpdateButton.Name = "PatchUpdateButton";
            this.PatchUpdateButton.Size = new System.Drawing.Size(124, 35);
            this.PatchUpdateButton.TabIndex = 0;
            this.PatchUpdateButton.TabStop = false;
            this.PatchUpdateButton.Text = "Disable update";
            this.PatchUpdateButton.UseVisualStyleBackColor = false;
            this.PatchUpdateButton.Click += new System.EventHandler(this.PatchUpdateButton_Click);
            // 
            // InstallSpotifyButton
            // 
            this.InstallSpotifyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.InstallSpotifyButton.FlatAppearance.BorderSize = 0;
            this.InstallSpotifyButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.InstallSpotifyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.InstallSpotifyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InstallSpotifyButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InstallSpotifyButton.ForeColor = System.Drawing.Color.White;
            this.InstallSpotifyButton.Location = new System.Drawing.Point(220, 46);
            this.InstallSpotifyButton.Name = "InstallSpotifyButton";
            this.InstallSpotifyButton.Size = new System.Drawing.Size(124, 35);
            this.InstallSpotifyButton.TabIndex = 1;
            this.InstallSpotifyButton.TabStop = false;
            this.InstallSpotifyButton.Text = "Install old Spotify";
            this.InstallSpotifyButton.UseVisualStyleBackColor = false;
            this.InstallSpotifyButton.Click += new System.EventHandler(this.InstallSpotifyButton_Click);
            // 
            // PatchAdsButton
            // 
            this.PatchAdsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.PatchAdsButton.FlatAppearance.BorderSize = 0;
            this.PatchAdsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.PatchAdsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.PatchAdsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PatchAdsButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PatchAdsButton.ForeColor = System.Drawing.Color.White;
            this.PatchAdsButton.Location = new System.Drawing.Point(480, 46);
            this.PatchAdsButton.Name = "PatchAdsButton";
            this.PatchAdsButton.Size = new System.Drawing.Size(124, 35);
            this.PatchAdsButton.TabIndex = 2;
            this.PatchAdsButton.TabStop = false;
            this.PatchAdsButton.Text = "Disable ads";
            this.PatchAdsButton.UseVisualStyleBackColor = false;
            this.PatchAdsButton.Click += new System.EventHandler(this.PatchAdsButton_Click);
            // 
            // DoEverythingButton
            // 
            this.DoEverythingButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.DoEverythingButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            this.DoEverythingButton.FlatAppearance.BorderSize = 0;
            this.DoEverythingButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.DoEverythingButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.DoEverythingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DoEverythingButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoEverythingButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(129)))), ((int)(((byte)(246)))));
            this.DoEverythingButton.Location = new System.Drawing.Point(13, 46);
            this.DoEverythingButton.Name = "DoEverythingButton";
            this.DoEverythingButton.Size = new System.Drawing.Size(201, 35);
            this.DoEverythingButton.TabIndex = 3;
            this.DoEverythingButton.TabStop = false;
            this.DoEverythingButton.Text = "Patch All";
            this.DoEverythingButton.UseVisualStyleBackColor = false;
            this.DoEverythingButton.Click += new System.EventHandler(this.DoEverythingButton_Click);
            // 
            // UninstallSpotifyButton
            // 
            this.UninstallSpotifyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.UninstallSpotifyButton.FlatAppearance.BorderSize = 0;
            this.UninstallSpotifyButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.UninstallSpotifyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.UninstallSpotifyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UninstallSpotifyButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UninstallSpotifyButton.ForeColor = System.Drawing.Color.White;
            this.UninstallSpotifyButton.Location = new System.Drawing.Point(350, 46);
            this.UninstallSpotifyButton.Name = "UninstallSpotifyButton";
            this.UninstallSpotifyButton.Size = new System.Drawing.Size(124, 35);
            this.UninstallSpotifyButton.TabIndex = 4;
            this.UninstallSpotifyButton.TabStop = false;
            this.UninstallSpotifyButton.Text = "Uninstall Spotify";
            this.UninstallSpotifyButton.UseVisualStyleBackColor = false;
            this.UninstallSpotifyButton.Click += new System.EventHandler(this.UninstallSpotifyButton_Click);
            // 
            // Worker
            // 
            this.Worker.WorkerSupportsCancellation = true;
            this.Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Worker_DoWork);
            // 
            // DragBar
            // 
            this.DragBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.DragBar.Controls.Add(this.CloseButton);
            this.DragBar.Controls.Add(this.GithubButton);
            this.DragBar.Controls.Add(this.pictureBox1);
            this.DragBar.Location = new System.Drawing.Point(-5, -2);
            this.DragBar.Name = "DragBar";
            this.DragBar.Size = new System.Drawing.Size(759, 38);
            this.DragBar.TabIndex = 5;
            this.DragBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragBar_MouseDown);
            // 
            // CloseButton
            // 
            this.CloseButton.AutoSize = true;
            this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(129)))), ((int)(((byte)(246)))));
            this.CloseButton.Location = new System.Drawing.Point(723, 8);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(26, 25);
            this.CloseButton.TabIndex = 7;
            this.CloseButton.Text = "✕";
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // GithubButton
            // 
            this.GithubButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.GithubButton.FlatAppearance.BorderSize = 0;
            this.GithubButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.GithubButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.GithubButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GithubButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GithubButton.ForeColor = System.Drawing.Color.White;
            this.GithubButton.Location = new System.Drawing.Point(659, 6);
            this.GithubButton.Name = "GithubButton";
            this.GithubButton.Size = new System.Drawing.Size(58, 27);
            this.GithubButton.TabIndex = 8;
            this.GithubButton.TabStop = false;
            this.GithubButton.Text = "Github";
            this.GithubButton.UseVisualStyleBackColor = false;
            this.GithubButton.Click += new System.EventHandler(this.GithubButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::SpotifyPatcher.Properties.Resources.Logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(9, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(158, 35);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.panel1.Location = new System.Drawing.Point(-7, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(763, 10);
            this.panel1.TabIndex = 6;
            // 
            // SecondWorker
            // 
            this.SecondWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SecondWorker_DoWork);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(129)))), ((int)(((byte)(246)))));
            this.panel4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel4.Location = new System.Drawing.Point(-3, 89);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(757, 10);
            this.panel4.TabIndex = 7;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(747, 91);
            this.Controls.Add(this.PatchUpdateButton);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.DragBar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.UninstallSpotifyButton);
            this.Controls.Add(this.DoEverythingButton);
            this.Controls.Add(this.PatchAdsButton);
            this.Controls.Add(this.InstallSpotifyButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.DragBar.ResumeLayout(false);
            this.DragBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PatchUpdateButton;
        private System.Windows.Forms.Button InstallSpotifyButton;
        private System.Windows.Forms.Button PatchAdsButton;
        private System.Windows.Forms.Button DoEverythingButton;
        private System.Windows.Forms.Button UninstallSpotifyButton;
        private System.ComponentModel.BackgroundWorker Worker;
        private System.Windows.Forms.Panel DragBar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button GithubButton;
        private System.Windows.Forms.Label CloseButton;
        private System.ComponentModel.BackgroundWorker SecondWorker;
        private System.Windows.Forms.Panel panel4;
    }
}

