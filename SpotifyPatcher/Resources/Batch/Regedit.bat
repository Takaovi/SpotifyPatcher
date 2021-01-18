@echo off
reg delete "HKEY_CURRENT_USER\Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Compatibility Assistant\Store" /v %appdata%\Spotify\Spotify.exe /f
reg delete "HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\StartupApproved\Run" /v Spotify /f
reg delete "HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\StartupApproved\Run" /v "Spotify Web Helper" /f
reg add "HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\Spotify" /v Version /t REG_SZ /d 1.1.48.625.g1c87c7f7 /F
reg add "HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\Spotify" /v DisplayVersion /t REG_SZ /d 1.1.48.625.g1c87c7f7 /F
reg delete "HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run" /v Spotify /f
reg delete "HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run" /v "Spotify Web Helper" /f