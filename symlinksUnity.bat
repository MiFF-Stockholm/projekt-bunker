@ECHO OFF

REM folders that will be linked
SET name1=Assets
SET name2=ProjectSettings

ECHO Symlinks creates a link between two folders. 
ECHO The folders must be on the same hard drive.
ECHO The disk must be NTFS.
ECHO.
ECHO =========================================================
ECHO =	this script will set up a connection between	=
ECHO =	a Unity project on your computer	      	=
ECHO =	and a unity project in a dropbox.	      	=
ECHO =========================================================
ECHO.
ECHO.
ECHO Exempel: C:\Unity\New Unity Project\Assets get a link to 
ECHO C:\Dropbox\Unity\New Unity Project\Assets
ECHO.
ECHO "C:\Unity\New Unity Project" is the start location "Start". 
ECHO And "C:\Dropbox\Unity\New Unity Project" is the target location "target".
ECHO.
ECHO *	A little tip: YOU CAN NOT USE CTRL + V BUY YOU CAN RIGHT CLICK AND COPY. 
ECHO.
ECHO Type the Start locations path.
ECHO For example: C:\Unity\New Unity Project
SET /P start=Start:

ECHO.
ECHO Type the Target locations path.
ECHO For example: C:\Dropbox\Unity\New Unity Project
SET /P target=Target:
ECHO.

IF EXIST %start%\%name1% ECHO %name1% has been renamed to Old%name1% 
IF EXIST %start%\%name1% REN %start%\%name1% Old%name1%
IF EXIST %start%\%name2% ECHO %name2% has been renamed to Old%name2%
IF EXIST %start%\%name2% REN %start%\%name2% Old%name2%
ECHO.
MKLINK /J "%start%\%name1%" "%target%\%name1%"
MKLINK /J "%start%\%name2%" "%target%\%name2%"
ECHO.



ECHO Press any key to exit...
PAUSE>null
