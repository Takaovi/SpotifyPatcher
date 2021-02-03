@ECHO OFF
START %Appdata%\Spotify\Spotify.exe
SETLOCAL EnableExtensions
set EXE=Spotify.exe
:LOOPSTART
FOR /F %%x IN ('tasklist /NH /FI "IMAGENAME eq %EXE%"') DO IF %%x == %EXE% goto FOUND
TIMEOUT /T 2
goto LOOPSTART
:FOUND
TIMEOUT /T 3
SETLOCAL
CD /d %~dp0

rmdir /s /q %localappdata%\Spotify\Update
mkdir %localappdata%\Spotify\Update
attrib -A +R %localappdata%\Spotify\Update

del %appdata%\Spotify\Spotify_new.exe
type NUL > %appdata%\Spotify\Spotify_new.txt
ren %appdata%\Spotify\*.txt *.exe
attrib -A +R  %appdata%\Spotify\Spotify_new.exe
del %appdata%\Spotify\Spotify_new.txt

del %appdata%\Spotify\SpotifyWebHelper.exe
type NUL > %appdata%\Spotify\SpotifyWebHelper.txt
ren %appdata%\Spotify\*.txt *.exe
attrib -A +R  %appdata%\Spotify\SpotifyWebHelper.exe
del %appdata%\Spotify\SpotifyWebHelper.txt

del %appdata%\Spotify\SpotifyStartupTask.exe
type NUL > %appdata%\Spotify\SpotifyStartupTask.txt
ren %appdata%\Spotify\*.txt *.exe
attrib -A +R  %appdata%\Spotify\SpotifyStartupTask.exe
del %appdata%\Spotify\SpotifyStartupTask.txt

del %appdata%\Spotify\SpotifyMigrator.exe
type NUL > %appdata%\Spotify\SpotifyMigrator.txt
ren %appdata%\Spotify\*.txt *.exe
attrib -A +R  %appdata%\Spotify\SpotifyMigrator.exe
del %appdata%\Spotify\SpotifyMigrator.txt

reg delete "HKEY_CURRENT_USER\Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Compatibility Assistant\Store" /v %appdata%\Spotify\Spotify.exe /f
reg delete "HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\StartupApproved\Run" /v Spotify /f
reg delete "HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\StartupApproved\Run" /v "Spotify Web Helper" /f
reg add "HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\Spotify" /v Version /t REG_SZ /d 1.1.48.625.g1c87c7f7 /F
reg add "HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Uninstall\Spotify" /v DisplayVersion /t REG_SZ /d 1.1.48.625.g1c87c7f7 /F
reg delete "HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run" /v Spotify /f
reg delete "HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run" /v "Spotify Web Helper" /f

exit
