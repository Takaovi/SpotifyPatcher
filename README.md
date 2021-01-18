<p align="center">
<img src="https://i.imgur.com/gYdMVuO.png">
</p>

### SpotifyPatcher bypasses Spotify's ads and auto-update on Windows.
Version | Status | Status update date | Contributors | Project at risk
------------ | ------------- | ------------- | ------------- | -------------
V1.0 | Working | 18.1.2021 | 0 | No | Yes

# About

SpotifyPatcher is a program made by Takaovi (Me). The program was not meant to be published, so expect some buggy code. 

The program (SpotifyPatcher) uses one batch file from [BlockTheSpot](https://github.com/master131/BlockTheSpot) (Huge shoutout to them!) to bypass ads. It uses another batch file to bypass and patch auto-update. The rest of the program is done in C# and it basically stitches everything together. If your anti-virus detects the program as a virus you have nothing to worry about, it's just a false positive.

⚠️ Please note that the program automatically adds a simple batch file that starts at startup. The batch file is needed to stop Spotify from updating. You will notice a small cmd pop up after logging in, this is expected and nothing to worry about. Click [here](https://github.com/Takaovi/SpotifyPatcher/blob/master/SpotifyPatcher/Resources/Batch/Regedit.bat) to view the batch file that is run at startup.

⚠️ This program is for the [Desktop release](https://www.spotify.com/download/windows/) of Spotify on Windows and not the Microsoft Store version.

# Future of SpotifyPatcher

The whole program will be fully C# with no external files. (Or a few)
* This will most likely take the false positive away.

Hopefully I will find the time to update SpotifyPatcher as Spotify continues to fight back the nonpaid adfree experience. 
* This might require your support too. If you have a thing you'd like to be added or fixed tell me, or even pull request!

# Uninstallation

[1] Click the "Uninstall Spotify" button on the program 
[2] Remove the program itself (Whole folder)
[3] CTRL + R, write regedit. Go to this address: HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run and remove "SpotifyStopUpdate".

# Screenshots

<p align="center">
  <img src="https://i.imgur.com/myVETxO.jpg">
</p>

# Legal

None of the authors, contributors, or anyone else connected with this open source project, in any way whatsoever, can be responsible for your use of the information or the application contained in or linked from this repository.

Under Section 107 of the Copyright Act 1976, allowance is made for "fair use" for purposes such as criticism, comment, news reporting, teaching, scholarship and research. Fair use is a use permitted by copyright statute that might otherwise be infringing. Non-profit, educational or personal use tips the balance in favor of fair use.

We take claims of copyright infringement seriously. We will respond to notices of alleged copyright infringement that comply with applicable law. If you believe any materials accessible on or from this repository infringe your copyright, you may request removal of those materials (or access to them) from the repository by submitting a DMCA takedown notice to [Github](https://github.com/contact/dmca). We kindly ask you to be in touch with the repository's owner before submitting any DMCA takedown notices.

If you don't agree with any of our disclaimers above please do not read the code or download anything from our repository as you have no permission to read and explore our repository till you agree.
