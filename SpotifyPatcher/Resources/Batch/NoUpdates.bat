@echo off
TASKKILL /IM Spotify.exe /F
rmdir /s /q %localappdata%\Spotify\Update
mkdir %localappdata%\Spotify\Update
attrib -A +R %localappdata%\Spotify\Update
del %appdata%\Spotify\Spotify_new.exe
type NUL > %appdata%\Spotify\Spotify_new.txt
ren %appdata%\Spotify\*.txt *.exe
attrib -A +R  %appdata%\Spotify\Spotify_new.exe
del %appdata%\Spotify\Spotify_new.txt





