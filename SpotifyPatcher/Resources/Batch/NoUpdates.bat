@echo off
TASKKILL /IM Spotify.exe /F
TASKKILL /IM SpotifyWebHelper.exe /F
TASKKILL /IM SpotifyStartupTask.exe /F
TASKKILL /IM SpotifyMigrator.exe /F

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
