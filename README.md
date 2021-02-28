<p align="center">
<img src="https://i.imgur.com/gYdMVuO.png">
</p>

### SpotifyPatcher bypasses Spotify's ads and auto-update on Windows.
Version | Status | Status update date | Contributors | Project at risk
------------ | ------------- | ------------- | ------------- | -------------
V1.0.1 | Working | 22.2.2021 | 0 | No | Yes

# About

SpotifyPatcher is a program made by Takaovi (Me). It was not meant to be published, so expect some buggy code. 

The program uses one batch file from [BlockTheSpot](https://github.com/master131/BlockTheSpot) and changes the Windows hosts to block ads. It uses some batch files to bypass and patch the auto-update. The rest of the program is done in C# and it basically just stitches everything together. If your anti-virus detects the program as a virus you have nothing to worry about, it's just a false positive.

# Important

⚠️ This program is for the [Desktop release](https://www.spotify.com/download/windows/) of Spotify on Windows and not the Microsoft Store version.

# Future of SpotifyPatcher (TODO)

The whole program will be fully C# with no external files. (Or a few)
* The reason this is not the case yet is because you can modify .bat files easily. Making own little changes to fix the patcher is easier for a wider userbase.

Hopefully I will find the time to update SpotifyPatcher as Spotify continues to fight back the nonpaid adfree experience. 
* This might require your support too. If you have a thing you'd like to be added or fixed tell me, or even pull request!

Add "Uninstall Spotify Patcher" button

# Uninstallation

1. Click the "Uninstall Spotify" button on the program 

2. Remove the program itself (Whole folder)

3. Go to Regedit HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run and remove "SpotifyStopUpdate"

4. Go to c:\windows\system32\drivers\etc\hosts and remove everything inside the hosts file

# Screenshots

<p align="center">
  <img src="https://i.imgur.com/OcBKN36.png">
</p>

# Legal

None of the authors, contributors, or anyone else connected with this open source project, in any way whatsoever, can be responsible for your use of the information or the application contained in or linked from this repository.

Under Section 107 of the Copyright Act 1976, allowance is made for "fair use" for purposes such as criticism, comment, news reporting, teaching, scholarship and research. Fair use is a use permitted by copyright statute that might otherwise be infringing. Non-profit, educational or personal use tips the balance in favor of fair use.

If you don't agree with any of our disclaimers above, do not read the code or download anything from our repository as you have no permission to read and explore our repository till you agree.
