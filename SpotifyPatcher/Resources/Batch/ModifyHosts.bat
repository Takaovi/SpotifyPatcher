@ECHO OFF
IF NOT "%1"=="am_admin" (powershell start -verb runas '%0' am_admin & exit /b)
SETLOCAL	
CD /d %~dp0
COPY /v /y "%CD%\hosts" "%WinDir%\system32\drivers\etc\hosts"